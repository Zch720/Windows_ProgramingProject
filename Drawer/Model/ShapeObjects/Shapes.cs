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
        private ShapeType _tempType;
        private int _selectedShape;
        private int _scalePointSize;

        public BindingList<ShapeData> ShapeDatas
        {
            get
            {
                return _shapeDatas;
            }
        }

        public int ScalePointSize
        {
            set
            {
                _scalePointSize = value;
            }
        }

        public Shapes(ShapeFactory shapeFactory)
        {
            _shapeFactory = shapeFactory;
            _shapes = new List<Shape>();
            _shapeDatas = new BindingList<ShapeData>();
            _tempShape = null;
            _tempType = ShapeType.None;
            _selectedShape = -1;
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
            if (_selectedShape != -1)
            {
                if (_selectedShape == index)
                    _selectedShape = -1;
                else if (_selectedShape > index)
                    _selectedShape--;
            }
        }

        /// <summary>
        /// Create a temp shape.
        /// </summary>
        /// <param name="shapeType">The shape type of new shape.</param>
        /// <param name="xCoordinate">X coordinate of new shape.</param>
        /// <param name="yCoordinate">Y coordinate of new shape.</param>
        public void CreateTempShape(ShapeType shapeType, Point point)
        {
            _tempType = shapeType;
            _tempShape = _shapeFactory.Create(shapeType, point, point);
        }

        /// <summary>
        /// Update the second point of the temp shape.
        /// </summary>
        /// <param name="xCoordinate">The second point x coordinate of the temp shape.</param>
        /// <param name="yCoordinate">The second point y coordinate of the temp shape.</param>
        public void UpdateTempShape(Point point)
        {
            if (_tempType != ShapeType.None)
                _tempShape = _shapeFactory.Create(_tempType, _tempShape.Point1, point);
        }

        /// <summary>
        /// Save the temp shape.
        /// </summary>
        public void SaveTempShape()
        {
            if (_tempType == ShapeType.None)
                return;
            _tempType = ShapeType.None;
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
                try
                {
                    if (Point.LowerEqual(_shapes[i].UpperLeft, point) && Point.LowerEqual(point, _shapes[i].LowerRight))
                    {
                        _shapes[i].IsSelected = true;
                        _selectedShape = i;
                        break;
                    }
                }
                catch
                {
                }
            }
            UpdateShapeDatasSelectedStatus();
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
            if (_selectedShape != -1)
            {
                _shapes.RemoveAt(_selectedShape);
                _shapeDatas.RemoveAt(_selectedShape);
                _selectedShape = -1;
            }
        }

        /// <summary>
        /// Check if the point is on the scale point of selected shape.
        /// </summary>
        /// <param name="point">The point need to check.</param>
        /// <returns>The scale point that point on.</returns>
        public ScalePoint IsPointOnSelectedShape(Point point)
        {
            
            if (_selectedShape == -1)
                return ScalePoint.None;
            Shape shape = _shapes[_selectedShape];
            if (Point.GetDistance(point, shape.UpperLeft) <= _scalePointSize)
                return ScalePoint.UpperLeft;
            if (Point.GetDistance(point, shape.UpperRight) <= _scalePointSize)
                return ScalePoint.UpperRight;
            if (Point.GetDistance(point, shape.LowerLeft) <= _scalePointSize)
                return ScalePoint.LowerLeft;
            if (Point.GetDistance(point, shape.LowerRight) <= _scalePointSize)
                return ScalePoint.LowerRight;
            return ScalePoint.None;
        }

        /// <summary>
        /// Set the selected scale point of selected shape.
        /// </summary>
        /// <param name="point">The scale point.</param>
        public void SetSelectedShapeScalePoint(ScalePoint point)
        {
            _shapes[_selectedShape].SelectedScalePoint = point;
        }

        /// <summary>
        /// Update the selected shape scale point position.
        /// </summary>
        /// <param name="point">The position that scale point should be update.</param>
        public void ScaleSelectedShape(Point point)
        {
            _shapes[_selectedShape].Scale(point);
            _shapeDatas[_selectedShape] = new ShapeData(_shapes[_selectedShape]);
        }

        /// <summary>
        /// Save the selected shape after scaled.
        /// </summary>
        public void SaveScaledShape()
        {
            _shapes[_selectedShape].SelectedScalePoint = ScalePoint.None;
        }

        /// <summary>
        /// Set all shapes in _shapes selected state to false.
        /// </summary>
        private void ClearShapesSelectedState()
        {
            if (_selectedShape == -1)
                return;
            _shapes[_selectedShape].IsSelected = false;
        }

        /// <summary>
        /// Update add ShapeData if the value if Shape.IsSelected is updated.
        /// </summary>
        private void UpdateShapeDatasSelectedStatus()
        {
            for (int i = 0; i < _shapeDatas.Count; i++)
                if (_shapeDatas[i].IsSelected != _shapes[i].IsSelected)
                    _shapeDatas[i] = new ShapeData(_shapes[i]);
        }
    }
}
