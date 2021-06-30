using System;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ObjMonitor
{
    class Program
    {
        public static bool IsSteam { get; set; } = true;

        public static readonly int TEAM_TABLE_OFFSET = IsSteam ? 0x1AAFCD4 : 0x0;

        public static List<InGameTeamObj> GetTeamList(ProcessMemoryReader reader, ObjForm form)
        {
            List<InGameTeamObj> objList = new List<InGameTeamObj>();
            for (int i = 0; i < 2; i++) //only want two teams
            {
                IntPtr basePtr = reader.ReadPtr(IntPtr.Add(reader.GetModuleBase(TEAM_TABLE_OFFSET), i * 4));
                InGameTeamObj obj = new InGameTeamObj(basePtr, reader);
                obj.IsHost = form.IsHost;
                objList.Add(obj);
            }
            return objList;
        }

        static void Main(string[] args)
        {
            var reader = new ProcessMemoryReader();
            reader.Open("BattlefrontII");

            var form = new ObjForm();
            Application.EnableVisualStyles();
            form.Show();


            while (true)
            {
                List<InGameTeamObj> teamObjList = GetTeamList(reader, form);
                form.UpdateTeamLabels(teamObjList[0].TeamName, teamObjList[1].TeamName);
                ObjList objList = new ObjList(reader, form);
                form.UpdateTeam1ObjList(objList.Team1);
                form.UpdateTeam2ObjList(objList.Team2);
                form.UpdateGameInfo(teamObjList);
                form.UpdateCommandPosts(objList.CommandPosts, teamObjList[0].TeamName, teamObjList[1].TeamName);

                Application.DoEvents();
                Thread.Sleep(20);
            }
        }
    }
}