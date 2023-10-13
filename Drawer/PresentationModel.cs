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
        public delegate void UpdateTempShape();

        public event ToolbarButtonsUpdatedEventHandler ToolbarButtonUpdated;
        public event ModelShapesUpdatedEventHandler ModelShapesListUpdated;
        public event UpdateCursorStyle CursorStyleUpdated;
        public event UpdateTempShape TempShapeUpdated;

        private Model _model;
        private bool _inDrawArea;
        private bool _isDrawing;
        private ShapeType _selectedShape;

        public bool ToolbarLineButtonChecked
        {
            get
            {
                return _selectedShape == ShapeType.Line;
            }
        }

        public bool ToolbarRectangleButtonChecked
        {
            get
            {
                return _selectedShape == ShapeType.Rectangle;
            }
        }

        public bool ToolbarCircleButtonChecked
        {
            get
            {
                return _selectedShape == ShapeType.Circle;
            }
        }

        public List<ShapeData> ShapeDatasWithTemp
        {
            get
            {
                return _model.ShapeDatasWithTemp;
            }
        }

        public PresentationModel(Model model)
        {
            _model = model;
            _inDrawArea = false;
            _isDrawing = false;
            _selectedShape = ShapeType.None;
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
            _selectedShape = ShapeType.Line;
            NotifyToolbarButtonCheckedUpdated();
        }

        public void ClickToolbarRectangleButton()
        {
            _selectedShape = ShapeType.Rectangle;
            NotifyToolbarButtonCheckedUpdated();
        }

        public void ClickToolbarCircleButton()
        {
            _selectedShape = ShapeType.Circle;
            NotifyToolbarButtonCheckedUpdated();
        }

        public void ClearToolbarButtonChecked()
        {
            _selectedShape = ShapeType.None;
            NotifyToolbarButtonCheckedUpdated();
            NotifyCursorStyleUpdated();
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

        public void MouseDownInDrawArea(int x, int y)
        {
            _isDrawing = true;
            _model.CreateTempShape(_selectedShape, x, y);
            NotifyTempShapeUpdated();
        }

        public void MouseMoveInDrawArea(int x, int y)
        {
            _model.UpdateTempShape(x, y);
            if (_isDrawing)
                NotifyTempShapeUpdated();
        }

        public void MouseUpInDrawArea(int x, int y)
        {
            _model.UpdateTempShape(x, y);
            _model.SaveTempShape();
            _isDrawing = false;
            ClearToolbarButtonChecked();
            NotifyTempShapeUpdated();
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
            if (_inDrawArea && _selectedShape != ShapeType.None)
                CursorStyleUpdated(Cursors.Cross);
            else
                CursorStyleUpdated(Cursors.Arrow);
        }

        private void NotifyTempShapeUpdated()
        {
            if (TempShapeUpdated != null)
                TempShapeUpdated();
        }
    }
}
