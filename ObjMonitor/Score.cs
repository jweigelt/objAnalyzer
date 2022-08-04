using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjMonitor
{
    public class Score
    {   
        //4Bytes
        private enum KillsOffsets : int
        {
            Team1 = 0x4,
            Team2 = 0x8
        }
        //4Bytes
        private enum PointsOffsets : int
        {
            All = 0x1F0,
            AllIndicator = 0x1F4
        }
        //2Bytes
        private enum TKOffsets : int
        {
            Team1 = 0xC,
            Team2 = 0xE
        }
        //2Bytes
        private enum DeathsOFfsets : int
        {
            Team1 = 0x5A,
            Team2 = 0x5C
        }
        //2Bytes
        private enum FlagCapsOffsets : int
        {
            Team1 = 0x14,
            Team2 = 0x16
        }
        //1Byte
        private enum KillStreakCurrentOffsets : int
        {
            Team1 = 0x39,
            Team2 = 0x3D
        }
        //1Byte
        private enum KillStreakLongestOffsets : int
        {
            Team1 = 0x3A,
            Team2 = 0x3E
        }
        //2Bytes
        private enum HeadshotsOffsets : int
        {
            Team1 = 0x52,
            Team2 = 0x56
        }

        private enum WeaponPtrOffsets : int
        {
            Team1_1 = 0x60,
            Team1_2 = 0x64,
            Team1_3 = 0x68,
            Team1_4 = 0x6C,
            Team1_5 = 0x70,
            Team1_6 = 0x74,
            Team1_7 = 0x78,
            Team1_8 = 0x7C,
            Team1_9 = 0x80,
            Team1_10= 0x84,
            Team2_1 = 0x88,
            Team2_2 = 0x8C,
            Team2_3 = 0x90,
            Team2_4 = 0x94,
            Team2_5 = 0x98,
            Team2_6 = 0x9C,
            Team2_7 = 0xA0,
            Team2_8 = 0xA4,
            Team2_9 = 0xA8,
            Team2_10= 0xAC
        }
        private enum WeaponTimerOffsets : int
        {
            Team1_1 = 0xB0,
            Team1_2 = 0xB4,
            Team1_3 = 0xB8,
            Team1_4 = 0xBC,
            Team1_5 = 0xC0,
            Team1_6 = 0xC4,
            Team1_7 = 0xC8,
            Team1_8 = 0xCC,
            Team1_9 = 0xD0,
            Team1_10 = 0xD4,
            Team2_1 = 0xD8,
            Team2_2 = 0xDC,
            Team2_3 = 0xE0,
            Team2_4 = 0xE4,
            Team2_5 = 0xE8,
            Team2_6 = 0xEC,
            Team2_7 = 0xF0,
            Team2_8 = 0xF4,
            Team2_9 = 0xF8,
            Team2_10 = 0xFC
        }
        private enum ClassPtrOffsets : int
        {
            Team1_1 = 0x150,
            Team1_2 = 0x154,
            Team1_3 = 0x158,
            Team1_4 = 0x15C,
            Team1_5 = 0x160,
            Team2_1 = 0x164,
            Team2_2 = 0x168,
            Team2_3 = 0x16C,
            Team2_4 = 0x170,
            Team2_5 = 0x174,
        }
        private enum ClassTimerOffsets : int
        {
            Team1_1 = 0x178,
            Team1_2 = 0x17C,
            Team1_3 = 0x180,
            Team1_4 = 0x184,
            Team1_5 = 0x188,
            Team2_1 = 0x18C,
            Team2_2 = 0x190,
            Team2_3 = 0x194,
            Team2_4 = 0x198,
            Team2_5 = 0x19C
        }
        private enum TotalSpawnTimeOffsets : int
        {
            Team1 = 0x1A0,
            Team2 = 0x1A4
        }
        private enum CurrentTimeAliveOffsets : int
        {
            Team1 = 0x1A8,
            Team2 = 0x1B0
        }
        private enum LongestTimeAliveOffsets : int
        {
            Team1 = 0x1AC,
            Team2 = 0x1B4
        }
        private enum CurrentCampTimeOffsets : int
        {
            Team1 = 0x1C4,
            Team2 = 0x1CC
        }
        private enum LongestCampTimeOffsets : int
        {
            Team1 = 0x1C8,
            Team2 = 0x1D0
        }

        public IntPtr baseAddr;
        public ProcessMemoryReader reader;

        public Score(IntPtr basePtr, ProcessMemoryReader reader)
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
        public virtual int Points
        {
            get
            {
                int amt = reader.ReadInt32(IntPtr.Add(baseAddr, (int)PointsOffsets.All));
                //Handle negative... I'm not smart enough to do it any other way (if there is another)
                if(amt % 65536 > 6000) // use a high number because I doubt anyone will get +-6000 points
                {
                    return amt - 65536;
                }
                return amt;
            }
        }
        public virtual int Kills
        {
            get
            {
                int team1 = reader.ReadInt32(IntPtr.Add(baseAddr, (int)KillsOffsets.Team1));
                int team2 = reader.ReadInt32(IntPtr.Add(baseAddr, (int)KillsOffsets.Team2));
                int team1TK = reader.ReadInt16(IntPtr.Add(baseAddr, (int)TKOffsets.Team1));
                int team2TK = reader.ReadInt16(IntPtr.Add(baseAddr, (int)TKOffsets.Team2));
                return team1 + team2 - 2*(team1TK + team2TK); 
            }
        }
        public virtual int Deaths
        {
            get
            {
                int team1 = reader.ReadInt16(IntPtr.Add(baseAddr, (int)DeathsOFfsets.Team1));
                int team2 = reader.ReadInt16(IntPtr.Add(baseAddr, (int)DeathsOFfsets.Team2));
                return team1 + team2;
            }   
        }
        public virtual int FlagCaps
        {
            get
            {
                int team1 = reader.ReadInt16(IntPtr.Add(baseAddr, (int)FlagCapsOffsets.Team1));
                int team2 = reader.ReadInt16(IntPtr.Add(baseAddr, (int)FlagCapsOffsets.Team2));
                return team1 + team2;
            }
        }
        public virtual int KillStreakCurrent
        {
            get
            {
                int team1 = reader.ReadInt8(IntPtr.Add(baseAddr, (int)KillStreakCurrentOffsets.Team1));
                int team2 = reader.ReadInt8(IntPtr.Add(baseAddr, (int)KillStreakCurrentOffsets.Team2));
                return team1 + team2;
            }
        }
        public virtual int KillStreakLongest
        {
            get
            {
                int team1 = reader.ReadInt8(IntPtr.Add(baseAddr, (int)KillStreakLongestOffsets.Team1));
                int team2 = reader.ReadInt8(IntPtr.Add(baseAddr, (int)KillStreakLongestOffsets.Team2));
                return team1 + team2;
            }
        }
        public virtual float TimeAliveTotal
        {
            get
            {
                float team1 = reader.ReadFloat(IntPtr.Add(baseAddr, (int)TotalSpawnTimeOffsets.Team1));
                float team2 = reader.ReadFloat(IntPtr.Add(baseAddr, (int)TotalSpawnTimeOffsets.Team2));
                return team1 + team2;
            }
        }
        public virtual float TimeAliveCurrent
        {
            get
            {
                float team1 = reader.ReadFloat(reader.ReadPtr(IntPtr.Add(baseAddr, (int)CurrentTimeAliveOffsets.Team1)));
                float team2 = reader.ReadFloat(reader.ReadPtr(IntPtr.Add(baseAddr, (int)CurrentTimeAliveOffsets.Team2)));
                return team1 + team2;
            }
        }

        public virtual float TimeAliveLongest
        {
            get
            {
                float team1 = reader.ReadFloat(reader.ReadPtr(IntPtr.Add(baseAddr, (int)LongestTimeAliveOffsets.Team1)));
                float team2 = reader.ReadFloat(reader.ReadPtr(IntPtr.Add(baseAddr, (int)LongestTimeAliveOffsets.Team2)));
                return team1 + team2;
            }
        }














        //TODO: get fav weapons
        private int GetLongestTimeIndex(int[] e)
        {
            float longestTime = 0;
            float time;
            int index=0;

            for(int i = 0; i < e.Length; i++)
            {
                time = reader.ReadInt32(IntPtr.Add(baseAddr, e[i]));
                if (longestTime > time){
                    longestTime = time;
                    index = i;
                }
            }
            return index;
        }

    }
}
