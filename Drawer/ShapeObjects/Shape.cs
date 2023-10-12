using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drawer.ShapeObjects
{
    public abstract class Shape
    {

        abstract public string Name
        {
            get;
        }

        public string Info
        {
            get
            {
                return $"{UpperLeft}, {LowerDown}";
            }
        }

        public Point UpperLeft
        {
            get;
            set;
        }

        public Point LowerDown
        {
            get;
            set;
        }
    }
}
