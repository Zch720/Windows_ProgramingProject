using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Drawer.ShapeObjects.Tests
{
    [TestClass]
    public class ShapeTest
    {
        [TestMethod]
        [DataRow(0, 0, 5, 5, 3, 3, 3, 3, 8, 8)]
        [DataRow(0, 0, 5, 5, -3, -3, -3, -3, 2, 2)]
        public void MoveShape(
            int point1X, int point1Y,
            int point2X, int point2Y,
            int xDistance, int yDistance,
            int exceptPoint1X, int exceptPoint1Y,
            int exceptPoint2X, int exceptPoint2Y
        )
        {
            Shape shape = new Line();
            shape.Point1 = new Point(point1X, point1Y);
            shape.Point2 = new Point(point2X, point2Y);

            shape.Move(new Point(xDistance, yDistance));

            Assert.AreEqual(exceptPoint1X, shape.Point1.X);
            Assert.AreEqual(exceptPoint1Y, shape.Point1.Y);
            Assert.AreEqual(exceptPoint2X, shape.Point2.X);
            Assert.AreEqual(exceptPoint2Y, shape.Point2.Y);
        }

        [TestMethod]
        [DataRow(0, 0, 3, 4, 0, 0, 3, 4)]
        [DataRow(0, 4, 3, 0, 0, 0, 3, 4)]
        [DataRow(3, 4, 0, 0, 0, 0, 3, 4)]
        [DataRow(3, 0, 0, 4, 0, 0, 3, 4)]
        public void GetShapeLocationPoints(
            int point1X, int point1Y,
            int point2X, int point2Y,
            int exceptUpperLeftX, int exceptUpperLeftY,
            int exceptLowerRightX, int exceptLowerRightY
        )
        {
            Shape shape = new Line();
            shape.Point1 = new Point(point1X, point1Y);
            shape.Point2 = new Point(point2X, point2Y);

            Assert.AreEqual(exceptUpperLeftX, shape.UpperLeft.X);
            Assert.AreEqual(exceptUpperLeftY, shape.UpperLeft.Y);
            Assert.AreEqual(exceptLowerRightX, shape.LowerRight.X);
            Assert.AreEqual(exceptLowerRightY, shape.LowerRight.Y);
        }

        [TestMethod]
        [DataRow(0, 0, 3, 4, 3, 4)]
        [DataRow(0, 4, 3, 0, 3, 4)]
        [DataRow(3, 4, 0, 0, 3, 4)]
        [DataRow(3, 0, 0, 4, 3, 4)]
        public void GetShapeSize(
            int point1X, int point1Y,
            int point2X, int point2Y,
            int width,
            int height
        )
        {
            Shape shape = new Line();
            shape.Point1 = new Point(point1X, point1Y);
            shape.Point2 = new Point(point2X, point2Y);

            Assert.AreEqual(width, shape.Width);
            Assert.AreEqual(height, shape.Height);
        }
    }
}
