using Drawer.ShapeObjects;

namespace Drawer.Presentation.State
{
    public class PointerState : IState
    {
        private DrawerModel _model;
        private Point _lastMousePoint;
        private bool _isMouseDown;

        public ShapeType SelectedShapeType
        {
            get => ShapeType.None;
        }

        public PointerState(DrawerModel model)
        {
            _model = model;
            _isMouseDown = false;
        }

        public void OnMouseDown(int xCoordinate, int yCoordinate)
        {
            _model.SelectedShapeAtPoint(xCoordinate, yCoordinate);
            _lastMousePoint = new Point(xCoordinate, yCoordinate);
            _isMouseDown = true;
        }

        public void OnMouseMove(int xCoordinate, int yCoordinate)
        {
            if (!_isMouseDown)
                return;
            _model.MoveSelectedShape(xCoordinate - _lastMousePoint.X, yCoordinate - _lastMousePoint.Y);
            _lastMousePoint = new Point(xCoordinate, yCoordinate);
        }

        public void OnMouseUp(int xCoordinate, int yCoordinate)
        {
            if (!_isMouseDown)
                return;
            _model.MoveSelectedShape(xCoordinate - _lastMousePoint.X, yCoordinate - _lastMousePoint.Y);
            _isMouseDown = false;
        }
    }
}
