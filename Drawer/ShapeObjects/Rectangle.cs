using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drawer.ShapeObjects
{
    class Rectangle : Shape
    {
        const string SHAPE_NAME = "矩形";

        public override string Name
        {
            get
            {
                return SHAPE_NAME;
            }
        }
    }
}
