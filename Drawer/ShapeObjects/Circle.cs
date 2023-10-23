using System;
using System.Collections.Generic;
using System.Drawing;
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
                return $"{UpperLeft}, {LowerRight}";
            }
        }

        /// <inheritdoc/>
        public override void Draw(IGraphics graphics)
        {
            graphics.DrawEllipse(UpperLeft, Width, Height);
        }
    }
}
