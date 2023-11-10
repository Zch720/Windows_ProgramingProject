﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drawer.ShapeObjects
{
    public abstract class Shape
    {
        abstract public ShapeType Type
        {
            get;
        }

        abstract public string Name
        {
            get;
        }

        abstract public string Info
        {
            get;
        }

        public Point Point1
        {
            get;
            set;
        }

        public Point Point2
        {
            get;
            set;
        }

        public Point UpperLeft
        {
            get
            {
                return new Point(Math.Min(Point1.X, Point2.X), Math.Min(Point1.Y, Point2.Y));
            }
        }

        public Point LowerRight
        {
            get
            {
                return new Point(Math.Max(Point1.X, Point2.X), Math.Max(Point1.Y, Point2.Y));
            }
        }

        public float Width
        {
            get
            {
                return LowerRight.X - UpperLeft.X;
            }
        }

        public float Height
        {
            get
            {
                return LowerRight.Y - UpperLeft.Y;
            }
        }

        public bool IsSelected
        {
            get;
            set;
        }

        /// <summary>
        /// Draw shape.
        /// </summary>
        /// <param name="graphics">The Graphics of draw area.</param>
        abstract public void Draw(IGraphics graphics);

        /// <summary>
        /// Move the shape.
        /// </summary>
        /// <param name="xDistance">The move distance of x direction.</param>
        /// <param name="yDistance">The move distance of y direction.</param>
        public void Move(int xDistance, int yDistance)
        {
            Point1 = new Point(Point1.X + xDistance, Point1.Y + yDistance);
            Point2 = new Point(Point2.X + xDistance, Point2.Y + yDistance);
        }
    }
}
