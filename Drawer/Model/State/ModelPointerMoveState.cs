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

        public void SelectOrCreateShape(Point point)
        {
            _selectPoint = point;
            _model.Shapes.SelectedShapeAtPoint(point);
            _originShape = _model.Shapes.SelectedShapeData;
            _previousPoint = point;
            _model.NotifyShapesListUpdated();
        }

        public void UpdateShape(Point point)
        {
            if (_model.Shapes.SelectedShapeIndex == -1)
                return;
            _model.Shapes.MoveSelectedShape(Point.Subtract(point, _previousPoint));
            _previousPoint = point;
            _model.NotifyShapesListUpdated();
        }

        public void SaveShape(Point point)
        {
            if (_model.Shapes.SelectedShapeIndex == -1)
                return;
            int selectedIndex = _model.Shapes.SelectedShapeIndex;
            _model.Shapes.MoveSelectedShape(Point.Subtract(point, _previousPoint));
            _model.NotifyShapesListUpdated();
            if (!Point.Equal(point, _selectPoint))
                _model.CommandManager.MoveShape(_model.Shapes.SelectedShapeIndex, _originShape);
            _model.Shapes.SelectShapeAtIndex(selectedIndex);
            _model.SetPointerState();
        }
    }
}
