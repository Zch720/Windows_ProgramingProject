using Drawer.Model.ShapeObjects;

namespace Drawer.Model.State
{
    public class ModelPointerScaleState : IState
    {
        private DrawerModel _model;
        private Point _selectPoint;
        private ShapeData _originScaledShape;

        public ScalePoint? CurrentScalePoint
        {
            get
            {
                return ScalePoint.None;
            }
        }

        public ModelPointerScaleState(DrawerModel model)
        {
            _model = model;
        }

        /// <inheritdoc/>
        public void SelectOrCreateShape(Point point)
        {
            _selectPoint = point;
            _model.CurrentShapes.SetSelectedShapeScalePoint(point);
            _originScaledShape = _model.CurrentShapes.SelectedShapeData;
            _model.NotifyShapesListUpdated();
        }

        /// <inheritdoc/>
        public void UpdateShape(Point point)
        {
            _model.CurrentShapes.ScaleSelectedShape(point);
            _model.NotifyShapesListUpdated();
        }

        /// <inheritdoc/>
        public void SaveShape(Point point)
        {
            _model.CurrentShapes.ScaleSelectedShape(point);
            _model.CurrentShapes.SaveScaledShape();
            if (!Point.Equal(point, _selectPoint))
                _model.CommandManager.ScaleShape(_model.CurrentShapes.SelectedShapeIndex, _originScaledShape);
            _model.NotifyShapesListUpdated();
            _model.SetPointerState();
        }
    }
}
