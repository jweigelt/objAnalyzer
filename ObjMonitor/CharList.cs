using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjMonitor
{
    public class CharList
    {
        public int CharacterTableBaseOffset = 0x01A30334;
        public int CharacterOffset          = 0x1B0;
        public List<InGameCharacterObject> characterList { get; set; } = new List<InGameCharacterObject>();
        public IntPtr baseAddr;
        public ProcessMemoryReader reader;
        public CharList(ProcessMemoryReader reader)
        {
            baseAddr = reader.ReadPtr(reader.GetModuleBase(CharacterTableBaseOffset));
            this.reader = reader;
        }
        public void Empty()
        {
            characterList.Clear();
        }
        public void GetCharList()
        {
            IntPtr addr = baseAddr;
            int idx = 0;
            if (!addr.Equals(IntPtr.Zero))
            {
                for (int i = 0; i < 64; i++)
                {
                    InGameCharacterObject obj = new InGameCharacterObject(addr, reader);
                    //obj.Index = idx;
                    characterList.Add(obj);
                    addr = IntPtr.Add(addr, CharacterOffset);
                    idx++;
                }
            }
        }
    }
}
