using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace imi_cnc_logger.log_comp.data.impl
{
    class cncActiveProgramm : CNCDataGenericBase<string>
    {
 
        internal override string Description
        {
            get
            {
                return "Return currently prossessed file name";
            }
        }

        internal override string Key
        {
            get
            {
                return "activeProg";
            }
        }

        internal override string Name
        {
            get
            {
                return "Active CNC Programm Name";
            }
        }

        public override string asString()
        {
            throw new NotImplementedException();
        }

        public override string getValue(string[] args)
        {
            return Value;
        }

        public override void initialize()
        {
            Value = "";
        }

        public override bool read()
        {
            Value = myInfo.FileName;
            return true;
        }
    }
}
