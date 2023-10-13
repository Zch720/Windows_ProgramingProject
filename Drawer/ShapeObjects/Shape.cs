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

        abstract public string Info
        {
            get;
        }

        public Point Point1
        {
            get;
            set;
        }

        public Point Point2
        {
            get;
            set;
        }
    }
}
