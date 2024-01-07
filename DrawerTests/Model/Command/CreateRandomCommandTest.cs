using Drawer.Model.ShapeObjects;
using DrawerTests.FakeObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Drawer.Model.Command.Tests
{
    [TestClass]
    public class CreateRandomCommandTest
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
        public void ExecuteCreateRandomCommand()
        {
            CreateRandomCommand command = new CreateRandomCommand(_model, "線", new Point(100));

            command.Execute();

            Assert.AreEqual(1, _model.ShapeDatas.Count);
        }

        /// <inheritdoc/>
        [TestMethod]
        public void CancelExecuteCreateRandomCommand()
        {
            CreateRandomCommand command = new CreateRandomCommand(_model, "線", new Point(100));
            command.Execute();

            command.CancelExecute();

            Assert.AreEqual(0, _model.ShapeDatas.Count);
        }

        /// <inheritdoc/>
        [TestMethod]
        public void ExecuteCreateRandomCommandTwice()
        {
            CreateRandomCommand command = new CreateRandomCommand(_model, "線", new Point(100));
            command.Execute();
            string shapeInfo = _model.ShapeDatas[0].Information;
            command.CancelExecute();

            command.Execute();

            Assert.AreEqual(shapeInfo, _model.ShapeDatas[0].Information);
        }
    }
}
