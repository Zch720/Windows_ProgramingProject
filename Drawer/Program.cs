using Drawer.ShapeObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Drawer
{
    static class Program
    {

        /// <summary>
        /// 應用程式的主要進入點。
        /// </summary>
        [STAThread]
        static void Main()
        {
            ShapeFactory shapeFactory = new ShapeFactory();
            Model model = new Model(shapeFactory);
            PersentationModel persentationModel = new PersentationModel(model);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new From(persentationModel));
        }
    }
}
