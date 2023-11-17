using Drawer.Model;
using Drawer.Model.ShapeObjects;
using Drawer.Presentation;
using System;
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
            DrawerModel model = new DrawerModel(shapeFactory);
            PresentationModel presentationModel = new PresentationModel(model);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new From(presentationModel));
        }
    }
}
