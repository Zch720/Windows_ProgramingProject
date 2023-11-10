using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Drawer.ShapeObjects
{
    public class Shapes
    {
        private ShapeFactory _shapeFactory;
        private List<Shape> _shapes;
        private BindingList<ShapeData> _shapeDatas;
        private Shape _tempShape;

        public BindingList<ShapeData> ShapeDatas
        {
            get
            {
                return _shapeDatas;
            }
        }

        public Shapes(ShapeFactory shapeFactory)
        {
            _shapeFactory = shapeFactory;
            _shapes = new List<Shape>();
            _shapeDatas = new BindingList<ShapeData>();
            _tempShape = null;
        }

        /// <summary>
        /// Create a new random shape.
        /// </summary>
        /// <param name="shapeType">The shape type string.</param>
        /// <param name="lowerRightCorner">The lower right corner of the area can create shape.</param>
        public void CreateRandomShape(string shapeType, Point lowerRightCorner)
        {
            Shape shape = _shapeFactory.CreateRandom(shapeType, lowerRightCorner);
            if (shape == null)
                return;
            _shapes.Add(shape);
            _shapeDatas.Add(new ShapeData(shape.Name, shape.Info, shape.UpperLeft, shape.LowerRight));
        }

        /// <summary>
        /// Delete the shape with index in the shapes list.
        /// </summary>
        /// <param name="index">The index in the list of the shape want to delete.</param>
        public void DeleteShape(int index)
        {
            _shapes.RemoveAt(index);
            _shapeDatas.RemoveAt(index);
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
                _shapeDatas.Add(new ShapeData(_tempShape.Name, _tempShape.Info, _tempShape.UpperLeft, _tempShape.LowerRight));
            }
            _tempShape = null;
        }

        /// <summary>
        /// Draw all shapes and temp shape.
        /// </summary>
        /// <param name="graphics">Graphics of draw area.</param>
        public void DrawWithTemp(IGraphics graphics)
        {
            foreach (Shape shape in _shapes)
                shape.Draw(graphics);
            if (_tempShape != null)
            {
                _tempShape.Draw(graphics);
            }
        }

        /// <summary>
        /// Selected shape in _shapes by point.
        /// </summary>
        /// <param name="xCoordinate">The x coordinate of point.</param>
        /// <param name="yCoordinate">The y coordinate of point.</param>
        public void SelectedShapeAtPoint(int xCoordinate, int yCoordinate)
        {
            Point point = new Point(xCoordinate, yCoordinate);
            ClearShapesSelectedState();
            for (int i = _shapes.Count - 1; i >= 0; i--)
            {
                if (_shapes[i].UpperLeft <= point && point <= _shapes[i].LowerRight)
                {
                    _shapes[i].IsSelected = true;
                    break;
                }
            }
        }

        /// <summary>
        /// Move selected shape in _shapes.
        /// </summary>
        /// <param name="xDistance">The move distance of x direction.</param>
        /// <param name="yDistance">The move distance of y direction.</param>
        public void MoveSelectedShape(int xDistance, int yDistance)
        {
            for (int i = 0; i < _shapes.Count; i++)
            {
                if (_shapes[i].IsSelected)
                    _shapes[i].Move(xDistance, yDistance);
                    _shapeDatas[i] = new ShapeData(_shapes[i].Name, _shapes[i].Info, _shapes[i].UpperLeft, _shapes[i].LowerRight);
            }
        }

        /// <summary>
        /// Delete selected shape in _shapes.
        /// </summary>
        public void DeleteSelectedShape()
        {
            for (int i = 0; i < _shapes.Count; i++)
            {
                if (_shapes[i].IsSelected)
                {
                    _shapes.RemoveAt(i);
                    _shapeDatas.RemoveAt(i);
                    i--;
                }
            }
        }

        /// <summary>
        /// Set all shapes in _shapes selected state to false.
        /// </summary>
        private void ClearShapesSelectedState()
        {
            foreach (Shape shape in _shapes)
                shape.IsSelected = false;
        }
    }
}
