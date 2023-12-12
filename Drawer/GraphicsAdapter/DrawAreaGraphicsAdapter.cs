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

        private float _scale;

        private Graphics _graphics 
        {
            get;
        }

        public DrawAreaGraphicsAdapter(Graphics graphics, float scale)
        {
            _graphics = graphics;
            _scale = scale;
        }

        /// <inheritdoc/>
        public void ClearAll()
        {
        }

        /// <inheritdoc/>
        public void DrawLine(Point point1, Point point2)
        {
            _graphics.DrawLine(Pens.Black, point1.X * _scale, point1.Y * _scale, point2.X * _scale, point2.Y * _scale);
        }

        /// <inheritdoc/>
        public void DrawRectangle(Point point, float width, float height)
        {
            _graphics.DrawRectangle(Pens.Black, point.X * _scale, point.Y * _scale, width * _scale, height * _scale);
        }

        /// <inheritdoc/>
        public void DrawEllipse(Point point, float width, float height)
        {
            _graphics.DrawEllipse(Pens.Black, point.X * _scale, point.Y * _scale, width * _scale, height * _scale);
        }

        /// <inheritdoc/>
        public void DrawSelectBox(Point upperLeft, int width, int height)
        {
            Point dotRadiusOffset = new Point(SELECTED_BOX_DOT_RADIUS);
            _graphics.DrawRectangle(Pens.Red, upperLeft.X * _scale, upperLeft.Y * _scale, width * _scale, height * _scale);
            DrawSelectBoxDot(upperLeft);
            DrawSelectBoxDot(Point.Add(upperLeft, new Point(width / HALF, 0)));
            DrawSelectBoxDot(Point.Add(upperLeft, new Point(width, 0)));
            DrawSelectBoxDot(Point.Add(upperLeft, new Point(0, height / HALF)));
            DrawSelectBoxDot(Point.Add(upperLeft, new Point(width, height / HALF)));
            DrawSelectBoxDot(Point.Add(upperLeft, new Point(0, height)));
            DrawSelectBoxDot(Point.Add(upperLeft, new Point(width / HALF, height)));
            DrawSelectBoxDot(Point.Add(upperLeft, new Point(width, height)));
        }

        /// <summary>
        /// Draw dot of select box.
        /// </summary>
        private void DrawSelectBoxDot(Point point)
        {
            float xCoordinate = point.X * _scale - SELECTED_BOX_DOT_RADIUS;
            float yCoordinate = point.Y * _scale - SELECTED_BOX_DOT_RADIUS;
            _graphics.FillEllipse(Brushes.White, xCoordinate, yCoordinate, SELECTED_BOX_DOT_DIAMETER, SELECTED_BOX_DOT_DIAMETER);
            _graphics.DrawEllipse(Pens.Gray, xCoordinate, yCoordinate, SELECTED_BOX_DOT_DIAMETER, SELECTED_BOX_DOT_DIAMETER);
        }
    }
}
