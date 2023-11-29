using Drawer.GraphicsAdapter;

namespace Drawer.Model.ShapeObjects
{
    public class Circle : Shape
    {
        const int HALF = 2;
        const string SHAPE_NAME = "圓";
        const string INFO_FORMAT = "{0}, {1}";

        public override ShapeType Type
        {
            get
            {
                return ShapeType.Circle;
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
                return string.Format(INFO_FORMAT, UpperLeft, LowerRight);
            }
        }

        public Circle() : base(new Point(0, 0), new Point(0, 0))
        {
        }

        public Circle(Point point1, Point point2) : base (point1, point2)
        {
        }

        /// <inheritdoc/>
        public override void Draw(IGraphics graphics)
        {
            graphics.DrawEllipse(UpperLeft, Width, Height);
            if (IsSelected)
                graphics.DrawSelectBox(UpperLeft, (int)Width, (int)Height);
        }
    }
}
