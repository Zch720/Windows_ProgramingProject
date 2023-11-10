using Drawer.ShapeObjects;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Drawer
{
    public class PresentationModel
    {
        public delegate void ToolBarButtonsUpdatedEventHandler();
        public delegate void ModelShapesUpdatedEventHandler();
        public delegate void UpdateCursorStyleEventHandler(Cursor corsur);
        public delegate void UpdateTempShapeEventHandler();

        public event ToolBarButtonsUpdatedEventHandler _toolBarButtonUpdated;
        public event ModelShapesUpdatedEventHandler _modelShapesListUpdated;
        public event UpdateCursorStyleEventHandler _cursorStyleUpdated;
        public event UpdateTempShapeEventHandler _tempShapeUpdated;

        private DrawerModel _model;
        private bool _inDrawArea;
        private bool _mouseDown;
        private ShapeType _selectedShape;
        private Point _lastMousePoint;

        public bool ToolBarLineButtonChecked
        {
            get
            {
                return _selectedShape == ShapeType.Line;
            }
        }

        public bool ToolBarRectangleButtonChecked
        {
            get
            {
                return _selectedShape == ShapeType.Rectangle;
            }
        }

        public bool ToolBarCircleButtonChecked
        {
            get
            {
                return _selectedShape == ShapeType.Circle;
            }
        }

        public bool ToolBarCursorButtonChecked
        {
            get
            {
                return _selectedShape == ShapeType.None;
            }
        }

        public BindingList<ShapeData> ShapeDatas
        {
            get
            {
                return _model.ShapeDatas;
            }
        }

        public PresentationModel(DrawerModel model)
        {
            _model = model;
            _inDrawArea = false;
            _mouseDown = false;
            _selectedShape = ShapeType.None;
            _model._shapesListUpdated += NotifyModelShapesListUpdated;
        }

        /// <summary>
        /// Handle create shape event from view.
        /// </summary>
        /// <param name="shapeType">Type of shape want to create.</param>
        /// <param name="drawAreaLowerRightCorner">The lower right corner of draw area.</param>
        public void ClickCreateShapeButton(string shapeType, Point drawAreaLowerRightCorner)
        {
            _model.CreateRandomShape(shapeType, drawAreaLowerRightCorner);
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
        public void ClickToolBarLineButton()
        {
            _selectedShape = ShapeType.Line;
            NotifyToolBarButtonCheckedUpdated();
        }

        /// <summary>
        /// Handle toolbar rectangle button click event from view.
        /// </summary>
        public void ClickToolBarRectangleButton()
        {
            _selectedShape = ShapeType.Rectangle;
            NotifyToolBarButtonCheckedUpdated();
        }

        /// <summary>
        /// Handle toolbar circle button click event from view.
        /// </summary>
        public void ClickToolBarCircleButton()
        {
            _selectedShape = ShapeType.Circle;
            NotifyToolBarButtonCheckedUpdated();
        }

        /// <summary>
        /// Clear toolbar buttons selected state.
        /// </summary>
        public void ClearToolBarButtonChecked()
        {
            _selectedShape = ShapeType.None;
            NotifyToolBarButtonCheckedUpdated();
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
        public void MouseDownInDrawArea(int xCoordinate, int yCoordinate)
        {
            _mouseDown = true;
            _lastMousePoint = new Point(xCoordinate, yCoordinate);
            if (_selectedShape == ShapeType.None)
            {
                _model.SelectedShapeAtPoint(xCoordinate, yCoordinate);
            }
            else
            {
                _model.CreateTempShape(_selectedShape, xCoordinate, yCoordinate);
                NotifyTempShapeUpdated();
            }
        }

        /// <summary>
        /// Handle draw area mouse move event from view.
        /// </summary>
        public void MouseMoveInDrawArea(int xCoordinate, int yCoordinate)
        {
            if (!_mouseDown)
                return;

            if (_selectedShape == ShapeType.None)
            {
                _model.MoveSelectedShape(xCoordinate - _lastMousePoint.X, yCoordinate - _lastMousePoint.Y);
            }
            else
            {
                _model.UpdateTempShape(xCoordinate, yCoordinate);
                NotifyTempShapeUpdated();
            }
            _lastMousePoint = new Point(xCoordinate, yCoordinate);
        }

        /// <summary>
        /// Handle draw area mouse up event from view.
        /// </summary>
        public void MouseUpInDrawArea(int xCoordinate, int yCoordinate)
        {
            if (!_mouseDown)
                return;

            if (_selectedShape == ShapeType.None)
            {
                _model.MoveSelectedShape(xCoordinate - _lastMousePoint.X, yCoordinate - _lastMousePoint.Y);
            }
            else
            {
                _model.UpdateTempShape(xCoordinate, yCoordinate);
                _model.SaveTempShape();
                ClearToolBarButtonChecked();
            }
            _mouseDown = false;
            NotifyTempShapeUpdated();
        }

        /// <summary>
        /// Draw all shapes and temp shape.
        /// </summary>
        /// <param name="graphics">Graphics of draw area.</param>
        public void DrawWithTemp(IGraphics graphics)
        {
            _model.DrawWithTemp(graphics);
        }

        public void DeleteSelectedShape()
        {
            _model.DeleteSelectedShape();
        }

        /// <summary>
        /// Notify handlers of ToolbarButtonUpdated to update.
        /// </summary>
        private void NotifyToolBarButtonCheckedUpdated()
        {
            if (_toolBarButtonUpdated != null)
                _toolBarButtonUpdated();
        }

        /// <summary>
        /// Notify handlers of ModelShapesListUpdated to update.
        /// </summary>
        private void NotifyModelShapesListUpdated()
        {
            if (_modelShapesListUpdated != null)
                _modelShapesListUpdated();
        }

        /// <summary>
        /// Notify handlers of CursorStyleUpdated to update.
        /// </summary>
        private void NotifyCursorStyleUpdated()
        {
            if (_inDrawArea && _selectedShape != ShapeType.None)
                _cursorStyleUpdated(Cursors.Cross);
            else
                _cursorStyleUpdated(Cursors.Arrow);
        }

        /// <summary>
        /// Notify handlers of NotifyTempShapeUpdated to update.
        /// </summary>
        private void NotifyTempShapeUpdated()
        {
            if (_tempShapeUpdated != null)
                _tempShapeUpdated();
        }
    }
}
