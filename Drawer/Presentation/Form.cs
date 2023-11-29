using Drawer.GraphicsAdapter;
using System;
using System.Windows.Forms;

namespace Drawer.Presentation
{
    public partial class From : Form
    {
        private const string TOOL_STRIP_BUTTON_CHECKED_PROP = "Checked";
        private const string LINE_CHECKED_PROP = "ToolBarLineButtonChecked";
        private const string RECTANGLE_CHECKED_PROP = "ToolBarRectangleButtonChecked";
        private const string CIRCLE_CHECKED_PROP = "ToolBarCircleButtonChecked";
        private const string CURSOR_CHECKED_PROP = "ToolBarCursorButtonChecked";

        private PresentationModel _presentationModel;

        public From(PresentationModel presentationModel)
        {
            InitializeComponent();
            ResizePageList();

            KeyPreview = true;
            KeyDown += HandleFormKeyDown;
            Resize += HandleFormResize;

            _shapeComboBox.SelectedIndex = 0;

            _drawArea.MouseEnter += MouseEnterDrawArea;
            _drawArea.MouseLeave += MouseLeaveDrawArea;
            _drawArea.MouseDown += MouseDownInDrawArea;
            _drawArea.MouseMove += MouseMoveInDrawArea;
            _drawArea.MouseUp += MouseUpInDrawArea;
            _drawArea.Paint += DrawAreaPaint;

            _page1.Paint += Page1Paint;

            _presentationModel = presentationModel;
            _presentationModel._modelShapesListUpdated += UpdateShapeList;
            _presentationModel._cursorStyleUpdated += UpdateCursorStyle;
            _presentationModel._tempShapeUpdated += UpdateTempShape;

            _shapeDataGrid.DataSource = _presentationModel.ShapeDatas;
            _toolBarLineButton.DataBindings.Add(TOOL_STRIP_BUTTON_CHECKED_PROP, _presentationModel, LINE_CHECKED_PROP);
            _toolBarRectangleButton.DataBindings.Add(TOOL_STRIP_BUTTON_CHECKED_PROP, _presentationModel, RECTANGLE_CHECKED_PROP);
            _toolBarCircleButton.DataBindings.Add(TOOL_STRIP_BUTTON_CHECKED_PROP, _presentationModel, CIRCLE_CHECKED_PROP);
            _toolBarCursorButton.DataBindings.Add(TOOL_STRIP_BUTTON_CHECKED_PROP, _presentationModel, CURSOR_CHECKED_PROP);
        }

        /// <summary>
        /// Handle keyboard key down event.
        /// </summary>
        private void HandleFormKeyDown(object sender, KeyEventArgs e)
        {
            _presentationModel.HandleFormKeyDown(e.KeyCode.ToString());
        }

        /// <summary>
        /// Handle from resize.
        /// </summary>
        private void HandleFormResize(object sender, EventArgs e)
        {
            ResizePageList();
        }

        /// <summary>
        /// Resize page size by draw area size.
        /// </summary>
        private void ResizePageList()
        {
            _page1.Height = (int)(_page1.Width * (float)_drawArea.Height / _drawArea.Width);
        }

        /// <summary>
        /// Handle click event for _createShapeButton.
        /// </summary>
        private void ClickCreateShapeButton(Object sender, EventArgs e)
        {
            Point drawAreaLowerRightCorner = new Point(_drawArea.Width, _drawArea.Height);
            _presentationModel.ClickCreateShapeButton(_shapeComboBox.Text, drawAreaLowerRightCorner);
        }

        /// <summary>
        /// Handle click event for cell of _shapeDataGridView.
        /// </summary>
        private void ClickShapeDataGridCell(object sender, DataGridViewCellEventArgs e)
        {
            _presentationModel.ClickShapeDataGridCell(e.ColumnIndex, e.RowIndex);
        }

