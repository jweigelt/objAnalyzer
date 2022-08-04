using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjMonitor
{
    public class InGameSoldierClassObj
    {
        
        private enum WeaponSlots : int
        { 
            Primary =           0x748,
            Secondary =         0x74C,
            PrimarySupport =    0x750,
            SecondarySupport =  0x754
        }
        public static int[] CLASS_NAME = { 0x20, 0x0};
        public IntPtr baseAddr;
        public ProcessMemoryReader reader;
        public InGameSoldierClassObj(IntPtr basePtr, ProcessMemoryReader reader)
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
                return reader.ReadWString(reader.GetOffsetIntPtr(baseAddr, CLASS_NAME), 32);
            }
        }
        //TODO: Weapon obects
    }
}
