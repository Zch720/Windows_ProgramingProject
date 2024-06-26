﻿using Drawer.GraphicsAdapter;
using Drawer.Model.ShapeObjects;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drawer.Model
{
    public delegate void ShapesUpdatedEventHandler();
    public delegate void TempShapeUpdatedEventHandler();
    public delegate void TempShapeSavedEventHandler();
    public delegate void SelectedPageChangedEventHandler();
    public delegate void PageCreatedEventHandler(int index);
    public delegate void PageDeletedEventHandler(int index);

    public interface IModel
    {
        event ShapesUpdatedEventHandler _shapesListUpdated;
        event TempShapeUpdatedEventHandler _tempShapeUpdated;
        event TempShapeSavedEventHandler _tempShapeSaved;
        event SelectedPageChangedEventHandler _selectedPageChanged;
        event PageCreatedEventHandler _pageCreated;
        event PageDeletedEventHandler _pageDeleted;

        BindingList<ShapeData> ShapeDatas
        {
            get;
        }

        ScalePoint? IsOnScalePoint
        {
            get;
        }

        int ScalePointSize
        {
            set;
        }

        bool HasPreviousCommand
        {
            get;
        }

        bool HasNextCommand
        {
            get;
        }

        int SelectedPage
        {
            get;
            set;
        }

        /// <summary>
        /// Set the state to pointer state.
        /// </summary>
        void SetPointerState();

        /// <summary>
        /// Set the state to drawing state.
        /// </summary>
        void SetDrawingState(ShapeType type);

        /// <summary>
        /// Create a new random shape.
        /// </summary>
        /// <param name="shapeType">The shape type string.</param>
        /// <param name="lowerRightCorner">The lower right corner of the area can create shape.</param>
        void CreateRandomShape(string shapeType, Point lowerRightCorner);

        void CreateShape(string type, Point upperLeft, Point lowerRight);

        /// <summary>
        /// Delete a shape from shape list by index.
        /// </summary>
        /// <param name="index">The shape need to delete.</param>
        void DeleteShape(int index);

        /// <summary>
        /// Invoke IState.SelectOrCreateShape.
        /// </summary>
        /// <param name="point">The point user input.</param>
        void SelectOrCreateShape(Point point);

        /// <summary>
        /// Invoke IState.UpdateShape.
        /// </summary>
        /// <param name="point">The point user input.</param>
        void UpdateShape(Point point);

        /// <summary>
        /// Invoke IState.SaveShape.
        /// </summary>
        /// <param name="point">The point user input.</param>
        void SaveShape(Point point);

        /// <summary>
        /// Draw all shapes and temp shape.
        /// </summary>
        /// <param name="graphics">Graphics of draw area.</param>
        void DrawWithTemp(int page, IGraphics graphics);

        /// <summary>
        /// Delete selected shape in shapes.
        /// </summary>
        void DeleteSelectedShape();

        /// <summary>
        /// Undo last step.
        /// </summary>
        void Undo();

        /// <summary>
        /// Redo last undo step.
        /// </summary>
        void Redo();

        void AddNewPage(int index);

        void RemovePage(int index);

        void Save();

        void Load();
    }
}
