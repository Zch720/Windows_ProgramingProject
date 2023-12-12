using Drawer.Model.ShapeObjects;

namespace Drawer.Model.Command
{
    public class CreateCommand : ICommand
    {
        Shapes _shapes;
        ShapeType _type;
        Point _point1;
        Point _point2;

        public CreateCommand(Shapes shapes, ShapeType type, Point point1, Point point2)
        {
            _shapes = shapes;
            _type = type;
            _point1 = point1;
            _point2 = point2;
        }

        public void Execute()
        {
            _shapes.CreateShape(_type, _point1, _point2);
        }

        public void Unexecute()
        {
            _shapes.DeleteShape(_shapes.ShapeDatas.Count - 1);
        }
    }
}
