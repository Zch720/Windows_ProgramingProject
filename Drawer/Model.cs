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

        public event ShapesUpdatedEventHandler ShapesListUpdated;

        private Shapes _shapes;

        public List<ShapeData> ShapeDatas
        {
            get
            {
                return _shapes.ShapeDatas;
            }
        }

        public List<ShapeData> ShapeDatasWithTemp
        {
            get
            {
                return _shapes.ShapeDatasWithTemp;
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
        /// <param name="x">X coordinate of new shape.</param>
        /// <param name="y">Y coordinate of new shape.</param>
        public void CreateTempShape(ShapeType shapeType, int x, int y)
        {
            _shapes.CreateTempShape(shapeType, x, y);
        }

        /// <summary>
        /// Update the second point of the temp shape for drawing.
        /// </summary>
        /// <param name="x">The second point x coordinate of the temp shape.</param>
        /// <param name="y">The second point y coordinate of the temp shape.</param>
        public void UpdateTempShape(int x, int y)
        {
            _shapes.UpdateTempShape(x, y);
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
            if (ShapesListUpdated != null)
                ShapesListUpdated();
        }
    }
}
