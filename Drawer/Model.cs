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

        public delegate void ShapesUpdatedEventHandler(List<ShapeData> shapeDatas);

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
        /// Create a new shape
        /// </summary>
        /// <param name="shapeType">The shape type string</param>
        /// <param name="upperLeft">The upper left corner of the shape</param>
        /// <param name="lowerDown">The lower down corner of the shape</param>
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

        public void CreateTempShape(ShapeType shapeType, int x, int y)
        {
            _shapes.CreateTempShape(shapeType, x, y);
        }

        public void UpdateTempShape(int x, int y)
        {
            _shapes.UpdateTempShape(x, y);
        }

        public void SaveTempShape()
        {
            _shapes.SaveTempShape();
            NotifyShapesListUpdated();
        }

        private void NotifyShapesListUpdated()
        {
            if (ShapesListUpdated != null)
                ShapesListUpdated(ShapeDatas);
        }
    }
}
