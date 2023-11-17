using System;

namespace Drawer.Model.ShapeObjects
{
    public abstract class Shape
    {
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

        public Point Point1
        {
            get;
            set;
        }

        public Point Point2
        {
            get;
            set;
        }

        public Point UpperLeft
        {
            get
            {
                return new Point(Math.Min(Point1.X, Point2.X), Math.Min(Point1.Y, Point2.Y));
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

        public Shape()
        {
            Point1 = new Point(0, 0);
            Point2 = new Point(0, 0);
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
            Point1 = Point.Add(Point1, distance);
            Point2 = Point.Add(Point2, distance);
        }
    }
}
