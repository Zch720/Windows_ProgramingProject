﻿using Drawer.ShapeObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drawer
{
    public class PresentationModel
    {
        private const int POINT1_TOP_LEFT = 0;
        private const int POINT1_BOTTOM_RIGHT = 50;
        private const int POINT2_BOTTOM_RIGHT = 100;

        public delegate void ToolbarButtonsUpdatedEventHandler();
        public delegate void ModelShapesUpdatedEventHandler(List<ShapeData> shapeDatas);

        public event ToolbarButtonsUpdatedEventHandler ToolbarButtonUpdated;
        public event ModelShapesUpdatedEventHandler ModelShapesListUpdated;

        private Model _model;
        private bool _toolbarLineButtonChecked;
        private bool _toolbarRectangleButtonChecked;
        private bool _toolbarCircleButtonChecked;

        public bool ToolbarLineButtonChecked
        {
            get
            {
                return _toolbarLineButtonChecked;
            }
        }

        public bool ToolbarRectangleButtonChecked
        {
            get
            {
                return _toolbarRectangleButtonChecked;
            }
        }

        public bool ToolbarCircleButtonChecked
        {
            get
            {
                return _toolbarCircleButtonChecked;
            }
        }

        public PresentationModel(Model model)
        {
            _model = model;
            _toolbarLineButtonChecked = false;
            _toolbarRectangleButtonChecked = false;
            _toolbarCircleButtonChecked = false;
            _model.ShapesListUpdated += NotifyModelShapesListUpdated;
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

        public void ClickToolbarLineButton()
        {
            _toolbarLineButtonChecked = true;
            _toolbarRectangleButtonChecked = false;
            _toolbarCircleButtonChecked = false;
            NotifyToolbarButtonCheckedUpdate();
        }

        public void ClickToolbarRectangleButton()
        {
            _toolbarLineButtonChecked = false;
            _toolbarRectangleButtonChecked = true;
            _toolbarCircleButtonChecked = false;
            NotifyToolbarButtonCheckedUpdate();
        }

        public void ClickToolbarCircleButton()
        {
            _toolbarLineButtonChecked = false;
            _toolbarRectangleButtonChecked = false;
            _toolbarCircleButtonChecked = true;
            NotifyToolbarButtonCheckedUpdate();
        }

        public void ClearToolbarButtonChecked()
        {
            _toolbarLineButtonChecked = false;
            _toolbarRectangleButtonChecked = false;
            _toolbarCircleButtonChecked = false;
            NotifyToolbarButtonCheckedUpdate();
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

        private void NotifyToolbarButtonCheckedUpdate()
        {
            if (ToolbarButtonUpdated != null)
                ToolbarButtonUpdated();
        }

        private void NotifyModelShapesListUpdated(List<ShapeData> shapeDatas)
        {
            if (ModelShapesListUpdated != null)
                ModelShapesListUpdated(shapeDatas);
        }
    }
}
