using System;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Text;
using System.Runtime.InteropServices;
using System.IO;

namespace ObjMonitor
{
    class Program
    {
        [DllImport("gdi32.dll")]
        private static extern IntPtr AddFontMemResourceEx(IntPtr pbFont, uint cbFont, IntPtr pdv, [In] ref uint pcFonts);

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

        private static void DumpDataString(string header, string path, string datastring, string saveDir)
        {
            if (!Directory.Exists(saveDir))
            {
                return;
            }

            if (!File.Exists(path))
            {
                StreamWriter sw = new StreamWriter(path);
                sw.WriteLine(header);
                sw.Close();
            }

            StreamWriter sw1 = new StreamWriter(path, true, Encoding.ASCII);
            sw1.WriteLine(datastring);
            sw1.Close();
        }


        static void Main(string[] args)
        {
            var reader = new ProcessMemoryReader();
            reader.Open("BattlefrontII");

            var form = new ObjForm();
            Application.EnableVisualStyles();
            form.Show();

            var counter = 0;
            var detectedEndgame = false;

            var timeString = DateTime.Now.ToString("yyyy-MM-dd-h-mm-ss-tt");
            String saveDir = "";
            String playerDir = "";
            String oldMap = "";

            while (true)
            {
               

                List<InGameTeamObj> teamObjList = GetTeamList(reader, form);
                form.UpdateTeamLabels(teamObjList[0].TeamName, teamObjList[1].TeamName);
                ObjList objList = new ObjList(reader, form);
                CharList charList = new CharList(reader);
                form.UpdateTeam1ObjList(charList.Team1);
                form.UpdateTeam2ObjList(charList.Team2);
                form.UpdateGameInfo(teamObjList);
                form.UpdateCommandPosts(objList.CommandPosts, teamObjList[0], teamObjList[1]);
                Application.DoEvents();


                if (form.cbTrackStats.Checked)
                {
                    var endgame = reader.ReadInt32(reader.GetModuleBase(0x1AAFCA0));
                    var map = reader.ReadString(reader.GetModuleBase(0x1A560E0), 10);
                    saveDir = $".\\{timeString}-data-{map}";
                    Directory.CreateDirectory($"{saveDir}\\players");  // No op if it exists already

                    if (endgame != 0) //Detects endgame if value is not 0
                    {
                        detectedEndgame = true;
                    }

                    //if endgame was detected but value is 0 that means new map has started
                    if (endgame == 0 && detectedEndgame == true)
                    {
                        // Update the time-stamp so that we avoid writing to the same directory
                        timeString = DateTime.Now.ToString("yyyy-MM-dd-h-mm-ss-tt");
                        saveDir = $".\\{timeString}-data-{map}";
                        Directory.CreateDirectory(saveDir);
                        detectedEndgame = false;
                    }

                    string datastring;
                    string strPath;
                    string header;

                    //Have to dump player data within form update for webadmin updates


                    //Dump data every 1 seconds
                    if (counter >= 1000 && form.cbTrackStats.Checked)
                    {
                        if (!form.cbHideCPS.Checked)
                        {
                            //CP Data
                            datastring = string.Join("\n", objList.CommandPosts.Select(x => x.GetDataString()));
                            strPath = $"{saveDir}\\CommandPosts.csv";
                            header = "Timestamp,HUDIndex,Team";
                            DumpDataString(header, strPath, datastring, saveDir);
                        }

                        //Team Data
                        datastring = string.Join("\n", teamObjList.Where(x => x.Exists).Select(x => x.GetDataString));
                        strPath = $"{saveDir}\\TeamData.csv";
                        header = "Timestamp,TeamName,TeamID,Score";
                        DumpDataString(header, strPath, datastring, saveDir);
                        counter = 0;
                    }
                    counter += 20;
                }
                Thread.Sleep(20);
            }
        }
    }
}