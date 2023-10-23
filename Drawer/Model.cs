using Drawer.ShapeObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drawer
{
    public class Model
    {

        public delegate void ShapesUpdatedEventHandler();

        public event ShapesUpdatedEventHandler _shapesListUpdated;

        private Shapes _shapes;

        public List<ShapeData> ShapeDatas
        {
            get
            {
                return _shapes.ShapeDatas;
            }
        }

        public Model(ShapeFactory shapeFactory)
        {
            _shapes = new Shapes(shapeFactory);
        }

        /// <summary>
        /// Create a new shape.
        /// </summary>
        /// <param name="shapeType">The shape type string.</param>
        /// <param name="upperLeft">The upper left corner of the shape.</param>
        /// <param name="lowerDown">The lower down corner of the shape.</param>
        public void CreateShape(string shapeType, Point upperLeft, Point lowerDown)
        {
            _shapes.CreateShape(shapeType, upperLeft, lowerDown);
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
            _shapes.CreateTempShape(shapeType, xCoordinate, yCoordinate);
        }

        /// <summary>
        /// Update the second point of the temp shape for drawing.
        /// </summary>
        /// <param name="xCoordinate">The second point x coordinate of the temp shape.</param>
        /// <param name="yCoordinate">The second point y coordinate of the temp shape.</param>
        public void UpdateTempShape(int xCoordinate, int yCoordinate)
        {
            _shapes.UpdateTempShape(xCoordinate, yCoordinate);
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
        /// Notify handlers of ShapesListUpdated to update.
        /// </summary>
        private void NotifyShapesListUpdated()
        {
            if (_shapesListUpdated != null)
                _shapesListUpdated();
        }
    }
}
