using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drawer
{
    public interface IGraphics
    {
        void ClearAll();
        void DrawLine(Point point1, Point point2);
        void DrawRectangle(Point point, float width, float height);
        void DrawEllipse(Point point, float width, float height);
    }
}
