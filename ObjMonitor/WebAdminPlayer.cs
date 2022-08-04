using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ObjMonitor
{

    public class WebAdminPlayer
    {
        public int Ping { get; set; }
        public string Team { get; set; }
        public int Slot { get; set; }
        public string Name { get; set; }
        public int Score { get; set; }
        public int Kills { get; set; }
        public int Deaths { get; set; }
        public int FlagCaptures { get; set; }
        public string KeyHash { get; set; }
        public bool IsBanned { get; set; }
        public int TotalVisits { get; set; }
        public string GroupName { get; set; }
        public string RemoteAddressStr { get; set; }
        public int DatabaseId { get; set; }
       
    }
}
