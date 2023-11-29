using Drawer.Model.ShapeObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drawer.Model.State
{
    public class ModelPointerState : IState
    {
        public event ShapeSelectedOrCreatedEventHandler _shapeSelectedOrCreated;
        public event ShapeUpdatedEventHandler _shapeUpdated;
        public event ShapeSavedEventHandler _shapeSaved;

        private Shapes _shapes;
        private Point _previousPoint;
        private ScalePoint _scalePoint;
        private bool _shapeSelected;

        public ScalePoint? CurrentScalePoint
        {
            get
            {
                return _scalePoint;
            }
        }

        public ModelPointerState(Shapes shapes)
        {
            _shapes = shapes;
            _scalePoint = ScalePoint.None;
            _shapeSelected = false;
        }

        /// <inheritdoc/>
        public void SelectOrCreateShape(Point point)
        {
            _scalePoint = _shapes.IsPointOnSelectedShape(point);
            if (_scalePoint == ScalePoint.None)
            {
                _shapes.SelectedShapeAtPoint(point);
                _previousPoint = point;
            }
            else
            {
                _shapes.SelectScalePoint(_scalePoint);
            }
            _shapeSelected = true;
            _shapeSelectedOrCreated?.Invoke();
        }

        /// <inheritdoc/>
        public void UpdateShape(Point point)
        {
            if (_shapeSelected)
            {
                if (_scalePoint == ScalePoint.None)
                {
                    _shapes.MoveSelectedShape(Point.Subtract(point, _previousPoint));
                    _previousPoint = point;
                }
                else
                {
                    _shapes.ScaleSelectedShape(point);
                }
                _shapeUpdated?.Invoke();
            }
            else
            {
                _scalePoint = _shapes.IsPointOnSelectedShape(point);
            }
        }

        /// <inheritdoc/>
        public void SaveShape(Point point)
        {
            if (!_shapeSelected)
                return;
            if (_scalePoint == ScalePoint.None)
            {
                _shapes.MoveSelectedShape(Point.Subtract(point, _previousPoint));
            }
            else
            {
                _shapes.ScaleSelectedShape(point);
                _shapes.SaveScaledShape();
            }
            _shapeSelected = false;
            _shapeSaved?.Invoke();
        }
    }
}
