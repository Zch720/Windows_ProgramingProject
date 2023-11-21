using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drawer.GraphicsAdapter
{
    class DrawAreaGraphicsAdapter : IGraphics
    {
        private const int HALF = 2;
        private const int SELECTED_BOX_DOT_RADIUS = 3;
        private const int SELECTED_BOX_DOT_DIAMETER = 6;

        private Graphics _graphics 
        {
            get;
        }

        public DrawAreaGraphicsAdapter(Graphics graphics)
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
        public void DrawSelectBox(Point upperLeft, int width, int height)
        {
            Point dotRadiusOffset = new Point(SELECTED_BOX_DOT_RADIUS);
            _graphics.DrawRectangle(Pens.Red, upperLeft.X, upperLeft.Y, width, height);
            DrawSelectBoxDot(Point.Subtract(upperLeft, dotRadiusOffset));
            DrawSelectBoxDot(Point.Subtract(Point.Add(upperLeft, new Point(width / HALF, 0)), dotRadiusOffset));
            DrawSelectBoxDot(Point.Subtract(Point.Add(upperLeft, new Point(width, 0)), dotRadiusOffset));
            DrawSelectBoxDot(Point.Subtract(Point.Add(upperLeft, new Point(0, height / HALF)), dotRadiusOffset));
            DrawSelectBoxDot(Point.Subtract(Point.Add(upperLeft, new Point(width, height / HALF)), dotRadiusOffset));
            DrawSelectBoxDot(Point.Subtract(Point.Add(upperLeft, new Point(0, height)), dotRadiusOffset));
            DrawSelectBoxDot(Point.Subtract(Point.Add(upperLeft, new Point(width / HALF, height)), dotRadiusOffset));
            DrawSelectBoxDot(Point.Subtract(Point.Add(upperLeft, new Point(width, height)), dotRadiusOffset));
        }

        /// <summary>
        /// Draw dot of select box.
        /// </summary>
        private void DrawSelectBoxDot(Point upperLeft)
        {
            _graphics.FillEllipse(Brushes.White, upperLeft.X, upperLeft.Y, SELECTED_BOX_DOT_DIAMETER, SELECTED_BOX_DOT_DIAMETER);
            _graphics.DrawEllipse(Pens.Gray, upperLeft.X, upperLeft.Y, SELECTED_BOX_DOT_DIAMETER, SELECTED_BOX_DOT_DIAMETER);
        }
    }
}
