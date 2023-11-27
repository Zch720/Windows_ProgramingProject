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

        void SelecteOrCreateShape(Point point);
        void UpdateShape(Point point);
        void SaveShape(Point point);
    }
}
