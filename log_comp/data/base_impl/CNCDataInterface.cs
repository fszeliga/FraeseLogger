using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace imi_cnc_logger.log_comp
{
    interface CNCDataInterface<T>
    {
        void read();
        string asString();
        T Value { get; set; }
    }
}
