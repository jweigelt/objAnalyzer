using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjMonitor
{
    public class InGameCharacterObject
    {
        public static readonly int[] NAME_OFFSET =                  { 0x30 };
        public static readonly int[] INDEX_OFFSET =                 { 0x130 };
        public static readonly int[] TEAMID_OFFSET =                { 0x134 };
        public static readonly int[] TEAM_OBJ_OFFSET =              { 0x138 };
        public static readonly int[] SOLDIER_CLASSID_OFFSET =       { 0x13C };
        public static readonly int[] SOLDIER_CLASS_OBJ_OFFSET =     { 0x140 };

        public IntPtr baseAddr;
        public ProcessMemoryReader reader;
        public InGameCharacterObject(IntPtr basePtr, ProcessMemoryReader reader)
        {
            this.reader = reader;
            baseAddr = basePtr;
        }

        public virtual bool Exists
        {
            get
            {
                return !baseAddr.Equals(IntPtr.Zero);
            }
        }
        public virtual string Name
        {
            get
            {
                return reader.ReadWString(reader.GetOffsetIntPtr(baseAddr, NAME_OFFSET), 64);
            }
            
        }
        public virtual int Index
        {
            get
            {
                return reader.ReadInt32(reader.GetOffsetIntPtr(baseAddr, INDEX_OFFSET));
            }
        }
        public int TeamID
        {
            get
            {
                return reader.ReadInt32(reader.GetOffsetIntPtr(baseAddr, TEAMID_OFFSET));
            }
        }
        public int ClassID
        {
            get
            {
                return reader.ReadInt32(reader.GetOffsetIntPtr(baseAddr, SOLDIER_CLASSID_OFFSET));
            }
        }
        public Score2 Score
        {
            get
            {
                IntPtr scoreBaseAddr = IntPtr.Add(reader.GetModuleBase(0x1ACC108), Index*0x60);
                return new Score2(scoreBaseAddr, reader);

                //TODO IsHost -- Clients can only see kills (tab screen) -- Server does not broadcast any other stat
                //IntPtr scoreBaseAddr = IntPtr.Add(reader.ReadPtr(reader.GetModuleBase(0x01A30338)), Index*0x1F8);
                //return new Score(scoreBaseAddr, reader);
            }
        }
        public InGameSoldierClassObj Class
        {
            get
            {
                return new InGameSoldierClassObj(reader.ReadPtr(reader.GetOffsetIntPtr(baseAddr, SOLDIER_CLASS_OBJ_OFFSET)), reader);
            }
        }
        public InGameTeamObj Team
        {
            get
            {
                return new InGameTeamObj(reader.ReadPtr(reader.GetOffsetIntPtr(baseAddr, TEAM_OBJ_OFFSET)), reader);
            }
        }
    }
}
