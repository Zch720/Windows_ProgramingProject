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
                return new Point((UpperLeft.X + LowerDown.X) / 2, (UpperLeft.Y + LowerDown.Y) / 2).ToString();
            }
        }
    }
}
