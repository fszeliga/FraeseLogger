using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace imi_cnc_logger.WebServer
{
    public abstract class HTTPServer
    {

        protected int port;
        protected IPAddress ip_addr;
        TcpListener listener;
        bool is_active = true;

        public HTTPServer(String ip_addr, int port)
        {
            this.port = port;
            this.ip_addr = IPAddress.Parse(ip_addr);
            listener = new TcpListener(this.ip_addr, this.port);
        }

        public void listen()
        {
            try
            {
                listener.Start();
                LoggerManager.THE().pushLog("Starting HTTPServer listener...accepting connections");
                while (is_active)
                {
                    TcpClient s = listener.AcceptTcpClient();
                    HTTPProcessor processor = new HTTPProcessor(s, this);
                    Thread thread = new Thread(new ThreadStart(processor.process));
                    thread.Start();
                    Thread.Sleep(1);
                }
            }
            catch(Exception e)
            {
                is_active = false;
            }
            finally
            {
                LoggerManager.THE().pushLog("Stopped HTTPServer");
            }

        }

        public void stop()
        {
            listener.Stop();
        }

        public abstract void handleGETRequest(HTTPProcessor p);
        public abstract void handlePOSTRequest(HTTPProcessor p, StreamReader inputData);
    }
}
