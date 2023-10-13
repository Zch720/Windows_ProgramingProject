using Drawer.ShapeObjects;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Drawer
{
    public partial class From : Form
    {
        private PresentationModel _presentationModel;

        public From(PresentationModel persentationModel)
        {
            InitializeComponent();
            _drawArea.MouseEnter += MouseEnterDrawArea;
            _drawArea.MouseLeave += MouseLeaveDrawArea;
            _drawArea.MouseDown += MouseDownInDrawArea;
            _drawArea.MouseMove += MouseMoveInDrawArea;
            _drawArea.MouseUp += MouseUpInDrawArea;
            _presentationModel = persentationModel;
            _presentationModel.ModelShapesListUpdated += UpdateShapeList;
            _presentationModel.ToolbarButtonUpdated += UpdateToolbarButton;
            _presentationModel.CursorStyleUpdated += UpdateCursorStyle;
        }

        /// <summary>
        /// Handle click event for _createShapeButton.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ClickCreateShapeButton(Object sender, EventArgs e)
        {
            _presentationModel.ClickCreateShapeButton(_shapeComboBox.Text);
        }

        /// <summary>
        /// Handle click event for cell of _shapeDataGridView.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ClickShapeDataGridCell(object sender, DataGridViewCellEventArgs e)
        {
            _presentationModel.ClickShapeDataGridCell(e.ColumnIndex, e.RowIndex);
        }

        private void ClickToolbarLineButton(object sender, EventArgs e)
        {
            _presentationModel.ClickToolbarLineButton();
        }

        private void ClickToolbarRectangleButton(object sender, EventArgs e)
        {
            _presentationModel.ClickToolbarRectangleButton();
        }

        private void ClickToolbarCircleButton(object sender, EventArgs e)
        {
            _presentationModel.ClickToolbarCircleButton();
        }

        private void MouseEnterDrawArea(object sender, System.EventArgs e)
        {
            _presentationModel.MouseEnterDrawArea();
        }

        private void MouseLeaveDrawArea(object sender, System.EventArgs e)
        {
            _presentationModel.MouseLeaveDrawArea();
        }

        private void MouseDownInDrawArea(object sender, MouseEventArgs e)
        {
            _presentationModel.MouseDownInDrawArea(e.X, e.Y);
        }

        private void MouseMoveInDrawArea(object sender, MouseEventArgs e)
        {
            _presentationModel.MouseMoveInDrawArea(e.X, e.Y);
        }

        private void MouseUpInDrawArea(object sender, MouseEventArgs e)
        {
            _presentationModel.MouseUpInDrawArea(e.X, e.Y);
        }

        /// <summary>
        /// Notify view the shapes in model is updated
        /// </summary>
        public void UpdateShapeList(List<ShapeData> shapeDatas)
        {
            UpdateShapeDataGrid(shapeDatas);
        }

        /// <summary>
        /// Update the DataGridView of shapes from model
        /// </summary>
        /// <param name="shapeDatas">The shapes should be show</param>
        private void UpdateShapeDataGrid(List<ShapeData> shapeDatas)
        {
            _shapeDataGrid.Rows.Clear();
            _shapeDataGrid.Refresh();

            foreach (ShapeData data in shapeDatas)
            {
                _shapeDataGrid.Rows.Add(new DataGridViewButtonCell(), data.ShapeName, data.Information);
            }
        }

        private void UpdateToolbarButton()
        {
            _toolbarLineButton.Checked = _presentationModel.ToolbarLineButtonChecked;
            _toolbarRectangleButton.Checked = _presentationModel.ToolbarRectangleButtonChecked;
            _toolbarCircleButton.Checked = _presentationModel.ToolbarCircleButtonChecked;
        }

        private void UpdateCursorStyle(Cursor cursor)
        {
            Cursor = cursor;
        }
    }
}
