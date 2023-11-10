using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drawer
{
    public interface IGraphics
    {
        /// <summary>
        /// Clear graphics.
        /// </summary>
        void ClearAll();

        /// <summary>
        /// Draw new line.
        /// </summary>
        /// <param name="point1">Point 1 of the line.</param>
        /// <param name="point2">Point 2 of the line.</param>
        void DrawLine(Point point1, Point point2);

        /// <summary>
        /// Draw new Rectangle.
        /// </summary>
        /// <param name="point">The upper left corner of the rectangle.</param>
        /// <param name="width">The width of the rectangle.</param>
        /// <param name="height">The height of the rectangle.</param>
        void DrawRectangle(Point point, float width, float height);

        /// <summary>
        /// Draw new Ellipse.
        /// </summary>
        /// <param name="point">The upper left corner of the ellipse.</param>
        /// <param name="width">The width of the ellipse.</param>
        /// <param name="height">The height of the ellipse.</param>
        void DrawEllipse(Point point, float width, float height);

        void DrawSelectBox(Point upperLeft, Point lowerRight);
    }
}
