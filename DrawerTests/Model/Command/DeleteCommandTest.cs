// TODO: fix tests
//using Drawer.Model.ShapeObjects;
//using Microsoft.VisualStudio.TestTools.UnitTesting;

//namespace Drawer.Model.Command.Tests
//{
//    [TestClass]
//    public class DeleteCommandTest
//    {
//        private Shapes _shapes;

//        /// <inheritdoc/>
//        [TestInitialize]
//        public void SetUp()
//        {
//            ShapeFactory shapeFactory = new ShapeFactory();
//            _shapes = new Shapes(shapeFactory);
//            _shapes.CreateShape(ShapeType.Line, new Point(3), new Point(7));
//            _shapes.CreateShape(ShapeType.Rectangle, new Point(11), new Point(16));
//        }

//        /// <inheritdoc/>
//        [TestMethod]
//        public void ExecuteDeleteCommand()
//        {
//            DeleteCommand command = new DeleteCommand(_shapes);

//            command.Execute();

//            Assert.AreEqual(1, _shapes.ShapeDatas.Count);
//            Assert.AreEqual("(11, 11), (16, 16)", _shapes.ShapeDatas[0].Information);
//        }

//        /// <inheritdoc/>
//        [TestMethod]
//        public void CancelExecuteDeleteCommand()
//        {
//            DeleteCommand command = new DeleteCommand(_shapes);
//            command.Execute();

//            command.CancelExecute();

//            Assert.AreEqual(2, _shapes.ShapeDatas.Count);
//            Assert.AreEqual("(3, 3), (7, 7)", _shapes.ShapeDatas[0].Information);
//            Assert.AreEqual("(11, 11), (16, 16)", _shapes.ShapeDatas[1].Information);
//        }

//        /// <inheritdoc/>
//        [TestMethod]
//        public void ExecuteDeleteCommandTwice()
//        {
//            DeleteCommand command = new DeleteCommand(_shapes);
//            command.Execute();
//            command.CancelExecute();

//            command.Execute();

//            Assert.AreEqual(1, _shapes.ShapeDatas.Count);
//            Assert.AreEqual("(11, 11), (16, 16)", _shapes.ShapeDatas[0].Information);
//        }
//    }
//}
