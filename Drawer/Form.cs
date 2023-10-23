using Drawer.ShapeObjects;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Drawer
{
    public partial class From : Form
    {
        private PresentationModel _presentationModel;

        public From(PresentationModel presentationModel)
        {
            InitializeComponent();
            _shapeComboBox.SelectedIndex = 0;

            _drawArea.MouseEnter += MouseEnterDrawArea;
            _drawArea.MouseLeave += MouseLeaveDrawArea;
            _drawArea.MouseDown += MouseDownInDrawArea;
            _drawArea.MouseMove += MouseMoveInDrawArea;
            _drawArea.MouseUp += MouseUpInDrawArea;
            _drawArea.Paint += DrawAreaPaint;

            _presentationModel = presentationModel;
            _presentationModel._modelShapesListUpdated += UpdateShapeList;
            _presentationModel._toolBarButtonUpdated += UpdateToolBarButton;
            _presentationModel._cursorStyleUpdated += UpdateCursorStyle;
            _presentationModel._tempShapeUpdated += UpdateTempShape;
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
            _presentationModel.DrawWithTemp(new FormGraphicsAdapter(e.Graphics));
        }

        /// <summary>
        /// Notify view the shapes in model is updated.
        /// </summary>
        public void UpdateShapeList()
        {
            UpdateShapeDataGrid();
            _drawArea.Invalidate(true);
        }

        /// <summary>
        /// Handle drawing shape udpate.
        /// </summary>
        public void UpdateTempShape()
        {
            _drawArea.Invalidate(true);
        }

        /// <summary>
        /// Update the DataGridView of shapes from model.
        /// </summary>
        /// <param name="shapeDatas">The shapes should be show.</param>
        private void UpdateShapeDataGrid()
        {
            _shapeDataGrid.Rows.Clear();

            foreach (ShapeData data in _presentationModel.ShapeDatas)
            {
                _shapeDataGrid.Rows.Add(new DataGridViewButtonCell(), data.ShapeName, data.Information);
            }
        }

        /// <summary>
        /// Handle toolbar button selected state update.
        /// </summary>
        private void UpdateToolBarButton()
        {
            _toolBarLineButton.Checked = _presentationModel.ToolBarLineButtonChecked;
            _toolBarRectangleButton.Checked = _presentationModel.ToolBarRectangleButtonChecked;
            _toolBarCircleButton.Checked = _presentationModel.ToolBarCircleButtonChecked;
        }

        /// <summary>
        /// Handle cursor style update.
        /// </summary>
        /// <param name="cursor">The cursor style.</param>
        private void UpdateCursorStyle(Cursor cursor)
        {
            SetCursor(cursor);
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
