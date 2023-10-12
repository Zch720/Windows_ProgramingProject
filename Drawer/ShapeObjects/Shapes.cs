using System;
using System.Collections.Generic;

namespace Drawer.ShapeObjects
{
    public class Shapes
    {
        private ShapeFactory _shapeFactory;
        private List<Shape> _shapes;

        public List<ShapeData> ShapesList
        {
            get
            {
                return _shapes.ConvertAll(shape => new ShapeData(shape.Name, shape.Info));
            }
        }

        public Shapes(ShapeFactory shapeFactory)
        {
            _shapeFactory = shapeFactory;
            _shapes = new List<Shape>();
        }

        /// <summary>
        /// Create a new shape
        /// </summary>
        /// <param name="shapeType">The shape type string</param>
        /// <param name="upperLeft">The upper left corner of the shape</param>
        /// <param name="lowerDown">The lower down corner of the shape</param>
        public void CreateShape(string shapeType, Point upperLeft, Point lowerDown)
        {
            Shape shape = _shapeFactory.Create(shapeType, upperLeft, lowerDown);
            _shapes.Add(shape);
        }

        /// <summary>
        /// Delete the shape with index in the shapes list.
        /// </summary>
        /// <param name="index">The index in the list of the shape want to delete.</param>
        public void DeleteShape(int index)
        {
            _shapes.RemoveAt(index);
        }
    }
}
