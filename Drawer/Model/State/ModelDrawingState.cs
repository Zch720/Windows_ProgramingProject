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
            NotifyShapeSelectedOrCreated();
        }

        /// <inheritdoc/>
        public void UpdateShape(Point point)
        {
            if (!_shapeCreated)
                return;
            _shapes.UpdateTempShape(point);
            NotifyShapeUpdated();
        }

        /// <inheritdoc/>
        public void SaveShape(Point point)
        {
            if (!_shapeCreated)
                return;
            _shapes.UpdateTempShape(point);
            _shapes.SaveTempShape();
            _shapeCreated = false;
            NotifyShapeSaved();
        }

        /// <summary>
        /// invoke shape selected or created event handler.
        /// </summary>
        private void NotifyShapeSelectedOrCreated()
        {
            if (_shapeSelectedOrCreated != null)
                _shapeSelectedOrCreated();
        }

        /// <summary>
        /// invoke shape updated event handler.
        /// </summary>
        private void NotifyShapeUpdated()
        {
            if (_shapeUpdated != null)
                _shapeUpdated();
        }

        /// <summary>
        /// invoke shape saved event handler.
        /// </summary>
        private void NotifyShapeSaved()
        {
            if (_shapeSaved != null)
                _shapeSaved();
        }
    }
}
