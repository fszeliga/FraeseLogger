using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace imi_cnc_logger.log_comp.data.data_types
{
    struct endschalter
    {
        private bool _x, _y, _z;
        public bool X
        {
            get
            {
                return _x;
            }
            set
            {
                _x = value;
            }
        }
        public bool Y
        {
            get
            {
                return _y;
            }
            set
            {
                _y = value;
            }
        }
        public bool Z
        {
            get
            {
                return _z;
            }
            set
            {
                _z = value;
            }
        }

        public endschalter(bool x = false, bool y = false, bool z = false)
        {
            _x = x;
            _y = y;
            _z = z;
        }

    }
}
