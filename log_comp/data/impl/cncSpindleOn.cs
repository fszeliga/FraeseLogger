using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace imi_cnc_logger.log_comp.data.impl
{
    class cncSpindleOn : CNCDataGenericBase<bool>
    {
 
        internal override string Description
        {
            get
            {
                return "asd";
            }
        }

        internal override string Key
        {
            get
            {
                return "spindleOn";
            }
        }

        internal override string Name
        {
            get
            {
                return "asd";
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
        }

        public override bool read()
        {
            Value = myConn.IsSpindleOn();
            return true;
        }
    }
}
