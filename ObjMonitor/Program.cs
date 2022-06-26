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
            var map = reader.ReadString(reader.GetModuleBase(0x1A560E0), 10);

            var endgame = reader.ReadInt32(reader.GetModuleBase(0x1AAFCA0));
            Console.WriteLine($"Outside loop: map = {map}, isEmpty = {String.IsNullOrEmpty(map)}, endgame = {endgame}");
            var timeString = DateTime.Now.ToString("yyyy-MM-dd-h-mm-ss-tt");
            var saveDir = $".\\{timeString}-data-{map}";
            String oldMap = "";
            bool savePlayerData = false;
            DateTime playerDataTime = DateTime.UtcNow;


            while (true)
            {
                // Invariant: map has a value
                List<InGameTeamObj> teamObjList = GetTeamList(reader, form);
                form.UpdateTeamLabels(teamObjList[0].TeamName, teamObjList[1].TeamName);
                ObjList objList = new ObjList(reader, form);
                CharList charList = new CharList(reader);
                //dump only every 1/2 second
                savePlayerData = DateTime.UtcNow > playerDataTime.AddSeconds(0.5) && form.cbTrackStats.Checked;
                if (savePlayerData)
                {
                    playerDataTime = DateTime.UtcNow;
                }
                // TODO: save data in memory and only dump data once in a while
                form.UpdateTeam1ObjList(charList.Team1, saveDir, savePlayerData);
                form.UpdateTeam2ObjList(charList.Team2, saveDir, savePlayerData);
                form.UpdateGameInfo(teamObjList);
                form.UpdateCommandPosts(objList.CommandPosts, teamObjList[0], teamObjList[1]);
                Application.DoEvents();
                if (form.cbTrackStats.Checked)
                {
                    endgame = reader.ReadInt32(reader.GetModuleBase(0x1AAFCA0));
                    map = reader.ReadString(reader.GetModuleBase(0x1A560E0), 10);

                    if (endgame != 0) // Detects endgame if value is not 0
                    {
                        detectedEndgame = true;
                    }
                    Boolean mapStartDetected = !String.IsNullOrEmpty(map) && (
                        (map != oldMap) // map change. Only checking endgame isn't enough because if someone join the server after starting this program, there will not have been an endgame
                        || (
                            // only checking map != oldMap isn't enough because there might be the same map twice in a row
                            endgame == 0 && detectedEndgame == true  // if endgame was detected but value is 0 that means new map has started
                        ) || (
                            !saveDir.Contains(map) // TODO: figure out why the previous two conditions aren't enough
                        )
                    );
                    if (mapStartDetected)
                    {
                        Console.WriteLine($"Map start detected. oldMap={oldMap}, map={map}, endgame={endgame}, detectedEndgame={detectedEndgame}");
                        Console.WriteLine($"old saveDir = {saveDir}");
                        timeString = DateTime.Now.ToString("yyyy-MM-dd-h-mm-ss-tt");
                        saveDir = $".\\{timeString}-data-{map}";
                        Console.WriteLine($"new saveDir = {saveDir}");
                        Directory.CreateDirectory($"{saveDir}\\players");
                        detectedEndgame = false;
                    }
                    oldMap = map;

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