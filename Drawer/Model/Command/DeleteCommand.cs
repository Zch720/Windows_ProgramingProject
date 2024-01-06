using Drawer.Model.ShapeObjects;

namespace Drawer.Model.Command
{
    public class DeleteCommand : ICommand
    {
        DrawerModel _model;
        ShapeData _shapeData;
        int _deleteIndex;
        int _currentShapesIndex;

        public DeleteCommand(DrawerModel model, int deleteIndex)
        {
            _model = model;
            _shapeData = null;
            _deleteIndex = deleteIndex;
            _currentShapesIndex = _model.SelectedPage;
        }

        /// <inheritdoc/>
        public void Execute()
        {
            if (_shapeData == null)
            {
                // move to constructor
                _shapeData = _model.CurrentShapes.ShapeDatas[_deleteIndex];
            }
            _model.SelectedPage = _currentShapesIndex;
            _model.CurrentShapes.DeleteShape(_deleteIndex);
        }

        /// <inheritdoc/>
        public void CancelExecute()
        {
            _model.SelectedPage = _currentShapesIndex;
            _model.CurrentShapes.InsertShapeFromData(_shapeData, _deleteIndex);
        }
    }
}
