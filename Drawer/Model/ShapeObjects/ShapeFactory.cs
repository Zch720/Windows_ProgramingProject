using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drawer.ShapeObjects
{
    public class ShapeFactory
    {
        const string LINE_TYPE_NAME = "線";
        const string RECTANGLE_TYPE_NAME = "矩形";
        const string CIRCLE_TYPE_NAME = "圓";

        private Random _random;

        public ShapeFactory()
        {
            _random = new Random();
        }

        /// <summary>
        /// Create a new random shape.
        /// </summary>
        /// <param name="shapeType">The shape type string.</param>
        /// <param name="lowerRightCorner">The lower right corner of the area can create shape.</param>
        public Shape CreateRandom(string shapeType, Point lowerRightCorner)
        {
            Point upperLeft = GenerateRandomPoint(new Point(0, 0), lowerRightCorner);
            Point lowerRight = GenerateRandomPoint(new Point(0, 0), lowerRightCorner);
            return Create(shapeType, upperLeft, lowerRight);
        }

        /// <summary>
        /// Create a new shape.
        /// </summary>
        /// <param name="shapeType">The shape type string.</param>
        /// <param name="upperLeft">The upper left corner of the shape.</param>
        /// <param name="lowerRight">The lower right corner of the shape.</param>
        public Shape Create(string shapeType, Point upperLeft, Point lowerRight)
        {
            switch (shapeType)
            {
                case LINE_TYPE_NAME:
                    return Create(ShapeType.Line, upperLeft, lowerRight);
                case RECTANGLE_TYPE_NAME:
                    return Create(ShapeType.Rectangle, upperLeft, lowerRight);
                case CIRCLE_TYPE_NAME:
                    return Create(ShapeType.Circle, upperLeft, lowerRight);
            }
            throw new Exception("Shape type is invalid");
        }

        /// <summary>
        /// Create a new shape.
        /// </summary>
        /// <param name="shapeType">The shape type.</param>
        /// <param name="upperLeft">The upper left corner of the shape.</param>
        /// <param name="lowerDown">The lower down corner of the shape.</param>
        public Shape Create(ShapeType shapeType, Point upperLeft, Point lowerDown)
        {
            Shape shape = CreateShapeInstance(shapeType);
            SetShapePoint(shape, upperLeft, lowerDown);
            return shape;
        }

        /// <summary>
        /// Create a shape instance.
        /// </summary>
        /// <param name="shapeType">The shape type want to create.</param>
        /// <returns></returns>
        private Shape CreateShapeInstance(ShapeType shapeType)
        {
            switch (shapeType)
            {
                case ShapeType.Line:
                    return new Line();
                case ShapeType.Rectangle:
                    return new Rectangle();
                case ShapeType.Circle:
                    return new Circle();
            }
            throw new Exception("Shape type is invalid");
        }

        /// <summary>
        /// Set the shape Point.
        /// </summary>
        /// <param name="shape">The shape.</param>
        /// <param name="upperLeft">The upper left corner of the shape.</param>
        /// <param name="lowerDown">The lower right corner of the shape.</param>
        private void SetShapePoint(Shape shape, Point upperLeft, Point lowerDown)
        {
            shape.Point1 = upperLeft;
            shape.Point2 = lowerDown;
        }

        /// <summary>
        /// Generate a rendom point between upperLeft and lowerRight.
        /// </summary>
        /// <param name="upperLeft">The upper left corner of random area.</param>
        /// <param name="lowerRight">The lower right corner of random area.</param>
        /// <returns></returns>
        private Point GenerateRandomPoint(Point upperLeft, Point lowerRight)
        {
            return new Point(
                _random.Next(upperLeft.X, lowerRight.X),
                _random.Next(upperLeft.Y, lowerRight.Y)
            );
        }
    }
}
