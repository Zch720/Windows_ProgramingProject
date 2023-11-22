using Drawer.Model.ShapeObjects;
using DrawerTests;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Drawer.Model.Tests
{
    [TestClass]
    public class DrawerModelTest
    {
        private const string LINE_STR = "線";
        private const string RECTANGLE_STR = "矩形";
        private const string CIRCLE_STR = "圓";

        private static ShapeFactory _shapeFactory;

        [ClassInitialize]
        public static void SetUp(TestContext context)
        {
            _shapeFactory = new ShapeFactory();
        }

        [TestMethod]
        public void CreateOneRandomNumber()
        {
            DrawerModel model = new DrawerModel(_shapeFactory);

            model.CreateRandomShape(LINE_STR, new Point(100, 100));

            Assert.AreEqual(1, model.ShapeDatas.Count);
            Assert.AreEqual(LINE_STR, model.ShapeDatas[0].ShapeName);
        }

        [TestMethod]
        public void CreateTwoRandomNumber()
        {
            DrawerModel model = new DrawerModel(_shapeFactory);

            model.CreateRandomShape(RECTANGLE_STR, new Point(100, 100));
            model.CreateRandomShape(CIRCLE_STR, new Point(100, 100));

            Assert.AreEqual(2, model.ShapeDatas.Count);
            Assert.AreEqual(RECTANGLE_STR, model.ShapeDatas[0].ShapeName);
            Assert.AreEqual(CIRCLE_STR, model.ShapeDatas[1].ShapeName);
        }

        [TestMethod]
        public void ShapeListUpdatedShouldBeNotifyAfterCreateRandomShape()
        {
            DrawerModel model = new DrawerModel(_shapeFactory);
            int notifyCount = 0;

            model._shapesListUpdated += () => {
                notifyCount++;
            };
            model.CreateRandomShape(LINE_STR, new Point(100, 100));

            Assert.AreEqual(1, notifyCount);
        }

        [TestMethod]
        public void DeleteFirstShape()
        {
            DrawerModel model = new DrawerModel(_shapeFactory);
            CreateShape(model, ShapeType.Line, new Point(0, 0), new Point(1, 1));
            CreateShape(model, ShapeType.Rectangle, new Point(0, 0), new Point(1, 1));
            CreateShape(model, ShapeType.Circle, new Point(0, 0), new Point(1, 1));

            model.DeleteShape(0);

            Assert.AreEqual(2, model.ShapeDatas.Count);
            Assert.AreEqual(RECTANGLE_STR, model.ShapeDatas[0].ShapeName);
            Assert.AreEqual(CIRCLE_STR, model.ShapeDatas[1].ShapeName);
        }

        [TestMethod]
        public void DeleteLastShape()
        {
            DrawerModel model = new DrawerModel(_shapeFactory);
            CreateShape(model, ShapeType.Line, new Point(0, 0), new Point(1, 1));
            CreateShape(model, ShapeType.Rectangle, new Point(0, 0), new Point(1, 1));
            CreateShape(model, ShapeType.Circle, new Point(0, 0), new Point(1, 1));

            model.DeleteShape(2);

            Assert.AreEqual(2, model.ShapeDatas.Count);
            Assert.AreEqual(LINE_STR, model.ShapeDatas[0].ShapeName);
            Assert.AreEqual(RECTANGLE_STR, model.ShapeDatas[1].ShapeName);
        }

        [TestMethod]
        public void DeleteMiddleShape()
        {
            DrawerModel model = new DrawerModel(_shapeFactory);
            CreateShape(model, ShapeType.Line, new Point(0, 0), new Point(1, 1));
            CreateShape(model, ShapeType.Rectangle, new Point(0, 0), new Point(1, 1));
            CreateShape(model, ShapeType.Circle, new Point(0, 0), new Point(1, 1));

            model.DeleteShape(1);

            Assert.AreEqual(2, model.ShapeDatas.Count);
            Assert.AreEqual(LINE_STR, model.ShapeDatas[0].ShapeName);
            Assert.AreEqual(CIRCLE_STR, model.ShapeDatas[1].ShapeName);
        }

        [TestMethod]
        public void DeleteShapeOverflow()
        {
            DrawerModel model = new DrawerModel(_shapeFactory);
            CreateShape(model, ShapeType.Line, new Point(0, 0), new Point(1, 1));
            CreateShape(model, ShapeType.Rectangle, new Point(0, 0), new Point(1, 1));
            CreateShape(model, ShapeType.Circle, new Point(0, 0), new Point(1, 1));

            model.DeleteShape(3);

            Assert.AreEqual(3, model.ShapeDatas.Count);
            Assert.AreEqual(LINE_STR, model.ShapeDatas[0].ShapeName);
            Assert.AreEqual(RECTANGLE_STR, model.ShapeDatas[1].ShapeName);
            Assert.AreEqual(CIRCLE_STR, model.ShapeDatas[2].ShapeName);
        }

        [TestMethod]
        public void DeleteShapeUnderflow()
        {
            DrawerModel model = new DrawerModel(_shapeFactory);
            CreateShape(model, ShapeType.Line, new Point(0, 0), new Point(1, 1));
            CreateShape(model, ShapeType.Rectangle, new Point(0, 0), new Point(1, 1));
            CreateShape(model, ShapeType.Circle, new Point(0, 0), new Point(1, 1));

            model.DeleteShape(-1);

            Assert.AreEqual(3, model.ShapeDatas.Count);
            Assert.AreEqual(LINE_STR, model.ShapeDatas[0].ShapeName);
            Assert.AreEqual(RECTANGLE_STR, model.ShapeDatas[1].ShapeName);
            Assert.AreEqual(CIRCLE_STR, model.ShapeDatas[2].ShapeName);
        }

        [TestMethod]
        public void ShapesListUpdatedShouldBeNotifyAfterDeleteShape()
        {
            DrawerModel model = new DrawerModel(_shapeFactory);
            int notifyCount = 0;

            model._shapesListUpdated += () => {
                notifyCount++;
            };
            model.DeleteShape(0);

            Assert.AreEqual(1, notifyCount);
        }

        [TestMethod]
        public void TempShapeUpdatedShouldBeNotifyAfterCreateTempShape()
        {
            DrawerModel model = new DrawerModel(_shapeFactory);
            int notifyCount = 0;

            model._tempShapeUpdated += () => {
                notifyCount++;
            };
            model.CreateTempShape(ShapeType.Line, new Point(0, 0));

            Assert.AreEqual(1, notifyCount);
        }

        [TestMethod]
        public void TempShapeUpdatedShouldBeNotifyAfterUpdateTempShape()
        {
            DrawerModel model = new DrawerModel(_shapeFactory);
            int notifyCount = 0;
            model.CreateTempShape(ShapeType.Line, new Point(0, 0));

            model._tempShapeUpdated += () => {
                notifyCount++;
            };
            model.UpdateTempShape(new Point(5, 5));

            Assert.AreEqual(1, notifyCount);
        }

        [TestMethod]
        public void ShapeListUpdatedShouldBeNotifyAfterSaveTempShape()
        {
            DrawerModel model = new DrawerModel(_shapeFactory);
            int notifyCount = 0;
            model.CreateTempShape(ShapeType.Line, new Point(0, 0));

            model._shapesListUpdated += () => {
                notifyCount++;
            };
            model.SaveTempShape();

            Assert.AreEqual(1, notifyCount);
        }

        [TestMethod]
        public void DrawWithTemp()
        {
            FakeGraphics graphics = new FakeGraphics();
            DrawerModel model = new DrawerModel(_shapeFactory);
            model.CreateTempShape(ShapeType.Line, new Point(4, 4));

            model.DrawWithTemp(graphics);

            Assert.AreEqual(1, graphics.NotifyDrawLineCount);
            Assert.AreEqual(0, graphics.NotifyDrawRectangleCount);
            Assert.AreEqual(0, graphics.NotifyDrawCircleCount);
            Assert.AreEqual(0, graphics.NotifyDrawSelectBoxCount);
        }

        [TestMethod]
        public void SelectShape()
        {
            DrawerModel model = new DrawerModel(_shapeFactory);
            TestUtilities.CreateShape(model, ShapeType.Line, new Point(0, 3), new Point(5, 6));

            model.SelectedShapeAtPoint(new Point(2, 5));

            Assert.IsTrue(model.ShapeDatas[0].IsSelected);
        }

        [TestMethod]
        public void SelectShapeOverlap()
        {
            DrawerModel model = new DrawerModel(_shapeFactory);
            TestUtilities.CreateShape(model, ShapeType.Circle, new Point(1, 4), new Point(9, 7));
            TestUtilities.CreateShape(model, ShapeType.Line, new Point(0, 3), new Point(5, 6));

            model.SelectedShapeAtPoint(new Point(2, 5));

            Assert.IsFalse(model.ShapeDatas[0].IsSelected);
            Assert.IsTrue(model.ShapeDatas[1].IsSelected);
        }

        [TestMethod]
        public void CancelSelectShape()
        {
            DrawerModel model = new DrawerModel(_shapeFactory);
            TestUtilities.CreateShape(model, ShapeType.Circle, new Point(1, 4), new Point(9, 7));
            TestUtilities.CreateShape(model, ShapeType.Line, new Point(0, 3), new Point(5, 6));
            model.SelectedShapeAtPoint(new Point(2, 5));
            Assert.IsTrue(model.ShapeDatas[1].IsSelected);

            model.SelectedShapeAtPoint(new Point(10, 10));

            Assert.IsFalse(model.ShapeDatas[0].IsSelected);
            Assert.IsFalse(model.ShapeDatas[1].IsSelected);
        }

        [TestMethod]
        public void ShapesListUpdatedShouldNotifyAfterSelectShape()
        {
            DrawerModel model = new DrawerModel(_shapeFactory);
            int notifyCount = 0;

            model._shapesListUpdated += () => {
                notifyCount++;
            };
            model.SelectedShapeAtPoint(new Point(20, 20));

            Assert.AreEqual(1, notifyCount);
        }

        [TestMethod]
        public void ShapesListUpdatedShouldBeNotifyAfterMoveSelectedShape()
        {
            DrawerModel model = new DrawerModel(_shapeFactory);
            int notifyCount = 0;

            model._shapesListUpdated += () => {
                notifyCount++;
            };
            model.MoveSelectedShape(new Point(20, 20));

            Assert.AreEqual(1, notifyCount);
        }

        [TestMethod]
        public void ShapesListUpdatedShouldBeNotifyAfterDeleteSelectedShape()
        {
            DrawerModel model = new DrawerModel(_shapeFactory);
            int notifyCount = 0;

            model._shapesListUpdated += () => {
                notifyCount++;
            };
            model.DeleteSelectedShape();

            Assert.AreEqual(1, notifyCount);
        }

        private void CreateShape(DrawerModel model, ShapeType type, Point point1, Point point2)
        {
            model.CreateTempShape(type, point1);
            model.UpdateTempShape(point2);
            model.SaveTempShape();
        }
    }
}
