using Drawer.Model.ShapeObjects;
using System.Linq;

namespace Drawer.Model.Command
{
    public class CreateRandomCommand : ICommand
    {
        private DrawerModel _model;
        private string _shapeType;
        private Point _drawArea;
        private ShapeData _shapeData;
        private int _currentShapesIndex;

        public CreateRandomCommand(DrawerModel model, string shapeType, Point drawArea)
        {
            _model = model;
            _shapeType = shapeType;
            _drawArea = drawArea;
            _shapeData = null;
            _currentShapesIndex = _model.SelectedPage;
        }

        /// <inheritdoc/>
        public void Execute()
        {
            if (_shapeData == null)
            {
                _model.CurrentShapes.CreateRandomShape(_shapeType, _drawArea);
                _shapeData = _model.CurrentShapes.ShapeDatas.Last();
            }
            else
            {
                _model.SelectedPage = _currentShapesIndex;
                _model.CurrentShapes.CreateFromData(_shapeData);
            }
        }

        /// <inheritdoc/>
        public void CancelExecute()
        {
            _model.SelectedPage = _currentShapesIndex;
            _model.CurrentShapes.DeleteLastShape();
        }
    }
}
