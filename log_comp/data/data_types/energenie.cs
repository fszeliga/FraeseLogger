using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Configuration;
using System.Net.NetworkInformation;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;

namespace imi_cnc_logger
{
    public class energenie
    {
        private bool read = false;
        private readonly IPAddress ip;

        public double watt { get; private set; } = 0.0;
        private const double wattConst = 466.0;

        public double current { get; private set; } = 0.0;
        private const double currentConst = 100.0;

        public double voltage { get; private set; } = 0.0;
        private const double voltageConst = 10.0;

        public double energy { get; private set; } = 0.0;
        private const double energyConst = 25.6;

        private Thread thread;

        public energenie(IPAddress ip)
        {
            this.ip = ip;
            ToggleAllowUnsafeHeaderParsing(true);

            thread = new Thread(new ThreadStart(readEnergenie));
            thread.IsBackground = true;
            thread.Start();
        }

        public void stop()
        {
            read = false;
        }

        public void readEnergenie()
        {
            read = true;
            while (read)
            {
                if (!isOnline()) continue; //ping to make sure is online


                WebRequest req = WebRequest.Create("http://" + ip + "/login.html");
                string postData = "pw=1";

                byte[] send = Encoding.Default.GetBytes(postData);
                req.Method = "POST";
                req.ContentType = "application/x-www-form-urlencoded";
                req.ContentLength = send.Length;

                Stream sout = req.GetRequestStream();
                sout.Write(send, 0, send.Length);
                sout.Flush();
                sout.Close();

                WebResponse res = req.GetResponse();
                StreamReader sr = new StreamReader(res.GetResponseStream());
                string returnvalue = sr.ReadToEnd();
                sr.Close();
                res.Close();

                returnvalue = WebUtility.HtmlDecode(returnvalue);
                returnvalue = Regex.Replace(returnvalue, @"\s+", "");
                HtmlDocument resultat = new HtmlDocument();
                resultat.LoadHtml(returnvalue);

                List<HtmlNode> nodeList = resultat.DocumentNode.Descendants().Where(x => (x.Name == "script")).ToList();

                Console.WriteLine("HtmlNodes {0}", nodeList.Count);

                foreach (HtmlNode n in nodeList)
                {
                    char[] delimiters = new char[] { ';', '=' };

                    List<String> vals = n.InnerText.Split(delimiters).ToList();
                    for (int i = 0; i < vals.Count; i += 2)
                    {
                        Console.WriteLine("Parsing: {0}", vals[i]);

                        if (vals[i].Contains("varV"))
                        {
                            voltage = Int32.Parse(vals[i + 1]) / voltageConst;
                        }
                        else if (vals[i].Contains("varI"))
                        {
                            current = Int32.Parse(vals[i + 1]) / currentConst;
                        }
                        else if (vals[i].Contains("varP"))
                        {
                            watt = Int32.Parse(vals[i + 1]) / wattConst;
                        }
                        else if (vals[i].Contains("varE"))
                        {
                            energy = Int32.Parse(vals[i + 1]) / energyConst;
                        }
                    }
                }

                Thread.Sleep(5000);
            }
        }
        
        public bool isOnline()
        {
            try
            {
                Ping pingSender = new Ping();
                PingReply reply = pingSender.Send(ip.ToString());
                if (reply.Status == IPStatus.Success)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }

        }

        /// <summary>
        /// Get a String representation of Ampere/Voltage/Watts/total Power.
        /// </summary>
        /// <param name="seperator">seperator used between the 3 values</param>
        /// <param name="names">include name infront of value/</param>
        /// <param name="units">include units after value?</param>
        /// <returns></returns>
        public string data2String(string seperator = " ", bool names = true, bool units = false)
        {
            return (names ? "Ampere: " : "") + current + (units ? "A" : "") + seperator
                + (names ? "Voltage: " : "") + voltage + (units ? "V" : "") + seperator
                + (names ? "Watt: " : "") + watt + (units ? "W" : "") + seperator
                + (names ? "Energy: " : "") + energy + (units ? "Wh" : "");
        }

        public string watt2String(bool name = true, bool units = false)
        {
            return name ? "Watt: " : "" + watt + (units ? "A" : "");
        }

        public string ampere2String(bool name = true, bool units = false)
        {
            return name ? "Ampere: " : "" + current + (units ? "A" : "");
        }

        public string volt2String(bool name = true, bool units = false)
        {
            return name ? "Voltage: " : "" + voltage + (units ? "A" : "");
        }

        public string power2String(bool name = true, bool units = false)
        {
            return name ? "Energy: " : "" + energy + (units ? "Wh" : "");
        }


        public static bool ToggleAllowUnsafeHeaderParsing(bool enable)
        {
            //Get the assembly that contains the internal class
            Assembly assembly = Assembly.GetAssembly(typeof(SettingsSection));
            if (assembly != null)
            {
                //Use the assembly in order to get the internal type for the internal class
                Type settingsSectionType = assembly.GetType("System.Net.Configuration.SettingsSectionInternal");
                if (settingsSectionType != null)
                {
                    //Use the internal static property to get an instance of the internal settings class.
                    //If the static instance isn't created already invoking the property will create it for us.
                    object anInstance = settingsSectionType.InvokeMember("Section",
                    BindingFlags.Static | BindingFlags.GetProperty | BindingFlags.NonPublic, null, null, new object[] { });
                    if (anInstance != null)
                    {
                        //Locate the private bool field that tells the framework if unsafe header parsing is allowed
                        FieldInfo aUseUnsafeHeaderParsing = settingsSectionType.GetField("useUnsafeHeaderParsing", BindingFlags.NonPublic | BindingFlags.Instance);
                        if (aUseUnsafeHeaderParsing != null)
                        {
                            aUseUnsafeHeaderParsing.SetValue(anInstance, enable);
                            return true;
                        }

                    }
                }
            }
            return false;
        }
    }
}
