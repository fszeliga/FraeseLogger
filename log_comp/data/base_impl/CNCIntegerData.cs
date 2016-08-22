using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace imi_cnc_logger.log_comp.data.base_impl
{
    class CNCIntegerData : CNCDataBase<int>
    {
        public CNCIntegerData(string n, string desc) : base(n, desc)
        {
        }

        public override string asString()
        {
            return Value.ToString();
        }

        public override void read()
        {
            throw new NotImplementedException();
        }
    }
}
