using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Drawer.Model.ShapeObjects.Tests
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
            shapes.Add(new Line(new Point(0, 0), new Point(1, 1)));
            shapes[0].IsSelected = false;
            shapes.Add(new Rectangle(new Point(0, 1), new Point(3, 4)));
            shapes[1].IsSelected = true;
            shapes.Add(new Circle(new Point(3, 4), new Point(1, 0)));
            shapes[2].IsSelected = true;
            shapes.Add(new Line(new Point(1, 0), new Point(-2, 4)));
            shapes[3].IsSelected = false;
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
        [DataRow(0, false)]
        [DataRow(1, true)]
        [DataRow(2, true)]
        [DataRow(3, false)]
        public void GetShapeSelectedStatus(
            int index,
            bool exceptResult
        )
        {
            ShapeData data = new ShapeData(shapes[index]);
            Assert.AreEqual(exceptResult, data.IsSelected);
        }
    }
}
