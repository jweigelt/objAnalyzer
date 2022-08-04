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
        double map_x_delta = 1.0;
        double map_y_delta = 1.0;

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

            map_to_image_file["tat2"] = ".\\minimaps_trimmed\\tat2_trimmed.png";
            map_to_image_file["c0r"] = ".\\minimaps_trimmed\\C0R_trimmed.png";
            map_to_image_file["ti2"] = ".\\minimaps_trimmed\\tan_trimmed.png";
            map_to_image_file["tan1"] = ".\\minimaps_trimmed\\tan_trimmed.png";
            map_to_image_file["mus1"] = ".\\minimaps_trimmed\\mus1_trimmed.png";
            map_to_image_file["tat3"] = ".\\minimaps_trimmed\\tat3_trimmed.png";
            map_to_image_file["kek"] = ".\\minimaps_trimmed\\KEK_trimmed.png";
            map_to_image_file["dg2"] = ".\\minimaps_trimmed\\dag1_trimmed.png";
            map_to_image_file["ed9"] = ".\\minimaps_trimmed\\ed9_trimmed.png";
            map_to_image_file["rvn"] = ".\\minimaps_trimmed\\Rhn1_trimmed.png";
            map_to_image_file["rvc"] = ".\\minimaps_trimmed\\Rhn2_trimmed.png";
            map_to_image_file["uta1"] = ".\\minimaps_trimmed\\uta1_trimmed.png";
            // You can quickly find these coordinates in freecam mode.
            // The ymin and ymax listed below correspond to the zmin and ymin from the game because the game uses xz-coordinates.
            map_to_xminmax_yminmax["tat2"] = Tuple.Create(-145.59, 143.11, -115.86, 96.0);
            map_to_xminmax_yminmax["c0r"] = Tuple.Create(-68.06, 111.82, -184.14, 36.38);
            map_to_xminmax_yminmax["ti2"] = Tuple.Create(-385.19, -210.20, 67.09, 203.39);
            map_to_xminmax_yminmax["tan1"] = Tuple.Create(-385.19, -210.20, 67.09, 203.39);
            map_to_xminmax_yminmax["mus1"] = Tuple.Create(-106.4, 143.0, -59.0, 152.0);
            map_to_xminmax_yminmax["tat3"] = Tuple.Create(-128.5, 5.5, 50.1, 197.5);
            map_to_xminmax_yminmax["kek"] = Tuple.Create(-180.0, 135.9, 64.24, 288.3);
            map_to_xminmax_yminmax["dg2"] = Tuple.Create(-75.6, 148.11, -167.1, 188.9);
            map_to_xminmax_yminmax["rvn"] = Tuple.Create(108.0, 305.85, 270.0, 460.1);
            map_to_xminmax_yminmax["rvc"] = Tuple.Create(-320.32, -86.65, -292.2, -63.4);
            map_to_xminmax_yminmax["uta1"] = Tuple.Create(-223.0, 134.2, 81.0, 304.3);
            map_to_xminmax_yminmax["ed9"] = Tuple.Create(-70.0, 202.3, 8.48, 160.3);
            // Some coordinates need to be reversed.
            map_to_xdir_ydir["tat2"] = Tuple.Create(1, -1);
            map_to_xdir_ydir["c0r"] = Tuple.Create(-1, 1); // For some reason, Cor patched has the x and z reversed.
            map_to_xdir_ydir["ti2"] = Tuple.Create(1, -1);
            map_to_xdir_ydir["tan1"] = Tuple.Create(1, -1);
            map_to_xdir_ydir["mus1"] = Tuple.Create(1, -1);
            map_to_xdir_ydir["tat3"] = Tuple.Create(1, -1);
            map_to_xdir_ydir["kek"] = Tuple.Create(1, -1);
            map_to_xdir_ydir["dg2"] = Tuple.Create(1, -1);
            map_to_xdir_ydir["rvn"] = Tuple.Create(1, -1);
            map_to_xdir_ydir["rvc"] = Tuple.Create(1, -1);
            map_to_xdir_ydir["uta1"] = Tuple.Create(1, -1);
            map_to_xdir_ydir["ed9"] = Tuple.Create(1, -1);
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

        public void ClearMap()
        {
            ChartArea ca_map = chart_map.ChartAreas.FindByName("chartarea_minimap");
            ca_map.BackImage = "";
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
            map_key = map_key.ToLower();
            if (!String.IsNullOrEmpty(map_key) && map_to_image_file.ContainsKey(map_key))
            {
                ChartArea ca_map = chart_map.ChartAreas.FindByName("chartarea_minimap");
                ca_map.BackImage = map_to_image_file[map_key];
                (double xmin, double xmax, double ymin, double ymax) = map_to_xminmax_yminmax[map_key];
                (current_xdir, current_ydir) = map_to_xdir_ydir[map_key];
                ca_map.AxisX.Minimum = Math.Min(xmin * current_xdir, xmax * current_xdir);
                ca_map.AxisX.Maximum = Math.Max(xmin * current_xdir, xmax * current_xdir);
                ca_map.AxisY.Minimum = Math.Min(ymin * current_ydir, ymax * current_ydir);
                ca_map.AxisY.Maximum = Math.Max(ymin * current_ydir, ymax * current_ydir);
                map_x_delta = ca_map.AxisX.Maximum - ca_map.AxisX.Minimum;
                map_y_delta = ca_map.AxisY.Maximum - ca_map.AxisY.Minimum;
            }
        }


        public void UpdateTeamObjList(List<InGameCharacterObject> objList, bool savePlayerData, StreamWriter save_sw, bool is_team_one)
        {
            int series_index;
            int series_direction_index;
            int series_label_index;
            if (is_team_one)
            {
                lvTeam1Objects.BeginUpdate();
                lvTeam1Objects.Items.Clear();
                series_index = 2;
                series_direction_index = 0;
                series_label_index = 4;
                //Make sure we are only updating values from webadmin every 5 seconds or we will ddos the server
                if (waCB.Checked && DateTime.UtcNow >= time.AddSeconds(5))  
                {
                    time = DateTime.UtcNow;
                    if (!wapList.Connect())
                    {
                        waCB.Checked = false;
                    }
                }
            } else
            {
                lvTeam2Objects.BeginUpdate();
                lvTeam2Objects.Items.Clear();
                series_index = 3;
                series_direction_index = 1;
                series_label_index = 5;
            }
            chart_map.Series[series_index].Points.Clear();
            chart_map.Series[series_direction_index].Points.Clear();
            chart_map.Series[series_label_index].Points.Clear();

            if (objList.Count > 0)
            {
                bool is_white = (objList[0].Team.TeamName == "Empire") || (objList[0].Team.TeamName == "Republic");
                if (is_white)
                {
                    chart_map.Series[series_index].MarkerColor = Color.LightBlue;
                    chart_map.Series[series_index].MarkerBorderColor = Color.DodgerBlue;
                    chart_map.Series[series_direction_index].MarkerColor = Color.DodgerBlue;
                    chart_map.Series[series_direction_index].MarkerBorderColor = Color.LightBlue;
                }
                else
                {
                    chart_map.Series[series_index].MarkerColor = Color.Chocolate;
                    chart_map.Series[series_index].MarkerBorderColor = Color.Red;
                    chart_map.Series[series_direction_index].MarkerColor = Color.Red;
                    chart_map.Series[series_direction_index].MarkerBorderColor = Color.Chocolate;
                }
            }

            foreach (var obj in objList)
            {
                if (!(obj.TimeStampOfLastSpawn > 0)) continue;

                string player_id = (obj.Index + 1).ToString();
                var datastring = obj.GetDataString();
                if (obj.EntitySoldier.Health > 0)
                {
                    var player_direction_dot = new DataPoint(
                        (obj.EntitySoldier.X + 1.5 * (map_x_delta / 64) * obj.EntitySoldier.xCamera) * current_xdir,
                        (obj.EntitySoldier.Z + 1.5 * (map_y_delta / 64) * obj.EntitySoldier.zCamera) * current_ydir
                    );
                    var player_label_dot = new DataPoint(
                        (obj.EntitySoldier.X + 0.25) * current_xdir,
                        (obj.EntitySoldier.Z - 3 * current_ydir * (map_y_delta / 64)) * current_ydir
                    );
                    //Console.WriteLine($"x = {obj.EntitySoldier.xCamera}, z = {obj.EntitySoldier.zCamera}");
                    //Console.WriteLine($"dot = {player_dot}, dir_dot = {player_direction_dot}");
                    var player_dot = new DataPoint(obj.EntitySoldier.X * current_xdir, obj.EntitySoldier.Z * current_ydir);
                    player_label_dot.Label = player_id;
                    player_label_dot.LabelForeColor = Color.Black;
                    player_label_dot.SetCustomProperty("LabelStyle", "Top");
                    chart_map.Series[series_index].Points.Add(player_dot);
                    chart_map.Series[series_direction_index].Points.Add(player_direction_dot);
                    chart_map.Series[series_label_index].Points.Add(player_label_dot);
                }

                var li = new ListViewItem();
                li.Font = new Font(myFont.FontFamily, 20, FontStyle.Regular);

                int health_percent = (int) Math.Ceiling(100 * obj.EntitySoldier.Health / obj.EntitySoldier.MaxHealth);
                ObjMonitor.CustomProgressBar health_bar;
                if (is_team_one)
                {
                    switch (obj.Index)
                    {
                        case 0:
                            health_bar = team1health_player0;
                            break;
                        case 1:
                            health_bar = team1health_player1;
                            break;
                        case 2:
                            health_bar = team1health_player2;
                            break;
                        case 3:
                            health_bar = team1health_player3;
                            break;
                        default:
                            health_bar = stub_progress_bar;
                            break;
                    }
                }
                else
                {
                    switch (obj.Index)
                    {
                        case 0:
                            health_bar = team2health_player0;
                            break;
                        case 1:
                            health_bar = team2health_player1;
                            break;
                        case 2:
                            health_bar = team2health_player2;
                            break;
                        case 3:
                            health_bar = team2health_player3;
                            break;
                        default:
                            health_bar = stub_progress_bar;
                            break;
                    }
                }

                //Gray out the name if they're dead
                if (health_percent <= 0)
                {
                    li.ForeColor = Color.Gray;
                    health_bar.Value = 0;
                    health_bar.Value = 0;
                    health_bar.ProgressColor = Color.Green;
                }
                else if (30 <= health_percent && health_percent < 60)
                {
                    li.ForeColor = Color.Orange;
                    health_bar.ProgressColor = Color.Orange;
                    health_bar.Value = health_percent;
                }
                else if (0 < health_percent && health_percent < 30)
                {
                    li.ForeColor = Color.Red;
                    health_bar.ProgressColor = Color.Red;
                    health_bar.Value = health_percent;
                } else
                {
                    health_bar.Value = health_percent;
                    health_bar.ProgressColor = Color.Green;
                }
                li.Text = player_id;
                li.SubItems.Add($"{player_id} {obj.Name}");

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
                if (is_team_one)
                {
                    lvTeam1Objects.Items.Add(li);
                } else
                {
                    lvTeam2Objects.Items.Add(li);
                }

                //Dump data to file
                if (savePlayerData)
                {
                    datastring += $",{obj.Team.TeamName}";
                    save_sw.WriteLine(datastring);
                }
            }
            if (is_team_one)
            {
                lvTeam1Objects.EndUpdate();
            } else
            {
                lvTeam2Objects.EndUpdate();
            }
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
