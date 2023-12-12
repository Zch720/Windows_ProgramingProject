using Drawer.Model.ShapeObjects;

namespace Drawer.Model.Command
{
    public class DeleteCommand : ICommand
    {
        Shapes _shapes;
        ShapeData _shapeData;
        int _deleteIndex;

        public DeleteCommand(Shapes shapes, int deleteIndex)
        {
            _shapes = shapes;
            _shapeData = null;
            _deleteIndex = deleteIndex;
        }

        /// <inheritdoc/>
        public void Execute()
        {
            if (_shapeData == null)
            {
                _shapeData = _shapes.ShapeDatas[_deleteIndex];
            }
            _shapes.DeleteShape(_deleteIndex);
        }

        /// <inheritdoc/>
        public void CancelExecute()
        {
            _shapes.InsertShapeFromData(_shapeData, _deleteIndex);
        }
    }
}
