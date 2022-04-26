using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ObjMonitor
{
    public partial class ObjForm : Form
    {
        public ObjForm()
        {
            InitializeComponent();
        }

        private void ObjForm_Load(object sender, EventArgs e)
        {

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
        
        public void UpdateTeam1ObjList(List<InGameObj> objList)
        {
            lvTeam1Objects.BeginUpdate();
            lvTeam1Objects.Items.Clear();
            foreach(var obj in objList)
            {
                var li = new ListViewItem();
                li.Text = obj.Character.Index.ToString();
                li.SubItems.Add(obj.Character.Name);
                li.SubItems.Add(obj.SoldierClass.Name);
                li.SubItems.Add(obj.Character.Score.Kills.ToString());
                li.SubItems.Add(obj.Health.ToString("n0"));

                //Color the row based off object health
                if (obj.Exists)
                {
                    if (obj.Health < (obj.MaxHealth/3))
                        li.BackColor = Color.Coral;
                    else if (obj.Health < (obj.MaxHealth/3)*2)
                        li.BackColor = Color.Wheat;
                    else
                        li.BackColor = Color.PaleGreen;
                }

                lvTeam1Objects.Items.Add(li);
            }
            lvTeam1Objects.EndUpdate();
        }

        public void UpdateTeam2ObjList(List<InGameObj> objList)
        {
            lvTeam2Objects.BeginUpdate();
            lvTeam2Objects.Items.Clear();
            foreach (var obj in objList)
            {
                var li = new ListViewItem();
                li.Text = obj.Character.Index.ToString();
                li.SubItems.Add(obj.Character.Name);
                li.SubItems.Add(obj.SoldierClass.Name);
                li.SubItems.Add(obj.Character.Score.Kills.ToString());
                li.SubItems.Add(obj.Health.ToString("n0"));

                //Color the row based off object health
                if (obj.Exists)
                {
                    if (obj.Health < (obj.MaxHealth / 3))
                        li.BackColor = Color.Coral;
                    else if (obj.Health < (obj.MaxHealth / 3) * 2)
                        li.BackColor = Color.Wheat;
                    else
                        li.BackColor = Color.PaleGreen;
                }

                lvTeam2Objects.Items.Add(li);
            }
            lvTeam2Objects.EndUpdate();
        }

        public Color getCPBackColor(IngameCPObject obj)
        {

            //CP behavior
            // Neutralize 0.0 -> 12.0
            // Capture 0.0 -> 10.0
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

        public void UpdateCommandPosts(List<IngameCPObject> objList, string team1Name, string team2Name)
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
                        lvCommandPosts.Columns.Insert(i, "CP", 100);
                    }
                    else
                    {
                        lvCommandPosts.Columns.Insert(i, "", 25);
                    }
                }
            }

            var team1CP = GetTeamCPS(objList, 1);
            var team2CP = GetTeamCPS(objList, 2);

            //Team 1 CP's --- "Rebels | 0 | 3 | 4 |"
            var li1 = new ListViewItem();
            li1.Text = team1Name;
            foreach (var obj in team1CP)
            {
                li1.SubItems.Add(obj.HudIndex.ToString());
                //li1.UseItemStyleForSubItems = false;
                //li1.SubItems.Add(new ListViewItem.ListViewSubItem(li1, obj.HudIndex.ToString(), Color.Black, getCPBackColor(obj), li1.Font));

            }

            //Team 2 CP's --- "Empire | 1 | 2 | 5 |"
            var li2 = new ListViewItem();
            li2.Text = team2Name;
            foreach (var obj in team2CP)
            {
                li2.SubItems.Add(obj.HudIndex.ToString());
                //li2.UseItemStyleForSubItems = false;
                //li2.SubItems.Add(new ListViewItem.ListViewSubItem(li2, obj.HudIndex.ToString(), Color.Black, getCPBackColor(obj), li1.Font));
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
    }
}
