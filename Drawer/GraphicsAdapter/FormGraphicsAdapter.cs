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
        private Graphics _graphics 
        {
            get;
        }

        public FormGraphicsAdapter(Graphics graphics)
        {
            _graphics = graphics;
        }

        /// <inheritdoc/>
        public void ClearAll()
        {
        }

        /// <inheritdoc/>
        public void DrawLine(Point point1, Point point2)
        {
            _graphics.DrawLine(Pens.Black, point1.X, point1.Y, point2.X, point2.Y);
        }

        /// <inheritdoc/>
        public void DrawRectangle(Point point, float width, float height)
        {
            _graphics.DrawRectangle(Pens.Black, point.X, point.Y, width, height);
        }

        /// <inheritdoc/>
        public void DrawEllipse(Point point, float width, float height)
        {
            _graphics.DrawEllipse(Pens.Black, point.X, point.Y, width, height);
        }

        /// <inheritdoc/>
        public void DrawSelectBox(Point upperLeft, Point lowerRight)
        {
            _graphics.DrawRectangle(Pens.Red, upperLeft.X, upperLeft.Y, lowerRight.X - upperLeft.X, lowerRight.Y - upperLeft.Y);
            _graphics.DrawEllipse(Pens.Gray, upperLeft.X - 3, upperLeft.Y - 3, 6, 6);
            _graphics.DrawEllipse(Pens.Gray, (upperLeft.X + lowerRight.X) / 2 - 3, upperLeft.Y - 3, 6, 6);
            _graphics.DrawEllipse(Pens.Gray, lowerRight.X - 3, upperLeft.Y - 3, 6, 6);
            _graphics.DrawEllipse(Pens.Gray, upperLeft.X - 3, (upperLeft.Y + lowerRight.Y) / 2 - 3, 6, 6);
            _graphics.DrawEllipse(Pens.Gray, lowerRight.X - 3, (upperLeft.Y + lowerRight.Y) / 2 - 3, 6, 6);
            _graphics.DrawEllipse(Pens.Gray, upperLeft.X - 3, lowerRight.Y - 3, 6, 6);
            _graphics.DrawEllipse(Pens.Gray, (upperLeft.X + lowerRight.X) / 2 - 3, lowerRight.Y - 3, 6, 6);
            _graphics.DrawEllipse(Pens.Gray, lowerRight.X - 3, lowerRight.Y - 3, 6, 6);
        }
    }
}
