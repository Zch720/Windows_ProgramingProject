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

        public ShapeData(Shape shape)
        {
            ShapeName = shape.Name;
            Information = shape.Info;
        }
    }
}
