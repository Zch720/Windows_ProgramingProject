using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drawer
{
    class FormGraphicsAdapter : IGraphics
    {
        private Graphics _graphics { get; }

        public FormGraphicsAdapter(Graphics graphics)
        {
            _graphics = graphics;
        }

        public void ClearAll()
        {
        }

        public void DrawLine(Point point1, Point point2)
        {
            _graphics.DrawLine(Pens.Black, point1.X, point1.Y, point2.X, point2.Y);
        }

        public void DrawRectangle(Point point, float width, float height)
        {
            _graphics.DrawRectangle(Pens.Black, point.X, point.Y, width, height);
        }

        public void DrawEllipse(Point point, float width, float height)
        {
            _graphics.DrawEllipse(Pens.Black, point.X, point.Y, width, height);
        }
    }
}
