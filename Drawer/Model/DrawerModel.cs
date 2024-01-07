// Ignore Spelling: Datas

using Drawer.GraphicsAdapter;
using Drawer.Model.Command;
using Drawer.Model.ShapeObjects;
using Drawer.Model.State;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Web.Script.Serialization;

namespace Drawer.Model
{
    public class DrawerModel : IModel
    {
        public event ShapesUpdatedEventHandler _shapesListUpdated;
        public event TempShapeUpdatedEventHandler _tempShapeUpdated;
        public event TempShapeSavedEventHandler _tempShapeSaved;
        public event SelectedPageChangedEventHandler _selectedPageChanged;
        public event PageCreatedEventHandler _pageCreated;
        public event PageDeletedEventHandler _pageDeleted;

        private const int DRAW_AREA_WIDTH = 1920;
        private const int DRAW_AREA_HEIGHT = 1080;
        private readonly Point _drawAreaSize;

        private ShapeFactory _shapeFactory;
        private IState _state;
        private List<Shapes> _pages;
        private BindingList<ShapeData> _shapeDatas;
        private Shape _tempShape;
        private CommandManager _commandManager;
        private int _selectedPage;
        private IStorage _storage;

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
                return _shapeDatas;
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
                if (_selectedPage != -1)
                    _pages[_selectedPage].ScalePointSize = value;
            }
        }

        public Shape TempShape
        {
            set
            {
                _tempShape = value;
            }
        }

        public bool HasPreviousCommand
        {
            get
            {
                return _commandManager.HasPreviousCommand;
            }
        }

        public bool HasNextCommand
        {
            get
            {
                return _commandManager.HasNextCommand;
            }
        }

        public int SelectedPage
        {
            get
            {
                return _selectedPage;
            }
            set
            {
                _selectedPage = value;
                _shapeDatas.Clear();
                foreach (ShapeData data in _pages[value].ShapeDatas)
                {
                    _shapeDatas.Add(data);
                }
                NotifySelectedPageChanged();
            }
        }

        public Shapes CurrentShapes
        {
            get
            {
                return _pages[_selectedPage];
            }
        }

        public DrawerModel(ShapeFactory shapeFactory, IStorage storage)
        {
            _shapeFactory = shapeFactory;
            _storage = storage;
            _drawAreaSize = new Point(DRAW_AREA_WIDTH, DRAW_AREA_HEIGHT);
            _pages = new List<Shapes>();
            _pages.Add(GetNewShapes());
            _shapeDatas = new BindingList<ShapeData>();
            _commandManager = new CommandManager(this);
            _tempShape = null;
            _selectedPage = 0;
            SetPointerState();
        }

        private Shapes GetNewShapes()
        {
            Shapes shapes = new Shapes(_shapeFactory);
            shapes._shapesAdded += (i) => _shapeDatas.Insert(i, _pages[_selectedPage].ShapeDatas[i]);
            shapes._shapesUpdated += (i) => _shapeDatas[i] = _pages[_selectedPage].ShapeDatas[i];
            shapes._shapesDeleted += (i) => {
                _shapeDatas.RemoveAt(i);
            };
            return shapes;
        }
        
        /// <inheritdoc/>
        public void SetPointerState()
        {
            _state = new ModelPointerState(this);
        }

        /// <summary>
        /// Set the state to pointer move state.
        /// </summary>
        public void SetPointerMoveState()
        {
            _state = new ModelPointerMoveState(this);
        }

        /// <summary>
        /// Set the state to pointer scale state.
        /// </summary>
        public void SetPointerScaleState()
        {
            _state = new ModelPointerScaleState(this);
        }

        /// <inheritdoc/>
        public void SetDrawingState(ShapeType type)
        {
            _state = new ModelDrawingState(this, type);
        }

        /// <inheritdoc/>
        public void CreateRandomShape(string shapeType, Point lowerRightCorner)
        {
            _commandManager.CreateRandomShape(shapeType, _drawAreaSize);
            NotifyShapesListUpdated();
        }

        /// <inheritdoc/>
        public void CreateShape(string type, Point upperLeft, Point lowerRight)
        {
            _commandManager.CreateShape(type, upperLeft, lowerRight);
            NotifyShapesListUpdated();
        }

        /// <inheritdoc/>
        public void CreateShape(ShapeType type, Point upperLeft, Point lowerRight)
        {
            _commandManager.CreateShape(type, upperLeft, lowerRight);
            NotifyShapesListUpdated();
        }

        /// <inheritdoc/>
        public void DeleteShape(int index)
        {
            if (index < 0 || _pages[_selectedPage].ShapeDatas.Count <= index)
                return;
            _commandManager.DeleteShape(index);
            NotifyShapesListUpdated();
        }

        /// <inheritdoc/>
        public void SelectOrCreateShape(Point point)
        {
            _state.SelectOrCreateShape(point);
        }

        /// <inheritdoc/>
        public void UpdateShape(Point point)
        {
            _state.UpdateShape(point);
        }

        /// <inheritdoc/>
        public void SaveShape(Point point)
        {
            _state.SaveShape(point);
        }

        /// <inheritdoc/>
        public void DrawWithTemp(int index, IGraphics graphics)
        {
            _pages[index].Draw(graphics);
            if (_tempShape != null && index == _selectedPage)
                _tempShape.Draw(graphics);
        }

        /// <inheritdoc/>
        public void DeleteSelectedShape()
        {
            if (_pages[_selectedPage].SelectedShapeIndex == -1)
                return;
            _commandManager.DeleteShape(_pages[_selectedPage].SelectedShapeIndex);
            NotifyShapesListUpdated();
        }

        /// <inheritdoc/>
        public void Undo()
        {
            _commandManager.Undo();
            NotifyShapesListUpdated();
        }

        /// <inheritdoc/>
        public void Redo()
        {
            _commandManager.Redo();
            NotifyShapesListUpdated();
        }

        public void AddNewPage(int index)
        {
            _commandManager.CreatePage(index);
        }

        public void RemovePage(int index)
        {
            _commandManager.DeletePage(index);
        }

        public void CreateNewPage(int index)
        {
            _pages.Insert(index, GetNewShapes());
            NotifyPageCreated(index);
        }

        public void DeletePage(int index)
        {
            _pages.RemoveAt(index);
            NotifyPageDeleted(index);
            if (index >= _pages.Count)
                SelectedPage = _pages.Count - 1;
            else
                SelectedPage = index;
        }

        public void Save()
        {
            const string NEW_LINE = "\n";
            StringBuilder datas = new StringBuilder();
            datas.Append(_pages.Count).Append(NEW_LINE);
            foreach (Shapes page in _pages)
            {
                datas.Append(page.ShapeDatas.Count).Append(NEW_LINE);
                foreach (ShapeData shape in page.ShapeDatas)
                {
                    datas.Append(shape.ShapeName).Append(NEW_LINE);
                    datas.Append(shape.Point1.X).Append(NEW_LINE);
                    datas.Append(shape.Point1.Y).Append(NEW_LINE);
                    datas.Append(shape.Point2.X).Append(NEW_LINE);
                    datas.Append(shape.Point2.Y).Append(NEW_LINE);
                }
            }
            _storage.Save(datas.ToString());
        }

        public void Load()
        {
            string rawData = _storage.Load();
            string[] lines = rawData.Split('\n');
            int lineCounter = 0;
            int pageCount = int.Parse(lines[lineCounter++]);

            for (int i = 0; i < _pages.Count; i++)
                NotifyPageDeleted(0);
            _pages.Clear();
            for (int i = 0; i < pageCount; i++)
            {
                Shapes page = GetNewShapes();
                _pages.Add(page);
                NotifyPageCreated(i);
                SelectedPage = i;
                int shapesCount = int.Parse(lines[lineCounter++]);
                for (int j = 0; j < shapesCount; j++)
                {
                    string name = lines[lineCounter++];
                    int point1X = int.Parse(lines[lineCounter++]);
                    int point1Y = int.Parse(lines[lineCounter++]);
                    int point2X = int.Parse(lines[lineCounter++]);
                    int point2Y = int.Parse(lines[lineCounter++]);
                    page.CreateShape(name, new Point(point1X, point1Y), new Point(point2X, point2Y));
                }
            }
            SelectedPage = 0;
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

        public void NotifySelectedPageChanged()
        {
            if (_selectedPageChanged != null)
                _selectedPageChanged();
        }

        public void NotifyPageCreated(int index)
        {
            if (_pageCreated != null)
                _pageCreated(index);
        }

        public void NotifyPageDeleted(int index)
        {
            if (_pageDeleted != null)
                _pageDeleted(index);
        }
    }
}
