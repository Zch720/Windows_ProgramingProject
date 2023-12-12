using System.ComponentModel;

namespace Drawer.Model.ShapeObjects
{
    public class ShapeData
    {
        [DisplayName("形狀")]
        public string ShapeName
        {
            get;
        }
        [DisplayName("資訊")]
        public string Information
        {
            get;
        }

        [Browsable(false)]
        public bool IsSelected
        {
            get;
        }

        [Browsable(false)]
        public Point Point1
        {
            get;
        }

        [Browsable(false)]
        public Point Point2
        {
            get;
        }

        public ShapeData(Shape shape)
        {
            ShapeName = shape.Name;
            Information = shape.Info;
            IsSelected = shape.IsSelected;
            Point1 = shape.Point1;
            Point2 = shape.Point2;
        }
    }
}
