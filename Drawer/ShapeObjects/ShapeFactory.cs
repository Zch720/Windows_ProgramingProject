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

        /// <summary>
        /// Create a new shape
        /// </summary>
        /// <param name="shapeType">The shape type string</param>
        /// <param name="upperLeft">The upper left corner of the shape</param>
        /// <param name="lowerDown">The lower down corner of the shape</param>
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
            }

            if (shape != null)
                SetShapePoint(shape, upperLeft, lowerDown);

            return shape;
        }

        /// <summary>
        /// Set the shape Point
        /// </summary>
        /// <param name="shape">The shape</param>
        /// <param name="upperLeft">The upper left corner of the shape</param>
        /// <param name="lowerDown">The lower right corner of the shape</param>
        private void SetShapePoint(Shape shape, Point upperLeft, Point lowerDown)
        {
            shape.UpperLeft = upperLeft;
            shape.LowerDown = lowerDown;
        }
    }
}
