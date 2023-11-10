using Drawer.ShapeObjects;

namespace Drawer.Presentation.State
{
    public interface IState
    {
        ShapeType SelectedShapeType
        {
            get;
        }

        void OnMouseDown(int xCoordinate, int yCoordinate);
        void OnMouseMove(int xCoordinate, int yCoordinate);
        void OnMouseUp(int xCoordinate, int yCoordinate);
    }
}
