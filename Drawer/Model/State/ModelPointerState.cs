using Drawer.Model.Command;
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
        private DrawerModel _model;
        private ScalePoint _scalePoint;

        public ScalePoint? CurrentScalePoint
        {
            get
            {
                return _scalePoint;
            }
        }

        public ModelPointerState(DrawerModel model)
        {
            _model = model;
            _scalePoint = ScalePoint.None;
        }

        /// <inheritdoc/>
        public void SelectOrCreateShape(Point point)
        {
            _scalePoint = _model.CurrentShapes.IsPointOnSelectedShape(point);
            if (_scalePoint != ScalePoint.None)
                _model.SetPointerScaleState();
            else
                _model.SetPointerMoveState();
            _model.SelectOrCreateShape(point);
        }

        /// <inheritdoc/>
        public void UpdateShape(Point point)
        {
            _scalePoint = _model.CurrentShapes.IsPointOnSelectedShape(point);
        }

        /// <inheritdoc/>
        public void SaveShape(Point point)
        {
        }
    }
}
