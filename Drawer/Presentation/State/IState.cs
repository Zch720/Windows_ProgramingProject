using Drawer.Model.ShapeObjects;

namespace Drawer.Presentation.State
{
    public interface IState
    {
        ShapeType SelectedShapeType
        {
            get;
        }

        /// <summary>
        /// Handle action mouse down.
        /// </summary>
        /// <param name="xCoordinate">The x coordinate of cursor.</param>
        /// <param name="yCoordinate">The y coordinate of cursor.</param>
        void HandleMouseDown(int xCoordinate, int yCoordinate);

        /// <summary>
        /// Handle action mouse move.
        /// </summary>
        /// <param name="xCoordinate">The x coordinate of cursor.</param>
        /// <param name="yCoordinate">The y coordinate of cursor.</param>
        void HandleMouseMove(int xCoordinate, int yCoordinate);

        /// <summary>
        /// Handle action mouse up.
        /// </summary>
        /// <param name="xCoordinate">The x coordinate of cursor.</param>
        /// <param name="yCoordinate">The y coordinate of cursor.</param>
        void HandleMouseUp(int xCoordinate, int yCoordinate);
    }
}
