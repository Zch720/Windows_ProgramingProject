using Drawer.Model.ShapeObjects;

namespace Drawer.Model.State
{
    public class ModelPointerScaleState : IState
    {
        private DrawerModel _model;
        private Shapes _shapes;
        private Point _selectPoint;
        private ShapeData _originScaledShape;

        public ScalePoint? CurrentScalePoint
        {
            get
            {
                return ScalePoint.None;
            }
        }

        public ModelPointerScaleState(DrawerModel model, Shapes shapes)
        {
            _model = model;
            _shapes = shapes;
        }

        /// <inheritdoc/>
        public void SelectOrCreateShape(Point point)
        {
            _selectPoint = point;
            _shapes.SetSelectedShapeScalePoint(point);
            _originScaledShape = _shapes.SelectedShapeData;
            _model.NotifyShapesListUpdated();
        }

        /// <inheritdoc/>
        public void UpdateShape(Point point)
        {
            _shapes.ScaleSelectedShape(point);
            _model.NotifyShapesListUpdated();
        }

        /// <inheritdoc/>
        public void SaveShape(Point point)
        {
            _shapes.ScaleSelectedShape(point);
            _shapes.SaveScaledShape();
            if (!Point.Equal(point, _selectPoint))
                _model.CommandManager.ScaleShape(_shapes.SelectedShapeIndex, _originScaledShape);
            _model.NotifyShapesListUpdated();
            _model.SetPointerState();
        }
    }
}
