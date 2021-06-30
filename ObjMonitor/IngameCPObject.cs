using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjMonitor
{
    public class IngameCPObject
    {

        public static readonly int[] LIST_INDEX =   { 0x0, 0x18 };
        public static readonly int[] HUD_INDEX =    { 0x0, 0x1C };
        public static readonly int[] TEAM =         { 0x0, 0xC48 };

        public IntPtr baseAddr;
        public ProcessMemoryReader reader;
        public string TeamName;

        public IngameCPObject(IntPtr basePtr, ProcessMemoryReader reader)
        {
            this.baseAddr = basePtr;
            this.reader = reader;
        }

        public virtual bool Exists
        {
            get
            {
                //Console.WriteLine(IntPtr.Add(baseAddr, 0x18).ToString("X"));
                return !baseAddr.Equals(IntPtr.Zero) && reader.ReadInt32(IntPtr.Add(baseAddr, 0x18)) != 0;
            }
        }

        public virtual int HudIndex
        {
            get
            {
                return reader.ReadInt32(reader.GetOffsetIntPtr(baseAddr, HUD_INDEX));
            }
        }

        public virtual int ListIndex
        {
            get
            {
                return reader.ReadInt32(reader.GetOffsetIntPtr(baseAddr, LIST_INDEX));
            }
        }

        public virtual int Team
        {
            get
            {
                return reader.ReadInt32(reader.GetOffsetIntPtr(baseAddr, TEAM));
            }
        }

        public virtual void SetTeamName(string name)
        {
            TeamName = name;
        }

        public virtual string GetTeamName
        {
            get
            {
                return TeamName;
            }
        }
    }
}
