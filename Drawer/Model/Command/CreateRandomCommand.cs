using Drawer.Model.ShapeObjects;
using System.Linq;

namespace Drawer.Model.Command
{
    public class CreateRandomCommand : ICommand
    {
        private Shapes _shapes;
        private string _shapeType;
        private Point _drawArea;
        private ShapeData _shapeData;

        public CreateRandomCommand(Shapes shapes, string shapeType, Point drawArea)
        {
            _shapes = shapes;
            _shapeType = shapeType;
            _drawArea = drawArea;
            _shapeData = null;
        }

        /// <inheritdoc/>
        public void Execute()
        {
            if (_shapeData == null)
            {
                _shapes.CreateRandomShape(_shapeType, _drawArea);
                _shapeData = _shapes.ShapeDatas.Last();
            }
            else
            {
                _shapes.CreateFromData(_shapeData);
            }
        }

        /// <inheritdoc/>
        public void CancelExecute()
        {
            _shapes.DeleteLastShape();
        }
    }
}
