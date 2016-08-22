using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace imi_cnc_logger.log_comp
{
    public struct CNCPosition : IEquatable<CNCPosition>
    {
        public int _x, _y, _z;

        public bool Equals(CNCPosition other)
        {
            if (other._x != this._x) return false;
            if (other._y != this._y) return false;
            if (other._z != this._z) return false;
            return true;
        }
    }
}
