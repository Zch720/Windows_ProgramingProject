using Drawer.Model.Command;
using Drawer.Model.ShapeObjects;

namespace Drawer.Model.State
{
    public class ModelDrawingState : IState
    {
        private DrawerModel _model;
        private Shapes _shapes;
        private ShapeType _type;
        private Point _createPoint;
        private bool _shapeCreated;

        public ScalePoint? CurrentScalePoint
        {
            get
            {
                return null;
            }
        }

        public ModelDrawingState(DrawerModel model, Shapes shapes, ShapeType type)
        {
            _model = model;
            _shapes = shapes;
            _type = type;
            _shapeCreated = false;
        }

        /// <inheritdoc/>
        public void SelectOrCreateShape(Point point)
        {
            _model.TempShape = _shapes.CreateTempShape(_type, point, point);
            _shapeCreated = true;
            _createPoint = point;
            _model.NotifyTempShapeUpdated();
        }

        /// <inheritdoc/>
        public void UpdateShape(Point point)
        {
            if (!_shapeCreated)
                return;
            _model.TempShape = _shapes.CreateTempShape(_type, _createPoint, point);
            _model.NotifyTempShapeUpdated();
        }

        /// <inheritdoc/>
        public void SaveShape(Point point)
        {
            if (!_shapeCreated)
                return;
            _model.TempShape = null;
            _shapeCreated = false;
            _model.CommandManager.CreateShape(_type, _createPoint, point);
            _model.NotifyTempShapeSaved();
            _model.NotifyShapesListUpdated();
        }
    }
}
