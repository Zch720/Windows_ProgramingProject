namespace Drawer.Model.State
{
    public interface IState
    {

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
