using Drawer.Model.ShapeObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Drawer.Model.Command.Tests
{
    [TestClass]
    public class CommandManagerTest
    {
        Shapes _shapes;

        /// <inheritdoc/>
        [TestInitialize]
        public void SetUp()
        {
            ShapeFactory shapeFactory = new ShapeFactory();
            _shapes = new Shapes(shapeFactory);
        }
        
        /// <inheritdoc/>
        [TestMethod]
        public void CreateRandomShape()
        {
            CommandManager commandManager = new CommandManager(_shapes);

            commandManager.CreateRandomShape("線", new Point(100));

            Assert.AreEqual(1, _shapes.ShapeDatas.Count);
        }
        
        /// <inheritdoc/>
        [TestMethod]
        public void CreateShape()
        {
            CommandManager commandManager = new CommandManager(_shapes);

            commandManager.CreateShape(ShapeType.Line, new Point(1), new Point(3));

            Assert.AreEqual(1, _shapes.ShapeDatas.Count);
        }
        
        /// <inheritdoc/>
        [TestMethod]
        public void DeleteShape()
        {
            CommandManager commandManager = new CommandManager(_shapes);
            _shapes.CreateShape(ShapeType.Line, new Point(1), new Point(2));

            commandManager.DeleteShape(0);

            Assert.AreEqual(0, _shapes.ShapeDatas.Count);
        }
        
        /// <inheritdoc/>
        [TestMethod]
        public void MoveShape()
        {
            CommandManager commandManager = new CommandManager(_shapes);
            _shapes.CreateShape(ShapeType.Line, new Point(1), new Point(2));
            ShapeData originData = _shapes.ShapeDatas[0];
            _shapes.SelectShapeAtIndex(0);
            _shapes.MoveSelectedShape(new Point(4));

            commandManager.MoveShape(0, originData);

            Assert.AreEqual("(5, 5), (6, 6)", _shapes.ShapeDatas[0].Information);
        }
        
        /// <inheritdoc/>
        [TestMethod]
        public void ScaleShape()
        {
            CommandManager commandManager = new CommandManager(_shapes);
            _shapes.CreateShape(ShapeType.Line, new Point(1), new Point(2));
            ShapeData originData = _shapes.ShapeDatas[0];
            _shapes.SelectShapeAtIndex(0);
            _shapes.SetSelectedShapeScalePoint(ScalePoint.LowerRight);
            _shapes.ScaleSelectedShape(new Point(3));
            _shapes.SaveScaledShape();

            commandManager.ScaleShape(0, originData);

            Assert.AreEqual("(1, 1), (3, 3)", _shapes.ShapeDatas[0].Information);
        }

        /// <inheritdoc/>
        [TestMethod]
        public void Undo()
        {
            CommandManager commandManager = new CommandManager(_shapes);
            commandManager.CreateRandomShape("線", new Point(100));

            commandManager.Undo();

            Assert.AreEqual(0, _shapes.ShapeDatas.Count);
        }
        
        /// <inheritdoc/>
        [TestMethod]
        public void UndoButNotPreviousCommand()
        {
            CommandManager commandManager = new CommandManager(_shapes);
            commandManager.Undo();
        }
        
        /// <inheritdoc/>
        [TestMethod]
        public void Redo()
        {
            CommandManager commandManager = new CommandManager(_shapes);
            commandManager.CreateRandomShape("線", new Point(100));
            commandManager.Undo();

            commandManager.Redo();

            Assert.AreEqual(1, _shapes.ShapeDatas.Count);
        }
        
        /// <inheritdoc/>
        [TestMethod]
        public void RedoButNotNextCommand()
        {
            CommandManager commandManager = new CommandManager(_shapes);
            commandManager.Redo();
        }
        
        /// <inheritdoc/>
        [TestMethod]
        public void GetCommandManagerCommandIndexStatus()
        {
            CommandManager commandManager = new CommandManager(_shapes);

            Assert.IsFalse(commandManager.HasPreviousCommand);
            Assert.IsFalse(commandManager.HasNextCommand);
        }
    }
}
