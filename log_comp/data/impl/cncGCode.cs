using imi_cnc_logger.log_comp.data.data_types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace imi_cnc_logger.log_comp.data.impl
{
    class cncGCode : CNCDataGenericBase<gcode>
    {
        internal override string Description
        {
            get
            {
                return "Return current gcode and line";
            }
        }

        internal override string Key
        {
            get
            {
               return "gcode";
            }
        }

        internal override string Name
        {
            get
            {
                return "Gcode";
            }
        }

        public override string asString()
        {
            throw new NotImplementedException();
        }

        public override string getValue(string[] args)
        {
            if (args == null || args[0] == "all" || args[0] == "")
            {
                return "line:" + Value.Line.ToString() + ", code:" + Value.Code;
            }
            else if (args[0] == "line")
            {
                return Value.Line.ToString();
            }
            else if (args[0] == "code")
            {
                return Value.Code;
            }
            else
            {
                return "Parameters not accepted: args=" + args[0];
            }
        }

        public override void initialize()
        {
            Value = new gcode();
        }

        public override bool read()
        {
            Value = new gcode(myInfo.JobInfo.GCodeLine, myInfo.JobInfo.GCode);
            return true;
        }
    }
}
