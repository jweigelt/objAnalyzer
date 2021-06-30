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

        public void UpdateCommandPosts(List<IngameCPObject> objList, string team1Name, string team2Name)
        {
            lvCommandPosts.BeginUpdate();
            lvCommandPosts.Items.Clear();

            //Create Command Post index Row
            if (lvCommandPosts.Columns.Count < 1){
                lvCommandPosts.Columns.Add("Hud Index", 90);
                foreach (var obj in objList)
                {
                    lvCommandPosts.Columns.Insert(lvCommandPosts.Columns.Count, obj.HudIndex.ToString(), 55);
                }
            }

            var li2 = new ListViewItem();
            foreach (var obj in objList)
            {
                li2.Text = "Team";
                li2.SubItems.Add(GetTeamName(obj.Team, team1Name, team2Name));
            }
            lvCommandPosts.Items.Add(li2);
            lvCommandPosts.EndUpdate();
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
