using Drawer.ShapeObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Drawer
{
    public class PresentationModel
    {
        private const int POINT1_TOP_LEFT = 0;
        private const int POINT1_BOTTOM_RIGHT = 50;
        private const int POINT2_BOTTOM_RIGHT = 100;

        public delegate void ToolbarButtonsUpdatedEventHandler();
        public delegate void ModelShapesUpdatedEventHandler(List<ShapeData> shapeDatas);
        public delegate void UpdateCursorStyle(Cursor corsur);

        public event ToolbarButtonsUpdatedEventHandler ToolbarButtonUpdated;
        public event ModelShapesUpdatedEventHandler ModelShapesListUpdated;
        public event UpdateCursorStyle CursorStyleUpdated;

        private Model _model;
        private bool _inDrawArea;
        private bool _shapeSelected;
        private bool _toolbarLineButtonChecked;
        private bool _toolbarRectangleButtonChecked;
        private bool _toolbarCircleButtonChecked;

        public bool ToolbarLineButtonChecked
        {
            get
            {
                return _toolbarLineButtonChecked;
            }
        }

        public bool ToolbarRectangleButtonChecked
        {
            get
            {
                return _toolbarRectangleButtonChecked;
            }
        }

        public bool ToolbarCircleButtonChecked
        {
            get
            {
                return _toolbarCircleButtonChecked;
            }
        }

        public PresentationModel(Model model)
        {
            _model = model;
            _inDrawArea = false;
            _shapeSelected = false;
            _toolbarLineButtonChecked = false;
            _toolbarRectangleButtonChecked = false;
            _toolbarCircleButtonChecked = false;
            _model.ShapesListUpdated += NotifyModelShapesListUpdated;
        }

        public void ClickCreateShapeButton(string shapeType)
        {
            Point upperLeft = GenerateRandomPoint(new Point(POINT1_TOP_LEFT, POINT1_TOP_LEFT), new Point(POINT1_BOTTOM_RIGHT, POINT1_BOTTOM_RIGHT));
            Point lowerRight = GenerateRandomPoint(upperLeft, new Point(POINT2_BOTTOM_RIGHT, POINT2_BOTTOM_RIGHT));
            _model.CreateShape(shapeType, upperLeft, lowerRight);
        }

        public void ClickShapeDataGridCell(int columnIndex, int rowIndex)
        {
            if (columnIndex == 0 && rowIndex >= 0)
                _model.DeleteShape(rowIndex);
        }

        public void ClickToolbarLineButton()
        {
            _shapeSelected = true;
            _toolbarLineButtonChecked = true;
            _toolbarRectangleButtonChecked = false;
            _toolbarCircleButtonChecked = false;
            NotifyToolbarButtonCheckedUpdated();
        }

        public void ClickToolbarRectangleButton()
        {
            _shapeSelected = true;
            _toolbarLineButtonChecked = false;
            _toolbarRectangleButtonChecked = true;
            _toolbarCircleButtonChecked = false;
            NotifyToolbarButtonCheckedUpdated();
        }

        public void ClickToolbarCircleButton()
        {
            _shapeSelected = true;
            _toolbarLineButtonChecked = false;
            _toolbarRectangleButtonChecked = false;
            _toolbarCircleButtonChecked = true;
            NotifyToolbarButtonCheckedUpdated();
        }

        public void ClearToolbarButtonChecked()
        {
            _shapeSelected = false;
            _toolbarLineButtonChecked = false;
            _toolbarRectangleButtonChecked = false;
            _toolbarCircleButtonChecked = false;
            NotifyToolbarButtonCheckedUpdated();
        }

        public void MouseEnterDrawArea()
        {
            _inDrawArea = true;
            NotifyCursorStyleUpdated();
        }

        public void MouseLeaveDrawArea()
        {
            _inDrawArea = false;
            NotifyCursorStyleUpdated();
        }

        /// <summary>
        /// Generate a rendom point between upperLeft and lowerRight
        /// </summary>
        /// <param name="upperLeft">The upper left corner of random area</param>
        /// <param name="lowerRight">The lower right corner of random area</param>
        /// <returns></returns>
        private Point GenerateRandomPoint(Point upperLeft, Point lowerRight)
        {
            Random random = new Random();
            return new Point(
                random.Next(upperLeft.X, lowerRight.X),
                random.Next(upperLeft.Y, lowerRight.Y)
            );
        }

        private void NotifyToolbarButtonCheckedUpdated()
        {
            if (ToolbarButtonUpdated != null)
                ToolbarButtonUpdated();
        }

        private void NotifyModelShapesListUpdated(List<ShapeData> shapeDatas)
        {
            if (ModelShapesListUpdated != null)
                ModelShapesListUpdated(shapeDatas);
        }

        private void NotifyCursorStyleUpdated()
        {
            if (_inDrawArea && _shapeSelected)
                CursorStyleUpdated(Cursors.Cross);
            else
                CursorStyleUpdated(Cursors.Arrow);
        }
    }
}
