using Drawer.GraphicsAdapter;

namespace Drawer.Model.ShapeObjects
{
    public class Rectangle : Shape
    {
        const string SHAPE_NAME = "矩形";
        const string INFO_FORMAT = "{0}, {1}";

        public override ShapeType Type
        {
            get
            {
                return ShapeType.Rectangle;
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

        public Rectangle(): base (new Point(0, 0), new Point(0, 0))
        {
        }

        public Rectangle(Point point1, Point point2): base(point1, point2)
        {
        }

        /// <inheritdoc/>
        public override void Draw(IGraphics graphics)
        {
            graphics.DrawRectangle(UpperLeft, Width, Height);
            if (IsSelected)
                graphics.DrawSelectBox(UpperLeft, (int)Width, (int)Height);
        }

        public void Scale(Point point)
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
    }
}
