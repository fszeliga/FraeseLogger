using imi_cnc_logger.log_comp;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace imi_cnc_logger.WebServer
{

    public class FraeseHttpServer : HTTPServer
    {
        
        ///<summary>
        ///FraeseHttpServer
        ///</summary>
        ///<remarks>
        ///This is a custom implementation of HTTPServer.
        ///Implemented Methods: handleGETRequest and handlePOSTRequest
        ///</remarks>
        public FraeseHttpServer(String ip_addr, int port) : base(ip_addr, port)
        {
            //TODO connector.ConnectorStatus += connector_ConnectorStatus;
        }
        public override void handleGETRequest(HTTPProcessor p)
        {
            char[] delimiterChars = { '/' };

            //make sure to throw the first one out
            //url is: /asd/qwe
            //*************first value will be empty*************
            String[] rest = p.http_url.Split(delimiterChars);

            if (rest[0] == rest[1]){
                p.writeSuccess("application/json");
                p.outputStream.WriteLine("[error:'Wrong REST API command!']");
                return;
            }

            p.writeSuccess("application/json");

            p.outputStream.WriteLine("rest lengt " + rest.Length);

            String eventsJson = "";

            if (rest[1] == "all")
                eventsJson = parseRESTallEvents(p);
            else if (rest[1] == "lastid")
            {
                try
                {
                    eventsJson = parseRESTallEvents(p, Int32.Parse(rest[2]));
                }
                catch
                {
                    p.outputStream.WriteLine("[error:'Wrong REST API command! URL: " + p.http_url + "']");
                    return;
                }
            }
            else
            {
                p.outputStream.WriteLine("[error:'Wrong REST API command! URL: " + p.http_url + "']");
                return;
            }

            p.outputStream.WriteLine("{\"events\":");
            p.outputStream.WriteLine(eventsJson);
            p.outputStream.WriteLine("}");
        }

        /// <summary>
        /// get all log events after (optional) id
        /// </summary>
        /// <param name="p"></param>
        /// <param name="rest"></param>
        /// <param name="sinceid"></param>
        private String parseRESTallEvents(HTTPProcessor p, int lastid = -1)
        {
            String json = "";
                        
            json += "[";

            List<LogEvent> events = LoggerManager.THE().getAllEventsAfterId(lastid);

            LogEvent lastEvent = events.FindLast(o => o.EventId >= 0);

            foreach(LogEvent e in events)
            {
                json += "{";

                json += "\"event_id\" : \"" + e.EventId + "\"" + ",";
                //json += "\"activeProg\" : \"" + e.activeProg + "\"" + ",";
                //json += "\"startTime\" : \"" + e.startTime + "\",";
                //json += "\"globalPostition\" : {" + "\"x\":" + e.cncPos._x + ",\"y\":" + e.cncPos._y + ",\"z\":" + e.cncPos._z + "}";

                json += "}";

                if(!e.Equals(lastEvent)) json += ",";
            }

            json += "]";

            return json;
        }

        public override void handlePOSTRequest(HTTPProcessor p, StreamReader inputData)
        {
            Console.WriteLine("POST request: {0}", p.http_url);
            string data = inputData.ReadToEnd();

            p.writeSuccess();
            p.outputStream.WriteLine("<html><body><h1>test server</h1>");
            p.outputStream.WriteLine("<a href=/test>return</a><p>");
            p.outputStream.WriteLine("postbody: <pre>{0}</pre>", data);
            
        }


    }

}
