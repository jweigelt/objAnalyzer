using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjMonitor
{
    public class InGameTeamObj
    {

        public static readonly int[] ID_OFFSET =            { 0x8 };
        public static readonly int[] SHORT_NAME_OFFSET =    { 0xC  };
        public static readonly int[] CTF_SCORE_OFFSET =     { 0x60 };
        public static readonly int[] CON_SCORE_OFFSET =     { 0x28 };
        public static readonly int[] CON_MAX_SCORE_OFFSET = { 0x2C };
        public static readonly int[] CON_BLEEDRATE_OFFSET = { 0x30 };
        public static readonly int[] NUM_ALIVE_OFFSET =     { 0x3C };
        public bool IsHost { get; set; }
        public IntPtr baseAddr;
        public ProcessMemoryReader reader;
        
        public InGameTeamObj(IntPtr basePtr, ProcessMemoryReader reader)
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
        public int TeamID
        {
            get
            {
                return reader.ReadInt32(reader.GetOffsetIntPtr(baseAddr, ID_OFFSET));
            }
        }
        public string TeamName
        {
            get
            {
                return reader.ReadWString(reader.ReadPtr(reader.GetOffsetIntPtr(baseAddr, SHORT_NAME_OFFSET)), 32);
            }
        }
        public int CTFScore
        {
            get
            {
                return reader.ReadInt32(reader.GetOffsetIntPtr(baseAddr, CTF_SCORE_OFFSET));
            }
        }
        public int CONScore
        {
            get
            {
                return reader.ReadInt32(reader.GetOffsetIntPtr(baseAddr, CON_SCORE_OFFSET));
            }
        }
        public int ConMaxScore
        {
            get
            {
                return reader.ReadInt32(reader.GetOffsetIntPtr(baseAddr, CON_MAX_SCORE_OFFSET));
            }
        }
        public float BleedRate
        {
            get
            {
                return reader.ReadFloat(reader.GetOffsetIntPtr(baseAddr, CON_BLEEDRATE_OFFSET));
            }
        }
        public int NumAlive
        {
            get
            {
                return reader.ReadInt32(reader.GetOffsetIntPtr(baseAddr, NUM_ALIVE_OFFSET));
            }
        }
        public int NumKills
        {
            get
            {
                return isCON ? 0 : 1024 - CONScore;
            }
        }
        public bool isCTF
        {
            get
            {
                return ConMaxScore > 20000; //Arbitrary number for in ctf games this is set to whatever 7FFFFFFF is in hex
            }
        }
        public bool isCON
        {
            get
            {
                return ConMaxScore < 20000;
            }
        }
        public int Score
        {
            get
            {
                return isCTF ? CTFScore : CONScore;
            }
        }

        public string GetDataString
        {
            get
            {
                var timestamp = reader.ReadFloat(reader.GetModuleBase(0x1BA88E8));
                return $"{timestamp},{TeamName},{TeamID},{Score}";
            }
        }
    }
}
