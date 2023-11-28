﻿using DrawerTests;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Drawer.Model.ShapeObjects.Tests
{
    [TestClass]
    public class RectangleTest
    {
        /// <inheritdoc/>
        [TestMethod]
        public void GetRectangleShapeType()
        {
            Rectangle rectangle = new Rectangle();
            Assert.AreEqual(ShapeType.Rectangle, rectangle.Type);
        }
        
        /// <inheritdoc/>
        [TestMethod]
        public void GetRectangleShapeName()
        {
            Rectangle rectangle = new Rectangle();
            Assert.AreEqual("矩形", rectangle.Name);
        }
        
        /// <inheritdoc/>
        [TestMethod]
        public void GetRectangleInfo()
        {
            Rectangle rectangle = new Rectangle(new Point(1, 1), new Point(2, 2));
            Assert.AreEqual("(1, 1), (2, 2)", rectangle.Info);
        }
        
        /// <inheritdoc/>
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
        
        /// <inheritdoc/>
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
