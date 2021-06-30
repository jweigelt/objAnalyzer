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
        private readonly int COMMAND_POST_LIST_OFFSET;
        private IntPtr baseAddr;
        private IntPtr commandPostListBaseAddr;
        private ProcessMemoryReader reader;
        public List<InGameObj> Team1 { get; set; } = new List<InGameObj>();
        public List<InGameObj> Team2 { get; set; } = new List<InGameObj>();
        public List<IngameCPObject> CommandPosts { get; set; } = new List<IngameCPObject>();

        public ObjList(ProcessMemoryReader reader, ObjForm form)
        {
            this.reader = reader;
            ENTITY_LIST_OFFSET = form.IsHost ? 0x01A64CD8 : 0x01BA6608;
            COMMAND_POST_LIST_OFFSET = 0x00152BE0;
            baseAddr = reader.ReadPtr(reader.GetModuleBase(ENTITY_LIST_OFFSET));
            commandPostListBaseAddr = reader.ReadPtr(reader.GetModuleBase(COMMAND_POST_LIST_OFFSET));

            BuildLists();
        }
        private void BuildLists()
        {
            IntPtr basePtr;
            //Build list of ingame Player Objects
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

            //Build list of ingame CommandPost Objects
            for (int i = 0; i < 7; i++)
            {
                basePtr = IntPtr.Add(commandPostListBaseAddr, i * 0x30);

                IngameCPObject obj = new IngameCPObject(basePtr, reader);

                if (obj.Exists)
                {
                    CommandPosts.Add(obj);
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
