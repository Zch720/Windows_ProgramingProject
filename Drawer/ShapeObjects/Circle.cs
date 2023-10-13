using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drawer.ShapeObjects
{
    public class Circle : Shape
    {
        const string SHAPE_NAME = "圓";

        public override string Name
        {
            get
            {
                return SHAPE_NAME;
            }
        }

        public override string Info
        {
            get
            {
                return new Point((Point1.X + Point2.X) / 2, (Point1.Y + Point2.Y) / 2).ToString();
            }
        }
    }
}
