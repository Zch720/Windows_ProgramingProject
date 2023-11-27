using Drawer.Model.ShapeObjects;

namespace Drawer.Model.State
{
    public class ModelDrawingState : IState
    {
        public event ShapeSelectedOrCreatedEventHandler _shapeSelectedOrCreated;
        public event ShapeUpdatedEventHandler _shapeUpdated;
        public event ShapeSavedEventHandler _shapeSaved;

        private Shapes _shapes;
        private ShapeType _type;

        public ModelDrawingState(Shapes shapes, ShapeType type)
        {
            _shapes = shapes;
            _type = type;
        }

        public void SelecteOrCreateShape(Point point)
        {
            _shapes.CreateTempShape(_type, point);
            _shapeSelectedOrCreated?.Invoke();
        }

        public void UpdateShape(Point point)
        {
            _shapes.UpdateTempShape(point);
            _shapeUpdated?.Invoke();
        }

        public void SaveShape(Point point)
        {
            _shapes.UpdateTempShape(point);
            _shapes.SaveTempShape();
            _shapeSaved?.Invoke();
        }
    }
}
