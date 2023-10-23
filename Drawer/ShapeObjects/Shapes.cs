using System;
using System.Collections.Generic;
using System.Drawing;

namespace Drawer.ShapeObjects
{
    public class Shapes
    {
        private ShapeFactory _shapeFactory;
        private List<Shape> _shapes;
        private Shape _tempShape;

        public List<ShapeData> ShapeDatas
        {
            get
            {
                    return _shapes.ConvertAll(shape => {
                        return new ShapeData(shape.Name, shape.Info, shape.Point1, shape.Point2);
                    });
            }
        }

        public Shapes(ShapeFactory shapeFactory)
        {
            _shapeFactory = shapeFactory;
            _shapes = new List<Shape>();
            _tempShape = null;
        }

        /// <summary>
        /// Create a new shape.
        /// </summary>
        /// <param name="shapeType">The shape type string.</param>
        /// <param name="upperLeft">The upper left corner of the shape.</param>
        /// <param name="lowerDown">The lower down corner of the shape.</param>
        public void CreateShape(string shapeType, Point upperLeft, Point lowerDown)
        {
            Shape shape = _shapeFactory.Create(shapeType, upperLeft, lowerDown);
            if (shape == null)
                return;
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

        /// <summary>
        /// Creaet a temp shape.
        /// </summary>
        /// <param name="shapeType">The shape type of new shape.</param>
        /// <param name="xCoordinate">X coordinate of new shape.</param>
        /// <param name="yCoordinate">Y coordinate of new shape.</param>
        public void CreateTempShape(ShapeType shapeType, int xCoordinate, int yCoordinate)
        {
            _tempShape = _shapeFactory.Create(shapeType, new Point(xCoordinate, yCoordinate), new Point(xCoordinate, yCoordinate));
        }

        /// <summary>
        /// Update the second point of the temp shape.
        /// </summary>
        /// <param name="xCoordinate">The second point x coordinate of the temp shape.</param>
        /// <param name="yCoordinate">The second point y coordinate of the temp shape.</param>
        public void UpdateTempShape(int xCoordinate, int yCoordinate)
        {
            if (_tempShape != null)
                _tempShape.Point2 = new Point(xCoordinate, yCoordinate);
        }

        /// <summary>
        /// Save the temp shape.
        /// </summary>
        public void SaveTempShape()
        {
            if (_tempShape != null)
            {
                _shapeFactory.ReviseShapePoints(_tempShape);
                _shapes.Add(_tempShape);
            }
            _tempShape = null;
        }

        /// <summary>
        /// Draw all shapes and temp shape.
        /// </summary>
        /// <param name="graphics">Graphics of draw area.</param>
        public void DrawWithTemp(Graphics graphics)
        {
            foreach (Shape shape in _shapes)
                shape.Draw(graphics);
            if (_tempShape != null)
            {
                _tempShape.Draw(graphics);
            }
        }
    }
}
