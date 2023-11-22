using Drawer;
using Drawer.Model;
using Drawer.Model.ShapeObjects;

namespace DrawerTests
{
    public class TestUtilities
    {
        public static void CreateShape(DrawerModel model, ShapeType type, Point point1, Point point2)
        {
            model.CreateTempShape(type, point1);
            model.UpdateTempShape(point2);
            model.SaveTempShape();
        }
    }
}
