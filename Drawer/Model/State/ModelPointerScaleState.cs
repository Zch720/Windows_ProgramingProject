using Drawer.Model.ShapeObjects;

namespace Drawer.Model.State
{
    public class ModelPointerScaleState : IState
    {
        private DrawerModel _model;
        private ScalePoint _scalePoint;
        private Point _selectPoint;
        private ShapeData _originScaledShape;

        public ScalePoint? CurrentScalePoint
        {
            get
            {
                return _scalePoint;
            }
        }

        public ModelPointerScaleState(DrawerModel model)
        {
            _model = model;
        }

        public void SelectOrCreateShape(Point point)
        {
            _scalePoint = _model.Shapes.IsPointOnSelectedShape(point);
            _selectPoint = point;
            _model.Shapes.SetSelectedShapeScalePoint(_scalePoint);
            _originScaledShape = _model.Shapes.SelectedShapeData;
            _model.NotifyShapesListUpdated();
        }

        public void UpdateShape(Point point)
        {
            _model.Shapes.ScaleSelectedShape(point);
            _model.NotifyShapesListUpdated();
        }

        public void SaveShape(Point point)
        {
            int selectedIndex = _model.Shapes.SelectedShapeIndex;
            _model.Shapes.ScaleSelectedShape(point);
            _model.Shapes.SaveScaledShape();
            if (!Point.Equal(point, _selectPoint))
                _model.CommandManager.ScaleShape(_model.Shapes.SelectedShapeIndex, _originScaledShape);
            _model.Shapes.SelectShapeAtIndex(selectedIndex);
            _model.NotifyShapesListUpdated();
            _model.SetPointerState();
        }
    }
}
