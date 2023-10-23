using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drawer.ShapeObjects
{
    class Rectangle : Shape
    {
        const string SHAPE_NAME = "矩形";

        public override ShapeType Type
        {
            get
            {
                return ShapeType.Rectangle;
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
            graphics.DrawRectangle(UpperLeft, Width, Height);
        }
    }
}
