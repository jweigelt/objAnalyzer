using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjMonitor
{
    public class Score2
    {
        public readonly int KILLS_OFFSET = 0x60;
        public IntPtr baseAddr;
        public ProcessMemoryReader reader;

        public Score2(IntPtr basePtr, ProcessMemoryReader reader)
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
        public virtual int Kills
        {
            get
            {
                return reader.ReadInt32(IntPtr.Add(baseAddr, KILLS_OFFSET));
            }
        }
    }
}
