/**
    Bilai-PnP-Gui, Desktop stat viewer for Banglalion devices
    Copyright (C) 2016 Md. Minhazul Haque

    This program is free software; you can redistribute it and/or
    modify it under the terms of the GNU General Public License
    as published by the Free Software Foundation; either version 3
    of the License, or (at your option) any later version.
*/

using System.Net;
using System.Text;
using System.IO;
using System;

namespace Bilai_PnP_Gui
{
    public class Bilai
    {
        const string BilaiURL = "http://192.168.2.1/apply.cgi";

        const string PostDataLogin = "submit_button=login&submit_type=do_login&change_action=gozila_cgi&username=admin&passwd=admin";
        const string PostDataStatus = "submit_button=wimaxinterfaceInfo&submit_type=ref&change_action=gozila_cgi";

        private string Cookie;
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
                var request = (HttpWebRequest)WebRequest.Create(BilaiURL);
                var data = Encoding.ASCII.GetBytes(PostDataLogin);

                request.Method = "POST";
                request.ContentType = "application/x-www-form-urlencoded";
                request.ContentLength = data.Length;

                var stream = request.GetRequestStream();
                stream.Write(data, 0, data.Length);
                stream.Close();

                var response = (HttpWebResponse)request.GetResponse();

                Cookie = response.GetResponseHeader("Set-Cookie").Replace("; Path=/", "");

                stream = response.GetResponseStream();
                var reader = new StreamReader(stream);
                string responseFromServer = reader.ReadToEnd();

                reader.Close();
                stream.Close();
                response.Close();

                if (responseFromServer == "success")
                    return "";
                else
                    return "Login Failed";
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
                var request = (HttpWebRequest)WebRequest.Create(BilaiURL);
                var data = Encoding.ASCII.GetBytes(PostDataStatus);

                request.Method = "POST";
                request.ContentType = "application/x-www-form-urlencoded";
                request.ContentLength = data.Length;

                var stream = request.GetRequestStream();
                stream.Write(data, 0, data.Length);
                stream.Close();

                var response = (HttpWebResponse)request.GetResponse();

                Cookie = response.GetResponseHeader("Cookie").Replace("; Path=/", "");

                stream = response.GetResponseStream();
                var reader = new StreamReader(stream);
                string[] StatusData = reader.ReadToEnd().Split(';');

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
                Uptime = Uptime.Split(':')[0] + "h " + Uptime.Replace(" ", "").Split(':')[1] + "m";

                reader.Close();
                stream.Close();
                response.Close();
            }
            catch (Exception exc)
            {
                return exc.Message;
            }
            return "";
        }
    }
}

