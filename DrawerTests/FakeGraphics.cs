using Drawer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawerTests
{
    class FakeGraphics : IGraphics
    {
        private int _notifyDrawLineCount;
        private int _notifyDrawRectangleCount;
        private int _notifyDrawCircleCount;
        private int _notifyDrawSelectBoxCount;

        public int NotifyDrawLineCount
        {
            get
            {
                return _notifyDrawLineCount;
            }
        }

        public int NotifyDrawRectangleCount
        {
            get
            {
                return _notifyDrawRectangleCount;
            }
        }

        public int NotifyDrawCircleCount
        {
            get
            {
                return _notifyDrawCircleCount;
            }
        }

        public int NotifyDrawSelectBoxCount
        {
            get
            {
                return _notifyDrawSelectBoxCount;
            }
        }

        public void ClearAll()
        {
            _notifyDrawLineCount = 0;
            _notifyDrawRectangleCount = 0;
            _notifyDrawCircleCount = 0;
            _notifyDrawSelectBoxCount = 0;
        }

        public void DrawLine(Point point1, Point point2)
        {
            _notifyDrawLineCount++;
        }

        public void DrawRectangle(Point point, float width, float height)
        {
            _notifyDrawRectangleCount++;
        }

        public void DrawEllipse(Point point, float width, float height)
        {
            _notifyDrawCircleCount++;
        }

        public void DrawSelectBox(Point upperLeft, int width, int height)
        {
            _notifyDrawSelectBoxCount++;
        }
    }
}
