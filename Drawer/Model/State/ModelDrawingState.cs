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
        private bool _shapeCreated;

        public ScalePoint? CurrentScalePoint
        {
            get
            {
                return null;
            }
        }

        public ModelDrawingState(Shapes shapes, ShapeType type)
        {
            _shapes = shapes;
            _type = type;
            _shapeCreated = false;
        }

        /// <inheritdoc/>
        public void SelectOrCreateShape(Point point)
        {
            _shapes.CreateTempShape(_type, point);
            _shapeCreated = true;
            if (_shapeSelectedOrCreated != null)
                _shapeSelectedOrCreated();
        }

        /// <inheritdoc/>
        public void UpdateShape(Point point)
        {
            if (!_shapeCreated)
                return;
            _shapes.UpdateTempShape(point);
            if (_shapeUpdated != null)
                _shapeUpdated();
        }

        /// <inheritdoc/>
        public void SaveShape(Point point)
        {
            if (!_shapeCreated)
                return;
            _shapes.UpdateTempShape(point);
            _shapes.SaveTempShape();
            _shapeCreated = false;
            if (_shapeSaved != null)
                _shapeSaved();
        }
    }
}
