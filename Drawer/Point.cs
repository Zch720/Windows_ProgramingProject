using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drawer
{
    public class Point
    {
        public int X
        {
            get;
        }

        public int Y
        {
            get;
        }

        public Point(int xCoordinate, int yCoordinate)
        {
            X = xCoordinate;
            Y = yCoordinate;
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            return $"({X}, {Y})";
        }
    }
}
