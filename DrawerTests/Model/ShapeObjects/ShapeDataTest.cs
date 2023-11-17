using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Drawer.ShapeObjects.Tests
{
    [TestClass]
    public class ShapeDataTest
    {
        private static List<Shape> shapes;

        /// <inheritdoc/>
        [ClassInitialize]
        static public void SetUp(TestContext context)
        {
            shapes = new List<Shape>();
            shapes.Add(new Line());
            shapes[0].Point1 = new Point(0, 0);
            shapes[0].Point2 = new Point(1, 1);
            shapes.Add(new Rectangle());
            shapes[1].Point1 = new Point(0, 1);
            shapes[1].Point2 = new Point(3, 4);
            shapes.Add(new Circle());
            shapes[2].Point1 = new Point(3, 4);
            shapes[2].Point2 = new Point(1, 0);
            shapes.Add(new Line());
            shapes[3].Point1 = new Point(1, 0);
            shapes[3].Point2 = new Point(-2, 4);
        }

        /// <inheritdoc/>
        [TestMethod]
        [DataRow(0, "線")]
        [DataRow(1, "矩形")]
        [DataRow(2, "圓")]
        [DataRow(3, "線")]
        public void GetShapeDataName(
            int index,
            string shapeName
        )
        {
            ShapeData data = new ShapeData(shapes[index]);
            Assert.AreEqual(shapeName, data.ShapeName);
        }

        /// <inheritdoc/>
        [TestMethod]
        [DataRow(0, "(0, 0), (1, 1)")]
        [DataRow(1, "(0, 1), (3, 4)")]
        [DataRow(2, "(1, 0), (3, 4)")]
        [DataRow(3, "(1, 0), (-2, 4)")]
        public void GetShapeInformation(
            int index,
            string shapeInfo
        )
        {
            ShapeData data = new ShapeData(shapes[index]);
            Assert.AreEqual(shapeInfo, data.Information);
        }

        /// <inheritdoc/>
        [TestMethod]
        [DataRow(0, 0, 0, 1, 1)]
        [DataRow(1, 0, 1, 3, 4)]
        [DataRow(2, 3, 4, 1, 0)]
        [DataRow(3, 1, 0, -2, 4)]
        public void GetShapePoints(
            int index,
            int point1X, int point1Y,
            int point2X, int point2Y
        )
        {
            ShapeData data = new ShapeData(shapes[index]);
            Assert.AreEqual(point1X, data.Point1.X);
            Assert.AreEqual(point1Y, data.Point1.Y);
            Assert.AreEqual(point2X, data.Point2.X);
            Assert.AreEqual(point2Y, data.Point2.Y);
        }

        /// <inheritdoc/>
        [TestMethod]
        [DataRow(0, 1, 1)]
        [DataRow(1, 3, 3)]
        [DataRow(2, 2, 4)]
        [DataRow(3, 3, 4)]
        public void GetShapeSize(
            int index,
            int width,
            int height
        )
        {
            ShapeData data = new ShapeData(shapes[index]);
            Assert.AreEqual(width, data.Width);
            Assert.AreEqual(height, data.Height);
        }
    }
}
