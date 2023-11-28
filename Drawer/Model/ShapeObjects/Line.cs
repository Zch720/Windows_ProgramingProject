using Drawer.GraphicsAdapter;

namespace Drawer.Model.ShapeObjects
{
    public class Line : Shape
    {
        const string SHAPE_NAME = "線";
        const string INFO_FORMAT = "{0}, {1}";

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
        }

        public Line(Point point1, Point point2) : base(point1, point2)
        {
        }

        /// <inheritdoc/>
        public override void Draw(IGraphics graphics)
        {
            graphics.DrawLine(Point1, Point2);
            if (IsSelected)
                graphics.DrawSelectBox(UpperLeft, (int)Width, (int)Height);
        }

        //public void Scale(Point point)
        //{
        //    Point1 = UpperLeft;
        //    Point2 = point;
        //}
    }
}
