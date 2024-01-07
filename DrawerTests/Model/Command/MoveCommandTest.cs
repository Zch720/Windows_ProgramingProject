using Drawer.Model.ShapeObjects;
using DrawerTests.FakeObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Drawer.Model.Command.Tests
{
    [TestClass]
    public class MoveCommandTest
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
        public void ExecuteMoveCommand()
        {
            ShapeData originData = _model.ShapeDatas[0];
            _model.CurrentShapes.SelectShapeAtIndex(0);
            _model.CurrentShapes.MoveSelectedShape(new Point(3));
            MoveCommand command = new MoveCommand(_model, 0, originData);
            _model.CurrentShapes.SetShapeAtIndex(0, originData);

            command.Execute();

            Assert.AreEqual("(6, 6), (10, 10)", _model.ShapeDatas[0].Information);
            Assert.AreEqual("(11, 11), (16, 16)", _model.ShapeDatas[1].Information);
        }

        /// <inheritdoc/>
        [TestMethod]
        public void CancelExecuteScaleCommand()
        {
            ShapeData originData = _model.ShapeDatas[0];
            _model.CurrentShapes.SelectShapeAtIndex(0);
            _model.CurrentShapes.MoveSelectedShape(new Point(3));
            MoveCommand command = new MoveCommand(_model, 0, originData);
            _model.CurrentShapes.SetShapeAtIndex(0, originData);

            command.CancelExecute();

            Assert.AreEqual("(3, 3), (7, 7)", _model.ShapeDatas[0].Information);
            Assert.AreEqual("(11, 11), (16, 16)", _model.ShapeDatas[1].Information);
        }
    }
}
