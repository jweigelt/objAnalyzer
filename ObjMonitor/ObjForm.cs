using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace ObjMonitor
{
    public partial class ObjForm : Form
    {
        [System.Runtime.InteropServices.DllImport("gdi32.dll")]
        private static extern IntPtr AddFontMemResourceEx(IntPtr pbFont, uint cbFont,
           IntPtr pdv, [System.Runtime.InteropServices.In] ref uint pcFonts);

        private PrivateFontCollection fonts = new PrivateFontCollection();

        Font myFont;
        WebAdminPlayerList wapList;
        DateTime time = DateTime.UtcNow;
        Dictionary<string, string> map_to_image_file = new Dictionary<string, string>();
        Dictionary<string, Tuple<double, double, double, double>> map_to_xminmax_yminmax = new Dictionary<string, Tuple<double, double, double, double>>();
        Dictionary<string, Tuple<int, int>> map_to_xdir_ydir = new Dictionary<string, Tuple<int, int>>();
        int current_xdir = 1;
        int current_ydir = 1;

        public ObjForm()
        {
            InitializeComponent();

            byte[] fontData = Properties.Resources.kenyancoffeerg;
            IntPtr fontPtr = System.Runtime.InteropServices.Marshal.AllocCoTaskMem(fontData.Length);
            System.Runtime.InteropServices.Marshal.Copy(fontData, 0, fontPtr, fontData.Length);
            uint dummy = 0;
            fonts.AddMemoryFont(fontPtr, Properties.Resources.kenyancoffeerg.Length);
            AddFontMemResourceEx(fontPtr, (uint)Properties.Resources.kenyancoffeerg.Length, IntPtr.Zero, ref dummy);
            System.Runtime.InteropServices.Marshal.FreeCoTaskMem(fontPtr);

            myFont = new Font(fonts.Families[0], 16.0F);

            wapList = new WebAdminPlayerList(ipAddress.Text, port.Text, username.Text, password.Text);

            map_to_image_file["tat2"] = "..\\..\\assets\\minimaps_trimmed\\tat2_trimmed.png";
            map_to_image_file["C0R"] = "..\\..\\assets\\minimaps_trimmed\\C0R_trimmed.png";
            map_to_image_file["tan"] = "..\\..\\assets\\minimaps_trimmed\\tan_trimmed.png";
            //map_to_xminmax_yminmax["tat2g_con"] = Tuple.Create(-137.59, 139.11, -103.86, 94.15);
            // You can quickly find these coordinates in freecam mode.
            // The ymin and ymax listed below correspond to the zmin and ymin from the game because the game uses xz-coordinates.
            map_to_xminmax_yminmax["tat2"] = Tuple.Create(-137.59, 139.11, -103.86, 94.15);
            map_to_xminmax_yminmax["C0R"] = Tuple.Create(-68.06, 111.82, -184.14, 36.38);
            map_to_xminmax_yminmax["tan"] = Tuple.Create(-385.19, -210.20, 67.09, 203.39);
            // Sometimes, the game
            map_to_xdir_ydir["tat2"] = Tuple.Create(1, -1);
            map_to_xdir_ydir["C0R"] = Tuple.Create(-1, 1);
            map_to_xdir_ydir["tan"] = Tuple.Create(1, -1);
        }

        private void ObjForm_Load(object sender, EventArgs e)
        {
            lvTeam1Objects.Font = new Font(myFont.FontFamily, 15, FontStyle.Regular);
            lvTeam2Objects.Font = new Font(myFont.FontFamily, 15, FontStyle.Regular);
            lvCommandPosts.Font = new Font(myFont.FontFamily, 20, FontStyle.Regular);
            lvGameInfo.Font = new Font(myFont.FontFamily, 15, FontStyle.Regular);
            lbTeam1Name.Font = new Font(myFont.FontFamily, 15, FontStyle.Bold);
            lbTeam2Name.Font = new Font(myFont.FontFamily, 15, FontStyle.Bold);
        }
        public bool IsHost
        {
            get
            {
                return cbHost.Checked;
            }
        }
        public void UpdateGameInfo(List<InGameTeamObj> teamObjs)
        {
            lvGameInfo.BeginUpdate();
            lvGameInfo.Items.Clear();
            foreach (var obj in teamObjs)
            {
                var li = new ListViewItem();
                li.Text = obj.TeamName;
                li.SubItems.Add(obj.isCTF ? obj.CTFScore.ToString() : obj.CONScore.ToString());
                li.SubItems.Add(obj.NumKills.ToString());
                li.SubItems.Add(obj.NumAlive.ToString());
                lvGameInfo.Items.Add(li);
            }
            lvGameInfo.EndUpdate();
        }

        public void SetMap(string map)
        {
            string map_key;
            if (String.IsNullOrEmpty(map))
            {
                map_key = (string) comboBox_map.Text;
            } else
            {
                map_key = map.Substring(0, map.Length - 5);
                comboBox_map.SelectedIndex = comboBox_map.FindStringExact(map_key);
            }
            if (!String.IsNullOrEmpty(map_key))
            {
                //Console.WriteLine($"Setting up map {map} ({map_key})");
                ChartArea ca_map = chart_map.ChartAreas.FindByName("chartarea_minimap");
                ca_map.BackImage = map_to_image_file[map_key];
                ca_map.BackImageWrapMode = ChartImageWrapMode.Scaled;
                (double xmin, double xmax, double ymin, double ymax) = map_to_xminmax_yminmax[map_key];
                (current_xdir, current_ydir) = map_to_xdir_ydir[map_key];
                ca_map.AxisX.Minimum = Math.Min(xmin * current_xdir, xmax * current_xdir);
                ca_map.AxisX.Maximum = Math.Max(xmin * current_xdir, xmax * current_xdir);
                ca_map.AxisY.Minimum = Math.Min(ymin * current_ydir, ymax * current_ydir);
                ca_map.AxisY.Maximum = Math.Max(ymin * current_ydir, ymax * current_ydir);
            }
        }
        
        public void UpdateTeam1ObjList(List<InGameCharacterObject> objList, bool savePlayerData, StreamWriter save_sw)
        {
            // TODO: set the min/max automatically based on the map
            // TODO: overlay image of the minimaps under the chart
            //chart_map.ChartAreas[0].AxisX.Minimum = -100;
            chart_map.Series[0].Points.Clear();
            //chart_map.Series[0].Style.Images = new ChartImageCollection(this.imageList1.Images);

            if (waCB.Checked && DateTime.UtcNow >= time.AddSeconds(5) )  //Make sure we are only updating values from webadmin every 10 seconds or we will ddos the server
            {
                time = DateTime.UtcNow;
                if (!wapList.Connect())
                {
                    waCB.Checked = false;
                }
            }

            lvTeam1Objects.BeginUpdate();
            lvTeam1Objects.Items.Clear();

            foreach (var obj in objList)
            {
                //Skip objects that haven't spawned in yet
                //We can use the characters last timestamp of spawn 
                if (!(obj.TimeStampOfLastSpawn > 0)) continue;


                //For writing data to a file
                var datastring = obj.GetDataString();
                if (obj.EntitySoldier.Health > 0)
                {
                    chart_map.Series[0].Points.Add(new DataPoint(obj.EntitySoldier.X * current_xdir, obj.EntitySoldier.Z * current_ydir));
                    if (obj.Name.Contains("Widow"))
                    {
                        Console.WriteLine($"Widow (x, z) = ({obj.EntitySoldier.X}, {obj.EntitySoldier.Z}, (xdir, ydir) = ({current_xdir}, {current_ydir})");
                    }
                }
                //Create listview item
                var li = new ListViewItem();
                li.Font = new Font(myFont.FontFamily, 20, FontStyle.Regular);

                //Gray out the name if they're dead
                if (obj.EntitySoldier.Health == 0)
                {
                    li.ForeColor = Color.Gray;
                }

                //add id and name
                li.Text = (obj.Index + 1).ToString();
                li.SubItems.Add($"{obj.Name}");

                if (wapList != null && wapList.playerList != null)
                {
                    WebAdminPlayer wap = wapList.playerList.FirstOrDefault(x => x.Slot == obj.Index + 1);
                    if (wap != null)
                    {   
                        //add score/kills/deaths if using webadmin
                        li.SubItems.Add(wap.Score.ToString());
                        li.SubItems.Add(wap.Kills.ToString());
                        li.SubItems.Add(wap.Deaths.ToString());

                        //Add datastring
                        datastring += $",{wap.Score},{wap.Kills},{wap.Deaths}";
                    }
                    else
                    {   
                        //add kills if not using webadmin and placeholders for rest
                        li.SubItems.Add("?");
                        li.SubItems.Add(obj.Score.Kills.ToString());
                        li.SubItems.Add("?");

                        //Add datastring
                        datastring += $",?,{obj.Score.Kills},?";
                    }
                }
                else
                {
                    //add kills if not using webadmin and placeholders for rest
                    li.SubItems.Add("?");
                    li.SubItems.Add(obj.Score.Kills.ToString());
                    li.SubItems.Add("?");

                    //Add datastring
                    datastring += $",?,{obj.Score.Kills},?";

                }

                //Add health
                li.SubItems.Add(Math.Round(obj.EntitySoldier.Health).ToString());
                lvTeam1Objects.Items.Add(li);


                //Dump data to file
                if (savePlayerData)
                {
                    //remove invalid characters for a file name
                    //var strPath = $"{saveDir}\\players\\{string.Concat(obj.Name.Split(Path.GetInvalidFileNameChars()))}_{obj.Team.TeamName}.csv";
                    //DumpPlayerDataString(obj.Map, strPath, datastring);
                    datastring += $",{obj.Team.TeamName}";
                    save_sw.WriteLine(datastring);

                }   
            }
            lvTeam1Objects.EndUpdate();
        }

        public void UpdateTeam2ObjList(List<InGameCharacterObject> objList, bool savePlayerData, StreamWriter save_sw)
        {

            //Bad implementation

            //Commenting this out so we aren't requesting info from the server needlessly 

            //TODO: optimize 
            /*if (waCB.Checked && DateTime.UtcNow >= time.AddSeconds(5))
            {
                time = DateTime.UtcNow;
                if (!wapList.Connect())
                {
                    waCB.Checked = false;
                }
            }*/
            chart_map.Series[1].Points.Clear();

            lvTeam2Objects.BeginUpdate();
            lvTeam2Objects.Items.Clear();
            foreach (var obj in objList)
            {
                if (!(obj.TimeStampOfLastSpawn > 0)) continue;

                var datastring = obj.GetDataString();
                if (obj.EntitySoldier.Health > 0)
                {
                    chart_map.Series[1].Points.Add(new DataPoint(obj.EntitySoldier.X * current_xdir, obj.EntitySoldier.Z * current_ydir));
                    if (obj.Name.Contains("Widow"))
                    {
                        Console.WriteLine($"Widow (x, z) = ({obj.EntitySoldier.X}, {obj.EntitySoldier.Z}, (xdir, ydir) = ({current_xdir}, {current_ydir})");
                    }
                }

                var li = new ListViewItem();
                li.Font = new Font(myFont.FontFamily, 20, FontStyle.Regular);

                //Gray out the name if they're dead
                if (obj.EntitySoldier.Health == 0)
                {
                    li.ForeColor = Color.Gray;
                }

                li.Text = (obj.Index + 1).ToString();
                li.SubItems.Add(obj.Name);

                if (wapList != null && wapList.playerList != null)
                {
                    WebAdminPlayer wap = wapList.playerList.FirstOrDefault(x => x.Slot == obj.Index + 1);
                    if (wap != null)
                    {
                        li.SubItems.Add(wap.Score.ToString());
                        li.SubItems.Add(wap.Kills.ToString());
                        li.SubItems.Add(wap.Deaths.ToString());

                        //Add datastring
                        datastring += $",{wap.Score},{wap.Kills},{wap.Deaths}";
                    }
                    else
                    {
                        li.SubItems.Add("?");
                        li.SubItems.Add(obj.Score.Kills.ToString());
                        li.SubItems.Add("?");

                        //Add datastring
                        datastring += $",?,{obj.Score.Kills},?";
                    }
                }
                else
                {
                    li.SubItems.Add("?");
                    li.SubItems.Add(obj.Score.Kills.ToString());
                    li.SubItems.Add("?");

                    //Add datastring
                    datastring += $",?,{obj.Score.Kills},?";
                }

                li.SubItems.Add(Math.Round(obj.EntitySoldier.Health).ToString());
                lvTeam2Objects.Items.Add(li);

                //Dump data to file
                if (savePlayerData)
                {
                    datastring += $",{obj.Team.TeamName}";
                    save_sw.WriteLine(datastring);
                }
            }
            lvTeam2Objects.EndUpdate();
        }

        public Color getCPBackColor(IngameCPObject obj)
        {

            //CP behavior
            // Neutralize 0.0 -> 12.0
            // Capture 0.0 -> 10.0      //stays at 10 until an enemy comes to capture then it resets to 0.0
            // Hardcap 12.0 -> 0.0

            //Color the row based off object health
            if (obj.Exists)
            {
                if (obj.NeutralizeTime <= 0.5)
                    return Color.White;
                else if (0.5 < obj.CaptureTime || obj.CaptureTime < 9.5)
                    return Color.Gray;
            }
            return Color.Blue;
        }

        public void UpdateCommandPosts(List<IngameCPObject> objList, InGameTeamObj team1, InGameTeamObj team2)
        {
            lvCommandPosts.BeginUpdate();
            lvCommandPosts.Items.Clear();


            //Create Command Post team Row
            if (lvCommandPosts.Columns.Count < 1){
                
                for (int i = 0; i < objList.Count+1; i++)
                {

                    

                    //First column
                    if (i == 0)
                    {
                        lvCommandPosts.Columns.Insert(i, "", 55, HorizontalAlignment.Center);
                    }
                    else
                    {
                        lvCommandPosts.Columns.Insert(i, "", 25, HorizontalAlignment.Center);
                    }
                }
                //insert extra column for tickets
                lvCommandPosts.Columns.Insert(0, "CP", 100, HorizontalAlignment.Center);
                lvCommandPosts.Columns.Insert(0, "dummy", 0);
            }



            var team1CP = GetTeamCPS(objList, 1);
            var team2CP = GetTeamCPS(objList, 2);

            //Team 1 CP's --- "Rebels | 0 | 3 | 4 |"
            var li1 = new ListViewItem();
            li1.SubItems.Add(team1.TeamName);
            li1.SubItems.Add(team1.isCTF ? team1.CTFScore.ToString() : team1.CONScore.ToString()); //add tickets before cp's

            //Add cp's if checkbox isn't checked
            if (!cbHideCPS.Checked)
            {
                foreach (var obj in team1CP)
                {
                    li1.SubItems.Add(obj.HudIndex.ToString());
                    //li1.UseItemStyleForSubItems = false;
                    //li1.SubItems.Add(new ListViewItem.ListViewSubItem(li1, obj.HudIndex.ToString(), Color.Black, getCPBackColor(obj), li1.Font));

                }
            }

           
            //Team 2 CP's --- "Empire | 1 | 2 | 5 |"
            var li2 = new ListViewItem();
            li2.SubItems.Add(team2.TeamName);
            li2.SubItems.Add(team2.isCTF ? team2.CTFScore.ToString() : team2.CONScore.ToString()); //add tickets before cp's

            if (!cbHideCPS.Checked)
            {
                foreach (var obj in team2CP)
                {
                    li2.SubItems.Add(obj.HudIndex.ToString());
                    //li2.UseItemStyleForSubItems = false;
                    //li2.SubItems.Add(new ListViewItem.ListViewSubItem(li2, obj.HudIndex.ToString(), Color.Black, getCPBackColor(obj), li1.Font));
                }
            }


            lvCommandPosts.Items.Add(li1);
            lvCommandPosts.Items.Add(li2);
            lvCommandPosts.EndUpdate();
        }

        public List<IngameCPObject> GetTeamCPS(List<IngameCPObject> objList, int team)
        {
            List<IngameCPObject> newObjList = new List<IngameCPObject> { };
            foreach(var obj in objList)
            {
                if (obj.Team == team)
                {
                    newObjList.Add(obj);
                }
            }

            return newObjList;
        }

        public string GetTeamName(int team, string team1Name, string team2Name)
        {
            if (team == 1)
            {
                return team1Name;
            }else if(team == 2)
            {
                return team2Name;
            }
            else
            {
                return "Neutral";
            }
        }

        public void UpdateTeamLabels(string team1Name, string team2Name)
        {
            lbTeam1Name.Text = team1Name;
            lbTeam2Name.Text = team2Name;
        }

        private void waCB_CheckedChanged(object sender, EventArgs e)
        {
            //use webadmin
            if (waCB.Checked)
            {
                wapList = new WebAdminPlayerList(ipAddress.Text, port.Text, username.Text, password.Text);
            }
        }

        private void bnSwapTeamViews_Click(object sender, EventArgs e)
        {
            int x = lbTeam1Name.Location.X;
            int y = lbTeam1Name.Location.Y;
            lbTeam1Name.Location = new Point(lbTeam2Name.Location.X, lbTeam2Name.Location.Y);
            lbTeam2Name.Location = new Point(x, y);

            x = lvTeam1Objects.Location.X;
            y = lvTeam1Objects.Location.Y;
            lvTeam1Objects.Location = new Point(lvTeam2Objects.Location.X, lvTeam2Objects.Location.Y);
            lvTeam2Objects.Location = new Point(x, y);
        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }
    }
}
