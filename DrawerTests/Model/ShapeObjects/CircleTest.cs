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
            Circle circle = new Circle(new Point(1, 1), new Point(2, 2));
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
        
        /// <inheritdoc/>
        [TestMethod]
        public void ScaleCircleFromLowerRightToLowerRight()
        {
            Circle circle = new Circle(new Point(1, 1), new Point(7, 7));

            circle.SelectedScalePoint = ScalePoint.LowerRight;
            circle.Scale(new Point(5, 6));

            Assert.AreEqual("(1, 1)", circle.UpperLeft.ToString());
            Assert.AreEqual("(5, 6)", circle.LowerRight.ToString());
            Assert.AreEqual(ScalePoint.LowerRight, circle.SelectedScalePoint);
        }
        
        /// <inheritdoc/>
        [TestMethod]
        public void ScaleCircleFromLowerRightToUpperRight()
        {
            Circle circle = new Circle(new Point(5, 5), new Point(7, 7));

            circle.SelectedScalePoint = ScalePoint.LowerRight;
            circle.Scale(new Point(8, 3));

            Assert.AreEqual("(5, 3)", circle.UpperLeft.ToString());
            Assert.AreEqual("(8, 5)", circle.LowerRight.ToString());
            Assert.AreEqual(ScalePoint.UpperRight, circle.SelectedScalePoint);
        }
        
        /// <inheritdoc/>
        [TestMethod]
        public void ScaleCircleFromLowerRightToLowerLeft()
        {
            Circle circle = new Circle(new Point(5, 5), new Point(7, 7));

            circle.SelectedScalePoint = ScalePoint.LowerRight;
            circle.Scale(new Point(3, 8));

            Assert.AreEqual("(3, 5)", circle.UpperLeft.ToString());
            Assert.AreEqual("(5, 8)", circle.LowerRight.ToString());
            Assert.AreEqual(ScalePoint.LowerLeft, circle.SelectedScalePoint);
        }
        
        /// <inheritdoc/>
        [TestMethod]
        public void ScaleCircleFromLowerRightToUpperLeft()
        {
            Circle retangle = new Circle(new Point(5, 5), new Point(7, 7));

            retangle.SelectedScalePoint = ScalePoint.LowerRight;
            retangle.Scale(new Point(3, 4));

            Assert.AreEqual("(3, 4)", retangle.UpperLeft.ToString());
            Assert.AreEqual("(5, 5)", retangle.LowerRight.ToString());
            Assert.AreEqual(ScalePoint.UpperLeft, retangle.SelectedScalePoint);
        }
        
        /// <inheritdoc/>
        [TestMethod]
        public void ScaleCircleFromLowerLeftToLowerLeft()
        {
            Circle circle = new Circle(new Point(5, 5), new Point(7, 7));

            circle.SelectedScalePoint = ScalePoint.LowerLeft;
            circle.Scale(new Point(6, 8));

            Assert.AreEqual("(6, 5)", circle.UpperLeft.ToString());
            Assert.AreEqual("(7, 8)", circle.LowerRight.ToString());
            Assert.AreEqual(ScalePoint.LowerLeft, circle.SelectedScalePoint);
        }
        
        /// <inheritdoc/>
        [TestMethod]
        public void ScaleCircleFromLowerLeftToLowerRight()
        {
            Circle circle = new Circle(new Point(5, 5), new Point(7, 7));

            circle.SelectedScalePoint = ScalePoint.LowerLeft;
            circle.Scale(new Point(9, 8));

            Assert.AreEqual("(7, 5)", circle.UpperLeft.ToString());
            Assert.AreEqual("(9, 8)", circle.LowerRight.ToString());
            Assert.AreEqual(ScalePoint.LowerRight, circle.SelectedScalePoint);
        }
        
        /// <inheritdoc/>
        [TestMethod]
        public void ScaleCircleFromLowerLeftToUpperLeft()
        {
            Circle circle = new Circle(new Point(5, 5), new Point(7, 7));

            circle.SelectedScalePoint = ScalePoint.LowerLeft;
            circle.Scale(new Point(3, 4));

            Assert.AreEqual("(3, 4)", circle.UpperLeft.ToString());
            Assert.AreEqual("(7, 5)", circle.LowerRight.ToString());
            Assert.AreEqual(ScalePoint.UpperLeft, circle.SelectedScalePoint);
        }
        
        /// <inheritdoc/>
        [TestMethod]
        public void ScaleCircleFromLowerLeftToUpperRight()
        {
            Circle circle = new Circle(new Point(5, 5), new Point(7, 7));

            circle.SelectedScalePoint = ScalePoint.LowerLeft;
            circle.Scale(new Point(9, 3));

            Assert.AreEqual("(7, 3)", circle.UpperLeft.ToString());
            Assert.AreEqual("(9, 5)", circle.LowerRight.ToString());
            Assert.AreEqual(ScalePoint.UpperRight, circle.SelectedScalePoint);
        }
        
        /// <inheritdoc/>
        [TestMethod]
        public void ScaleCircleFromUpperLeftToUpperLeft()
        {
            Circle circle = new Circle(new Point(5, 5), new Point(7, 7));

            circle.SelectedScalePoint = ScalePoint.UpperLeft;
            circle.Scale(new Point(6, 3));

            Assert.AreEqual("(6, 3)", circle.UpperLeft.ToString());
            Assert.AreEqual("(7, 7)", circle.LowerRight.ToString());
            Assert.AreEqual(ScalePoint.UpperLeft, circle.SelectedScalePoint);
        }
        
        /// <inheritdoc/>
        [TestMethod]
        public void ScaleCircleFromUpperLeftToLowerLeft()
        {
            Circle circle = new Circle(new Point(5, 5), new Point(7, 7));

            circle.SelectedScalePoint = ScalePoint.UpperLeft;
            circle.Scale(new Point(4, 8));

            Assert.AreEqual("(4, 7)", circle.UpperLeft.ToString());
            Assert.AreEqual("(7, 8)", circle.LowerRight.ToString());
            Assert.AreEqual(ScalePoint.LowerLeft, circle.SelectedScalePoint);
        }
        
        /// <inheritdoc/>
        [TestMethod]
        public void ScaleCircleFromUpperLeftToLowerRight()
        {
            Circle circle = new Circle(new Point(5, 5), new Point(7, 7));

            circle.SelectedScalePoint = ScalePoint.UpperLeft;
            circle.Scale(new Point(8, 9));

            Assert.AreEqual("(7, 7)", circle.UpperLeft.ToString());
            Assert.AreEqual("(8, 9)", circle.LowerRight.ToString());
            Assert.AreEqual(ScalePoint.LowerRight, circle.SelectedScalePoint);
        }

        /// <inheritdoc/>
        [TestMethod]
        public void ScaleCircleFromUpperLeftToUpperRight()
        {
            Circle circle = new Circle(new Point(5, 5), new Point(7, 7));

            circle.SelectedScalePoint = ScalePoint.UpperLeft;
            circle.Scale(new Point(9, 4));

            Assert.AreEqual("(7, 4)", circle.UpperLeft.ToString());
            Assert.AreEqual("(9, 7)", circle.LowerRight.ToString());
            Assert.AreEqual(ScalePoint.UpperRight, circle.SelectedScalePoint);
        }
        
        /// <inheritdoc/>
        [TestMethod]
        public void ScaleCircleFromUpperRightToUpperRight()
        {
            Circle circle = new Circle(new Point(5, 5), new Point(7, 7));

            circle.SelectedScalePoint = ScalePoint.UpperRight;
            circle.Scale(new Point(6, 3));

            Assert.AreEqual("(5, 3)", circle.UpperLeft.ToString());
            Assert.AreEqual("(6, 7)", circle.LowerRight.ToString());
            Assert.AreEqual(ScalePoint.UpperRight, circle.SelectedScalePoint);
        }
        
        /// <inheritdoc/>
        [TestMethod]
        public void ScaleCircleFromUpperRightToUpperLeft()
        {
            Circle circle = new Circle(new Point(5, 5), new Point(7, 7));

            circle.SelectedScalePoint = ScalePoint.UpperRight;
            circle.Scale(new Point(3, 4));

            Assert.AreEqual("(3, 4)", circle.UpperLeft.ToString());
            Assert.AreEqual("(5, 7)", circle.LowerRight.ToString());
            Assert.AreEqual(ScalePoint.UpperLeft, circle.SelectedScalePoint);
        }
        
        /// <inheritdoc/>
        [TestMethod]
        public void ScaleCircleFromUpperRightToLowerLeft()
        {
            Circle circle = new Circle(new Point(5, 5), new Point(7, 7));

            circle.SelectedScalePoint = ScalePoint.UpperRight;
            circle.Scale(new Point(3, 8));

            Assert.AreEqual("(3, 7)", circle.UpperLeft.ToString());
            Assert.AreEqual("(5, 8)", circle.LowerRight.ToString());
            Assert.AreEqual(ScalePoint.LowerLeft, circle.SelectedScalePoint);
        }
        
        /// <inheritdoc/>
        [TestMethod]
        public void ScaleCircleFromUpperRightToLowerRight()
        {
            Circle circle = new Circle(new Point(5, 5), new Point(7, 7));

            circle.SelectedScalePoint = ScalePoint.UpperRight;
            circle.Scale(new Point(7, 9));

            Assert.AreEqual("(5, 7)", circle.UpperLeft.ToString());
            Assert.AreEqual("(7, 9)", circle.LowerRight.ToString());
            Assert.AreEqual(ScalePoint.LowerRight, circle.SelectedScalePoint);
        }
    }
}
