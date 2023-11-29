namespace Drawer.Model.State
{
    public delegate void ShapeSelectedOrCreatedEventHandler();
    public delegate void ShapeUpdatedEventHandler();
    public delegate void ShapeSavedEventHandler();
    public interface IState
    {
        event ShapeSelectedOrCreatedEventHandler _shapeSelectedOrCreated;
        event ShapeUpdatedEventHandler _shapeUpdated;
        event ShapeSavedEventHandler _shapeSaved;

        ScalePoint? CurrentScalePoint
        {
            get;
        }

        /// <summary>
        /// Select a shape or create new shape.
        /// </summary>
        /// <param name="point">The shape user input.</param>
        void SelectOrCreateShape(Point point);

        /// <summary>
        /// Update the selected shape or creating shape.
        /// </summary>
        /// <param name="point">The shape user input.</param>
        void UpdateShape(Point point);

        /// <summary>
        /// Save the shape.
        /// </summary>
        /// <param name="point">The shape user input.</param>
        void SaveShape(Point point);
    }
}
