using Drawer.Model.ShapeObjects;

namespace Drawer.Model.State
{
    public class ModelPointerMoveState : IState
    {
        private DrawerModel _model;
        private ShapeData _originShape;
        private Point _selectPoint;
        private Point _previousPoint;

        public ScalePoint? CurrentScalePoint
        {
            get
            {
                return ScalePoint.None;
            }
        }

        public ModelPointerMoveState(DrawerModel model)
        {
            _model = model;
        }

        /// <inheritdoc/>
        public void SelectOrCreateShape(Point point)
        {
            _selectPoint = point;
            _model.CurrentShapes.SelectedShapeAtPoint(point);
            _originShape = _model.CurrentShapes.SelectedShapeData;
            _previousPoint = point;
            _model.NotifyShapesListUpdated();
        }

        /// <inheritdoc/>
        public void UpdateShape(Point point)
        {
            if (_model.CurrentShapes.SelectedShapeIndex == -1)
                return;
            _model.CurrentShapes.MoveSelectedShape(Point.Subtract(point, _previousPoint));
            _previousPoint = point;
            _model.NotifyShapesListUpdated();
        }

        /// <inheritdoc/>
        public void SaveShape(Point point)
        {
            if (_model.CurrentShapes.SelectedShapeIndex == -1)
                return;
            _model.CurrentShapes.MoveSelectedShape(Point.Subtract(point, _previousPoint));
            _model.NotifyShapesListUpdated();
            if (!Point.Equal(point, _selectPoint))
                _model.CommandManager.MoveShape(_model.CurrentShapes.SelectedShapeIndex, _originShape);
            _model.SetPointerState();
        }
    }
}
