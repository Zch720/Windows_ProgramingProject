// Ignore Spelling: Datas

using Drawer.Model.ShapeObjects;
using System.ComponentModel;
using System.Windows.Forms;
using Drawer.Model;
using Drawer.GraphicsAdapter;
using System;

namespace Drawer.Presentation
{
    public class PresentationModel : INotifyPropertyChanged
    {
        public delegate void ModelShapesUpdatedEventHandler();
        public delegate void UpdateCursorStyleEventHandler();
        public delegate void UpdateTempShapeEventHandler();
        public delegate void SelectedPageChangedEventHandler();
        public delegate void PageDeletedEventHandler(int index);

        public event ModelShapesUpdatedEventHandler _modelShapesListUpdated;
        public event UpdateCursorStyleEventHandler _cursorStyleUpdated;
        public event UpdateTempShapeEventHandler _tempShapeUpdated;
        public event PropertyChangedEventHandler PropertyChanged;
        public event SelectedPageChangedEventHandler _selectedPageChanged;
        public event PageDeletedEventHandler _pageDeleted;

        private const string DELETE_KEY_STRING = "Delete";
        private const float DRAW_AREA_MODEL_WIDTH = 1920.0f;
        private const float DRAW_AREA_MODEL_HEIGHT = 1080.0f;

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

        private IModel _model;
        private ShapeType _toolBarSelectedShape;
        private CursorStatus _cursorStyle;
        private bool _inDrawArea;
        private int _lastClickPage;

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

        public int ScalePointSize
        {
            set
            {
                _model.ScalePointSize = value;
            }
        }

        public bool HasPreviousCommand
        {
            get
            {
                return _model.HasPreviousCommand;
            }
        }

        public bool HasNextCommand
        {
            get
            {
                return _model.HasNextCommand;
            }
        }

        public int SelectedPage
        {
            get
            {
                return _model.SelectedPage;
            }
            set
            {
                _model.SelectedPage = value;
                //_selectedPageChanged?.Invoke();
            }
        }

        public PresentationModel(IModel model)
        {
            _model = model;
            _model._tempShapeSaved += ClearToolBarButtonChecked;
            _toolBarSelectedShape = ShapeType.None;
            _cursorStyle = CursorStatus.Pointer;
            _inDrawArea = false;
            _lastClickPage = -1;
            _model._shapesListUpdated += NotifyModelShapesListUpdated;
            _model._tempShapeUpdated += NotifyTempShapeUpdated;
            _model._selectedPageChanged += NotifySelectedPageChanged;
            _model._pageDeleted += NotifyPageDeleted;
        }

        /// <summary>
        /// Handle create shape event from view.
        /// </summary>
        /// <param name="shapeType">Type of shape want to create.</param>
        public void ClickCreateShapeButton(string shapeType)
        {
            _model.CreateRandomShape(shapeType, new Point((int)DRAW_AREA_MODEL_WIDTH, (int)DRAW_AREA_MODEL_HEIGHT));
        }

        /// <summary>
        /// Handle shape data grid view click event from view.
        /// </summary>
        /// <param name="columnIndex">The column index of clicked cell.</param>
        /// <param name="rowIndex">The row index of oed cell.</param>
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
        /// Handle tool bar undo button.
        /// </summary>
        public void ClickToolBarUndoButton()
        {
            _model.Undo();
        }

        /// <summary>
        /// Handle tool bar redo button.
        /// </summary>
        public void ClickToolBarRedoButton()
        {
            _model.Redo();
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
            int positionX = (int)(xCoordinate * DRAW_AREA_MODEL_WIDTH / drawAreaWidth);
            int positionY = (int)(yCoordinate * DRAW_AREA_MODEL_HEIGHT / drawAreaHeight);
            _model.SelectOrCreateShape(new Point(positionX, positionY));
            _lastClickPage = -1;
        }

        /// <summary>
        /// Handle draw area mouse move event from view.
        /// </summary>
        public void MouseMoveInDrawArea(int xCoordinate, int yCoordinate, int drawAreaWidth, int drawAreaHeight)
        {
            int positionX = (int)(xCoordinate * DRAW_AREA_MODEL_WIDTH / drawAreaWidth);
            int positionY = (int)(yCoordinate * DRAW_AREA_MODEL_HEIGHT / drawAreaHeight);
            _model.UpdateShape(new Point(positionX, positionY));

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
            int positionX = (int)(xCoordinate * DRAW_AREA_MODEL_WIDTH / drawAreaWidth);
            int positionY = (int)(yCoordinate * DRAW_AREA_MODEL_HEIGHT / drawAreaHeight);
            _model.SaveShape(new Point(positionX, positionY));
        }

        /// <summary>
        /// Draw all shapes and temp shape.
        /// </summary>
        /// <param name="graphics">Graphics of draw area.</param>
        public void DrawWithTemp(int index, IGraphics graphics)
        {
            _model.DrawWithTemp(index, graphics);
        }

        /// <summary>
        /// Handle key down event from form.
        /// </summary>
        public void HandleFormKeyDown(string keyString)
        {
            if (keyString == DELETE_KEY_STRING)
            {
                if (_lastClickPage == -1)
                    _model.DeleteSelectedShape();
                else
                    _model.DeletePage(SelectedPage);
            }
        }

        public void AddNewPage()
        {
            _model.AddNewPage(SelectedPage + 1);
        }

        public void ClickPage(int index)
        {
            if (index == -1) return;
            SelectedPage = index;
            _lastClickPage = index;
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

        private void NotifySelectedPageChanged()
        {
            if (_selectedPageChanged != null)
                _selectedPageChanged();
        }

        private void NotifyPageDeleted(int index)
        {
            if (_pageDeleted != null)
                _pageDeleted(index);
        }
    }
}
