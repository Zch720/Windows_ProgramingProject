using Drawer.Model;
using Drawer.Model.ShapeObjects;

namespace Drawer.Presentation.State
{
    public class PointerState : IState
    {
        private DrawerModel _model;
        private Point _lastMousePoint;
        private bool _isMouseDown;

        public ShapeType SelectedShapeType
        {
            get
            {
                return ShapeType.None;
            }
        }

        public PointerState(DrawerModel model)
        {
            _model = model;
            _isMouseDown = false;
        }

        /// <inheritdoc/>
        public void HandleMouseDown(int xCoordinate, int yCoordinate)
        {
            _lastMousePoint = new Point(xCoordinate, yCoordinate);
            _model.SelectedShapeAtPoint(_lastMousePoint);
            _isMouseDown = true;
        }

        /// <inheritdoc/>
        public void HandleMouseMove(int xCoordinate, int yCoordinate)
        {
            if (!_isMouseDown)
                return;
            MoveSelectedShape(new Point(xCoordinate, yCoordinate));
        }

        /// <inheritdoc/>
        public void HandleMouseUp(int xCoordinate, int yCoordinate)
        {
            if (!_isMouseDown)
                return;
            MoveSelectedShape(new Point(xCoordinate, yCoordinate));
            _isMouseDown = false;
        }

        /// <summary>
        /// Move selected shape by model.
        /// </summary>
        /// <param name="cursorPoint">The new cursor position.</param>
        private void MoveSelectedShape(Point cursorPoint)
        {
            _model.MoveSelectedShape(Point.Subtract(cursorPoint, _lastMousePoint));
            _lastMousePoint = cursorPoint;
        }
    }
}
