using Drawer.GraphicsAdapter;
using System;

namespace Drawer.Model.ShapeObjects
{
    public class Line : Shape
    {
        const string SHAPE_NAME = "線";
        const string INFO_FORMAT = "{0}, {1}";

        private enum Direction
        {
            Forward,
            Back
        }

        private Direction _direction;

        public override ShapeType Type
        {
            get
            {
                return ShapeType.Line;
            }
        }

        public override string Name
        {
            get
            {
                return SHAPE_NAME;
            }
        }

        public override string Info
        {
            get
            {
                return string.Format(INFO_FORMAT, Point1, Point2);
            }
        }

        public Line() : base(new Point(0, 0), new Point(0, 0))
        {
            _direction = Direction.Forward;
        }

        public Line(Point point1, Point point2) : base(point1, point2)
        {
            try
            {
                Point.LowerEqual(point1, point2);
                _direction = Direction.Forward;
            }
            catch
            {
                _direction = Direction.Back;
            }
        }

        /// <inheritdoc/>
        public override void Draw(IGraphics graphics)
        {
            graphics.DrawLine(Point1, Point2);
            if (IsSelected)
                graphics.DrawSelectBox(UpperLeft, (int)Width, (int)Height);
        }

        /// <inheritdoc/>
        public override void Scale(Point point)
        {
            ScalePoint oldScalePoint = SelectedScalePoint;
            base.Scale(point);
            ReviseDirection(oldScalePoint, SelectedScalePoint);
            ReviseLinePoint();
        }

        /// <summary>
        /// Check if the two scale point is on opposite side.
        /// </summary>
        private bool IsOppositeScalePoint(ScalePoint point1, ScalePoint point2)
        {
            return (point1 == ScalePoint.UpperLeft && point2 == ScalePoint.LowerRight) ||
                (point1 == ScalePoint.UpperRight && point2 == ScalePoint.LowerLeft) ||
                (point1 == ScalePoint.LowerLeft && point2 == ScalePoint.UpperRight) ||
                (point1 == ScalePoint.LowerRight && point2 == ScalePoint.UpperLeft);
        }

        /// <summary>
        /// Revised the line direction by compare two scale point;
        /// </summary>
        /// <param name="point1"></param>
        /// <param name="point2"></param>
        private void ReviseDirection(ScalePoint point1, ScalePoint point2)
        {
            if (point1 == point2 || IsOppositeScalePoint(point1, point2))
                return;
            ChangeDirection();
        }

        /// <summary>
        /// Change the line direction to opposite direction.
        /// </summary>
        private void ChangeDirection()
        {
            if (_direction == Direction.Forward)
                _direction = Direction.Back;
            else
                _direction = Direction.Forward;
        }

        /// <summary>
        /// Revise _point1 and _point2 by direction.
        /// </summary>
        private void ReviseLinePoint()
        {
            Point point1 = _point1;
            Point point2 = _point2;

            if (_direction == Direction.Forward)
            {
                _point1 = new Point(Math.Min(point1.X, point2.X), Math.Min(point1.Y, point2.Y));
                _point2 = new Point(Math.Max(point1.X, point2.X), Math.Max(point1.Y, point2.Y));
            }
            else
            {
                _point1 = new Point(Math.Min(point1.X, point2.X), Math.Max(point1.Y, point2.Y));
                _point2 = new Point(Math.Max(point1.X, point2.X), Math.Min(point1.Y, point2.Y));
            }
        }
    }
}
