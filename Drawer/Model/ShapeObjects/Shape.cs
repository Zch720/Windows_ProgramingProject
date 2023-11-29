using Drawer.GraphicsAdapter;
using System;

namespace Drawer.Model.ShapeObjects
{
    public abstract class Shape
    {
        protected Point _point1;
        protected Point _point2;

        abstract public ShapeType Type
        {
            get;
        }

        abstract public string Name
        {
            get;
        }

        abstract public string Info
        {
            get;
        }

        virtual public Point Point1
        {
            get
            {
                return _point1;
            }
            //set;
        }

        public Point Point2
        {
            get
            {
                return _point2;
            }
            //set;
        }

        public Point UpperLeft
        {
            get
            {
                return new Point(Math.Min(Point1.X, Point2.X), Math.Min(Point1.Y, Point2.Y));
            }
        }

        public Point UpperRight
        {
            get
            {
                return new Point(Math.Max(_point1.X, _point2.X), Math.Min(_point1.Y, _point2.Y));
            }
        }

        public Point LowerLeft
        {
            get
            {
                return new Point(Math.Min(_point1.X, _point2.X), Math.Max(_point1.Y, _point2.Y));
            }
        }

        public Point LowerRight
        {
            get
            {
                return new Point(Math.Max(Point1.X, Point2.X), Math.Max(Point1.Y, Point2.Y));
            }
        }

        public float Width
        {
            get
            {
                return LowerRight.X - UpperLeft.X;
            }
        }

        public float Height
        {
            get
            {
                return LowerRight.Y - UpperLeft.Y;
            }
        }

        public bool IsSelected
        {
            get;
            set;
        }

        public ScalePoint SelectedScalePoint
        {
            get;
            set;
        }

        public Shape(Point point1, Point point2)
        {
            _point1 = new Point(point1);
            _point2 = new Point(point2);
            SelectedScalePoint = ScalePoint.None;
        }

        /// <summary>
        /// Draw shape.
        /// </summary>
        /// <param name="graphics">The Graphics of draw area.</param>
        abstract public void Draw(IGraphics graphics);

        /// <summary>
        /// Move the shape.
        /// </summary>
        /// <param name="distance">The move distance.</param>
        public void Move(Point distance)
        {
            _point1 = Point.Add(Point1, distance);
            _point2 = Point.Add(Point2, distance);
        }

        /// <summary>
        /// Scale the shape by update selected scale point to the position of point.
        /// </summary>
        /// <param name="point">The position that scale point will set.</param>
        public virtual void Scale(Point point)
        {
            if (SelectedScalePoint == ScalePoint.LowerLeft)
                LowerLeftScale(point);
            else if (SelectedScalePoint == ScalePoint.LowerRight)
                LowerRightScale(point);
            else if (SelectedScalePoint == ScalePoint.UpperLeft)
                UpperLeftScale(point);
            else
                UpperRightScale(point);

            ReviseSelectedScalePoint();
        }

        /// <summary>
        /// Set the points when scale point is UpperLeft.
        /// </summary>
        /// <param name="point">The position that scale point will set.</param>
        protected void UpperLeftScale(Point point)
        {
            _point1 = LowerRight;
            _point2 = point;
        }

        /// <summary>
        /// Set the points when scale point is UpperRight.
        /// </summary>
        /// <param name="point">The position that scale point will set.</param>
        protected void UpperRightScale(Point point)
        {
            _point1 = LowerLeft;
            _point2 = point;
        }

        /// <summary>
        /// Set the points when scale point is LowerLeft.
        /// </summary>
        /// <param name="point">The position that scale point will set.</param>
        protected void LowerLeftScale(Point point)
        {
            _point1 = UpperRight;
            _point2 = point;
        }

        /// <summary>
        /// Set the points when scale point is LowerRight.
        /// </summary>
        /// <param name="point">The position that scale point will set.</param>
        protected void LowerRightScale(Point point)
        {
            _point1 = UpperLeft;
            _point2 = point;
        }

        /// <summary>
        /// Revise selected scale point after scaled the shape.
        /// </summary>
        protected void ReviseSelectedScalePoint()
        {
            if (Point.Equal(_point1, LowerLeft))
                SelectedScalePoint = ScalePoint.UpperRight;
            else if (Point.Equal(_point1, LowerRight))
                SelectedScalePoint = ScalePoint.UpperLeft;
            else if (Point.Equal(_point1, UpperLeft))
                SelectedScalePoint = ScalePoint.LowerRight;
            else
                SelectedScalePoint = ScalePoint.LowerLeft;
        }
    }
}
