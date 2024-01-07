using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

namespace Drawer.Presentation.Tests
{
    [TestClass]
    public class FormTest
    {
        private Robot _robot;
        private const string APP_TITLE = "Form 1";
        private float widthRatio;
        private float heightRatio;

        [TestInitialize]
        public void SetUp()
        {
            const string PROJECT_NAME = "Drawer";
            string solutionPath = Path.GetFullPath(
                Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "../../../")
            );
            string APP_PATH = Path.Combine(solutionPath, PROJECT_NAME, "bin", "Debug", "Drawer.exe");
            _robot = new Robot(APP_PATH, APP_TITLE);

            widthRatio = 1920.0f / _robot.GetElementWidth("drawArea");
            heightRatio = 1080.0f / _robot.GetElementHeight("drawArea");
        }

        [TestCleanup]
        public void CleanUp()
        {
            _robot.CleanUp();
        }

        [TestMethod]
        public void DrawLine()
        {
            _robot.ClickButton("toolBarLineButton");
            _robot.MoveTo("drawArea", 5, 5, 100, 100);

            _robot.AssertDataGridViewRowCountBy("shapeDatas", 1);
            _robot.AssertDataGridViewCellDataBy("shapeDatas", 0, 1, "線");
            _robot.AssertDataGridViewCellDataBy("shapeDatas", 0, 2, "(5, 5), (100, 100)");
        }

        [TestMethod]
        public void DrawRectangle()
        {
            _robot.ClickButton("toolBarRectangleButton");
            _robot.MoveTo("drawArea", 5, 5, 100, 100);

            _robot.AssertDataGridViewRowCountBy("shapeDatas", 1);
            _robot.AssertDataGridViewCellDataBy("shapeDatas", 0, 1, "矩形");
            _robot.AssertDataGridViewCellDataBy("shapeDatas", 0, 2, "(5, 5), (100, 100)");
        }

        [TestMethod]
        public void DrawCircle()
        {
            _robot.ClickButton("toolBarCircleButton");
            _robot.MoveTo("drawArea", 5, 5, 100, 100);

            _robot.AssertDataGridViewRowCountBy("shapeDatas", 1);
            _robot.AssertDataGridViewCellDataBy("shapeDatas", 0, 1, "圓");
            _robot.AssertDataGridViewCellDataBy("shapeDatas", 0, 2, "(5, 5), (100, 100)");
        }

        [TestMethod]
        public void RedoUndoCreateShape()
        {
            _robot.ClickButton("toolBarRectangleButton");
            _robot.MoveTo("drawArea", 5, 5, 100, 100);

            _robot.ClickButton("toolBarUndoButton");

            _robot.AssertDataGridViewRowCountBy("shapeDatas", 0);

            _robot.ClickButton("toolBarRedoButton");

            _robot.AssertDataGridViewRowCountBy("shapeDatas", 1);
            _robot.AssertDataGridViewCellDataBy("shapeDatas", 0, 1, "矩形");
            _robot.AssertDataGridViewCellDataBy("shapeDatas", 0, 2, "(5, 5), (100, 100)");
        }

        [TestMethod]
        public void RedoUndoScale()
        {
            _robot.ClickButton("toolBarRectangleButton");
            _robot.MoveTo("drawArea", 5, 5, 100, 100);
            _robot.MoveTo("drawArea", 50, 50, 50, 50);
            _robot.MoveTo("drawArea", 100, 100, 150, 150);

            _robot.ClickButton("toolBarUndoButton");

            _robot.AssertDataGridViewRowCountBy("shapeDatas", 1);
            _robot.AssertDataGridViewCellDataBy("shapeDatas", 0, 1, "矩形");
            _robot.AssertDataGridViewCellDataBy("shapeDatas", 0, 2, "(5, 5), (150, 150)");

            _robot.ClickButton("toolBarRedoButton");

            _robot.AssertDataGridViewRowCountBy("shapeDatas", 1);
            _robot.AssertDataGridViewCellDataBy("shapeDatas", 0, 1, "矩形");
            _robot.AssertDataGridViewCellDataBy("shapeDatas", 0, 2, "(5, 5), (100, 100)");
        }

        [TestMethod]
        public void RedoUndoMoveShape()
        {
            _robot.ClickButton("toolBarRectangleButton");
            _robot.MoveTo("drawArea", 5, 5, 100, 100);
            _robot.MoveTo("drawArea", 50, 50, 50, 50);
            _robot.MoveTo("drawArea", 50, 50, 100, 100);

            _robot.ClickButton("toolBarUndoButton");

            _robot.AssertDataGridViewRowCountBy("shapeDatas", 1);
            _robot.AssertDataGridViewCellDataBy("shapeDatas", 0, 1, "矩形");
            _robot.AssertDataGridViewCellDataBy("shapeDatas", 0, 2, "(5, 5), (100, 100)");

            _robot.ClickButton("toolBarRedoButton");

            _robot.AssertDataGridViewRowCountBy("shapeDatas", 1);
            _robot.AssertDataGridViewCellDataBy("shapeDatas", 0, 1, "矩形");
            _robot.AssertDataGridViewCellDataBy("shapeDatas", 0, 2, "(55, 55), (150, 150)");
        }
    }
}
