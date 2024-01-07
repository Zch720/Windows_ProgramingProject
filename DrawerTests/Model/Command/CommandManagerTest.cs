using Drawer.Model.ShapeObjects;
using DrawerTests.FakeObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Drawer.Model.Command.Tests
{
    [TestClass]
    public class CommandManagerTest
    {
        private DrawerModel _model;

        /// <inheritdoc/>
        [TestInitialize]
        public void SetUp()
        {
            ShapeFactory shapeFactory = new ShapeFactory();
            _model = new DrawerModel(shapeFactory, new FakeStorage());
        }

        /// <inheritdoc/>
        [TestMethod]
        public void CreateRandomShape()
        {
            CommandManager commandManager = new CommandManager(_model);

            commandManager.CreateRandomShape("線", new Point(100));

            Assert.AreEqual(1, _model.ShapeDatas.Count);
        }

        /// <inheritdoc/>
        [TestMethod]
        public void CreateShape()
        {
            CommandManager commandManager = new CommandManager(_model);

            commandManager.CreateShape(ShapeType.Line, new Point(1), new Point(3));

            Assert.AreEqual(1, _model.ShapeDatas.Count);
        }

        /// <inheritdoc/>
        [TestMethod]
        public void CreateShapeByString()
        {
            CommandManager commandManager = new CommandManager(_model);

            commandManager.CreateShape("線", new Point(1), new Point(3));

            Assert.AreEqual(1, _model.ShapeDatas.Count);
        }

        /// <inheritdoc/>
        [TestMethod]
        public void DeleteShape()
        {
            CommandManager commandManager = new CommandManager(_model);
            _model.CreateShape(ShapeType.Line, new Point(1), new Point(2));

            commandManager.DeleteShape(0);

            Assert.AreEqual(0, _model.ShapeDatas.Count);
        }

        /// <inheritdoc/>
        [TestMethod]
        public void MoveShape()
        {
            CommandManager commandManager = new CommandManager(_model);
            _model.CreateShape(ShapeType.Line, new Point(1), new Point(2));
            ShapeData originData = _model.ShapeDatas[0];
            _model.CurrentShapes.SelectShapeAtIndex(0);
            _model.CurrentShapes.MoveSelectedShape(new Point(4));

            commandManager.MoveShape(0, originData);

            Assert.AreEqual("(5, 5), (6, 6)", _model.ShapeDatas[0].Information);
        }

        /// <inheritdoc/>
        [TestMethod]
        public void ScaleShape()
        {
            CommandManager commandManager = new CommandManager(_model);
            _model.CreateShape(ShapeType.Line, new Point(1), new Point(2));
            ShapeData originData = _model.ShapeDatas[0];
            _model.CurrentShapes.SelectShapeAtIndex(0);
            _model.CurrentShapes.SetSelectedShapeScalePoint(ScalePoint.LowerRight);
            _model.CurrentShapes.ScaleSelectedShape(new Point(3));
            _model.CurrentShapes.SaveScaledShape();

            commandManager.ScaleShape(0, originData);

            Assert.AreEqual("(1, 1), (3, 3)", _model.ShapeDatas[0].Information);
        }

        /// <inheritdoc/>
        [TestMethod]
        public void CreatePage()
        {
            CommandManager commandManager = new CommandManager(_model);

            commandManager.CreatePage(1);

            PrivateObject privateModel = new PrivateObject(_model);
            List<Shapes> pages = privateModel.GetField("_pages") as List<Shapes>;
            Assert.IsNotNull(pages);
            Assert.AreEqual(2, pages.Count);
        }

        /// <inheritdoc/>
        [TestMethod]
        public void DeletePage()
        {
            CommandManager commandManager = new CommandManager(_model);
            commandManager.CreatePage(1);

            commandManager.DeletePage(1);

            PrivateObject privateModel = new PrivateObject(_model);
            List<Shapes> pages = privateModel.GetField("_pages") as List<Shapes>;
            Assert.IsNotNull(pages);
            Assert.AreEqual(1, pages.Count);
        }

        /// <inheritdoc/>
        [TestMethod]
        public void Undo()
        {
            CommandManager commandManager = new CommandManager(_model);
            commandManager.CreateRandomShape("線", new Point(100));

            commandManager.Undo();

            Assert.AreEqual(0, _model.ShapeDatas.Count);
        }

        /// <inheritdoc/>
        [TestMethod]
        public void UndoButNotPreviousCommand()
        {
            CommandManager commandManager = new CommandManager(_model);
            commandManager.Undo();
        }

        /// <inheritdoc/>
        [TestMethod]
        public void Redo()
        {
            CommandManager commandManager = new CommandManager(_model);
            commandManager.CreateRandomShape("線", new Point(100));
            commandManager.Undo();

            commandManager.Redo();

            Assert.AreEqual(1, _model.ShapeDatas.Count);
        }

        /// <inheritdoc/>
        [TestMethod]
        public void RedoButNotNextCommand()
        {
            CommandManager commandManager = new CommandManager(_model);
            commandManager.Redo();
        }

        /// <inheritdoc/>
        [TestMethod]
        public void GetCommandManagerCommandIndexStatus()
        {
            CommandManager commandManager = new CommandManager(_model);

            Assert.IsFalse(commandManager.HasPreviousCommand);
            Assert.IsFalse(commandManager.HasNextCommand);
        }
    }
}
