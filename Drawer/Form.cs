using Drawer.ShapeObjects;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Drawer
{
    public partial class From : Form
    {
        private const int POINT1_TOP_LEFT = 0;
        private const int POINT1_BOTTOM_RIGHT = 50;
        private const int POINT2_BOTTOM_RIGHT = 100;

        private Model _model;

        public From(Model model)
        {
            InitializeComponent();
            _model = model;
        }

        /// <summary>
        /// Handle click event for _createShapeButton.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ClickCreateShapeButton(Object sender, EventArgs e)
        {
            Point upperLeft = GenerateRandomPoint(new Point(POINT1_TOP_LEFT, POINT1_TOP_LEFT), new Point(POINT1_BOTTOM_RIGHT, POINT1_BOTTOM_RIGHT));
            Point lowerRight = GenerateRandomPoint(upperLeft, new Point (POINT2_BOTTOM_RIGHT, POINT2_BOTTOM_RIGHT));
            _model.CreateShape(_shapeComboBox.Text, upperLeft, lowerRight);

            UpdateShapeDataGridView();
        }

        /// <summary>
        /// Handle click event for cell of _shapeDataGridView.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ClickCellOfShapeDataGrid(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex != 0)
                return;
            if (e.RowIndex < 0)
                return;

            _model.DeleteShape(e.RowIndex);
            UpdateShapeDataGridView();
        }

        /// <summary>
        /// Update the DataGridView of shapes from model
        /// </summary>
        private void UpdateShapeDataGridView()
        {
            _shapeDataGrid.Rows.Clear();
            _shapeDataGrid.Refresh();

            foreach (ShapeData data in _model.ShapeDatas)
            {
                _shapeDataGrid.Rows.Add(new DataGridViewButtonCell(), data.ShapeName, data.Information);
            }
        }

        /// <summary>
        /// Generate a rendom point between upperLeft and lowerRight
        /// </summary>
        /// <param name="upperLeft">The upper left corner of random area</param>
        /// <param name="lowerRight">The lower right corner of random area</param>
        /// <returns></returns>
        private Point GenerateRandomPoint(Point upperLeft, Point lowerRight)
        {
            Random random = new Random();
            return new Point(
                random.Next(upperLeft.X, lowerRight.X),
                random.Next(upperLeft.Y, lowerRight.Y)
            );
        }
    }
}
