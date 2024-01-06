using Drawer.Model.ShapeObjects;

namespace Drawer.Model.Command
{
    public class MoveCommand : ICommand
    {
        private DrawerModel _model;
        private ShapeData _originShape;
        private ShapeData _shapeData;
        private int _index;
        private int _currentShapesIndex;

        public MoveCommand(DrawerModel model, int index, ShapeData originShape)
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
