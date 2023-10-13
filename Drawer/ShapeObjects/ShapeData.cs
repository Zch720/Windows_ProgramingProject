using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drawer.ShapeObjects
{
    public class ShapeData
    {
        public ShapeType ShapeType
        {
            get;
        }

        public string ShapeName
        {
            get;
        }
        public string Information
        {
            get;
        }

        public Point Point1
        {
            get;
        }

        public Point Point2
        {
            get;
        }

        public float Width
        {
            get
            {
                return Point2.X - Point1.X;
            }
        }

        public float Height
        {
            get
            {
                return Point2.Y - Point1.Y;
            }
        }

        public ShapeData(ShapeType shapeType, string shapeName, string information, Point point1, Point point2)
        {
            ShapeType = shapeType;
            ShapeName = shapeName;
            Information = information;
            Point1 = point1;
            Point2 = point2;
        }
    }
}
