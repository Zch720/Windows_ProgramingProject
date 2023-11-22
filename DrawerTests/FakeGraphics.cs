using Drawer;
using Drawer.GraphicsAdapter;
using System.Collections.Generic;

namespace DrawerTests
{
    class FakeGraphics : IGraphics
    {
        public struct PointPair
        {
            public Point Point1
            {
                get;
            }
            public Point Point2
            {
                get;
            }

            public PointPair(Point point1, Point point2)
            {
                Point1 = point1;
                Point2 = point2;
            }
        }

        private int _notifyDrawLineCount;
        private int _notifyDrawRectangleCount;
        private int _notifyDrawCircleCount;
        private int _notifyDrawSelectBoxCount;
        private List<PointPair> _lineDrawHistories;
        private List<PointPair> _rectangleDrawHistories;
        private List<PointPair> _circleDrawHistories;
        private List<PointPair> _selectBoxDrawHistories;

        public FakeGraphics()
        {
            _lineDrawHistories = new List<PointPair>();
            _rectangleDrawHistories = new List<PointPair>();
            _circleDrawHistories = new List<PointPair>();
            _selectBoxDrawHistories = new List<PointPair>();
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

        public List<PointPair> LineDrawHistories
        {
            get
            {
                return _lineDrawHistories;
            }
        }

        public List<PointPair> RectangleDrawHistories
        {
            get
            {
                return _rectangleDrawHistories;
            }
        }

        public List<PointPair> CircleDrawHistories
        {
            get
            {
                return _circleDrawHistories;
            }
        }

        public List<PointPair> SelectBoxDrawHistories
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
            _lineDrawHistories.Add(new PointPair(point1, point2));
        }

        /// <inheritdoc/>
        public void DrawRectangle(Point point, float width, float height)
        {
            _notifyDrawRectangleCount++;
            Point point2 = Point.Add(point, new Point((int)width, (int)height));
            _rectangleDrawHistories.Add(new PointPair(point, point2));
        }

        /// <inheritdoc/>
        public void DrawEllipse(Point point, float width, float height)
        {
            _notifyDrawCircleCount++;
            Point point2 = Point.Add(point, new Point((int)width, (int)height));
            _circleDrawHistories.Add(new PointPair(point, point2));
        }

        /// <inheritdoc/>
        public void DrawSelectBox(Point upperLeft, int width, int height)
        {
            _notifyDrawSelectBoxCount++;
            Point point2 = Point.Add(upperLeft, new Point((int)width, (int)height));
            _selectBoxDrawHistories.Add(new PointPair(upperLeft, point2));
        }
    }
}
