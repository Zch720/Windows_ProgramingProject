﻿// Ignore Spelling: Datas

using Drawer.Model.ShapeObjects;
using System.ComponentModel;
using System.Windows.Forms;
using Drawer.Model;
using Drawer.GraphicsAdapter;

namespace Drawer.Presentation
{
    public class PresentationModel : INotifyPropertyChanged
    {
        public delegate void ModelShapesUpdatedEventHandler();
        public delegate void UpdateCursorStyleEventHandler();
        public delegate void UpdateTempShapeEventHandler();

        public event ModelShapesUpdatedEventHandler _modelShapesListUpdated;
        public event UpdateCursorStyleEventHandler _cursorStyleUpdated;
        public event UpdateTempShapeEventHandler _tempShapeUpdated;
        public event PropertyChangedEventHandler PropertyChanged;

        private const string DELETE_KEY_STRING = "Delete";

        public enum CursorStatus
        {
            Pointer,
            Cross,
            SizeUpperLeft,
            SizeUpperRight
        }

        private const string LINE_CHECKED_PROP = "ToolBarLineButtonChecked";
        private const string RECTANGLE_CHECKED_PROP = "ToolBarRectangleButtonChecked";
        private const string CIRCLE_CHECKED_PROP = "ToolBarCircleButtonChecked";
        private const string CURSOR_CHECKED_PROP = "ToolBarCursorButtonChecked";

        private DrawerModel _model;
        private ShapeType _toolBarSelectedShape;
        private CursorStatus _cursorStyle;
        private bool _inDrawArea;

        private ScalePoint? IsCursorOnScalePoint
        {
            get
            {
                return _model.IsOnScalePoint;
            }
        }

        public bool ToolBarLineButtonChecked
        {
            get
            {
                return _toolBarSelectedShape == ShapeType.Line;
            }
        }

        public bool ToolBarRectangleButtonChecked
        {
            get
            {
                return _toolBarSelectedShape == ShapeType.Rectangle;
            }
        }

        public bool ToolBarCircleButtonChecked
        {
            get
            {
                return _toolBarSelectedShape == ShapeType.Circle;
            }
        }

        public bool ToolBarCursorButtonChecked
        {
            get
            {
                return _toolBarSelectedShape == ShapeType.None;
            }
        }

        public CursorStatus CursorStyle
        {
            get
            {
                return _cursorStyle;
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
            _model._tempShapeSaved += ClearToolBarButtonChecked;
            _toolBarSelectedShape = ShapeType.None;
            _cursorStyle = CursorStatus.Pointer;
            _inDrawArea = false;
            _model._shapesListUpdated += NotifyModelShapesListUpdated;
            _model._tempShapeUpdated += NotifyTempShapeUpdated;
        }

        /// <summary>
        /// Handle create shape event from view.
        /// </summary>
        /// <param name="shapeType">Type of shape want to create.</param>
        public void ClickCreateShapeButton(string shapeType)
        {
            _model.CreateRandomShape(shapeType, new Point(1920, 1080));
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
        /// Handle tool bar line button click event from view.
        /// </summary>
        public void ClickToolBarLineButton()
        {
            _toolBarSelectedShape = ShapeType.Line;
            _model.SetDrawingState(ShapeType.Line);
            NotifyToolBarButtonCheckedUpdated();
        }

        /// <summary>
        /// Handle tool bar rectangle button click event from view.
        /// </summary>
        public void ClickToolBarRectangleButton()
        {
            _toolBarSelectedShape = ShapeType.Rectangle;
            _model.SetDrawingState(ShapeType.Rectangle);
            NotifyToolBarButtonCheckedUpdated();
        }

        /// <summary>
        /// Handle tool bar circle button click event from view.
        /// </summary>
        public void ClickToolBarCircleButton()
        {
            _toolBarSelectedShape = ShapeType.Circle;
            _model.SetDrawingState(ShapeType.Circle);
            NotifyToolBarButtonCheckedUpdated();
        }

        /// <summary>
        /// Clear tool bar buttons selected state.
        /// </summary>
        public void ClearToolBarButtonChecked()
        {
            _toolBarSelectedShape = ShapeType.None;
            _model.SetPointerState();
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
        public void MouseDownInDrawArea(int xCoordinate, int yCoordinate, int drawAreaWidth, int drawAreaHeight)
        {
            int x = (int)(xCoordinate * 1920.0f / drawAreaWidth);
            int y = (int)(yCoordinate * 1080.0f / drawAreaHeight);
            _model.SelectOrCreateShape(new Point(x, y));
        }

        /// <summary>
        /// Handle draw area mouse move event from view.
        /// </summary>
        public void MouseMoveInDrawArea(int xCoordinate, int yCoordinate, int drawAreaWidth, int drawAreaHeight)
        {
            int x = (int)(xCoordinate * 1920.0f / drawAreaWidth);
            int y = (int)(yCoordinate * 1080.0f / drawAreaHeight);
            _model.UpdateShape(new Point(x, y));

            if (IsCursorOnScalePoint == ScalePoint.None)
                _cursorStyle = CursorStatus.Pointer;
            else if (IsCursorOnScalePoint == ScalePoint.UpperLeft)
                _cursorStyle = CursorStatus.SizeUpperLeft;
            else if (IsCursorOnScalePoint == ScalePoint.UpperRight)
                _cursorStyle = CursorStatus.SizeUpperRight;
            else if (IsCursorOnScalePoint == ScalePoint.LowerLeft)
                _cursorStyle = CursorStatus.SizeUpperRight;
            else if (IsCursorOnScalePoint == ScalePoint.LowerRight)
                _cursorStyle = CursorStatus.SizeUpperLeft;
            if (IsCursorOnScalePoint != null)
                NotifyCursorStyleUpdated();
        }

        /// <summary>
        /// Handle draw area mouse up event from view.
        /// </summary>
        public void MouseUpInDrawArea(int xCoordinate, int yCoordinate, int drawAreaWidth, int drawAreaHeight)
        {
            int x = (int)(xCoordinate * 1920.0f / drawAreaWidth);
            int y = (int)(yCoordinate * 1080.0f / drawAreaHeight);
            _model.SaveShape(new Point(x, y));
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
        public void HandleFormKeyDown(string keyString)
        {
            if (keyString == DELETE_KEY_STRING)
                _model.DeleteSelectedShape();
        }

        public void UpdateScalePointSize(int size)
        {
            _model.ScalePointSize = size;
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
            if (_inDrawArea && _toolBarSelectedShape != ShapeType.None)
                _cursorStyle = CursorStatus.Cross;
            if (_cursorStyleUpdated != null)
                _cursorStyleUpdated();
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
        /// Notify property changed for data binding.
        /// </summary>
        /// <param name="propertyName">The property name in this class.</param>
        private void NotifyPropertyChange(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
