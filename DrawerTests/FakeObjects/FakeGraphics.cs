using Drawer;
using Drawer.GraphicsAdapter;
using System.Collections.Generic;

namespace DrawerTests
{
    class FakeGraphics : IGraphics
    {
        private int _notifyDrawLineCount;
        private int _notifyDrawRectangleCount;
        private int _notifyDrawCircleCount;
        private int _notifyDrawSelectBoxCount;
        private List<string> _lineDrawHistories;
        private List<string> _selectBoxDrawHistories;

        public FakeGraphics()
        {
            _lineDrawHistories = new List<string>();
            _selectBoxDrawHistories = new List<string>();
        }

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

        public List<string> LineDrawHistories
        {
            get
            {
                return _lineDrawHistories;
            }
        }

        public List<string> SelectBoxDrawHistories
        {
            get
            {
                return _selectBoxDrawHistories;
            }
        }

        /// <inheritdoc/>
        public void ClearAll()
        {
            _notifyDrawLineCount = 0;
            _notifyDrawRectangleCount = 0;
            _notifyDrawCircleCount = 0;
            _notifyDrawSelectBoxCount = 0;
        }

        /// <inheritdoc/>
        public void DrawLine(Point point1, Point point2)
        {
            _notifyDrawLineCount++;
            _lineDrawHistories.Add(point1.ToString() + ", " + point2.ToString());
        }

        /// <inheritdoc/>
        public void DrawRectangle(Point point, float width, float height)
        {
            _notifyDrawRectangleCount++;
            Point point2 = Point.Add(point, new Point((int)width, (int)height));
        }

        /// <inheritdoc/>
        public void DrawEllipse(Point point, float width, float height)
        {
            _notifyDrawCircleCount++;
            Point point2 = Point.Add(point, new Point((int)width, (int)height));
        }

        /// <inheritdoc/>
        public void DrawSelectBox(Point upperLeft, int width, int height)
        {
            _notifyDrawSelectBoxCount++;
            Point point2 = Point.Add(upperLeft, new Point((int)width, (int)height));
            _selectBoxDrawHistories.Add(upperLeft.ToString() + ", " + point2.ToString());
        }
    }
}
