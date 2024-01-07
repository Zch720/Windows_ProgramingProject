// TODO: fix tests
//using Drawer.Model.ShapeObjects;
//using Microsoft.VisualStudio.TestTools.UnitTesting;

//namespace Drawer.Model.Command.Tests
//{
//    [TestClass]
//    public class CreateCommandTest
//    {
//        Shapes _shapes;

//        /// <inheritdoc/>
//        [TestInitialize]
//        public void SetUp()
//        {
//            ShapeFactory shapeFactory = new ShapeFactory();
//            _shapes = new Shapes(shapeFactory);
//        }

//        /// <inheritdoc/>
//        [TestMethod]
//        public void ExecuteCreateCommand()
//        {
//            CreateCommand command = new CreateCommand(_shapes, new Point(1), new Point(2));

//            command.Execute();

//            Assert.AreEqual(1, _shapes.ShapeDatas.Count);
//        }

//        /// <inheritdoc/>
//        [TestMethod]
//        public void CancelExecuteCreateCommand()
//        {
//            CreateCommand command = new CreateCommand(_shapes, new Point(1), new Point(2));
//            command.Execute();

//            command.CancelExecute();

//            Assert.AreEqual(0, _shapes.ShapeDatas.Count);
//        }
//    }
//}
