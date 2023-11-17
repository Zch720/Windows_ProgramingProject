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
    }
}
