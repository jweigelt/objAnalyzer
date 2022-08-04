using System;
using System.Text;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.ComponentModel;
using System.Linq;

namespace ObjMonitor
{
    public class ProcessMemoryReader
    {
        [Flags]
        private enum ProcessAccessFlags : uint
        {
            All = 0x001F0FFF,
            Terminate = 0x00000001,
            CreateThread = 0x00000002,
            VirtualMemoryOperation = 0x00000008,
            VirtualMemoryRead = 0x00000010,
            VirtualMemoryWrite = 0x00000020,
            DuplicateHandle = 0x00000040,
            CreateProcess = 0x000000080,
            SetQuota = 0x00000100,
            SetInformation = 0x00000200,
            QueryInformation = 0x00000400,
            QueryLimitedInformation = 0x00001000,
            Synchronize = 0x00100000
        }

        [DllImport("kernel32.dll", SetLastError = true)]
        static extern IntPtr OpenProcess(ProcessAccessFlags processAccess, bool bInheritHandle, int processId);

        [DllImport("kernel32.dll", SetLastError = true)]
        static extern bool ReadProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, [Out] byte[] lpBuffer, int dwSize, out IntPtr lpNumberOfBytesRead);

        [DllImport("kernel32.dll", SetLastError = true)]
        static extern bool WriteProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, byte[] lpBuffer, uint nSize, out UIntPtr lpNumberOfBytesWritten);

        [DllImport("kernel32.dll", SetLastError = true)]
        static extern bool CloseHandle(IntPtr hObject);

        private IntPtr hProc = IntPtr.Zero;
        private IntPtr moduleBase;

        public void Open(string name)
        {
            Process[] procs = Process.GetProcessesByName(name);
            if (procs.Length < 1) throw new Exception("No process found.");

            Process proc = null;
            foreach(var p in procs) {
                //TODO
                //if(p.MainModule.FileName.Contains("Steam"))
                //{
                    proc = p;
                    break;
                //}
            }
            if (proc == null) throw new Exception("No process found.");

            hProc = OpenProcess(ProcessAccessFlags.All, false, proc.Id);
            if (hProc == IntPtr.Zero) throw new Exception("OpenProcess() failed.");

            moduleBase = proc.MainModule.BaseAddress;
        }

        public IntPtr GetModuleBase(int offset)
        {
            return IntPtr.Add(moduleBase, offset);
        }

        public float ReadFloat(IntPtr address)
        {
            byte[] buf = new byte[4];
            ReadProcessMemory(hProc, address, buf, 4, out IntPtr read);
            return BitConverter.ToSingle(buf, 0);
        }

        public void WriteFloat(IntPtr address, float value)
        {
            byte[] buf = BitConverter.GetBytes(value);
            if (!WriteProcessMemory(hProc, address, buf, 4, out UIntPtr written))
            {
                Console.WriteLine("hProc -> {0}", hProc);
                throw new Win32Exception();
            }
        }
        public int ReadInt32(IntPtr address)
        {
            byte[] buf = new byte[4];
            ReadProcessMemory(hProc, address, buf, 4, out IntPtr read);
            return BitConverter.ToInt32(buf, 0);
        }
        public int ReadInt16(IntPtr address)
        {
            byte[] buf = new byte[2];
            ReadProcessMemory(hProc, address, buf, 2, out IntPtr read);
            return BitConverter.ToInt16(buf, 0);
        }
        public int ReadInt8(IntPtr address)
        {
            byte[] buf = new byte[1];
            ReadProcessMemory(hProc, address, buf, 1, out IntPtr read);
            return Convert.ToByte(buf[0]);
        }
        public string ReadWString(IntPtr address, int len)
        {
            len *= 2;
            byte[] buf = new byte[len];
            ReadProcessMemory(hProc, address, buf, len, out IntPtr read);
            int strLen = 0;
            for (int i = 0; i < len; i += 2)
            {
                if (buf[i] == 0)
                {
                    strLen = i;
                    break;
                }
            }
            return Encoding.Unicode.GetString(buf, 0, strLen);
        }

        public string ReadString(IntPtr address, int len)
        {
            byte[] buf = new byte[len];
            ReadProcessMemory(hProc, address, buf, len, out IntPtr read);
            int strLen = 0;
            for (int i = 0; i < len; i++)
            {
                if (buf[i] == 0)
                {
                    strLen = i;
                    break;
                }
            }
            return Encoding.ASCII.GetString(buf, 0, strLen);
        }

        public IntPtr ReadPtr(IntPtr address)
        {
            byte[] buf = new byte[4];
            ReadProcessMemory(hProc, address, buf, 4, out IntPtr read);
            return IntPtr.Add(IntPtr.Zero, BitConverter.ToInt32(buf, 0));
        }

        /*
         * basePtr    - starting address to add offsets to
         * offsets    - array of offsets for pointers
         */
        public IntPtr GetOffsetIntPtr(IntPtr basePtr, int[] offsets)
        { 
            for (int i = 0; i < offsets.Length-1; i++)
            {
                basePtr = ReadPtr(IntPtr.Add(basePtr, offsets[i]));
            }

            IntPtr address = IntPtr.Add(basePtr, offsets[offsets.Length-1]);

            return address; 
        }

        ~ProcessMemoryReader()
        {
            if (hProc != IntPtr.Zero)
            {
                CloseHandle(hProc);
            }
        }
    }
}