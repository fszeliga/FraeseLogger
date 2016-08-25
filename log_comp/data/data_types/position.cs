using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace imi_cnc_logger.log_comp.data.data_types
{
    struct position
    {
        private double _x, _y, _z;

        public double X
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

        public double Y
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

        public double Z
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

        public position(double xx, double yy, double zz)
        {
            this._x = xx;
            this._y = yy;
            this._z = zz;
        }
    }
}
