using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drawer.ShapeObjects
{
    class Line : Shape
    {
        const string SHAPE_NAME = "線";

        public override ShapeType Type
        {
            get
            {
                return ShapeType.Line;
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
                return $"{Point1}, {Point2}";
            }
        }

        /// <inheritdoc/>
        public override void Draw(Graphics graphics)
        {
            graphics.DrawLine(Pens.Black, Point1.X, Point1.Y, Point2.X, Point2.Y);
        }
    }
}