        /// <summary>
        /// Handle click event for _toolbarLinebutton.
        /// </summary>
        private void ClickToolBarLineButton(object sender, EventArgs e)
        {
            _presentationModel.ClickToolBarLineButton();
        }

        /// <summary>
        /// Handle click event for _toolbarRectanglebutton.
        /// </summary>
        private void ClickToolBarRectangleButton(object sender, EventArgs e)
        {
            _presentationModel.ClickToolBarRectangleButton();
        }

        /// <summary>
        /// Handle click event for _toolbarCirclebutton.
        /// </summary>
        private void ClickToolBarCircleButton(object sender, EventArgs e)
        {
            _presentationModel.ClickToolBarCircleButton();
        }

        /// <summary>
        /// Handle click event for _toolbarCursorbutton.
        /// </summary>
        private void ClickToolBarCursorButton(object sender, EventArgs e)
        {
            _presentationModel.ClearToolBarButtonChecked();
        }

        /// <summary>
        /// Handle mouse enter event of _drawArea.
        /// </summary>
        private void MouseEnterDrawArea(object sender, System.EventArgs e)
        {
            _presentationModel.MouseEnterDrawArea();
        }

        /// <summary>
        /// Handle mouse leave event of _drawArea.
        /// </summary>
        private void MouseLeaveDrawArea(object sender, System.EventArgs e)
        {
            _presentationModel.MouseLeaveDrawArea();
        }

        /// <summary>
        /// Handle mouse down event of _drawArea.
        /// </summary>
        private void MouseDownInDrawArea(object sender, MouseEventArgs e)
        {
            _presentationModel.MouseDownInDrawArea(e.X, e.Y);
        }

        /// <summary>
        /// Handle mouse mvoe event of _drawArea.
        /// </summary>
        private void MouseMoveInDrawArea(object sender, MouseEventArgs e)
        {
            _presentationModel.MouseMoveInDrawArea(e.X, e.Y);
        }

        /// <summary>
        /// Handle mouse up event of _drawArea.
        /// </summary>
        private void MouseUpInDrawArea(object sender, MouseEventArgs e)
        {
            _presentationModel.MouseUpInDrawArea(e.X, e.Y);
        }

        /// <summary>
        /// Handle paint event of _drawArea.
        /// </summary>
        private void DrawAreaPaint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            _presentationModel.DrawWithTemp(new DrawAreaGraphicsAdapter(e.Graphics));
        }

        /// <summary>
        /// Handle paint event of _page1.
        /// </summary>
        private void Page1Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            _presentationModel.DrawWithTemp(new PageGraphicsAdapter(e.Graphics, (float)_page1.Width / (float)_drawArea.Width));
        }

        /// <summary>
        /// Notify view the shapes in model is updated.
        /// </summary>
        public void UpdateShapeList()
        {
            _drawArea.Invalidate(true);
            _page1.Invalidate(true);
        }

        /// <summary>
        /// Handle drawing shape udpate.
        /// </summary>
        public void UpdateTempShape()
        {
            _drawArea.Invalidate(true);
            _page1.Invalidate(true);
        }

        /// <summary>
        /// Handle cursor style update.
        /// </summary>
        /// <param name="cursor">The cursor style.</param>
        private void UpdateCursorStyle()
        {
            switch (_presentationModel.CursorStyle)
            {
                case PresentationModel.CursorStatus.Pointer:
                    SetCursor(Cursors.Arrow);
                    break;
                case PresentationModel.CursorStatus.Cross:
                    SetCursor(Cursors.Cross);
                    break;
                case PresentationModel.CursorStatus.SizeUpperRight:
                    SetCursor(Cursors.SizeNESW);
                    break;
                case PresentationModel.CursorStatus.SizeUpperLeft:
                    SetCursor(Cursors.SizeNWSE);
                    break;
            }
        }

        /// <summary>
        /// Set cursor style of form.
        /// </summary>
        /// <param name="cursor">The cursor style.</param>
        private void SetCursor(Cursor cursor)
        {
            Cursor = cursor;
        }
    }
}
