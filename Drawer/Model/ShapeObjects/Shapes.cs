// Ignore Spelling: Datas

using Drawer.GraphicsAdapter;
using System.Collections.Generic;
using System.ComponentModel;

namespace Drawer.Model.ShapeObjects
{
    public class Shapes
    {
        public delegate void ShapesModifyEventHandler(int index);

        public event ShapesModifyEventHandler _shapesAdded;
        public event ShapesModifyEventHandler _shapesUpdated;
        public event ShapesModifyEventHandler _shapesDeleted;

        private ShapeFactory _shapeFactory;
        private List<Shape> _shapes;
        private BindingList<ShapeData> _shapeDatas;
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

        public ShapeData SelectedShapeData
        {
            get
            {
                if (_selectedShape == -1)
                    return null;
                return _shapeDatas[_selectedShape];
            }
        }

        public int SelectedShapeIndex
        {
            get
            {
                return _selectedShape;
            }
        }

        public Shapes(ShapeFactory shapeFactory)
        {
            _shapeFactory = shapeFactory;
            _shapes = new List<Shape>();
            _shapeDatas = new BindingList<ShapeData>();
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
            NotifyShapesAdded(_shapes.Count - 1);
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
            NotifyShapesAdded(_shapes.Count - 1);
        }

        /// <summary>
        /// Create a new shape from shape data.
        /// </summary>
        /// <param name="data">The shape data.</param>
        public void CreateFromData(ShapeData data)
        {
            Shape shape = _shapeFactory.Create(data.ShapeName, data.Point1, data.Point2);
            _shapes.Add(shape);
            _shapeDatas.Add(data);
            NotifyShapesAdded(_shapes.Count - 1);
        }

        /// <summary>
        /// Insert shape from data into _shapes.
        /// </summary>
        /// <param name="data">The shape data.</param>
        /// <param name="index">The index want to insert.</param>
        public void InsertShapeFromData(ShapeData data, int index)
        {
            Shape shape = _shapeFactory.Create(data.ShapeName, data.Point1, data.Point2);
            _shapes.Insert(index, shape);
            _shapeDatas.Insert(index, data);
            if (_selectedShape != -1)
            {
                if (_selectedShape >= index)
                    _selectedShape++;
            }
            NotifyShapesAdded(index);
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
            NotifyShapesDeleted(index);
        }

        /// <summary>
        /// Delete last shape in shape list.
        /// </summary>
        public void DeleteLastShape()
        {
            DeleteShape(_shapes.Count - 1);
        }

        /// <summary>
        /// Set shape value from data.
        /// </summary>
        /// <param name="index">The index want to set shape</param>
        /// <param name="data"></param>
        public void SetShapeAtIndex(int index, ShapeData data)
        {
            DeleteShape(index);
            InsertShapeFromData(data, index);
            NotifyShapesUpdated(index);
        }

        /// <summary>
        /// Create a temp shape.
        /// </summary>
        public Shape CreateTempShape(ShapeType type, Point point1, Point point2)
        {
            return _shapeFactory.Create(type, point1, point2);
        }

        /// <summary>
        /// Draw all shapes and temp shape.
        /// </summary>
        /// <param name="graphics">Graphics of draw area.</param>
        public void Draw(IGraphics graphics)
        {
            foreach (Shape shape in _shapes)
                shape.Draw(graphics);
        }
        
        /// <summary>
        /// Select shape at index.
        /// </summary>
        public void SelectShapeAtIndex(int index)
        {
            if (_selectedShape != -1)
                _shapes[_selectedShape].IsSelected = false;
            _shapes[index].IsSelected = true;
            _selectedShape = index;
            UpdateShapeDatasSelectedStatus();
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
            // TODO: modify use _selectedShape
            for (int i = 0; i < _shapes.Count; i++)
            {
                if (_shapes[i].IsSelected)
                {
                    _shapes[i].Move(distance);
                    _shapeDatas[i] = new ShapeData(_shapes[i]);
                    NotifyShapesUpdated(i);
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
                NotifyShapesDeleted(_selectedShape);
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
        /// <param name="scalePoint">The scale point.</param>
        public void SetSelectedShapeScalePoint(ScalePoint scalePoint)
        {
            _shapes[_selectedShape].SelectedScalePoint = scalePoint;
        }

        /// <summary>
        /// Set the selected scale point of selected shape.
        /// </summary>
        /// <param name="point">The point to check is on scale point.</param>
        public void SetSelectedShapeScalePoint(Point point)
        {
            ScalePoint scalePoint = IsPointOnSelectedShape(point);
            if (scalePoint != ScalePoint.None)
                SetSelectedShapeScalePoint(scalePoint);
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
            _selectedShape = -1;
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

        private void NotifyShapesAdded(int index)
        {
            if (_shapesAdded != null)
                _shapesAdded(index);
        }

        private void NotifyShapesUpdated(int index)
        {
            if (_shapesUpdated != null)
                _shapesUpdated(index);
        }

        private void NotifyShapesDeleted(int index)
        {
            if (_shapesDeleted != null)
                _shapesDeleted(index);
        }
    }
}
