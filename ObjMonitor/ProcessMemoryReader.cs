using System;
using System.Text;
using System.Diagnostics;
using System.Runtime.InteropServices;
namespace ObjMonitor
{
    public abstract class ProcessMemoryReader
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

        protected IntPtr GetModuleBase(int offset)
        {
            return IntPtr.Add(moduleBase, offset);
        }

        protected float ReadFloat(IntPtr address)
        {
            byte[] buf = new byte[4];
            ReadProcessMemory(hProc, address, buf, 4, out IntPtr read);
            return BitConverter.ToSingle(buf, 0);
        }

        protected void WriteFloat(IntPtr address, float value)
        {
            byte[] buf = BitConverter.GetBytes(value);
            WriteProcessMemory(hProc, address, buf, 4, out UIntPtr written);
        }
        protected int ReadInt32(IntPtr address)
        {
            byte[] buf = new byte[4];
            ReadProcessMemory(hProc, address, buf, 4, out IntPtr read);
            return BitConverter.ToInt32(buf, 0);
        }
        protected string ReadWString(IntPtr address, int len)
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

        protected string ReadString(IntPtr address, int len)
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

        protected IntPtr ReadPtr(IntPtr address)
        {
            byte[] buf = new byte[4];
            ReadProcessMemory(hProc, address, buf, 4, out IntPtr read);
            return IntPtr.Add(IntPtr.Zero, BitConverter.ToInt32(buf, 0));
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