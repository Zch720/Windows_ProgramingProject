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

        public From(PresentationModel persentationModel)
        {
            InitializeComponent();
            _drawArea.MouseEnter += MouseEnterDrawArea;
            _drawArea.MouseLeave += MouseLeaveDrawArea;
            _drawArea.MouseDown += MouseDownInDrawArea;
            _drawArea.MouseMove += MouseMoveInDrawArea;
            _drawArea.MouseUp += MouseUpInDrawArea;
            _drawArea.Paint += DrawAreaPaint;

            _presentationModel = persentationModel;
            _presentationModel.ModelShapesListUpdated += UpdateShapeList;
            _presentationModel.ToolbarButtonUpdated += UpdateToolbarButton;
            _presentationModel.CursorStyleUpdated += UpdateCursorStyle;
            _presentationModel.TempShapeUpdated += UpdateTempShape;
        }

        /// <summary>
        /// Handle click event for _createShapeButton.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ClickCreateShapeButton(Object sender, EventArgs e)
        {
            Point drawAreaLowerRightCorner = new Point(_drawArea.Width, _drawArea.Height);
            _presentationModel.ClickCreateShapeButton(_shapeComboBox.Text, drawAreaLowerRightCorner);
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

        private void DrawAreaPaint(object sender, PaintEventArgs e)
        {
            foreach (ShapeData shapeData in _presentationModel.ShapeDatasWithTemp)
            {
                switch(shapeData.ShapeType)
                {
                    case ShapeType.Line:
                        DrawLine(e.Graphics, shapeData.Point1, shapeData.Point2);
                        break;
                    case ShapeType.Rectangle:
                        DrawRectangle(e.Graphics, shapeData.Point1, shapeData.Point2);
                        break;
                    case ShapeType.Circle:
                        DrawCircle(e.Graphics, shapeData.Point1, shapeData.Point2);
                        break;
                }
            }
        }

        private void DrawLine(Graphics graphics, Point point1, Point point2)
        {
            graphics.DrawLine(Pens.Black, point1.X, point1.Y, point2.X, point2.Y);
        }

        private void DrawRectangle(Graphics graphics, Point point1, Point point2)
        {
            float width = point2.X - point1.X;
            float height = point2.Y - point1.Y;
            graphics.DrawRectangle(Pens.Black, point1.X, point1.Y, width, height);
        }

        private void DrawCircle(Graphics graphics, Point point1, Point point2)
        {
            float width = point2.X - point1.X;
            float height = point2.Y - point1.Y;
            graphics.DrawEllipse(Pens.Black, point1.X, point1.Y, width, height);
        }

        /// <summary>
        /// Notify view the shapes in model is updated
        /// </summary>
        public void UpdateShapeList()
        {
            UpdateShapeDataGrid();
            _drawArea.Invalidate(true);
        }

        public void UpdateTempShape()
        {
            _drawArea.Invalidate(true);
        }

        /// <summary>
        /// Update the DataGridView of shapes from model
        /// </summary>
        /// <param name="shapeDatas">The shapes should be show</param>
        private void UpdateShapeDataGrid()
        {
            _shapeDataGrid.Rows.Clear();
            _shapeDataGrid.Refresh();

            foreach (ShapeData data in _presentationModel.ShapeDatas)
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
