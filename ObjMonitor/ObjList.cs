using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjMonitor
{
    public class ObjList
    {
        private readonly int ENTITY_LIST_OFFSET;
        private IntPtr baseAddr;
        private ProcessMemoryReader reader;
        public List<InGameObj> Team1 { get; set; } = new List<InGameObj>();
        public List<InGameObj> Team2 { get; set; } = new List<InGameObj>();
        public ObjList(ProcessMemoryReader reader, ObjForm form)
        {
            this.reader = reader;
            ENTITY_LIST_OFFSET = form.IsHost ? 0x01A64CD8 : 0x01BA6608;
            baseAddr = reader.ReadPtr(reader.GetModuleBase(ENTITY_LIST_OFFSET));
            BuildLists();
        }
        private void BuildLists()
        {
            IntPtr basePtr;
            for(int i = 0; i < 64; i++)
            {
                basePtr = reader.ReadPtr(IntPtr.Add(baseAddr, i * 4));
                InGameObj obj = new InGameObj(basePtr, reader);
                if (obj.IsPlayer)
                {
                    if (obj.Character.Team.TeamID == 1) //Team1
                    {
                        Team1.Add(obj);
                    }
                    else
                    {
                        Team2.Add(obj);
                    }
                }
            }
        }
        public void Empty()
        {
            Team1.Clear();
            Team2.Clear();
        }
        public void EmptyTeam1()
        {
            Team1.Clear();
        }
        public void EmptyTeam2()
        {
            Team2.Clear();
        }
    }   
}
