using Drawer;
using Drawer.Model;
using Drawer.Model.ShapeObjects;

namespace DrawerTests
{
    public class TestUtilities
    {
        public static void CreateShape(DrawerModel model, ShapeType type, Point point1, Point point2)
        {
            model.SetDrawingState(type);
            model.SelectOrCreateShape(point1);
            model.SaveShape(point2);
            model.SetPointerState();
        }
    }
}
