using Drawer.Model;
using Drawer.Model.ShapeObjects;
using System;

namespace Drawer.Presentation.State
{
    public class DrawingState : IState
    {
        private DrawerModel _model;
        private ShapeType _shapeType;
        private bool _isMouseDown;
        private Action _triggerAfterMouseUp;

        public ShapeType SelectedShapeType
        {
            get
            {
                return _shapeType;
            }
        }

        public DrawingState(DrawerModel model, ShapeType shapeType, Action afterMouseUp)
        {
            _model = model;
            _shapeType = shapeType;
            _isMouseDown = false;
            _triggerAfterMouseUp = afterMouseUp;
        }

        /// <inheritdoc/>
        public void HandleMouseDown(int xCoordinate, int yCoordinate)
        {
            _isMouseDown = true;
            _model.CreateTempShape(_shapeType, new Point(xCoordinate, yCoordinate));
        }

        /// <inheritdoc/>
        public void HandleMouseMove(int xCoordinate, int yCoordinate)
        {
            if (!_isMouseDown)
                return;
            _model.UpdateTempShape(new Point(xCoordinate, yCoordinate));
        }

        /// <inheritdoc/>
        public void HandleMouseUp(int xCoordinate, int yCoordinate)
        {
            if (!_isMouseDown)
                return;
            _model.UpdateTempShape(new Point(xCoordinate, yCoordinate));
            _model.SaveTempShape();
            _triggerAfterMouseUp();
        }
    }
}
