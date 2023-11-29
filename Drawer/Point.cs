using System;

namespace Drawer
{
    public class Point
    {
        const string STRING_FORMAT = "({0}, {1})";
        const string CANNOT_COMPARE_ERROR_FORMAT = "Can not compare those points: {0}, {1}";

        public int X
        {
            get;
        }

        public int Y
        {
            get;
        }

        public Point(int coordinate)
        {
            X = coordinate;
            Y = coordinate;
        }

        public Point(int xCoordinate, int yCoordinate)
        {
            X = xCoordinate;
            Y = yCoordinate;
        }

        public Point(Point point)
        {
            X = point.X;
            Y = point.Y;
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            return string.Format(STRING_FORMAT, X, Y);
        }

        /// <summary>
        /// Check if tow points are equal.
        /// </summary>
        public static bool Equal(Point point1, Point point2)
        {
            return point1.X == point2.X && point1.Y == point2.Y;
        }

        /// <summary>
        /// Check if point1 smaller or equal to point2.
        /// </summary>
        public static bool LowerEqual(Point point1, Point point2)
        {
            if (point1.X <= point2.X ^ point1.Y <= point2.Y)
                throw new System.Exception(string.Format(CANNOT_COMPARE_ERROR_FORMAT, point1, point2));
            return point1.X <= point2.X && point1.Y <= point2.Y;
        }

        /// <summary>
        /// Add tow points.
        /// </summary>
        public static Point Add(Point point1, Point point2)
        {
            return new Point(point1.X + point2.X, point1.Y + point2.Y);
        }

        /// <summary>
        /// Subtract two points.
        /// </summary>
        public static Point Subtract(Point point1, Point point2)
        {
            return new Point(point1.X - point2.X, point1.Y - point2.Y);
        }

        /// <summary>
        /// Calculate distance of two point.
        /// </summary>
        public static float GetDistance(Point point1, Point point2)
        {
            const int TWO = 2;
            return (float)Math.Sqrt(Math.Pow(point1.X - point2.X, TWO) + Math.Pow(point1.Y - point2.Y, TWO));
        } 
    }
}
;