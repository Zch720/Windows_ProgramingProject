// Ignore Spelling: Datas

using Drawer.GraphicsAdapter;
using Drawer.Model.ShapeObjects;
using Drawer.Model.State;
using System.ComponentModel;

namespace Drawer.Model
{
    public class DrawerModel
    {
        public delegate void ShapesUpdatedEventHandler();
        public delegate void TempShapeUpdatedEventHandler();
        public delegate void TempShapeSavedEventHandler();

        public event ShapesUpdatedEventHandler _shapesListUpdated;
        public event TempShapeUpdatedEventHandler _tempShapeUpdated;
        public event TempShapeSavedEventHandler _tempShapeSaved;

        private IState _state;
        private Shapes _shapes;

        public BindingList<ShapeData> ShapeDatas
        {
            get
            {
                return _shapes.ShapeDatas;
            }
        }

        public DrawerModel(ShapeFactory shapeFactory)
        {
            _shapes = new Shapes(shapeFactory);
            SetPointerState();
        }

        public void SetPointerState()
        {
            _state = new ModelPointerState(_shapes);
            _state._shapeSelectedOrCreated += NotifyShapesListUpdated;
            _state._shapeUpdated += NotifyShapesListUpdated;
            _state._shapeSaved += NotifyShapesListUpdated;
        }

        public void SetDrawingState(ShapeType type)
        {
            _state = new ModelDrawingState(_shapes, type);
            _state._shapeSelectedOrCreated += NotifyTempShapeUpdated;
            _state._shapeUpdated += NotifyTempShapeUpdated;
            _state._shapeSaved += NotifyTempShapeSaved;
            _state._shapeSaved += NotifyShapesListUpdated;
        }

        /// <summary>
        /// Create a new random shape.
        /// </summary>
        /// <param name="shapeType">The shape type string.</param>
        /// <param name="lowerRight corner">The lower right corner of the area can create shape.</param>
        public void CreateRandomShape(string shapeType, Point lowerRightCorner)
        {
            _shapes.CreateRandomShape(shapeType, lowerRightCorner);
            NotifyShapesListUpdated();
        }

        /// <summary>
        /// Delete a shape from shape list by index.
        /// </summary>
        /// <param name="index">The shape need to delete.</param>
        public void DeleteShape(int index)
        {
            _shapes.DeleteShape(index);
            NotifyShapesListUpdated();
        }

        public void SelectOrCreateShape(Point point)
        {
            _state.SelecteOrCreateShape(point);
        }

        public void UpdateShape(Point point)
        {
            _state.UpdateShape(point);
        }

        public void SaveShape(Point point)
        {
            _state.SaveShape(point);
        }

        /// <summary>
        /// Draw all shapes and temp shape.
        /// </summary>
        /// <param name="graphics">Graphics of draw area.</param>
        public void DrawWithTemp(IGraphics graphics)
        {
            _shapes.DrawWithTemp(graphics);
        }

        /// <summary>
        /// Delete selected shape in shapes.
        /// </summary>
        public void DeleteSelectedShape()
        {
            _shapes.DeleteSelectedShape();
            NotifyShapesListUpdated();
        }

        /// <summary>
        /// Notify handlers of ShapesListUpdated to update.
        /// </summary>
        private void NotifyShapesListUpdated()
        {
            if (_shapesListUpdated != null)
                _shapesListUpdated();
        }

        /// <summary>
        /// Notify handlers of TempShapeUpdated to update.
        /// </summary>
        private void NotifyTempShapeUpdated()
        {
            if (_tempShapeUpdated != null)
                _tempShapeUpdated();
        }

        /// <summary>
        /// Notify handlers of TempShapeSaved to update.
        /// </summary>
        private void NotifyTempShapeSaved()
        {
            if (_tempShapeSaved != null)
                _tempShapeSaved();
        }
    }
}
