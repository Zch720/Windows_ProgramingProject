using Drawer.Model.ShapeObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Drawer.Model.Command.Tests
{
    [TestClass]
    public class MoveCommandTest
    {
        private Shapes _shapes;

        /// <inheritdoc/>
        [TestInitialize]
        public void SetUp()
        {
            ShapeFactory shapeFactory = new ShapeFactory();
            _shapes = new Shapes(shapeFactory);
            _shapes.CreateShape(ShapeType.Line, new Point(3), new Point(7));
            _shapes.CreateShape(ShapeType.Rectangle, new Point(11), new Point(16));
        }

        /// <inheritdoc/>
        [TestMethod]
        public void ExecuteMoveCommand()
        {
            ShapeData originData = _shapes.ShapeDatas[0];
            _shapes.SelectShapeAtIndex(0);
            _shapes.MoveSelectedShape(new Point(3));
            MoveCommand command = new MoveCommand(_shapes, originData);
            _shapes.SetShapeAtIndex(0, originData);

            command.Execute();

            Assert.AreEqual("(6, 6), (10, 10)", _shapes.ShapeDatas[0].Information);
            Assert.AreEqual("(11, 11), (16, 16)", _shapes.ShapeDatas[1].Information);
        }
        
        /// <inheritdoc/>
        [TestMethod]
        public void CancelExecuteScaleCommand()
        {
            ShapeData originData = _shapes.ShapeDatas[0];
            _shapes.SelectShapeAtIndex(0);
            _shapes.MoveSelectedShape(new Point(3));
            MoveCommand command = new MoveCommand(_shapes, originData);
            _shapes.SetShapeAtIndex(0, originData);

            command.CancelExecute();

            Assert.AreEqual("(3, 3), (7, 7)", _shapes.ShapeDatas[0].Information);
            Assert.AreEqual("(11, 11), (16, 16)", _shapes.ShapeDatas[1].Information);
        }
    }
}
