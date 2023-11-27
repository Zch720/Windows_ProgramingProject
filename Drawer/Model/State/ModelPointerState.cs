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

        public ModelPointerState(Shapes shapes)
        {
            _shapes = shapes;
        }

        public void SelecteOrCreateShape(Point point)
        {
            _shapes.SelectedShapeAtPoint(point);
            _previousPoint = point;
            _shapeSelectedOrCreated?.Invoke();
        }

        public void UpdateShape(Point point)
        {
            _shapes.MoveSelectedShape(Point.Subtract(point, _previousPoint));
            _previousPoint = point;
            _shapeUpdated?.Invoke();
        }

        public void SaveShape(Point point)
        {
            _shapes.MoveSelectedShape(Point.Subtract(point, _previousPoint));
            _shapeSaved?.Invoke();
        }
    }
}
