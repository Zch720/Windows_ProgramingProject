using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Drawer.ShapeObjects.Tests
{
    [TestClass]
    public class ShapeFactoryTest
    {
        private static Point fakeDrawAreaSize;

        [ClassInitialize]
        public static void SetUp(TestContext context)
        {
            fakeDrawAreaSize = new Point(100, 100);
        }
    
        [TestMethod]
        public void CreateRandomLine()
        {
            ShapeFactory factory = new ShapeFactory();
            Shape shape = factory.CreateRandom("線", fakeDrawAreaSize);
            Assert.IsTrue(shape is Line);
        }

        [TestMethod]
        public void CreateRandomRectangle()
        {
            ShapeFactory factory = new ShapeFactory();
            Shape shape = factory.CreateRandom("矩形", fakeDrawAreaSize);
            Assert.IsTrue(shape is Rectangle);
        }

        [TestMethod]
        public void CreateRandomCircle()
        {
            ShapeFactory factory = new ShapeFactory();
            Shape shape = factory.CreateRandom("圓", fakeDrawAreaSize);
            Assert.IsTrue(shape is Circle);
        }

        [TestMethod]
        public void CreateRandomShapeWithInvalidType()
        {
            ShapeFactory factory = new ShapeFactory();
            Assert.ThrowsException<Exception>(() => {
                factory.CreateRandom("invalid type", fakeDrawAreaSize);
            });
        }

        [TestMethod]
        public void CreateLineByShapeTypeString()
        {
            ShapeFactory factory = new ShapeFactory();
            Shape shape = factory.Create("線", new Point(3, 0), new Point(1, 4));

            Assert.IsTrue(shape is Line);
            Assert.AreEqual(3, shape.Point1.X);
            Assert.AreEqual(0, shape.Point1.Y);
            Assert.AreEqual(1, shape.Point2.X);
            Assert.AreEqual(4, shape.Point2.Y);
        }

        [TestMethod]
        public void CreateRectangleByShapeTypeString()
        {
            ShapeFactory factory = new ShapeFactory();
            Shape shape = factory.Create("矩形", new Point(5, 2), new Point(3, 7));

            Assert.IsTrue(shape is Rectangle);
            Assert.AreEqual(5, shape.Point1.X);
            Assert.AreEqual(2, shape.Point1.Y);
            Assert.AreEqual(3, shape.Point2.X);
            Assert.AreEqual(7, shape.Point2.Y);
        }

        [TestMethod]
        public void CreateCircleByShapeTypeString()
        {
            ShapeFactory factory = new ShapeFactory();
            Shape shape = factory.Create("圓", new Point(4, 2), new Point(5, 9));

            Assert.IsTrue(shape is Circle);
            Assert.AreEqual(4, shape.Point1.X);
            Assert.AreEqual(2, shape.Point1.Y);
            Assert.AreEqual(5, shape.Point2.X);
            Assert.AreEqual(9, shape.Point2.Y);
        }

        [TestMethod]
        public void CreateShapeWithInvalidShapeTypeString()
        {
            ShapeFactory factory = new ShapeFactory();
            Assert.ThrowsException<Exception>(() => {
                factory.Create("invalid type", new Point(0, 1), new Point(4, 7));
            });
        }

        [TestMethod]
        public void CreateLineByShapeTypeEnum()
        {
            ShapeFactory factory = new ShapeFactory();
            Shape shape = factory.Create(ShapeType.Line, new Point(3, 0), new Point(1, 4));

            Assert.IsTrue(shape is Line);
            Assert.AreEqual(3, shape.Point1.X);
            Assert.AreEqual(0, shape.Point1.Y);
            Assert.AreEqual(1, shape.Point2.X);
            Assert.AreEqual(4, shape.Point2.Y);
        }

        [TestMethod]
        public void CreateRectangleByShapeTypeEnum()
        {
            ShapeFactory factory = new ShapeFactory();
            Shape shape = factory.Create(ShapeType.Rectangle, new Point(5, 2), new Point(3, 7));

            Assert.IsTrue(shape is Rectangle);
            Assert.AreEqual(5, shape.Point1.X);
            Assert.AreEqual(2, shape.Point1.Y);
            Assert.AreEqual(3, shape.Point2.X);
            Assert.AreEqual(7, shape.Point2.Y);
        }

        [TestMethod]
        public void CreateCircleByShapeTypeEnum()
        {
            ShapeFactory factory = new ShapeFactory();
            Shape shape = factory.Create(ShapeType.Circle, new Point(4, 2), new Point(5, 9));

            Assert.IsTrue(shape is Circle);
            Assert.AreEqual(4, shape.Point1.X);
            Assert.AreEqual(2, shape.Point1.Y);
            Assert.AreEqual(5, shape.Point2.X);
            Assert.AreEqual(9, shape.Point2.Y);
        }

        [TestMethod]
        public void CreateShapeWithInvalidShapeTypeEnum()
        {
            ShapeFactory factory = new ShapeFactory();
            Assert.ThrowsException<Exception>(() => {
                factory.Create(ShapeType.None, new Point(0, 1), new Point(4, 7));
            });
        }
    }
}
