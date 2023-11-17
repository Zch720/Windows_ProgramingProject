using DrawerTests;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Drawer.ShapeObjects.Tests
{
    [TestClass]
    public class RectangleTest
    {
        [TestMethod]
        public void GetRectangleShapeType()
        {
            Rectangle rectangle = new Rectangle();
            Assert.AreEqual(ShapeType.Rectangle, rectangle.Type);
        }

        [TestMethod]
        public void GetRectangleShapeName()
        {
            Rectangle rectangle = new Rectangle();
            Assert.AreEqual("矩形", rectangle.Name);
        }

        [TestMethod]
        public void GetRectangleInfo()
        {
            Rectangle rectangle = new Rectangle();
            rectangle.Point1 = new Point(1, 1);
            rectangle.Point2 = new Point(2, 2);
            Assert.AreEqual("(1, 1), (2, 2)", rectangle.Info);
        }

        [TestMethod]
        public void DrawRectangle()
        {
            FakeGraphics graphics = new FakeGraphics();
            Rectangle rectangle = new Rectangle();
            rectangle.Draw(graphics);

            Assert.AreEqual(0, graphics.NotifyDrawLineCount);
            Assert.AreEqual(1, graphics.NotifyDrawRectangleCount);
            Assert.AreEqual(0, graphics.NotifyDrawCircleCount);
            Assert.AreEqual(0, graphics.NotifyDrawSelectBoxCount);
        }

        [TestMethod]
        public void DrawSelectedRectangle()
        {
            FakeGraphics graphics = new FakeGraphics();
            Rectangle rectangle = new Rectangle();
            rectangle.IsSelected = true;
            rectangle.Draw(graphics);

            Assert.AreEqual(0, graphics.NotifyDrawLineCount);
            Assert.AreEqual(1, graphics.NotifyDrawRectangleCount);
            Assert.AreEqual(0, graphics.NotifyDrawCircleCount);
            Assert.AreEqual(1, graphics.NotifyDrawSelectBoxCount);
        }
    }
}
