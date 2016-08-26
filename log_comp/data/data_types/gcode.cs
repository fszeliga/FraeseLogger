using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace imi_cnc_logger.log_comp.data.data_types
{
    struct gcode
    {
        int _line;
        String _code;
        public int Line
        {
            get
            {
                return _line;
            }
        }

        public String Code
        {
            get
            {
                return _code;
            }
        }

        public gcode(int l, String c)
        {
            _line = l;
            _code = c;
        }
    }
}
