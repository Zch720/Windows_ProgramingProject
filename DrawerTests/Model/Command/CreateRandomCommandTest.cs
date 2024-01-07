// TODO: fix tests
//using Drawer.Model.ShapeObjects;
//using Microsoft.VisualStudio.TestTools.UnitTesting;

//namespace Drawer.Model.Command.Tests
//{
//    [TestClass]
//    public class CreateRandomCommandTest
//    {
//        private Shapes _shapes;

//        /// <inheritdoc/>
//        [TestInitialize]
//        public void SetUp()
//        {
//            ShapeFactory shapeFactory = new ShapeFactory();
//            _shapes = new Shapes(shapeFactory);
//        }

//        /// <inheritdoc/>
//        [TestMethod]
//        public void ExecuteCreateRandomCommand()
//        {
//            CreateRandomCommand command = new CreateRandomCommand(_shapes, new Point(100));

//            command.Execute();

//            Assert.AreEqual(1, _shapes.ShapeDatas.Count);
//        }

//        /// <inheritdoc/>
//        [TestMethod]
//        public void CancelExecuteCreateRandomCommand()
//        {
//            CreateRandomCommand command = new CreateRandomCommand(_shapes, new Point(100));
//            command.Execute();

//            command.CancelExecute();

//            Assert.AreEqual(0, _shapes.ShapeDatas.Count);
//        }

//        /// <inheritdoc/>
//        [TestMethod]
//        public void ExecuteCreateRandomCommandTwice()
//        {
//            CreateRandomCommand command = new CreateRandomCommand(_shapes, new Point(100));
//            command.Execute();
//            string shapeInfo = _shapes.ShapeDatas[0].Information;
//            command.CancelExecute();

//            command.Execute();

//            Assert.AreEqual(shapeInfo, _shapes.ShapeDatas[0].Information);
//        }
//    }
//}
