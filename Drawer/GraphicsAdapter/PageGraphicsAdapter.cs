using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drawer.GraphicsAdapter
{
    class PageGraphicsAdapter : IGraphics
    {
        private Graphics _graphics;
        private float _scale;

        public PageGraphicsAdapter(Graphics graphics, float scale)
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
        }
    }
}
