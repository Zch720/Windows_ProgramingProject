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

        [TestMethod]
        public void ScaleForwardSlashFromLowerRightToLowerRight()
        {
            Line line = new Line(new Point(1, 1), new Point(7, 7));

            line.SelectedScalePoint = ScalePoint.LowerRight;
            line.Scale(new Point(5, 6));

            Assert.AreEqual("(1, 1)", line.Point1.ToString());
            Assert.AreEqual("(5, 6)", line.Point2.ToString());
            Assert.AreEqual(ScalePoint.LowerRight, line.SelectedScalePoint);
        }

        [TestMethod]
        public void ScaleBackslashFromLowerRightToLowerRight()
        {
            Line line = new Line(new Point(1, 7), new Point(7, 1));

            line.SelectedScalePoint = ScalePoint.LowerRight;
            line.Scale(new Point(5, 6));

            Assert.AreEqual("(1, 6)", line.Point1.ToString());
            Assert.AreEqual("(5, 1)", line.Point2.ToString());
            Assert.AreEqual(ScalePoint.LowerRight, line.SelectedScalePoint);
        }

        [TestMethod]
        public void ScaleForwardSlashFromLowerRightToUpperRight()
        {
            Line line = new Line(new Point(5, 5), new Point(7, 7));

            line.SelectedScalePoint = ScalePoint.LowerRight;
            line.Scale(new Point(8, 3));

            Assert.AreEqual("(5, 5)", line.Point1.ToString());
            Assert.AreEqual("(8, 3)", line.Point2.ToString());
            Assert.AreEqual(ScalePoint.UpperRight, line.SelectedScalePoint);
        }

        [TestMethod]
        public void ScaleBackslashFromLowerRightToUpperRight()
        {
            Line line = new Line(new Point(5, 7), new Point(7, 5));

            line.SelectedScalePoint = ScalePoint.LowerRight;
            line.Scale(new Point(8, 3));

            Assert.AreEqual("(5, 3)", line.Point1.ToString());
            Assert.AreEqual("(8, 5)", line.Point2.ToString());
            Assert.AreEqual(ScalePoint.UpperRight, line.SelectedScalePoint);
        }

        [TestMethod]
        public void ScaleForwardSlashFromLowerRightToLowerLeft()
        {
            Line line = new Line(new Point(5, 5), new Point(7, 7));

            line.SelectedScalePoint = ScalePoint.LowerRight;
            line.Scale(new Point(3, 8));

            Assert.AreEqual("(3, 8)", line.Point1.ToString());
            Assert.AreEqual("(5, 5)", line.Point2.ToString());
            Assert.AreEqual(ScalePoint.LowerLeft, line.SelectedScalePoint);
        }

        [TestMethod]
        public void ScaleBackslashFromLowerRightToLowerLeft()
        {
            Line line = new Line(new Point(5, 7), new Point(7, 5));

            line.SelectedScalePoint = ScalePoint.LowerRight;
            line.Scale(new Point(3, 8));

            Assert.AreEqual("(3, 5)", line.Point1.ToString());
            Assert.AreEqual("(5, 8)", line.Point2.ToString());
            Assert.AreEqual(ScalePoint.LowerLeft, line.SelectedScalePoint);
        }

        [TestMethod]
        public void ScaleForwardSlashFromLowerRightToUpperLeft()
        {
            Line line = new Line(new Point(5, 5), new Point(7, 7));

            line.SelectedScalePoint = ScalePoint.LowerRight;
            line.Scale(new Point(3, 4));

            Assert.AreEqual("(3, 4)", line.Point1.ToString());
            Assert.AreEqual("(5, 5)", line.Point2.ToString());
            Assert.AreEqual(ScalePoint.UpperLeft, line.SelectedScalePoint);
        }

        [TestMethod]
        public void ScaleBackslashFromLowerRightToUpperLeft()
        {
            Line line = new Line(new Point(5, 7), new Point(7, 5));

            line.SelectedScalePoint = ScalePoint.LowerRight;
            line.Scale(new Point(3, 4));

            Assert.AreEqual("(3, 5)", line.Point1.ToString());
            Assert.AreEqual("(5, 4)", line.Point2.ToString());
            Assert.AreEqual(ScalePoint.UpperLeft, line.SelectedScalePoint);
        }

        [TestMethod]
        public void ScaleForwardSlashFromLowerLeftToLowerLeft()
        {
            Line line = new Line(new Point(5, 5), new Point(7, 7));

            line.SelectedScalePoint = ScalePoint.LowerLeft;
            line.Scale(new Point(6, 8));

            Assert.AreEqual("(6, 5)", line.Point1.ToString());
            Assert.AreEqual("(7, 8)", line.Point2.ToString());
            Assert.AreEqual(ScalePoint.LowerLeft, line.SelectedScalePoint);
        }

        [TestMethod]
        public void ScaleBackSlashFromLowerLeftToLowerLeft()
        {
            Line line = new Line(new Point(5, 7), new Point(7, 5));

            line.SelectedScalePoint = ScalePoint.LowerLeft;
            line.Scale(new Point(6, 8));

            Assert.AreEqual("(6, 8)", line.Point1.ToString());
            Assert.AreEqual("(7, 5)", line.Point2.ToString());
            Assert.AreEqual(ScalePoint.LowerLeft, line.SelectedScalePoint);
        }

        [TestMethod]
        public void ScaleForwardSlashFromLowerLeftToLowerRight()
        {
            Line line = new Line(new Point(5, 5), new Point(7, 7));

            line.SelectedScalePoint = ScalePoint.LowerLeft;
            line.Scale(new Point(9, 8));

            Assert.AreEqual("(7, 8)", line.Point1.ToString());
            Assert.AreEqual("(9, 5)", line.Point2.ToString());
            Assert.AreEqual(ScalePoint.LowerRight, line.SelectedScalePoint);
        }

        [TestMethod]
        public void ScaleBackSlashFromLowerLeftToLowerRight()
        {
            Line line = new Line(new Point(5, 7), new Point(7, 5));

            line.SelectedScalePoint = ScalePoint.LowerLeft;
            line.Scale(new Point(9, 8));

            Assert.AreEqual("(7, 5)", line.Point1.ToString());
            Assert.AreEqual("(9, 8)", line.Point2.ToString());
            Assert.AreEqual(ScalePoint.LowerRight, line.SelectedScalePoint);
        }

        [TestMethod]
        public void ScaleForwardSlashFromLowerLeftToUpperLeft()
        {
            Line line = new Line(new Point(5, 5), new Point(7, 7));

            line.SelectedScalePoint = ScalePoint.LowerLeft;
            line.Scale(new Point(3, 4));

            Assert.AreEqual("(3, 5)", line.Point1.ToString());
            Assert.AreEqual("(7, 4)", line.Point2.ToString());
            Assert.AreEqual(ScalePoint.UpperLeft, line.SelectedScalePoint);
        }

        [TestMethod]
        public void ScaleBackSlashFromLowerLeftToUpperLeft()
        {
            Line line = new Line(new Point(5, 7), new Point(7, 5));

            line.SelectedScalePoint = ScalePoint.LowerLeft;
            line.Scale(new Point(3, 4));

            Assert.AreEqual("(3, 4)", line.Point1.ToString());
            Assert.AreEqual("(7, 5)", line.Point2.ToString());
            Assert.AreEqual(ScalePoint.UpperLeft, line.SelectedScalePoint);
        }

        [TestMethod]
        public void ScaleForwardSlashFromLowerLeftToUpperRight()
        {
            Line line = new Line(new Point(5, 5), new Point(7, 7));

            line.SelectedScalePoint = ScalePoint.LowerLeft;
            line.Scale(new Point(9, 3));

            Assert.AreEqual("(7, 3)", line.Point1.ToString());
            Assert.AreEqual("(9, 5)", line.Point2.ToString());
            Assert.AreEqual(ScalePoint.UpperRight, line.SelectedScalePoint);
        }

        [TestMethod]
        public void ScaleBackSlashFromLowerLeftToUpperRight()
        {
            Line line = new Line(new Point(5, 7), new Point(7, 5));

            line.SelectedScalePoint = ScalePoint.LowerLeft;
            line.Scale(new Point(9, 3));

            Assert.AreEqual("(7, 5)", line.Point1.ToString());
            Assert.AreEqual("(9, 3)", line.Point2.ToString());
            Assert.AreEqual(ScalePoint.UpperRight, line.SelectedScalePoint);
        }

        [TestMethod]
        public void ScaleForwardSlashFromUpperLeftToUpperLeft()
        {
            Line line = new Line(new Point(5, 5), new Point(7, 7));

            line.SelectedScalePoint = ScalePoint.UpperLeft;
            line.Scale(new Point(6, 3));

            Assert.AreEqual("(6, 3)", line.Point1.ToString());
            Assert.AreEqual("(7, 7)", line.Point2.ToString());
            Assert.AreEqual(ScalePoint.UpperLeft, line.SelectedScalePoint);
        }

        [TestMethod]
        public void ScaleBackSlashFromUpperLeftToUpperLeft()
        {
            Line line = new Line(new Point(5, 7), new Point(7, 5));

            line.SelectedScalePoint = ScalePoint.UpperLeft;
            line.Scale(new Point(6, 3));

            Assert.AreEqual("(6, 7)", line.Point1.ToString());
            Assert.AreEqual("(7, 3)", line.Point2.ToString());
            Assert.AreEqual(ScalePoint.UpperLeft, line.SelectedScalePoint);
        }

        [TestMethod]
        public void ScaleForwardSlashFromUpperLeftToLowerLeft()
        {
            Line line = new Line(new Point(5, 5), new Point(7, 7));

            line.SelectedScalePoint = ScalePoint.UpperLeft;
            line.Scale(new Point(4, 8));

            Assert.AreEqual("(4, 8)", line.Point1.ToString());
            Assert.AreEqual("(7, 7)", line.Point2.ToString());
            Assert.AreEqual(ScalePoint.LowerLeft, line.SelectedScalePoint);
        }

        [TestMethod]
        public void ScaleBackSlashFromUpperLeftToLowerLeft()
        {
            Line line = new Line(new Point(5, 7), new Point(7, 5));

            line.SelectedScalePoint = ScalePoint.UpperLeft;
            line.Scale(new Point(4, 8));

            Assert.AreEqual("(4, 7)", line.Point1.ToString());
            Assert.AreEqual("(7, 8)", line.Point2.ToString());
            Assert.AreEqual(ScalePoint.LowerLeft, line.SelectedScalePoint);
        }

        [TestMethod]
        public void ScaleForwardSlashFromUpperLeftToLowerRight()
        {
            Line line = new Line(new Point(5, 5), new Point(7, 7));

            line.SelectedScalePoint = ScalePoint.UpperLeft;
            line.Scale(new Point(8, 9));

            Assert.AreEqual("(7, 7)", line.Point1.ToString());
            Assert.AreEqual("(8, 9)", line.Point2.ToString());
            Assert.AreEqual(ScalePoint.LowerRight, line.SelectedScalePoint);
        }

        [TestMethod]
        public void ScaleBackSlashFromUpperLeftToLowerRight()
        {
            Line line = new Line(new Point(5, 7), new Point(7, 5));

            line.SelectedScalePoint = ScalePoint.UpperLeft;
            line.Scale(new Point(8, 9));

            Assert.AreEqual("(7, 9)", line.Point1.ToString());
            Assert.AreEqual("(8, 7)", line.Point2.ToString());
            Assert.AreEqual(ScalePoint.LowerRight, line.SelectedScalePoint);
        }

        [TestMethod]
        public void ScaleForwardSlashFromUpperLeftToUpperRight()
        {
            Line line = new Line(new Point(5, 5), new Point(7, 7));

            line.SelectedScalePoint = ScalePoint.UpperLeft;
            line.Scale(new Point(9, 4));

            Assert.AreEqual("(7, 7)", line.Point1.ToString());
            Assert.AreEqual("(9, 4)", line.Point2.ToString());
            Assert.AreEqual(ScalePoint.UpperRight, line.SelectedScalePoint);
        }

        [TestMethod]
        public void ScaleBackSlashFromUpperLeftToUpperRight()
        {
            Line line = new Line(new Point(5, 7), new Point(7, 5));

            line.SelectedScalePoint = ScalePoint.UpperLeft;
            line.Scale(new Point(9, 4));

            Assert.AreEqual("(7, 4)", line.Point1.ToString());
            Assert.AreEqual("(9, 7)", line.Point2.ToString());
            Assert.AreEqual(ScalePoint.UpperRight, line.SelectedScalePoint);
        }

        [TestMethod]
        public void ScaleForwardSlashFromUpperRightToUpperRight()
        {
            Line line = new Line(new Point(5, 5), new Point(7, 7));

            line.SelectedScalePoint = ScalePoint.UpperRight;
            line.Scale(new Point(6, 3));

            Assert.AreEqual("(5, 3)", line.Point1.ToString());
            Assert.AreEqual("(6, 7)", line.Point2.ToString());
            Assert.AreEqual(ScalePoint.UpperRight, line.SelectedScalePoint);
        }

        [TestMethod]
        public void ScaleBackSlashFromUpperRightToUpperRight()
        {
            Line line = new Line(new Point(5, 7), new Point(7, 5));

            line.SelectedScalePoint = ScalePoint.UpperRight;
            line.Scale(new Point(6, 3));

            Assert.AreEqual("(5, 7)", line.Point1.ToString());
            Assert.AreEqual("(6, 3)", line.Point2.ToString());
            Assert.AreEqual(ScalePoint.UpperRight, line.SelectedScalePoint);
        }

        [TestMethod]
        public void ScaleForwardSlashFromUpperRightToUpperLeft()
        {
            Line line = new Line(new Point(5, 5), new Point(7, 7));

            line.SelectedScalePoint = ScalePoint.UpperRight;
            line.Scale(new Point(3, 4));

            Assert.AreEqual("(3, 7)", line.Point1.ToString());
            Assert.AreEqual("(5, 4)", line.Point2.ToString());
            Assert.AreEqual(ScalePoint.UpperLeft, line.SelectedScalePoint);
        }

        [TestMethod]
        public void ScaleBackSlashFromUpperRightToUpperLeft()
        {
            Line line = new Line(new Point(5, 7), new Point(7, 5));

            line.SelectedScalePoint = ScalePoint.UpperRight;
            line.Scale(new Point(3, 4));

            Assert.AreEqual("(3, 4)", line.Point1.ToString());
            Assert.AreEqual("(5, 7)", line.Point2.ToString());
            Assert.AreEqual(ScalePoint.UpperLeft, line.SelectedScalePoint);
        }

        [TestMethod]
        public void ScaleForwardSlashFromUpperRightToLowerLeft()
        {
            Line line = new Line(new Point(5, 5), new Point(7, 7));

            line.SelectedScalePoint = ScalePoint.UpperRight;
            line.Scale(new Point(3, 8));

            Assert.AreEqual("(3, 7)", line.Point1.ToString());
            Assert.AreEqual("(5, 8)", line.Point2.ToString());
            Assert.AreEqual(ScalePoint.LowerLeft, line.SelectedScalePoint);
        }

        [TestMethod]
        public void ScaleBackSlashFromUpperRightToLowerLeft()
        {
            Line line = new Line(new Point(5, 7), new Point(7, 5));

            line.SelectedScalePoint = ScalePoint.UpperRight;
            line.Scale(new Point(3, 8));

            Assert.AreEqual("(3, 8)", line.Point1.ToString());
            Assert.AreEqual("(5, 7)", line.Point2.ToString());
            Assert.AreEqual(ScalePoint.LowerLeft, line.SelectedScalePoint);
        }

        [TestMethod]
        public void ScaleForwardSlashFromUpperRightToLowerRight()
        {
            Line line = new Line(new Point(5, 5), new Point(7, 7));

            line.SelectedScalePoint = ScalePoint.UpperRight;
            line.Scale(new Point(7, 9));

            Assert.AreEqual("(5, 9)", line.Point1.ToString());
            Assert.AreEqual("(7, 7)", line.Point2.ToString());
            Assert.AreEqual(ScalePoint.LowerRight, line.SelectedScalePoint);
        }

        [TestMethod]
        public void ScaleBackSlashFromUpperRightToLowerRight()
        {
            Line line = new Line(new Point(5, 7), new Point(7, 5));

            line.SelectedScalePoint = ScalePoint.UpperRight;
            line.Scale(new Point(7, 9));

            Assert.AreEqual("(5, 7)", line.Point1.ToString());
            Assert.AreEqual("(7, 9)", line.Point2.ToString());
            Assert.AreEqual(ScalePoint.LowerRight, line.SelectedScalePoint);
        }
    }
}