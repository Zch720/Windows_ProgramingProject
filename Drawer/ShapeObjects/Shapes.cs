using System;
using System.Collections.Generic;

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
                return _shapes.ConvertAll(shape => new ShapeData(shape.Type, shape.Name, shape.Info, shape.Point1, shape.Point2));
            }
        }

        public List<ShapeData> ShapeDatasWithTemp
        {
            get
            {
                List<ShapeData> shapeDatas = ShapeDatas;
                if (_tempShape != null)
                {
                    Shape copy = _shapeFactory.CopyShape(_tempShape);
                    _shapeFactory.ReviseShapePoints(copy);
                    shapeDatas.Add(new ShapeData(copy.Type, copy.Name, copy.Info, copy.Point1, copy.Point2));
                }
                return shapeDatas;
            }
        }

        public Shapes(ShapeFactory shapeFactory)
        {
            _shapeFactory = shapeFactory;
            _shapes = new List<Shape>();
            _tempShape = null;
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
            _shapeFactory.ReviseShapePoints(shape);
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

        public void CreateTempShape(ShapeType shapeType, int x, int y)
        {
            _tempShape = _shapeFactory.Create(shapeType, new Point(x, y), new Point(x, y));
        }

        public void UpdateTempShape(int x, int y)
        {
            if (_tempShape != null)
                _tempShape.Point2 = new Point(x, y);
        }

        public void SaveTempShape()
        {
            if (_tempShape != null)
            {
                _shapeFactory.ReviseShapePoints(_tempShape);
                _shapes.Add(_tempShape);
            }
            _tempShape = null;
        }
    }
}
