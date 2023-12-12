using Drawer.Model.ShapeObjects;

namespace Drawer.Model.Command
{
    public class ScaleCommand : ICommand
    {
        Shapes _shapes;
        ShapeData _originShape;
        ShapeData _shapeData;
        int _index;

        public ScaleCommand(Shapes shapes, int index, ShapeData originShape)
        {
            _shapes = shapes;
            _originShape = originShape;
            _shapeData = _shapes.ShapeDatas[index];
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
