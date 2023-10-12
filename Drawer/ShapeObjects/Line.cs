using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drawer.ShapeObjects
{
    class Line : Shape
    {
        const string SHAPE_NAME = "線";

        public override string Name
        {
            get
            {
                return SHAPE_NAME;
            }
        }
    }
}
