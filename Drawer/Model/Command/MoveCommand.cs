using Drawer.Model.ShapeObjects;

namespace Drawer.Model.Command
{
    public class MoveCommand : ICommand
    {
        private Shapes _shapes;
        ShapeData _originShape;
        ShapeData _shapeData;
        private int _index;

        public MoveCommand(Shapes shapes, int index, ShapeData originShape)
        {
            _shapes = shapes;
            _originShape = originShape;
            _shapeData = shapes.ShapeDatas[index];
            _index = index;
        }

        /// <inheritdoc/>
        public void Execute()
        {
            _shapes.SetShapeAtIndex(_index, _shapeData);
        }

        /// <inheritdoc/>
        public void CancelExecute()
        {
            _shapes.SetShapeAtIndex(_index, _originShape);
        }
    }
}
