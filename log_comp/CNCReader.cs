﻿using De.Boenigk.SMC5D.Basics;
using De.Boenigk.Utility.CNC.Info;
using System;
using System.Collections.Generic;

namespace imi_cnc_logger.log_comp
{
    class CNCReader
    {
        private Connector conn = null;
        private MachInfo machInfo = null;

        public CNCReader(Connector c, MachInfo m)
        {
            this.conn = c;
            this.machInfo = m;
        }

        public Tuple<bool, LogEvent> getNewData(LogEvent lastData)
        {
            if (conn == null || machInfo == null) return new Tuple<bool, LogEvent>(false, null);
            //LoggerManager.THE().pushLog("[CNCRead] - id of last event: " + lastData.EventId );
            //set flag that it changed, so LoggerManager can add it (no duplicates if machine not moving)

            LogEvent e = new LogEvent(lastData.EventId + 1);

            foreach (KeyValuePair<string, data.CNCDataBase> entry in e.data)
            {
                if (!entry.Value._constant) entry.Value.read();
                //bool success = ;
            }

            //...check for changes
            

            Tuple<bool, LogEvent> newData = new Tuple<bool, LogEvent>(!e.Equals(lastData), e);
            
            return newData;
        }
    }
}
