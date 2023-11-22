using Microsoft.VisualStudio.TestTools.UnitTesting;
using DrawerTests;

namespace Drawer.Model.ShapeObjects.Tests
{
    [TestClass]
    public class LineTests
    {
        /// <inheritdoc/>
        [TestMethod]
        public void GetLineShapeType()
        {
            Line line = new Line();
            Assert.AreEqual(ShapeType.Line, line.Type);
        }

        /// <inheritdoc/>
        [TestMethod]
        public void GetLineShapeName()
        {
            Line line = new Line();
            Assert.AreEqual("線", line.Name);
        }

        /// <inheritdoc/>
        [TestMethod]
        public void GetLineInfo()
        {
            Line line = new Line();
            line.Point1 = new Point(1, 1);
            line.Point2 = new Point(2, 2);
            Assert.AreEqual("(1, 1), (2, 2)", line.Info);
        }

        /// <inheritdoc/>
        [TestMethod]
        public void DrawLine()
        {
            FakeGraphics graphics = new FakeGraphics();
            Line line = new Line();
            graphics.ClearAll();

            line.Draw(graphics);

            Assert.AreEqual(1, graphics.NotifyDrawLineCount);
            Assert.AreEqual(0, graphics.NotifyDrawRectangleCount);
            Assert.AreEqual(0, graphics.NotifyDrawCircleCount);
            Assert.AreEqual(0, graphics.NotifyDrawSelectBoxCount);
        }

        /// <inheritdoc/>
        [TestMethod]
        public void DrawSelectedLine()
        {
            FakeGraphics graphics = new FakeGraphics();
            Line line = new Line();
            graphics.ClearAll();
            line.IsSelected = true;

            line.Draw(graphics);

            Assert.AreEqual(1, graphics.NotifyDrawLineCount);
            Assert.AreEqual(0, graphics.NotifyDrawRectangleCount);
            Assert.AreEqual(0, graphics.NotifyDrawCircleCount);
            Assert.AreEqual(1, graphics.NotifyDrawSelectBoxCount);
            Assert.AreEqual("(0, 0), (0, 0)", graphics.SelectBoxDrawHistories[0]);
        }
    }
}