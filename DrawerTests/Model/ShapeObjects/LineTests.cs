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
            Line line = new Line(new Point(1, 1), new Point(2, 2));
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

        //[TestMethod]
        //public void ScaleForwardSlashFromLowerRightToLowerRight()
        //{
        //    Line line = new Line(new Point(1, 1), new Point(7, 7));

        //    line.SelectedScalePoint = Shape.ScalePoint.LowerRight;
        //    line.Scale(new Point(5, 6));

        //    Assert.AreEqual(1, line.Point1.X);
        //    Assert.AreEqual(1, line.Point1.Y);
        //    Assert.AreEqual(5, line.Point2.X);
        //    Assert.AreEqual(6, line.Point2.Y);
        //}

        //[TestMethod]
        //public void ScaleBackslashFromLowerRightToLowerRight()
        //{
        //    Line line = new Line(new Point(1, 7), new Point(7, 1));

        //    line.SelectedScalePoint = Shape.ScalePoint.LowerRight;
        //    line.Scale(new Point(5, 6));

        //    Assert.AreEqual(1, line.Point1.X);
        //    Assert.AreEqual(6, line.Point1.Y);
        //    Assert.AreEqual(5, line.Point2.X);
        //    Assert.AreEqual(1, line.Point2.Y);
        //}

        //[TestMethod]
        //public void ScaleForwardSlashFromLowerRightToUpperRight()
        //{
        //    Line line = new Line(new Point(5, 5), new Point(7, 7));

        //    line.SelectedScalePoint = Shape.ScalePoint.LowerRight;
        //    line.Scale(new Point(8, 3));

        //    Assert.AreEqual(5, line.Point1.X);
        //    Assert.AreEqual(5, line.Point1.Y);
        //    Assert.AreEqual(8, line.Point2.X);
        //    Assert.AreEqual(3, line.Point2.Y);
        //    Assert.AreEqual(Shape.ScalePoint.UpperRight, line.SelectedScalePoint);
        //}

        //[TestMethod]
        //public void ScaleBackslashFromLowerRightToUpperRight()
        //{
        //    Line line = new Line(new Point(5, 7), new Point(7, 5));

        //    line.SelectedScalePoint = Shape.ScalePoint.LowerRight;
        //    line.Scale(new Point(8, 3));

        //    Assert.AreEqual(5, line.Point1.X);
        //    Assert.AreEqual(3, line.Point1.Y);
        //    Assert.AreEqual(8, line.Point2.X);
        //    Assert.AreEqual(5, line.Point2.Y);
        //    Assert.AreEqual(Shape.ScalePoint.UpperRight, line.SelectedScalePoint);
        //}
    }
}