// Ignore Spelling: Datas

using Drawer.GraphicsAdapter;
using Drawer.Model.Command;
using Drawer.Model.ShapeObjects;
using Drawer.Model.State;
using System.ComponentModel;

namespace Drawer.Model
{
    public partial class DrawerModel : IModel
    {
        public event ShapesUpdatedEventHandler _shapesListUpdated;
        public event TempShapeUpdatedEventHandler _tempShapeUpdated;
        public event TempShapeSavedEventHandler _tempShapeSaved;

        private const int DRAW_AREA_WIDTH = 1920;
        private const int DRAW_AREA_HEIGHT = 1080;
        private readonly Point _drawAreaSize;

        private IState _state;
        private Shapes _shapes;
        private Shape _tempShape;
        private CommandManager _commandManager;

        public Shapes Shapes
        {
            get
            {
                return _shapes;
            }
        }

        public CommandManager CommandManager
        {
            get
            {
                return _commandManager;
            }
        }

        public BindingList<ShapeData> ShapeDatas
        {
            get
            {
                return _shapes.ShapeDatas;
            }
        }

        public ScalePoint? IsOnScalePoint
        {
            get
            {
                return _state.CurrentScalePoint;
            }
        }

        public int ScalePointSize
        {
            set
            {
                _shapes.ScalePointSize = value;
            }
        }

        public Shape TempShape
        {
            get
            {
                return _tempShape;
            }
            set
            {
                _tempShape = value;
            }
        }

        public DrawerModel(ShapeFactory shapeFactory)
        {
            _drawAreaSize = new Point(DRAW_AREA_WIDTH, DRAW_AREA_HEIGHT);
            _shapes = new Shapes(shapeFactory);
            _commandManager = new CommandManager(_shapes);
            _tempShape = null;
            SetPointerState();
        }

        /// <summary>
        /// Set the state to pointer state.
        /// </summary>
        public void SetPointerState()
        {
            _state = new ModelPointerState(this);
        }

        public void SetPointerMoveState()
        {
            _state = new ModelPointerMoveState(this);
        }

        public void SetPointerScaleState()
        {
            _state = new ModelPointerScaleState(this);
        }

        /// <summary>
        /// Set the state to drawing state.
        /// </summary>
        public void SetDrawingState(ShapeType type)
        {
            _state = new ModelDrawingState(this, type);
        }

        /// <summary>
        /// Create a new random shape.
        /// </summary>
        /// <param name="shapeType">The shape type string.</param>
        /// <param name="lowerRight corner">The lower right corner of the area can create shape.</param>
        public void CreateRandomShape(string shapeType, Point lowerRightCorner)
        {
            _commandManager.CreateRandomShape(shapeType, _drawAreaSize);
            NotifyShapesListUpdated();
        }

        /// <summary>
        /// Delete a shape from shape list by index.
        /// </summary>
        /// <param name="index">The shape need to delete.</param>
        public void DeleteShape(int index)
        {
            _commandManager.DeleteShape(index);
            NotifyShapesListUpdated();
        }

        /// <summary>
        /// Invoke IState.SelectOrCreateShape.
        /// </summary>
        /// <param name="point">The point user input.</param>
        public void SelectOrCreateShape(Point point)
        {
            _state.SelectOrCreateShape(point);
        }

        /// <summary>
        /// Invoke IState.UpdateShape.
        /// </summary>
        /// <param name="point">The point user input.</param>
        public void UpdateShape(Point point)
        {
            _state.UpdateShape(point);
        }

        /// <summary>
        /// Invoke IState.SaveShape.
        /// </summary>
        /// <param name="point">The point user input.</param>
        public void SaveShape(Point point)
        {
            _state.SaveShape(point);
        }

        /// <summary>
        /// Draw all shapes and temp shape.
        /// </summary>
        /// <param name="graphics">Graphics of draw area.</param>
        public void DrawWithTemp(IGraphics graphics)
        {
            _shapes.DrawWithTemp(graphics);
            if (_tempShape != null)
                _tempShape.Draw(graphics);
        }

        /// <summary>
        /// Delete selected shape in shapes.
        /// </summary>
        public void DeleteSelectedShape()
        {
            _commandManager.DeleteShape(_shapes.SelectedShapeIndex);
            NotifyShapesListUpdated();
        }

        public void Undo()
        {
            _commandManager.Undo();
            NotifyShapesListUpdated();
        }

        public void Redo()
        {
            _commandManager.Redo();
            NotifyShapesListUpdated();
        }

        /// <summary>
        /// Notify handlers of ShapesListUpdated to update.
        /// </summary>
        public void NotifyShapesListUpdated()
        {
            if (_shapesListUpdated != null)
                _shapesListUpdated();
        }

        /// <summary>
        /// Notify handlers of TempShapeUpdated to update.
        /// </summary>
        public void NotifyTempShapeUpdated()
        {
            if (_tempShapeUpdated != null)
                _tempShapeUpdated();
        }

        /// <summary>
        /// Notify handlers of TempShapeSaved to update.
        /// </summary>
        public void NotifyTempShapeSaved()
        {
            if (_tempShapeSaved != null)
                _tempShapeSaved();
        }
    }
}
