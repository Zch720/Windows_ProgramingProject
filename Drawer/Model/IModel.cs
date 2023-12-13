using Drawer.GraphicsAdapter;
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

    public interface IModel
    {
        event ShapesUpdatedEventHandler _shapesListUpdated;
        event TempShapeUpdatedEventHandler _tempShapeUpdated;
        event TempShapeSavedEventHandler _tempShapeSaved;

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
        void DrawWithTemp(IGraphics graphics);

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
    }
}
