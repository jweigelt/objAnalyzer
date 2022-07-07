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
        public static readonly int[] INDEX_OFFSET =                 { 0x130 };  //WILL BE 0xFFFFFFFF IF AI IS POPULATING CHARACTER
        public static readonly int[] TEAMID_OFFSET =                { 0x134 };
        public static readonly int[] TEAM_OBJ_OFFSET =              { 0x138 };
        public static readonly int[] SOLDIER_CLASSID_OFFSET =       { 0x13C };
        public static readonly int[] SOLDIER_CLASS_OBJ_OFFSET =     { 0x140 };
        public static readonly int[] CP_OBJ_SPAWNED_AT =            { 0X144 };
        public static readonly int[] ENTITY_SOLDIER =               { 0x148 }; // NOTE: this is not the same as ingame obj. You can get that address by subtracting 0x240 from the address this points to
        public static readonly int[] LAST_CP_IN_RANGE =             { 0x198 }; // This gets populated after first spawn
        public static readonly int[] TIMESTAMP_OF_LAST_SPAWN =      { 0x188 }; // Timestamp is from when player joined server not server timestamp
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
                IntPtr scoreBaseAddr = IntPtr.Add(reader.GetModuleBase(0x1ACC108), (Index-1)*0x60);
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
        public InGameObj EntitySoldier
        {
            get
            {
                return new InGameObj(reader.ReadPtr(reader.GetOffsetIntPtr(baseAddr, ENTITY_SOLDIER)) - 0x240, reader);
            }
        }
        public IngameCPObject LastInRangeCP
        {
            get
            {
                return new IngameCPObject(reader.ReadPtr(reader.GetOffsetIntPtr(baseAddr, LAST_CP_IN_RANGE)), reader);
            }
        }
        public float TimeStampOfLastSpawn
        {
            get
            {
                return reader.ReadFloat(reader.GetOffsetIntPtr(baseAddr, TIMESTAMP_OF_LAST_SPAWN));
            }
        }
        public string Map
        {
            get
            {
                return reader.ReadString(reader.GetModuleBase(0x1A560E0), 10);
            }
        }
        public string GetDataString()
        {
            var timestamp = reader.ReadFloat(reader.GetModuleBase(0x1BA88E8));
            return $"{timestamp},{Index+1},{Name},{EntitySoldier.Health},{EntitySoldier.X},{EntitySoldier.Y},{EntitySoldier.Z},{EntitySoldier.xCamera},{EntitySoldier.yCamera},{EntitySoldier.zCamera}";
        }
    }
}
