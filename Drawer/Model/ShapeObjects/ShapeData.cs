using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drawer.ShapeObjects
{
    public class ShapeData
    {
        [DisplayName("形狀")]
        public string ShapeName
        {
            get;
        }
        [DisplayName("資訊")]
        public string Information
        {
            get;
        }
        
        [Browsable(false)]
        public Point Point1
        {
            get;
        }

        [Browsable(false)]
        public Point Point2
        {
            get;
        }

        [Browsable(false)]
        public float Width
        {
            get;
        }

        [Browsable(false)]
        public float Height
        {
            get;
        }

        public ShapeData(Shape shape)
        {
            ShapeName = shape.Name;
            Information = shape.Info;
            Point1 = shape.Point1;
            Point2 = shape.Point2;
            Width = shape.Width;
            Height = shape.Height;
        }
    }
}
