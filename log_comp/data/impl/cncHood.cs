using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace imi_cnc_logger.log_comp.data.impl
{
    class cncHood : CNCDataGenericBase<bool>
    {
 
        internal override string Description
        {
            get
            {
                return "true if hood open, false otherwise";
            }
        }

        internal override string Key
        {
            get
            {
                return "hoodOpen";
            }
        }

        internal override string Name
        {
            get
            {
                return "State of the CNC hood";
            }
        }

        public override string asString()
        {
            throw new NotImplementedException();
        }

        public override string getValue(string[] args)
        {
            return Value.ToString();
        }

        public override void initialize()
        {
            Value = false;
            LoggerManager.THE().addLog("called init in cncHood");
        }

        public override bool read()
        {
            Value = myConn.IsHoodOpen();
            return true;
        }
    }
}
