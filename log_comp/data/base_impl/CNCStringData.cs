using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace imi_cnc_logger.log_comp.data.base_impl
{
    class CNCStringData : CNCDataBase<string>
    {
        public CNCStringData(string n, string desc) : base(n, desc)
        {
        }

        public override string asString()
        {
            return Value;
        }

        public override void read()
        {
            throw new NotImplementedException();
        }
    }
}
