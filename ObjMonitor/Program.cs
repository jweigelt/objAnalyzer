using System;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Text;
using System.Runtime.InteropServices;

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

        public PrivateFontCollection InitCustomLabelFont()
        {
            //Create your private font collection object.
            PrivateFontCollection pfc = new PrivateFontCollection();

            //Select your font from the resources.
            //My font here is "Digireu.ttf"
            int fontLength = Properties.Resources.kcr.Length;

            // create a buffer to read in to
            byte[] fontdata = Properties.Resources.kcr;

            // create an unsafe memory block for the font data
            System.IntPtr data = Marshal.AllocCoTaskMem(fontLength);

            // copy the bytes to the unsafe memory block
            Marshal.Copy(fontdata, 0, data, fontLength);

            ///IMPORTANT line to register font in system
            uint cFonts = 0;
            AddFontMemResourceEx(data, (uint)fontdata.Length, IntPtr.Zero, ref cFonts);

            // pass the font to the font collection
            pfc.AddMemoryFont(data, fontLength);

            return pfc;
        }
    }
}