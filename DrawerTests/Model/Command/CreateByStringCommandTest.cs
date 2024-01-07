using Drawer.Model.ShapeObjects;
using DrawerTests.FakeObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Drawer.Model.Command.Tests
{
    [TestClass]
    public class CreateByStringCommandTest
    {
        DrawerModel _model;

        /// <inheritdoc/>
        [TestInitialize]
        public void SetUp()
        {
            ShapeFactory shapeFactory = new ShapeFactory();
            _model = new DrawerModel(shapeFactory, new FakeStorage());
        }

        /// <inheritdoc/>
        [TestMethod]
        public void ExecuteCreateCommand()
        {
            CreateByStringCommand command = new CreateByStringCommand(_model, "線", new Point(1), new Point(2));

            command.Execute();

            Assert.AreEqual(1, _model.ShapeDatas.Count);
        }

        /// <inheritdoc/>
        [TestMethod]
        public void CancelExecuteCreateCommand()
        {
            CreateByStringCommand command = new CreateByStringCommand(_model, "線", new Point(1), new Point(2));
            command.Execute();

            command.CancelExecute();

            Assert.AreEqual(0, _model.ShapeDatas.Count);
        }
    }
}
