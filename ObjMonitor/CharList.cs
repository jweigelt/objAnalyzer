using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjMonitor
{
    public class CharList
    {
        public int CharacterTableBaseOffset = 0x01A30334;
        public int CharacterOffset          = 0x1B0;
        public List<InGameCharacterObject> Team1 { get; set; } = new List<InGameCharacterObject>();
        public List<InGameCharacterObject> Team2 { get; set; } = new List<InGameCharacterObject>();

        public IntPtr baseAddr;
        public ProcessMemoryReader reader;
        public CharList(ProcessMemoryReader reader)
        {
            baseAddr = reader.GetModuleBase(CharacterTableBaseOffset);
            this.reader = reader;
            GetCharList();
        }
        public void Empty()
        {
            Team1.Clear();
            Team2.Clear();
        }
        public void GetCharList()
        {
            IntPtr addr = reader.ReadPtr(baseAddr);

            if (!addr.Equals(IntPtr.Zero))
            {
                for (int i = 0; i < 64; i++)
                {
                    InGameCharacterObject obj = new InGameCharacterObject(addr, reader);
                    if (obj.TeamID == 1 && obj.TimeStampOfLastSpawn > 0)
                    {
                        Team1.Add(obj);
                    }
                    else if(obj.TeamID == 2 && obj.TimeStampOfLastSpawn > 0)
                    {
                        Team2.Add(obj);
                    }
                    addr = IntPtr.Add(addr, CharacterOffset);
                }
            }
        }
        public void DumpData(float timestamp)
        {
            foreach (InGameCharacterObject obj in Team1)
            {
                if (!File.Exists($".\\data\\{obj.Name}_{obj.Team.TeamName}_data.csv"))
                {
                    StreamWriter sw1 = new StreamWriter($".\\data\\{obj.Name}_{obj.Team.TeamName}_data.csv");
                    sw1.WriteLine("Timestamp,Name,Health,X,Y,Z");
                    sw1.Close();
                }

                StreamWriter sw = new StreamWriter($".\\data\\{obj.Name}_{obj.Team.TeamName}_data.csv", true, Encoding.ASCII);

                sw.WriteLine($"{timestamp},{obj.Name},{obj.EntitySoldier.Health},{obj.EntitySoldier.X},{obj.EntitySoldier.Y},{obj.EntitySoldier.Z}");

                sw.Close();
            }

            foreach (InGameCharacterObject obj in Team2)
            {
                if (!File.Exists($".\\data\\{obj.Name}_{obj.Team.TeamName}_data.csv"))
                {
                    StreamWriter sw1 = new StreamWriter($".\\data\\{obj.Name}_{obj.Team.TeamName}_data.csv");
                    sw1.WriteLine("Timestamp,Name,Health,X,Y,Z");
                    sw1.Close();
                }

                StreamWriter sw = new StreamWriter($".\\data\\{obj.Name}_{obj.Team.TeamName}_data.csv", true, Encoding.ASCII);

                sw.WriteLine($"{timestamp},{obj.Name},{obj.EntitySoldier.Health},{obj.EntitySoldier.X},{obj.EntitySoldier.Y},{obj.EntitySoldier.Z}");

                sw.Close();
            }

        }
    }
}
