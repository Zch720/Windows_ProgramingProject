using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Drawer.Tests
{
    [TestClass]
    public class PointTest
    {
        [TestMethod]
        public void CreatePointXY() {
            Point point = new Point(1, 2);

            Assert.AreEqual(1, point.X);
            Assert.AreEqual(2, point.Y);
        }

        [TestMethod]
        public void CreatePointWithOneValue()
        {
            Point point = new Point(1);

            Assert.AreEqual(1, point.X);
            Assert.AreEqual(1, point.Y);
        }
        
        [TestMethod]
        public void PointToString()
        {
            Point point = new Point(1, 2);

            Assert.AreEqual("(1, 2)", point.ToString());
        }

        [TestMethod]
        public void Point1SmallThanPoint2()
        {
            Point point1 = new Point(1, 1);
            Point point2 = new Point(2, 2);

            Assert.IsTrue(Point.LowerEqual(point1, point2));
        }

        [TestMethod]
        public void Point1EqualToPoint2()
        {
            Point point1 = new Point(1, 1);
            Point point2 = new Point(1, 1);

            Assert.IsTrue(Point.LowerEqual(point1, point2));
        }

        [TestMethod]
        public void Point1LargeThanPoint2()
        {
            Point point1 = new Point(2, 2);
            Point point2 = new Point(1, 1);

            Assert.IsFalse(Point.LowerEqual(point1, point2));
        }

        [TestMethod]
        public void CannotComparePoint2AtFirstQuadrantOfPoint1()
        {
            Point point1 = new Point(1, 1);
            Point point2 = new Point(2, 0);

            Assert.ThrowsException<Exception>(() => {
                Point.LowerEqual(point1, point2);
            });
        }

        [TestMethod]
        public void CannotComparePoint2AtThirdQuadrantOfPoint1()
        {
            Point point1 = new Point(1, 1);
            Point point2 = new Point(0, 2);

            Assert.ThrowsException<Exception>(() => {
                Point.LowerEqual(point1, point2);
            });
        }

        [TestMethod]
        public void AddTwoPoint()
        {
            Point point1 = new Point(5, -3);
            Point point2 = new Point(3, 7);

            Point result = Point.Add(point1, point2);

            Assert.AreEqual(8, result.X);
            Assert.AreEqual(4, result.Y);
        }

        [TestMethod]
        public void MinusTwoPoint()
        {
            Point point1 = new Point(5, -3);
            Point point2 = new Point(3, 7);

            Point result = Point.Subtract(point1, point2);

            Assert.AreEqual(2, result.X);
            Assert.AreEqual(-10, result.Y);
        }
    }
}
