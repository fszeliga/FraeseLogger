using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace imi_cnc_logger.log_comp.data.base_impl
{
    class cncPosition : CNCDataGenericBase<position>
    {
        public cncPosition(string n, string desc) : base(n, desc)
        {
        }
        
        public override string asString()
        {
            throw new NotImplementedException();
        }

        public override string getValue(string[] args)
        {
            throw new NotImplementedException();
        }

        public override bool read()
        {
            LoggerManager.THE().addLog("reading from custom position" + Name);
            return true;
        }
    }

    struct position
    {

    }
}
