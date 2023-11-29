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
                SelectShape(point);
            else
                SelectShapeScalePoint();
            _shapeSelected = true;
            NotifyShapeSelectedOrCreated();
        }

        /// <inheritdoc/>
        public void UpdateShape(Point point)
        {
            if (_shapeSelected)
            {
                if (_scalePoint == ScalePoint.None)
                    MoveShape(point);
                else
                    ScaleShape(point);
                NotifyShapeUpdated();
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
                SaveMovedShape(point);
            else
                SaveScaledShape(point);
            _shapeSelected = false;
            NotifyShapeSaved();
        }

        /// <summary>
        /// Select shape at point through shapes.
        /// </summary>
        private void SelectShape(Point point)
        {
            _shapes.SelectedShapeAtPoint(point);
            _previousPoint = point;
        }

        /// <summary>
        /// Set selected shape scale point in shapes.
        /// </summary>
        private void SelectShapeScalePoint()
        {
            _shapes.SetSelectedShapeScalePoint(_scalePoint);
        }

        /// <summary>
        /// Move selected shape through shapes.
        /// </summary>
        private void MoveShape(Point point)
        {
            _shapes.MoveSelectedShape(Point.Subtract(point, _previousPoint));
            _previousPoint = point;
        }

        /// <summary>
        /// Scale selected shape through shapes.
        /// </summary>
        private void ScaleShape(Point point)
        {
            _shapes.ScaleSelectedShape(point);
        }

        /// <summary>
        /// Last move selected shape and save it through shapes.
        /// </summary>
        private void SaveMovedShape(Point point)
        {
            _shapes.MoveSelectedShape(Point.Subtract(point, _previousPoint));
        }

        /// <summary>
        /// Last scale selected shape and save it through shapes.
        /// </summary>
        private void SaveScaledShape(Point point)
        {
            _shapes.ScaleSelectedShape(point);
            _shapes.SaveScaledShape();
        }

        /// <summary>
        /// invoke shape selected or created event handler.
        /// </summary>
        private void NotifyShapeSelectedOrCreated()
        {
            if (_shapeSelectedOrCreated != null)
                _shapeSelectedOrCreated();
        }

        /// <summary>
        /// invoke shape updated event handler.
        /// </summary>
        private void NotifyShapeUpdated()
        {
            if (_shapeUpdated != null)
                _shapeUpdated();
        }

        /// <summary>
        /// invoke shape saved event handler.
        /// </summary>
        private void NotifyShapeSaved()
        {
            if (_shapeSaved != null)
                _shapeSaved();
        }
    }
}
