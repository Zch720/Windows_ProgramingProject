using Drawer.Model.ShapeObjects;
using Drawer.Presentation.State;

namespace DrawerTests
{
    public class FakeState : IState
    {
        private int _notifyMouseDownCount;
        private int _notifyMouseMoveCount;
        private int _notifyMouseUpCount;

        public int NotifyMouseDownCount
        {
            get
            {
                return _notifyMouseDownCount;
            }
        }

        public int NotifyMouseMoveCount
        {
            get
            {
                return _notifyMouseMoveCount;
            }
        }

        public int NotifyMouseUpCount
        {
            get
            {
                return _notifyMouseUpCount;
            }
        }

        public FakeState()
        {
            _notifyMouseDownCount = 0;
            _notifyMouseMoveCount = 0;
            _notifyMouseUpCount = 0;
        }

        public ShapeType SelectedShapeType => throw new System.NotImplementedException();

        public void HandleMouseDown(int xCoordinate, int yCoordinate)
        {
            _notifyMouseDownCount++;
        }

        public void HandleMouseMove(int xCoordinate, int yCoordinate)
        {
            _notifyMouseMoveCount++;
        }

        public void HandleMouseUp(int xCoordinate, int yCoordinate)
        {
            _notifyMouseUpCount++;
        }
    }
}
