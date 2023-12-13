using Drawer.Model.ShapeObjects;

namespace Drawer.Model.State
{
    public class ModelPointerMoveState : IState
    {
        private DrawerModel _model;
        private Shapes _shapes;
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

        public ModelPointerMoveState(DrawerModel model, Shapes shapes)
        {
            _model = model;
            _shapes = shapes;
        }

        /// <inheritdoc/>
        public void SelectOrCreateShape(Point point)
        {
            _selectPoint = point;
            _shapes.SelectedShapeAtPoint(point);
            _originShape = _shapes.SelectedShapeData;
            _previousPoint = point;
            _model.NotifyShapesListUpdated();
        }

        /// <inheritdoc/>
        public void UpdateShape(Point point)
        {
            if (_shapes.SelectedShapeIndex == -1)
                return;
            _shapes.MoveSelectedShape(Point.Subtract(point, _previousPoint));
            _previousPoint = point;
            _model.NotifyShapesListUpdated();
        }

        /// <inheritdoc/>
        public void SaveShape(Point point)
        {
            if (_shapes.SelectedShapeIndex == -1)
                return;
            _shapes.MoveSelectedShape(Point.Subtract(point, _previousPoint));
            _model.NotifyShapesListUpdated();
            if (!Point.Equal(point, _selectPoint))
                _model.CommandManager.MoveShape(_shapes.SelectedShapeIndex, _originShape);
            _model.SetPointerState();
        }
    }
}
