using DrawerTests;
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

        [TestMethod]
        public void ScaleRectangleFromLowerRightToLowerRight()
        {
            Rectangle rectangle = new Rectangle(new Point(1, 1), new Point(7, 7));

            rectangle.SelectedScalePoint = ScalePoint.LowerRight;
            rectangle.Scale(new Point(5, 6));

            Assert.AreEqual("(1, 1)", rectangle.UpperLeft.ToString());
            Assert.AreEqual("(5, 6)", rectangle.LowerRight.ToString());
            Assert.AreEqual(ScalePoint.LowerRight, rectangle.SelectedScalePoint);
        }

        [TestMethod]
        public void ScaleRectangleFromLowerRightToUpperRight()
        {
            Rectangle rectangle = new Rectangle(new Point(5, 5), new Point(7, 7));

            rectangle.SelectedScalePoint = ScalePoint.LowerRight;
            rectangle.Scale(new Point(8, 3));

            Assert.AreEqual("(5, 3)", rectangle.UpperLeft.ToString());
            Assert.AreEqual("(8, 5)", rectangle.LowerRight.ToString());
            Assert.AreEqual(ScalePoint.UpperRight, rectangle.SelectedScalePoint);
        }

        [TestMethod]
        public void ScaleRectangleFromLowerRightToLowerLeft()
        {
            Rectangle rectangle = new Rectangle(new Point(5, 5), new Point(7, 7));

            rectangle.SelectedScalePoint = ScalePoint.LowerRight;
            rectangle.Scale(new Point(3, 8));

            Assert.AreEqual("(3, 5)", rectangle.UpperLeft.ToString());
            Assert.AreEqual("(5, 8)", rectangle.LowerRight.ToString());
            Assert.AreEqual(ScalePoint.LowerLeft, rectangle.SelectedScalePoint);
        }

        [TestMethod]
        public void ScaleRectangleFromLowerRightToUpperLeft()
        {
            Rectangle retangle = new Rectangle(new Point(5, 5), new Point(7, 7));

            retangle.SelectedScalePoint = ScalePoint.LowerRight;
            retangle.Scale(new Point(3, 4));

            Assert.AreEqual("(3, 4)", retangle.UpperLeft.ToString());
            Assert.AreEqual("(5, 5)", retangle.LowerRight.ToString());
            Assert.AreEqual(ScalePoint.UpperLeft, retangle.SelectedScalePoint);
        }

        [TestMethod]
        public void ScaleRectangleFromLowerLeftToLowerLeft()
        {
            Rectangle rectangle = new Rectangle(new Point(5, 5), new Point(7, 7));

            rectangle.SelectedScalePoint = ScalePoint.LowerLeft;
            rectangle.Scale(new Point(6, 8));

            Assert.AreEqual("(6, 5)", rectangle.UpperLeft.ToString());
            Assert.AreEqual("(7, 8)", rectangle.LowerRight.ToString());
            Assert.AreEqual(ScalePoint.LowerLeft, rectangle.SelectedScalePoint);
        }

        [TestMethod]
        public void ScaleRectangleFromLowerLeftToLowerRight()
        {
            Rectangle rectangle = new Rectangle(new Point(5, 5), new Point(7, 7));

            rectangle.SelectedScalePoint = ScalePoint.LowerLeft;
            rectangle.Scale(new Point(9, 8));

            Assert.AreEqual("(7, 5)", rectangle.UpperLeft.ToString());
            Assert.AreEqual("(9, 8)", rectangle.LowerRight.ToString());
            Assert.AreEqual(ScalePoint.LowerRight, rectangle.SelectedScalePoint);
        }

        [TestMethod]
        public void ScaleRectangleFromLowerLeftToUpperLeft()
        {
            Rectangle rectangle = new Rectangle(new Point(5, 5), new Point(7, 7));

            rectangle.SelectedScalePoint = ScalePoint.LowerLeft;
            rectangle.Scale(new Point(3, 4));

            Assert.AreEqual("(3, 4)", rectangle.UpperLeft.ToString());
            Assert.AreEqual("(7, 5)", rectangle.LowerRight.ToString());
            Assert.AreEqual(ScalePoint.UpperLeft, rectangle.SelectedScalePoint);
        }

        [TestMethod]
        public void ScaleRectangleFromLowerLeftToUpperRight()
        {
            Rectangle rectangle = new Rectangle(new Point(5, 5), new Point(7, 7));

            rectangle.SelectedScalePoint = ScalePoint.LowerLeft;
            rectangle.Scale(new Point(9, 3));

            Assert.AreEqual("(7, 3)", rectangle.UpperLeft.ToString());
            Assert.AreEqual("(9, 5)", rectangle.LowerRight.ToString());
            Assert.AreEqual(ScalePoint.UpperRight, rectangle.SelectedScalePoint);
        }

        [TestMethod]
        public void ScaleRectangleFromUpperLeftToUpperLeft()
        {
            Rectangle rectangle = new Rectangle(new Point(5, 5), new Point(7, 7));

            rectangle.SelectedScalePoint = ScalePoint.UpperLeft;
            rectangle.Scale(new Point(6, 3));

            Assert.AreEqual("(6, 3)", rectangle.UpperLeft.ToString());
            Assert.AreEqual("(7, 7)", rectangle.LowerRight.ToString());
            Assert.AreEqual(ScalePoint.UpperLeft, rectangle.SelectedScalePoint);
        }

        [TestMethod]
        public void ScaleRectangleFromUpperLeftToLowerLeft()
        {
            Rectangle rectangle = new Rectangle(new Point(5, 5), new Point(7, 7));

            rectangle.SelectedScalePoint = ScalePoint.UpperLeft;
            rectangle.Scale(new Point(4, 8));

            Assert.AreEqual("(4, 7)", rectangle.UpperLeft.ToString());
            Assert.AreEqual("(7, 8)", rectangle.LowerRight.ToString());
            Assert.AreEqual(ScalePoint.LowerLeft, rectangle.SelectedScalePoint);
        }

        [TestMethod]
        public void ScaleRectangleFromUpperLeftToLowerRight()
        {
            Rectangle rectangle = new Rectangle(new Point(5, 5), new Point(7, 7));

            rectangle.SelectedScalePoint = ScalePoint.UpperLeft;
            rectangle.Scale(new Point(8, 9));

            Assert.AreEqual("(7, 7)", rectangle.UpperLeft.ToString());
            Assert.AreEqual("(8, 9)", rectangle.LowerRight.ToString());
            Assert.AreEqual(ScalePoint.LowerRight, rectangle.SelectedScalePoint);
        }

        [TestMethod]
        public void ScaleRectangleFromUpperLeftToUpperRight()
        {
            Rectangle rectangle = new Rectangle(new Point(5, 5), new Point(7, 7));

            rectangle.SelectedScalePoint = ScalePoint.UpperLeft;
            rectangle.Scale(new Point(9, 4));

            Assert.AreEqual("(7, 4)", rectangle.UpperLeft.ToString());
            Assert.AreEqual("(9, 7)", rectangle.LowerRight.ToString());
            Assert.AreEqual(ScalePoint.UpperRight, rectangle.SelectedScalePoint);
        }

        [TestMethod]
        public void ScaleRectangleFromUpperRightToUpperRight()
        {
            Rectangle rectangle = new Rectangle(new Point(5, 5), new Point(7, 7));

            rectangle.SelectedScalePoint = ScalePoint.UpperRight;
            rectangle.Scale(new Point(6, 3));

            Assert.AreEqual("(5, 3)", rectangle.UpperLeft.ToString());
            Assert.AreEqual("(6, 7)", rectangle.LowerRight.ToString());
            Assert.AreEqual(ScalePoint.UpperRight, rectangle.SelectedScalePoint);
        }

        [TestMethod]
        public void ScaleRectangleFromUpperRightToUpperLeft()
        {
            Rectangle rectangle = new Rectangle(new Point(5, 5), new Point(7, 7));

            rectangle.SelectedScalePoint = ScalePoint.UpperRight;
            rectangle.Scale(new Point(3, 4));

            Assert.AreEqual("(3, 4)", rectangle.UpperLeft.ToString());
            Assert.AreEqual("(5, 7)", rectangle.LowerRight.ToString());
            Assert.AreEqual(ScalePoint.UpperLeft, rectangle.SelectedScalePoint);
        }

        [TestMethod]
        public void ScaleRectangleFromUpperRightToLowerLeft()
        {
            Rectangle rectangle = new Rectangle(new Point(5, 5), new Point(7, 7));

            rectangle.SelectedScalePoint = ScalePoint.UpperRight;
            rectangle.Scale(new Point(3, 8));

            Assert.AreEqual("(3, 7)", rectangle.UpperLeft.ToString());
            Assert.AreEqual("(5, 8)", rectangle.LowerRight.ToString());
            Assert.AreEqual(ScalePoint.LowerLeft, rectangle.SelectedScalePoint);
        }

        [TestMethod]
        public void ScaleRectangleFromUpperRightToLowerRight()
        {
            Rectangle rectangle = new Rectangle(new Point(5, 5), new Point(7, 7));

            rectangle.SelectedScalePoint = ScalePoint.UpperRight;
            rectangle.Scale(new Point(7, 9));

            Assert.AreEqual("(5, 7)", rectangle.UpperLeft.ToString());
            Assert.AreEqual("(7, 9)", rectangle.LowerRight.ToString());
            Assert.AreEqual(ScalePoint.LowerRight, rectangle.SelectedScalePoint);
        }
    }
}
