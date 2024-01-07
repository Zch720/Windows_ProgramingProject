using Drawer.Model.ShapeObjects;
using DrawerTests.FakeObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Drawer.Model.Command.Tests
{
    [TestClass]
    public class DeleteCommandTest
    {
        private DrawerModel _model;

        /// <inheritdoc/>
        [TestInitialize]
        public void SetUp()
        {
            ShapeFactory shapeFactory = new ShapeFactory();
            _model = new DrawerModel(shapeFactory, new FakeStorage());
            _model.CreateShape(ShapeType.Line, new Point(3), new Point(7));
            _model.CreateShape(ShapeType.Rectangle, new Point(11), new Point(16));
        }

        /// <inheritdoc/>
        [TestMethod]
        public void ExecuteDeleteCommand()
        {
            DeleteCommand command = new DeleteCommand(_model, 0);

            command.Execute();

            Assert.AreEqual(1, _model.ShapeDatas.Count);
            Assert.AreEqual("(11, 11), (16, 16)", _model.ShapeDatas[0].Information);
        }

        /// <inheritdoc/>
        [TestMethod]
        public void CancelExecuteDeleteCommand()
        {
            DeleteCommand command = new DeleteCommand(_model, 0);
            command.Execute();

            command.CancelExecute();

            Assert.AreEqual(2, _model.ShapeDatas.Count);
            Assert.AreEqual("(3, 3), (7, 7)", _model.ShapeDatas[0].Information);
            Assert.AreEqual("(11, 11), (16, 16)", _model.ShapeDatas[1].Information);
        }

        /// <inheritdoc/>
        [TestMethod]
        public void ExecuteDeleteCommandTwice()
        {
            DeleteCommand command = new DeleteCommand(_model, 0);
            command.Execute();
            command.CancelExecute();

            command.Execute();

            Assert.AreEqual(1, _model.ShapeDatas.Count);
            Assert.AreEqual("(11, 11), (16, 16)", _model.ShapeDatas[0].Information);
        }
    }
}
