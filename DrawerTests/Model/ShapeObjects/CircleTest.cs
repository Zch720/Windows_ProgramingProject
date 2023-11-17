using DrawerTests;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Drawer.Model.ShapeObjects.Tests
{
    [TestClass]
    public class CircleTest
    {
        /// <inheritdoc/>
        [TestMethod]
        public void GetCircleShapeType()
        {
            Circle circle = new Circle();
            Assert.AreEqual(ShapeType.Circle, circle.Type);
        }
        
        /// <inheritdoc/>
        [TestMethod]
        public void GetCircleShapeName()
        {
            Circle circle = new Circle();
            Assert.AreEqual("圓", circle.Name);
        }
        
        /// <inheritdoc/>
        [TestMethod]
        public void GetCircleInfo()
        {
            Circle circle = new Circle();
            circle.Point1 = new Point(1, 1);
            circle.Point2 = new Point(2, 2);
            Assert.AreEqual("(1, 1), (2, 2)", circle.Info);
        }
        
        /// <inheritdoc/>
        [TestMethod]
        public void DrawCircle()
        {
            FakeGraphics graphics = new FakeGraphics();
            Circle circle = new Circle();
            circle.Draw(graphics);

            Assert.AreEqual(0, graphics.NotifyDrawLineCount);
            Assert.AreEqual(0, graphics.NotifyDrawRectangleCount);
            Assert.AreEqual(1, graphics.NotifyDrawCircleCount);
            Assert.AreEqual(0, graphics.NotifyDrawSelectBoxCount);
        }
        
        /// <inheritdoc/>
        [TestMethod]
        public void DrawSelectedCircle()
        {
            FakeGraphics graphics = new FakeGraphics();
            Circle circle = new Circle();
            circle.IsSelected = true;
            circle.Draw(graphics);

            Assert.AreEqual(0, graphics.NotifyDrawLineCount);
            Assert.AreEqual(0, graphics.NotifyDrawRectangleCount);
            Assert.AreEqual(1, graphics.NotifyDrawCircleCount);
            Assert.AreEqual(1, graphics.NotifyDrawSelectBoxCount);
        }
    }
}
