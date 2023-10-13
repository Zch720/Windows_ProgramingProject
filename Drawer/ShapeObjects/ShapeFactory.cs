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

        /// <summary>
        /// Create a new shape.
        /// </summary>
        /// <param name="shapeType">The shape type string.</param>
        /// <param name="upperLeft">The upper left corner of the shape.</param>
        /// <param name="lowerDown">The lower down corner of the shape.</param>
        public Shape Create(string shapeType, Point upperLeft, Point lowerDown)
        {
            Shape shape = null;
            switch (shapeType)
            {
                case LINE_TYPE_NAME:
                    shape = new Line();
                    break;
                case RECTANGLE_TYPE_NAME:
                    shape = new Rectangle();
                    break;
                case CIRCLE_TYPE_NAME:
                    shape = new Circle();
                    break;
            }

            if (shape != null)
                SetShapePoint(shape, upperLeft, lowerDown);

            return shape;
        }

        /// <summary>
        /// Create a new shape.
        /// </summary>
        /// <param name="shapeType">The shape type.</param>
        /// <param name="upperLeft">The upper left corner of the shape.</param>
        /// <param name="lowerDown">The lower down corner of the shape.</param>
        public Shape Create(ShapeType shapeType, Point upperLeft, Point lowerDown)
        {
            Shape shape = null;
            switch (shapeType)
            {
                case ShapeType.Line:
                    shape = new Line();
                    break;
                case ShapeType.Rectangle:
                    shape = new Rectangle();
                    break;
                case ShapeType.Circle:
                    shape = new Circle();
                    break;
            }

            if (shape != null)
                SetShapePoint(shape, upperLeft, lowerDown);

            return shape;
        }

        /// <summary>
        /// Revise the Point1 and Point2 to the upper left corner and lower right corner of Recangle and circle.
        /// </summary>
        /// <param name="shape">The shape want to revise.</param>
        public void ReviseShapePoints(Shape shape)
        {
            if (shape is Line)
                return;

            Point point1 = new Point(Math.Min(shape.Point1.X, shape.Point2.X), Math.Min(shape.Point1.Y, shape.Point2.Y));
            Point point2 = new Point(Math.Max(shape.Point1.X, shape.Point2.X), Math.Max(shape.Point1.Y, shape.Point2.Y));
            shape.Point1 = point1;
            shape.Point2 = point2;
        }

        /// <summary>
        /// Deep copy of shape.
        /// </summary>
        /// <param name="shape">The shape want to copy.</param>
        /// <returns>The copied object.</returns>
        public Shape CopyShape(Shape shape)
        {
            Shape copy;
            if (shape is Line)
                copy = new Line();
            else if (shape is Rectangle)
                copy = new Rectangle();
            else if (shape is Circle)
                copy = new Circle();
            else
                throw new TypeLoadException();

            SetShapePoint(copy, shape.Point1, shape.Point2);
            return copy;
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
    }
}
