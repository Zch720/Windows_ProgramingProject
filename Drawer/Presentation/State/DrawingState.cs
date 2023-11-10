using Drawer.ShapeObjects;
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
            get => _shapeType;
        }

        public DrawingState(DrawerModel model, ShapeType shapeType, Action AfterMouseUp)
        {
            _model = model;
            _shapeType = shapeType;
            _isMouseDown = false;
            _triggerAfterMouseUp = AfterMouseUp;
        }

        public void OnMouseDown(int xCoordinate, int yCoordinate)
        {
            _isMouseDown = true;
            _model.CreateTempShape(_shapeType, xCoordinate, yCoordinate);
        }

        public void OnMouseMove(int xCoordinate, int yCoordinate)
        {
            if (!_isMouseDown)
                return;
            _model.UpdateTempShape(xCoordinate, yCoordinate);
        }

        public void OnMouseUp(int xCoordinate, int yCoordinate)
        {
            if (!_isMouseDown)
                return;
            _model.UpdateTempShape(xCoordinate, yCoordinate);
            _model.SaveTempShape();
            _triggerAfterMouseUp();
        }
    }
}
