using Drawer.Model.ShapeObjects;

namespace Drawer.Model.Command
{
    public class ScaleCommand : ICommand
    {
        DrawerModel _model;
        ShapeData _originShape;
        ShapeData _shapeData;
        int _index;
        int _currentShapesIndex;

        public ScaleCommand(DrawerModel model, int index, ShapeData originShape)
        {
            _model = model;
            _originShape = originShape;
            _shapeData = _model.CurrentShapes.ShapeDatas[index];
            _index = index;
            _currentShapesIndex = _model.SelectedPage;
        }

        /// <inheritdoc/>
        public void Execute()
        {
            _model.SelectedPage = _currentShapesIndex;
            _model.CurrentShapes.SetShapeAtIndex(_index, _shapeData);
        }

        /// <inheritdoc/>
        public void CancelExecute()
        {
            _model.SelectedPage = _currentShapesIndex;
            _model.CurrentShapes.SetShapeAtIndex(_index, _originShape);
        }
    }
}
