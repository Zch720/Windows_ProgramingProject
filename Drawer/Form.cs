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
            _shapeComboBox.SelectedIndex = 0;

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
        private void ClickToolbarLineButton(object sender, EventArgs e)
        {
            _presentationModel.ClickToolbarLineButton();
        }

        /// <summary>
        /// Handle click event for _toolbarRectanglebutton.
        /// </summary>
        private void ClickToolbarRectangleButton(object sender, EventArgs e)
        {
            _presentationModel.ClickToolbarRectangleButton();
        }

        /// <summary>
        /// Handle click event for _toolbarCirclebutton.
        /// </summary>
        private void ClickToolbarCircleButton(object sender, EventArgs e)
        {
            _presentationModel.ClickToolbarCircleButton();
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

        /// <summary>
        /// Draw line.
        /// </summary>
        /// <param name="graphics">The graphics of drawing area.</param>
        /// <param name="point1">First point of line.</param>
        /// <param name="point2">Second point of line.</param>
        private void DrawLine(Graphics graphics, Point point1, Point point2)
        {
            graphics.DrawLine(Pens.Black, point1.X, point1.Y, point2.X, point2.Y);
        }

        /// <summary>
        /// Draw rectangle.
        /// </summary>
        /// <param name="graphics">The graphics of drawing area.</param>
        /// <param name="point1">Upper left corner of rectangle.</param>
        /// <param name="point2">Lower right corner of rectangle.</param>
        private void DrawRectangle(Graphics graphics, Point point1, Point point2)
        {
            float width = point2.X - point1.X;
            float height = point2.Y - point1.Y;
            graphics.DrawRectangle(Pens.Black, point1.X, point1.Y, width, height);
        }

        /// <summary>
        /// Draw circle.
        /// </summary>
        /// <param name="graphics">The graphics of drawing area.</param>
        /// <param name="point1">Upper left corner of circle.</param>
        /// <param name="point2">Lower right corner of circle.</param>
        private void DrawCircle(Graphics graphics, Point point1, Point point2)
        {
            float width = point2.X - point1.X;
            float height = point2.Y - point1.Y;
            graphics.DrawEllipse(Pens.Black, point1.X, point1.Y, width, height);
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
            _shapeDataGrid.Refresh();

            foreach (ShapeData data in _presentationModel.ShapeDatas)
            {
                _shapeDataGrid.Rows.Add(new DataGridViewButtonCell(), data.ShapeName, data.Information);
            }
        }

        /// <summary>
        /// Handle toolbar button selected state update.
        /// </summary>
        private void UpdateToolbarButton()
        {
            _toolbarLineButton.Checked = _presentationModel.ToolbarLineButtonChecked;
            _toolbarRectangleButton.Checked = _presentationModel.ToolbarRectangleButtonChecked;
            _toolbarCircleButton.Checked = _presentationModel.ToolbarCircleButtonChecked;
        }

        /// <summary>
        /// Handle cursor style update.
        /// </summary>
        /// <param name="cursor">The cursor style.</param>
        private void UpdateCursorStyle(Cursor cursor)
        {
            Cursor = cursor;
        }
    }
}
