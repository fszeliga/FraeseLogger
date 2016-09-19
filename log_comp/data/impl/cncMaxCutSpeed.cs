using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace imi_cnc_logger.log_comp.data.impl
{
    class cncMaxCutSpeed : CNCDataGenericBase<uint>
    {
 
        internal override string Description
        {
            get
            {
                return "Maximum Cut speed of the CNC";
            }
        }

        internal override string Key
        {
            get
            {
                return "maxCutSpeed";
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
            Value = 0;
        }

        public override bool read()
        {
            Value = myConn.MaxSpeed;

            return true;
        }
    }
}
