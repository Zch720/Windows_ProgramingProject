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

        void SetPointerState();
        void SetDrawingState(ShapeType type);
        void CreateRandomShape(string shapeType, Point lowerRightCorner);
        void DeleteShape(int index);
        void SelectOrCreateShape(Point point);
        void UpdateShape(Point point);
        void SaveShape(Point point);
        void DrawWithTemp(IGraphics graphics);
        void DeleteSelectedShape();
        void Undo();
        void Redo();
    }
}
