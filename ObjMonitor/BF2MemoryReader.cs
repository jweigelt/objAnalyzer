using System;
using System.Collections.Generic;

namespace ObjMonitor
{
    public class BF2IngameObject
    {
        public int Index { get; set; } = -1;
        public int LastUpdate { get; set; } = 0;
        public int ClientLag { get; set; } = 0;
        public string Name { get; set; }
        public string ClassName { get; set; }
        public int Hash { get; }

        public virtual bool Exists
        {
            get
            {
                return !basePtr.Equals(IntPtr.Zero);
            }
        }
        private IntPtr basePtr;
        public BF2IngameObject(int hash, IntPtr basePtr)
        {
            Hash = hash;
            this.basePtr = basePtr;
        }
    }

    public class BF2MemoryReader : ProcessMemoryReader
    {
        public bool IsSteam { get; set; } = true;
        public List<BF2IngameObject> ReadObjTable()
        {
            IntPtr tblBasePtr = GetModuleBase((IsSteam ? 0x01FA6608 : 0x007E9268) - 0x400000);

            var objList = new List<BF2IngameObject>();
            var ticks = GetClientTicks();

            for(int i = 0; i < 64; i++)
            {
                IntPtr objPtr = ReadPtr(IntPtr.Add(tblBasePtr, i * 4));

                var obj = new BF2IngameObject(i, objPtr);
                if (objPtr != IntPtr.Zero)
                {
                    obj.Index = ReadInt32(IntPtr.Add(objPtr, 4));
                    obj.LastUpdate = ReadInt32(IntPtr.Add(objPtr, 8));

                    IntPtr modelPtr = ReadPtr(objPtr);
                    IntPtr clientPtr = ReadPtr(IntPtr.Add(modelPtr, 0x030C));
                    obj.Name = ReadWString(IntPtr.Add(clientPtr, 0x30), 64);
                    obj.ClientLag = GetClientTicks() - obj.LastUpdate;

                    IntPtr p1 = ReadPtr(IntPtr.Add(modelPtr, 0x08));
                    IntPtr p2 = ReadPtr(IntPtr.Add(p1, 0x20));
                    obj.ClassName = ReadWString(p2, 32);
                }
               
                objList.Add(obj);
            }
            return objList;
        }

        public int GetClientTicks()
        {
            return ReadInt32(GetModuleBase((IsSteam ? 0x01E64DE4 : 0x01E66294) - 0x400000));
        }

        public int GetClientUpdates()
        {
            return ReadInt32(GetModuleBase((IsSteam ? 0x01E64EEC : 0x01E6639C) - 0x400000)); 
        }
    }
}
