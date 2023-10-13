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
        public delegate void ToolbarButtonsUpdatedEventHandler();
        public delegate void ModelShapesUpdatedEventHandler();
        public delegate void UpdateCursorStyle(Cursor corsur);
        public delegate void UpdateTempShape();

        public event ToolbarButtonsUpdatedEventHandler ToolbarButtonUpdated;
        public event ModelShapesUpdatedEventHandler ModelShapesListUpdated;
        public event UpdateCursorStyle CursorStyleUpdated;
        public event UpdateTempShape TempShapeUpdated;

        private Random _random;
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

        public List<ShapeData> ShapeDatas
        {
            get
            {
                return _model.ShapeDatas;
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
            _random = new Random();
            _model = model;
            _inDrawArea = false;
            _isDrawing = false;
            _selectedShape = ShapeType.None;
            _model.ShapesListUpdated += NotifyModelShapesListUpdated;
        }

        /// <summary>
        /// Handle create shape event from view.
        /// </summary>
        /// <param name="shapeType">Type of shape want to create.</param>
        /// <param name="drawAreaLowerRightCorner">The lower right corner of draw area.</param>
        public void ClickCreateShapeButton(string shapeType, Point drawAreaLowerRightCorner)
        {
            Point upperLeft = GenerateRandomPoint(new Point(0, 0), drawAreaLowerRightCorner);
            Point lowerRight = GenerateRandomPoint(new Point(0, 0), drawAreaLowerRightCorner);
            _model.CreateShape(shapeType, upperLeft, lowerRight);
        }

        /// <summary>
        /// Handle shape data grid view click event from view.
        /// </summary>
        /// <param name="columnIndex">The column index of clicked cell.</param>
        /// <param name="rowIndex">The row index of clicked cell.</param>
        public void ClickShapeDataGridCell(int columnIndex, int rowIndex)
        {
            if (columnIndex == 0 && rowIndex >= 0)
                _model.DeleteShape(rowIndex);
        }

        /// <summary>
        /// Handle toolbar line button click event from view.
        /// </summary>
        public void ClickToolbarLineButton()
        {
            _selectedShape = ShapeType.Line;
            NotifyToolbarButtonCheckedUpdated();
        }

        /// <summary>
        /// Handle toolbar rectangle button click event from view.
        /// </summary>
        public void ClickToolbarRectangleButton()
        {
            _selectedShape = ShapeType.Rectangle;
            NotifyToolbarButtonCheckedUpdated();
        }

        /// <summary>
        /// Handle toolbar circle button click event from view.
        /// </summary>
        public void ClickToolbarCircleButton()
        {
            _selectedShape = ShapeType.Circle;
            NotifyToolbarButtonCheckedUpdated();
        }

        /// <summary>
        /// Clear toolbar buttons selected state.
        /// </summary>
        public void ClearToolbarButtonChecked()
        {
            _selectedShape = ShapeType.None;
            NotifyToolbarButtonCheckedUpdated();
            NotifyCursorStyleUpdated();
        }

        /// <summary>
        /// Handle draw area mouse enter event from view.
        /// </summary>
        public void MouseEnterDrawArea()
        {
            _inDrawArea = true;
            NotifyCursorStyleUpdated();
        }

        /// <summary>
        /// Handle draw area mouse leave event from view.
        /// </summary>
        public void MouseLeaveDrawArea()
        {
            _inDrawArea = false;
            NotifyCursorStyleUpdated();
        }

        /// <summary>
        /// Handle draw area mouse down event from view.
        /// </summary>
        public void MouseDownInDrawArea(int x, int y)
        {
            _isDrawing = true;
            _model.CreateTempShape(_selectedShape, x, y);
            NotifyTempShapeUpdated();
        }

        /// <summary>
        /// Handle draw area mouse move event from view.
        /// </summary>
        public void MouseMoveInDrawArea(int x, int y)
        {
            _model.UpdateTempShape(x, y);
            if (_isDrawing)
                NotifyTempShapeUpdated();
        }

        /// <summary>
        /// Handle draw area mouse up event from view.
        /// </summary>
        public void MouseUpInDrawArea(int x, int y)
        {
            _model.UpdateTempShape(x, y);
            _model.SaveTempShape();
            _isDrawing = false;
            ClearToolbarButtonChecked();
            NotifyTempShapeUpdated();
        }

        /// <summary>
        /// Generate a rendom point between upperLeft and lowerRight.
        /// </summary>
        /// <param name="upperLeft">The upper left corner of random area.</param>
        /// <param name="lowerRight">The lower right corner of random area.</param>
        /// <returns></returns>
        private Point GenerateRandomPoint(Point upperLeft, Point lowerRight)
        {
            return new Point(
                _random.Next(upperLeft.X, lowerRight.X),
                _random.Next(upperLeft.Y, lowerRight.Y)
            );
        }

        /// <summary>
        /// Notify handlers of ToolbarButtonUpdated to update.
        /// </summary>
        private void NotifyToolbarButtonCheckedUpdated()
        {
            if (ToolbarButtonUpdated != null)
                ToolbarButtonUpdated();
        }

        /// <summary>
        /// Notify handlers of ModelShapesListUpdated to update.
        /// </summary>
        private void NotifyModelShapesListUpdated()
        {
            if (ModelShapesListUpdated != null)
                ModelShapesListUpdated();
        }

        /// <summary>
        /// Notify handlers of CursorStyleUpdated to update.
        /// </summary>
        private void NotifyCursorStyleUpdated()
        {
            if (_inDrawArea && _selectedShape != ShapeType.None)
                CursorStyleUpdated(Cursors.Cross);
            else
                CursorStyleUpdated(Cursors.Arrow);
        }

        /// <summary>
        /// Notify handlers of NotifyTempShapeUpdated to update.
        /// </summary>
        private void NotifyTempShapeUpdated()
        {
            if (TempShapeUpdated != null)
                TempShapeUpdated();
        }
    }
}
