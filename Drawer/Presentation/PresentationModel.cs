﻿// Ignore Spelling: Datas

using Drawer.Presentation.State;
using Drawer.Model.ShapeObjects;
using System.ComponentModel;
using System.Windows.Forms;
using Drawer.Model;

namespace Drawer.Presentation
{
    public class PresentationModel : INotifyPropertyChanged
    {

        public delegate void ModelShapesUpdatedEventHandler();
        public delegate void UpdateCursorStyleEventHandler(Cursor corsur);
        public delegate void UpdateTempShapeEventHandler();

        public event ModelShapesUpdatedEventHandler _modelShapesListUpdated;
        public event UpdateCursorStyleEventHandler _cursorStyleUpdated;
        public event UpdateTempShapeEventHandler _tempShapeUpdated;
        public event PropertyChangedEventHandler PropertyChanged;

        private const string LINE_CHECKED_PROP = "ToolBarLineButtonChecked";
        private const string RECTANGLE_CHECKED_PROP = "ToolBarRectangleButtonChecked";
        private const string CIRCLE_CHECKED_PROP = "ToolBarCircleButtonChecked";
        private const string CURSOR_CHECKED_PROP = "ToolBarCursorButtonChecked";

        private DrawerModel _model;
        private IState _state;
        private bool _inDrawArea;

        public bool ToolBarLineButtonChecked
        {
            get
            {
                return _state.SelectedShapeType == ShapeType.Line;
            }
        }

        public bool ToolBarRectangleButtonChecked
        {
            get
            {
                return _state.SelectedShapeType == ShapeType.Rectangle;
            }
        }

        public bool ToolBarCircleButtonChecked
        {
            get
            {
                return _state.SelectedShapeType == ShapeType.Circle;
            }
        }

        public bool ToolBarCursorButtonChecked
        {
            get
            {
                return _state.SelectedShapeType == ShapeType.None;
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
            _state = new PointerState(_model);
            _inDrawArea = false;
            _model._shapesListUpdated += NotifyModelShapesListUpdated;
            _model._tempShapeUpdated += NotifyTempShapeUpdated;
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
            _state = new DrawingState(_model, ShapeType.Line, ClearToolBarButtonChecked);
            NotifyToolBarButtonCheckedUpdated();
        }

        /// <summary>
        /// Handle toolbar rectangle button click event from view.
        /// </summary>
        public void ClickToolBarRectangleButton()
        {
            _state = new DrawingState(_model, ShapeType.Rectangle, ClearToolBarButtonChecked);
            NotifyToolBarButtonCheckedUpdated();
        }

        /// <summary>
        /// Handle toolbar circle button click event from view.
        /// </summary>
        public void ClickToolBarCircleButton()
        {
            _state = new DrawingState(_model, ShapeType.Circle, ClearToolBarButtonChecked);
            NotifyToolBarButtonCheckedUpdated();
        }

        /// <summary>
        /// Clear toolbar buttons selected state.
        /// </summary>
        public void ClearToolBarButtonChecked()
        {
            _state = new PointerState(_model);
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
            _state.HandleMouseDown(xCoordinate, yCoordinate);
        }

        /// <summary>
        /// Handle draw area mouse move event from view.
        /// </summary>
        public void MouseMoveInDrawArea(int xCoordinate, int yCoordinate)
        {
            _state.HandleMouseMove(xCoordinate, yCoordinate);
        }

        /// <summary>
        /// Handle draw area mouse up event from view.
        /// </summary>
        public void MouseUpInDrawArea(int xCoordinate, int yCoordinate)
        {
            _state.HandleMouseUp(xCoordinate, yCoordinate);
        }

        /// <summary>
        /// Draw all shapes and temp shape.
        /// </summary>
        /// <param name="graphics">Graphics of draw area.</param>
        public void DrawWithTemp(IGraphics graphics)
        {
            _model.DrawWithTemp(graphics);
        }

        /// <summary>
        /// Handle key down event from form.
        /// </summary>
        public void HandleFormKeyDown(Keys key)
        {
            if (key == Keys.Delete)
                _model.DeleteSelectedShape();
        }

        /// <summary>
        /// Notify handlers of ToolbarButtonUpdated to update.
        /// </summary>
        private void NotifyToolBarButtonCheckedUpdated()
        {
            NotifyPropertyChange(LINE_CHECKED_PROP);
            NotifyPropertyChange(RECTANGLE_CHECKED_PROP);
            NotifyPropertyChange(CIRCLE_CHECKED_PROP);
            NotifyPropertyChange(CURSOR_CHECKED_PROP);
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
            if (_inDrawArea && _state.SelectedShapeType != ShapeType.None)
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

        /// <summary>
        /// Notify property changed for databinding.
        /// </summary>
        /// <param name="propertyName">The property name in this class.</param>
        private void NotifyPropertyChange(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
