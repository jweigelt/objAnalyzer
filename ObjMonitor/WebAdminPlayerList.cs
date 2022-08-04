using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ObjMonitor
{
    public class WebAdminPlayerList
    {
        public List<WebAdminPlayer> playerList;
        WebRequest playerListRequest;

        private string IP;
        private string PORT;
        private string USERNAME;
        private string PASSWORD;

        public WebAdminPlayerList(string ip, string port, string username, string password)
        {
            IP = ip;
            PORT = port;
            USERNAME = username;
            PASSWORD = password;
        }

        public bool Connect()
        {
            try
            {
                playerListRequest = WebRequest.Create($"http://{IP}:{PORT}/live/players");
                playerListRequest.Credentials = new NetworkCredential(USERNAME, PASSWORD);
                playerListRequest.ContentType = "application/json";
                playerListRequest.Method = "POST";
            
                using (var streamWriter = new StreamWriter(playerListRequest.GetRequestStream()))
                {
                    string json = "{" + "\"Action\"" + ":" + "\"players_update\"" + "}";
                    streamWriter.Write(json);
                    streamWriter.Flush();
                }
                WebResponse playerListResponse = playerListRequest.GetResponse();

                Stream playerListStream = playerListResponse.GetResponseStream();
                playerList = GetPlayerListArray(playerListStream);
                playerListStream.Close();

                return true;
            }
            catch (WebException ex)
            {
                Console.WriteLine(ex.Status);
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return false;
            }
        }
        
        private List<WebAdminPlayer> GetPlayerListArray(Stream dataStream)
        {
            StreamReader reader = new StreamReader(dataStream);
            return JsonConvert.DeserializeObject<List<WebAdminPlayer>>(reader.ReadToEnd());
        }
    }
}
