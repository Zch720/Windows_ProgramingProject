using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drawer
{
    public class Point
    {
        const string STRING_FORMAT = "({0}, {1})";

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

        /// <inheritdoc/>
        public override string ToString()
        {
            return string.Format(STRING_FORMAT, X, Y);
        }

        /// <summary>
        /// Check if point1 smaller or equal to point2.
        /// </summary>
        public static bool LowerEqual(Point point1, Point point2)
        {
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
    }
}
