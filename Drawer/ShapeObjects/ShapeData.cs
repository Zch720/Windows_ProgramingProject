using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drawer.ShapeObjects
{
    public class ShapeData
    {
        public string ShapeName
        {
            get;
        }
        public string Information
        {
            get;
        }

        public ShapeData(string shapeName, string information)
        {
            ShapeName = shapeName;
            Information = information;
        }
    }
}
