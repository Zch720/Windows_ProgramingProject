using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drawer.ShapeObjects
{
    public class Circle : Shape
    {
        const int HALF = 2;
        const string SHAPE_NAME = "圓";

        public override ShapeType Type
        {
            get
            {
                return ShapeType.Circle;
            }
        }

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
                return new Point((Point1.X + Point2.X) / HALF, (Point1.Y + Point2.Y) / HALF).ToString();
            }
        }
    }
}
