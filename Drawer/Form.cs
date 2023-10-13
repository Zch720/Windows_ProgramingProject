using Drawer.ShapeObjects;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Drawer
{
    public partial class From : Form
    {
        private PersentationModel _persentationModel;

        public From(PersentationModel persentationModel)
        {
            InitializeComponent();
            _persentationModel = persentationModel;
            _persentationModel.Model.ModelShapesListUpdated += UpdateShapeList;
        }

        /// <summary>
        /// Handle click event for _createShapeButton.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ClickCreateShapeButton(Object sender, EventArgs e)
        {
            _persentationModel.ClickCreateShapeButton(_shapeComboBox.Text);
        }

        /// <summary>
        /// Handle click event for cell of _shapeDataGridView.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ClickShapeDataGridCell(object sender, DataGridViewCellEventArgs e)
        {
            _persentationModel.ClickShapeDataGridCell(e.ColumnIndex, e.RowIndex);
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
    }
}
