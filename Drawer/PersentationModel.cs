using Drawer.ShapeObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drawer
{
    public class PersentationModel
    {
        private const int POINT1_TOP_LEFT = 0;
        private const int POINT1_BOTTOM_RIGHT = 50;
        private const int POINT2_BOTTOM_RIGHT = 100;
        private Model _model;

        public Model Model
        {
            get
            {
                return _model;
            }
        }

        public PersentationModel(Model model)
        {
            _model = model;
        }

        public void ClickCreateShapeButton(string shapeType)
        {
            Point upperLeft = GenerateRandomPoint(new Point(POINT1_TOP_LEFT, POINT1_TOP_LEFT), new Point(POINT1_BOTTOM_RIGHT, POINT1_BOTTOM_RIGHT));
            Point lowerRight = GenerateRandomPoint(upperLeft, new Point(POINT2_BOTTOM_RIGHT, POINT2_BOTTOM_RIGHT));
            _model.CreateShape(shapeType, upperLeft, lowerRight);
        }

        public void ClickShapeDataGridCell(int columnIndex, int rowIndex)
        {
            if (columnIndex == 0 && rowIndex > 0)
                _model.DeleteShape(rowIndex);
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
