using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;

namespace imi_cnc_logger
{
    public class energenie
    {
        private bool read = false;
        private int val = 0;
        private readonly IPAddress ip;

        public double watt { get; private set; } = 0.0;
        public double ampere { get; private set; } = 0.0;
        public double voltage { get; private set; } = 0.0;

        public energenie(IPAddress ip)
        {
            this.ip = ip;
        }

        public void start()
        {
            Thread log = new Thread(new ThreadStart(readEnergenie2));
            read = true;
            log.Start();
        }

        public void stop()
        {
            read = false;
            val = 0;
        }

        private void readEnergenie2()
        {
            while (read)
            {
                val += 1;
                voltage += .17;
                ampere += .34;
                watt = voltage * ampere;
                Thread.Sleep(1000);
                if (val > 10) read = false;
            }
        }

        private void readEnergenie()
        {

            while (read)
            {
                WebRequest req = WebRequest.Create("http://www.w3schools.com/html/action_page.php");
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
                //'V', 'Voltage',  10.0, 'V',        # factors are take from script: eg.js
                //'I', 'Current', 100.0, 'A',
                //'P', 'Power',   466.0, 'W',
                //'E', 'Energie',  25.6, 'Wh'
                //TODO parse data and device by above values?

                System.Threading.Thread.Sleep(3000);
            }
        }

        /// <summary>
        /// Get a String representation of Ampere/Voltage/Watts.
        /// </summary>
        /// <param name="seperator">seperator used between the 3 values</param>
        /// <param name="names">include name infront of value/</param>
        /// <param name="units">include units after value?</param>
        /// <returns></returns>
        public String data2String(String seperator = " ", bool names = true, bool units = false)
        {

            return (names ? "Ampere: " : "") + ampere + (units ? "A" : "") + seperator
                + (names ? "Voltage: " : "") + voltage + (units ? "V" : "") + seperator
                + (names ? "Watt: " : "") + watt + (units ? "W" : "");
        }

        public String watt2String(bool name = true, bool units = false)
        {
            return name ? "Watt: " : "" + watt + (units ? "A" : "");
        }

        public String ampere2String(bool name = true, bool units = false)
        {
            return name ? "Ampere: " : "" + ampere + (units ? "A" : "");
        }

        public String volt2String(bool name = true, bool units = false)
        {
            return name ? "Voltage: " : "" + voltage + (units ? "A" : "");
        }
    }
}
