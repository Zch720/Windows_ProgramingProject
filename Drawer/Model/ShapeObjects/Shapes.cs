// Ignore Spelling: Datas

using Drawer.GraphicsAdapter;
using System.Collections.Generic;
using System.ComponentModel;

namespace Drawer.Model.ShapeObjects
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
            _shapes.Add(shape);
            _shapeDatas.Add(new ShapeData(shape));
        }

        /// <summary>
        /// Create a new shape.
        /// </summary>
        /// <param name="type">The shape type enum.</param>
        /// <param name="point1">The first point of the shape.</param>
        /// <param name="point2">The second point of the shape</param>
        public void CreateShape(ShapeType type, Point point1, Point point2)
        {
            Shape shape = _shapeFactory.Create(type, point1, point2);
            _shapes.Add(shape);
            _shapeDatas.Add(new ShapeData(shape));
        }

        /// <summary>
        /// Delete the shape with index in the shapes list.
        /// </summary>
        /// <param name="index">The index in the list of the shape want to delete.</param>
        public void DeleteShape(int index)
        {
            if (index < 0 || _shapes.Count <= index)
                return;
            _shapes.RemoveAt(index);
            _shapeDatas.RemoveAt(index);
        }

        /// <summary>
        /// Creaet a temp shape.
        /// </summary>
        /// <param name="shapeType">The shape type of new shape.</param>
        /// <param name="xCoordinate">X coordinate of new shape.</param>
        /// <param name="yCoordinate">Y coordinate of new shape.</param>
        public void CreateTempShape(ShapeType shapeType, Point point)
        {
            _tempShape = _shapeFactory.Create(shapeType, point, point);
        }

        /// <summary>
        /// Update the second point of the temp shape.
        /// </summary>
        /// <param name="xCoordinate">The second point x coordinate of the temp shape.</param>
        /// <param name="yCoordinate">The second point y coordinate of the temp shape.</param>
        public void UpdateTempShape(Point point)
        {
            if (_tempShape != null)
                _tempShape.Point2 = point;
        }

        /// <summary>
        /// Save the temp shape.
        /// </summary>
        public void SaveTempShape()
        {
            if (_tempShape == null)
                return;
            _shapes.Add(_tempShape);
            _shapeDatas.Add(new ShapeData(_tempShape));
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
        /// <param name="point">The point selected.</param>
        public void SelectedShapeAtPoint(Point point)
        {
            ClearShapesSelectedState();
            for (int i = _shapes.Count - 1; i >= 0; i--)
            {
                if (Point.LowerEqual(_shapes[i].UpperLeft, point) && Point.LowerEqual(point, _shapes[i].LowerRight))
                {
                    _shapes[i].IsSelected = true;
                    break;
                }
            }
        }

        /// <summary>
        /// Move selected shape in _shapes.
        /// </summary>
        /// <param name="distance">The move distance.</param>
        public void MoveSelectedShape(Point distance)
        {
            for (int i = 0; i < _shapes.Count; i++)
            {
                if (_shapes[i].IsSelected)
                {
                    _shapes[i].Move(distance);
                    _shapeDatas[i] = new ShapeData(_shapes[i]);
                }
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
