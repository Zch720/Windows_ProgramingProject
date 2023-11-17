using Drawer.ShapeObjects;
using System.ComponentModel;

namespace Drawer
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
        /// Create a new ranndom shape.
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
        /// <param name="xCoordinate">X coordinate of new shape.</param>
        /// <param name="yCoordinate">Y coordinate of new shape.</param>
        public void CreateTempShape(ShapeType shapeType, int xCoordinate, int yCoordinate)
        {
            _shapes.CreateTempShape(shapeType, new Point(xCoordinate, yCoordinate));
            NotifyTempShapeUpdated();
        }

        /// <summary>
        /// Update the second point of the temp shape for drawing.
        /// </summary>
        /// <param name="xCoordinate">The second point x coordinate of the temp shape.</param>
        /// <param name="yCoordinate">The second point y coordinate of the temp shape.</param>
        public void UpdateTempShape(int xCoordinate, int yCoordinate)
        {
            _shapes.UpdateTempShape(new Point(xCoordinate, yCoordinate));
            NotifyTempShapeUpdated();
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
        /// Save the temp shape for drawing.
        /// </summary>
        public void SaveTempShape()
        {
            _shapes.SaveTempShape();
            NotifyShapesListUpdated();
        }

        /// <summary>
        /// Select shape from shapes by point.
        /// </summary>
        /// <param name="xCoordinate">The x coordinage of point.</param>
        /// <param name="yCoordinate">The y coordinage of point.</param>
        public void SelectedShapeAtPoint(int xCoordinate, int yCoordinate)
        {
            _shapes.SelectedShapeAtPoint(new Point(xCoordinate, yCoordinate));
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
