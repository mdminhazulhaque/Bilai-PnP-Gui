/* For some devices of Banglalion, we need to parse data's by GET method. 
 * This modified code covers that GET method.
 * 
 * Modified by Habibur Rahman,
 * Email: habib_cse_ruet@yahoo.com
 */

using System.Net;
using System.Text;
using System.IO;
using System;

namespace Bilai_PnP_Gui
{
    public class Bilai2
    {
        const string BilaiURLLogin = "http://192.168.2.1/apply.cgi";
        const string BilaiURLUpdate = "http://192.168.2.1/wimax/InterfaceInfo_Ref.asp";
        public string BSID { get; private set; }
        public string Freq { get; private set; }
        public string CINR { get; private set; }
        public string RSSI { get; private set; }
        public string ULRate { get; private set; }
        public string DLRate { get; private set; }
        public string Uptime { get; private set; }
        public int Signal { get; private set; }

        public string Login()
        {
            try
            {
                WebClient client = new WebClient();
                String username = "admin";
                String password = "admin";
                string url = BilaiURLLogin + username;
                client.Credentials = new System.Net.NetworkCredential(username, password);
                string credentials = Convert.ToBase64String(Encoding.ASCII.GetBytes(username + ":" + password));
                client.Headers[HttpRequestHeader.Authorization] = "Basic " + credentials;
                var result = client.DownloadString(url);
                return result;
            }
            catch (Exception exc)
            {
                return exc.Message;
            }
        }

        public string Update()
        {
            try
            {
                WebClient client = new WebClient();
                String username = "admin";
                String password = "admin";
                string url = BilaiURLLogin + username;
                client.Credentials = new System.Net.NetworkCredential(username, password);
                string credentials = Convert.ToBase64String(Encoding.ASCII.GetBytes(username + ":" + password));
                client.Headers[HttpRequestHeader.Authorization] = "Basic " + credentials;
                string result = client.DownloadString(BilaiURLUpdate);
                string[] StatusData = result.Split(';');

                BSID = StatusData[1];
                Freq = StatusData[2];
                CINR = StatusData[4];
                RSSI = StatusData[3];
                ULRate = StatusData[20];
                DLRate = StatusData[21];
                Uptime = StatusData[19];

                double nRSSI = Convert.ToSingle(RSSI.Replace(" dBm", ""));

                // Calculate signal quality from RSSI
                nRSSI = (nRSSI + 100F) * 1.33;

                if (nRSSI >= 80)
                    Signal = 5;
                else if (nRSSI >= 60)
                    Signal = 4;
                else if (nRSSI >= 40)
                    Signal = 3;
                else if (nRSSI >= 20)
                    Signal = 2;
                else if (nRSSI >= 10)
                    Signal = 1;
                else
                    Signal = 0;

                // Convert 12:34 to 12h 34m format
                Uptime = Uptime.Replace(" ", "");
                bool flag = false;
                for (int i = 0; i < Uptime.Length; i++)
                {
                    if (Uptime[i] == ':')
                        flag = true;
                }
                if (flag == true)
                    Uptime = Uptime.Split(':')[0] + " Hour " + Uptime.Replace(" ", "").Split(':')[1] + " Minute";
                else
                {
                    if (Uptime.Contains("min"))
                    {
                        Uptime = Uptime.Replace("min"," Minute");
                    }
                    if (Uptime.Contains("hour"))
                    {
                        Uptime = Uptime.Replace("hour", " Hour");
                        
                    }
                    Uptime = Uptime.Replace("h", " Hour");
                }
                

            }
            catch (Exception exc)
            {
                return exc.Message;
            }
            return "";
        }
    }
}
