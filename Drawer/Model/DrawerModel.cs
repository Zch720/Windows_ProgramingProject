// Ignore Spelling: Datas

using Drawer.Model.ShapeObjects;
using System.ComponentModel;

namespace Drawer.Model
{
    public class DrawerModel
    {

        public delegate void ShapesUpdatedEventHandler();
        public delegate void TempShapeUpdatedEventHandler();

        public event ShapesUpdatedEventHandler _shapesListUpdated;
        public event TempShapeUpdatedEventHandler _tempShapeUpdated;

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

        /// <summary>
        /// Create a temp shape for drawing.
        /// </summary>
        /// <param name="shapeType">The shape type of new shape.</param>
        /// <param name="point">The point of new shape.</param>
        public void CreateTempShape(ShapeType shapeType, Point point)
        {
            _shapes.CreateTempShape(shapeType, point);
            NotifyTempShapeUpdated();
        }

        /// <summary>
        /// Update the second point of the temp shape for drawing.
        /// </summary>
        /// <param name="point">The second point of the temp shape.</param>
        public void UpdateTempShape(Point point)
        {
            _shapes.UpdateTempShape(point);
            NotifyTempShapeUpdated();
        }

        /// <summary>
        /// Save the temp shape for drawing.
        /// </summary>
        public void SaveTempShape()
        {
            _shapes.SaveTempShape();
            NotifyShapesListUpdated();
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
        /// Select shape from shapes by point.
        /// </summary>
        /// <param name="point">The point select.</param>
        public void SelectedShapeAtPoint(Point point)
        {
            _shapes.SelectedShapeAtPoint(point);
            NotifyShapesListUpdated();
        }

        /// <summary>
        /// Move selected shape in shapes.
        /// </summary>
        /// <param name="distance">The move distance.</param>
        public void MoveSelectedShape(Point distance)
        {
            _shapes.MoveSelectedShape(distance);
            NotifyShapesListUpdated();
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
    }
}
