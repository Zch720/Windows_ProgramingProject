using Drawer.Model.ShapeObjects;
using Drawer.Model.State;
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

        /// <inheritdoc/>
        [ClassInitialize]
        public static void SetUp(TestContext context)
        {
            _shapeFactory = new ShapeFactory();
        }

        /// <inheritdoc/>
        [TestMethod]
        public void DefaultStateIsPointerState()
        {
            DrawerModel model = new DrawerModel(_shapeFactory);
            PrivateObject privateModel = new PrivateObject(model);

            IState state = privateModel.GetField("_state") as IState;

            Assert.IsNotNull(state);
            Assert.IsTrue(state is ModelPointerState);
        }

        /// <inheritdoc/>
        [TestMethod]
        public void SetStateToDrawingState()
        {
            DrawerModel model = new DrawerModel(_shapeFactory);
            PrivateObject privateModel = new PrivateObject(model);

            model.SetDrawingState(ShapeType.Line);

            IState state = privateModel.GetField("_state") as IState;
            Assert.IsNotNull(state);
            Assert.IsTrue(state is ModelDrawingState);
        }

        /// <inheritdoc/>
        [TestMethod]
        public void SetStateToPointerState()
        {
            DrawerModel model = new DrawerModel(_shapeFactory);
            PrivateObject privateModel = new PrivateObject(model);
            model.SetDrawingState(ShapeType.Line);

            model.SetPointerState();

            IState state = privateModel.GetField("_state") as IState;
            Assert.IsNotNull(state);
            Assert.IsTrue(state is ModelPointerState);
        }

        /// <inheritdoc/>
        [TestMethod]
        public void CreateOneRandomShape()
        {
            DrawerModel model = new DrawerModel(_shapeFactory);

            model.CreateRandomShape(LINE_STR, new Point(100, 100));

            Assert.AreEqual(1, model.ShapeDatas.Count);
            Assert.AreEqual(LINE_STR, model.ShapeDatas[0].ShapeName);
        }
        
        /// <inheritdoc/>
        [TestMethod]
        public void CreateTwoRandomShape()
        {
            DrawerModel model = new DrawerModel(_shapeFactory);

            model.CreateRandomShape(RECTANGLE_STR, new Point(100, 100));
            model.CreateRandomShape(CIRCLE_STR, new Point(100, 100));

            Assert.AreEqual(2, model.ShapeDatas.Count);
            Assert.AreEqual(RECTANGLE_STR, model.ShapeDatas[0].ShapeName);
            Assert.AreEqual(CIRCLE_STR, model.ShapeDatas[1].ShapeName);
        }
        
        /// <inheritdoc/>
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
        
        /// <inheritdoc/>
        [TestMethod]
        public void DeleteFirstShape()
        {
            DrawerModel model = new DrawerModel(_shapeFactory);
            TestUtilities.CreateShape(model, ShapeType.Line, new Point(0, 0), new Point(1, 1));
            TestUtilities.CreateShape(model, ShapeType.Rectangle, new Point(0, 0), new Point(1, 1));
            TestUtilities.CreateShape(model, ShapeType.Circle, new Point(0, 0), new Point(1, 1));

            model.DeleteShape(0);

            Assert.AreEqual(2, model.ShapeDatas.Count);
            Assert.AreEqual(RECTANGLE_STR, model.ShapeDatas[0].ShapeName);
            Assert.AreEqual(CIRCLE_STR, model.ShapeDatas[1].ShapeName);
        }
        
        /// <inheritdoc/>
        [TestMethod]
        public void DeleteLastShape()
        {
            DrawerModel model = new DrawerModel(_shapeFactory);
            TestUtilities.CreateShape(model, ShapeType.Line, new Point(0, 0), new Point(1, 1));
            TestUtilities.CreateShape(model, ShapeType.Rectangle, new Point(0, 0), new Point(1, 1));
            TestUtilities.CreateShape(model, ShapeType.Circle, new Point(0, 0), new Point(1, 1));

            model.DeleteShape(2);

            Assert.AreEqual(2, model.ShapeDatas.Count);
            Assert.AreEqual(LINE_STR, model.ShapeDatas[0].ShapeName);
            Assert.AreEqual(RECTANGLE_STR, model.ShapeDatas[1].ShapeName);
        }
        
        /// <inheritdoc/>
        [TestMethod]
        public void DeleteMiddleShape()
        {
            DrawerModel model = new DrawerModel(_shapeFactory);
            TestUtilities.CreateShape(model, ShapeType.Line, new Point(0, 0), new Point(1, 1));
            TestUtilities.CreateShape(model, ShapeType.Rectangle, new Point(0, 0), new Point(1, 1));
            TestUtilities.CreateShape(model, ShapeType.Circle, new Point(0, 0), new Point(1, 1));

            model.DeleteShape(1);

            Assert.AreEqual(2, model.ShapeDatas.Count);
            Assert.AreEqual(LINE_STR, model.ShapeDatas[0].ShapeName);
            Assert.AreEqual(CIRCLE_STR, model.ShapeDatas[1].ShapeName);
        }
        
        /// <inheritdoc/>
        [TestMethod]
        public void DeleteShapeOverflow()
        {
            DrawerModel model = new DrawerModel(_shapeFactory);
            TestUtilities.CreateShape(model, ShapeType.Line, new Point(0, 0), new Point(1, 1));
            TestUtilities.CreateShape(model, ShapeType.Rectangle, new Point(0, 0), new Point(1, 1));
            TestUtilities.CreateShape(model, ShapeType.Circle, new Point(0, 0), new Point(1, 1));

            model.DeleteShape(3);

            Assert.AreEqual(3, model.ShapeDatas.Count);
            Assert.AreEqual(LINE_STR, model.ShapeDatas[0].ShapeName);
            Assert.AreEqual(RECTANGLE_STR, model.ShapeDatas[1].ShapeName);
            Assert.AreEqual(CIRCLE_STR, model.ShapeDatas[2].ShapeName);
        }
        
        /// <inheritdoc/>
        [TestMethod]
        public void DeleteShapeUnderflow()
        {
            DrawerModel model = new DrawerModel(_shapeFactory);
            TestUtilities.CreateShape(model, ShapeType.Line, new Point(0, 0), new Point(1, 1));
            TestUtilities.CreateShape(model, ShapeType.Rectangle, new Point(0, 0), new Point(1, 1));
            TestUtilities.CreateShape(model, ShapeType.Circle, new Point(0, 0), new Point(1, 1));

            model.DeleteShape(-1);

            Assert.AreEqual(3, model.ShapeDatas.Count);
            Assert.AreEqual(LINE_STR, model.ShapeDatas[0].ShapeName);
            Assert.AreEqual(RECTANGLE_STR, model.ShapeDatas[1].ShapeName);
            Assert.AreEqual(CIRCLE_STR, model.ShapeDatas[2].ShapeName);
        }
        
        /// <inheritdoc/>
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

        /// <inheritdoc/>
        [TestMethod]
        public void CreateTempShapeWhenStateIsDrawing()
        {
            FakeGraphics graphics = new FakeGraphics();
            DrawerModel model = new DrawerModel(_shapeFactory);
            model.SetDrawingState(ShapeType.Line);

            model.SelectOrCreateShape(new Point(10, 10));

            model.DrawWithTemp(graphics);
            Assert.AreEqual(1, graphics.NotifyDrawLineCount);
            Assert.AreEqual("(10, 10), (10, 10)", graphics.LineDrawHistories[0]);
            Assert.AreEqual(0, graphics.NotifyDrawRectangleCount);
            Assert.AreEqual(0, graphics.NotifyDrawCircleCount);
            Assert.AreEqual(0, graphics.NotifyDrawSelectBoxCount);
        }

        /// <inheritdoc/>
        [TestMethod]
        public void TempShapeUpdatedShouldBeNotifyAfterCreateTempShape()
        {
            DrawerModel model = new DrawerModel(_shapeFactory);
            int notifyCount = 0;
            model.SetDrawingState(ShapeType.Line);

            model._tempShapeUpdated += () =>
            {
                notifyCount++;
            };
            model.SelectOrCreateShape(new Point(10, 10));

            Assert.AreEqual(1, notifyCount);
        }

        /// <inheritdoc/>
        [TestMethod]
        public void TempShapeUpdatedShouldBeNotifyAfterUpdatedTempShape()
        {
            DrawerModel model = new DrawerModel(_shapeFactory);
            int notifyCount = 0;
            model.SetDrawingState(ShapeType.Line);
            model.SelectOrCreateShape(new Point(10, 10));

            model._tempShapeUpdated += () =>
            {
                notifyCount++;
            };
            model.UpdateShape(new Point(20, 20));

            Assert.AreEqual(1, notifyCount);
        }

        /// <inheritdoc/>
        [TestMethod]
        public void UpdateTempShapeWhenStateIsDrawing()
        {
            FakeGraphics graphics = new FakeGraphics();
            DrawerModel model = new DrawerModel(_shapeFactory);
            model.SetDrawingState(ShapeType.Line);
            model.SelectOrCreateShape(new Point(10, 10));

            model.UpdateShape(new Point(20, 20));

            model.DrawWithTemp(graphics);
            Assert.AreEqual(1, graphics.NotifyDrawLineCount);
            Assert.AreEqual("(10, 10), (20, 20)", graphics.LineDrawHistories[0]);
            Assert.AreEqual(0, graphics.NotifyDrawRectangleCount);
            Assert.AreEqual(0, graphics.NotifyDrawCircleCount);
            Assert.AreEqual(0, graphics.NotifyDrawSelectBoxCount);
        }

        /// <inheritdoc/>
        [TestMethod]
        public void ShapeListUpdatedShouldBeNotifyAfterSavedTempShape()
        {
            DrawerModel model = new DrawerModel(_shapeFactory);
            int notifyCount = 0;
            model.SetDrawingState(ShapeType.Line);
            model.SelectOrCreateShape(new Point(10, 10));

            model._shapesListUpdated += () =>
            {
                notifyCount++;
            };
            model.SaveShape(new Point(20, 20));

            Assert.AreEqual(1, notifyCount);
        }

        /// <inheritdoc/>
        [TestMethod]
        public void SaveTempShapeWhenStateIsDrawing()
        {
            FakeGraphics graphics = new FakeGraphics();
            DrawerModel model = new DrawerModel(_shapeFactory);
            model.SetDrawingState(ShapeType.Line);
            model.SelectOrCreateShape(new Point(10, 10));

            model.SaveShape(new Point(20, 20));

            Assert.AreEqual(1, model.ShapeDatas.Count);
            Assert.AreEqual("(10, 10), (20, 20)", model.ShapeDatas[0].Information);
        }

        /// <inheritdoc/>
        [TestMethod]
        public void TempShapeSavedShouldBeNotifyAfterSaveTempShape()
        {
            DrawerModel model = new DrawerModel(_shapeFactory);
            int notifyCount = 0;
            model.SetDrawingState(ShapeType.Line);
            model.SelectOrCreateShape(new Point(10, 10));

            model._tempShapeSaved += () => {
                notifyCount++;
            };
            model.SaveShape(new Point(20, 20));

            Assert.AreEqual(1, notifyCount);
        }
        
        /// <inheritdoc/>
        [TestMethod]
        public void DrawWithTemp()
        {
            FakeGraphics graphics = new FakeGraphics();
            DrawerModel model = new DrawerModel(_shapeFactory);
            model.SetDrawingState(ShapeType.Line);
            model.SelectOrCreateShape(new Point(4, 4));

            model.DrawWithTemp(graphics);

            Assert.AreEqual(1, graphics.NotifyDrawLineCount);
            Assert.AreEqual(0, graphics.NotifyDrawRectangleCount);
            Assert.AreEqual(0, graphics.NotifyDrawCircleCount);
            Assert.AreEqual(0, graphics.NotifyDrawSelectBoxCount);
        }

        /// <inheritdoc/>
        [TestMethod]
        public void SelectShapeWhenStateIsPointer()
        {
            DrawerModel model = new DrawerModel(_shapeFactory);
            TestUtilities.CreateShape(model, ShapeType.Circle, new Point(1, 4), new Point(9, 7));
            TestUtilities.CreateShape(model, ShapeType.Line, new Point(0, 3), new Point(5, 6));
            model.SetPointerState();

            model.SelectOrCreateShape(new Point(2, 5));

            Assert.IsFalse(model.ShapeDatas[0].IsSelected);
            Assert.IsTrue(model.ShapeDatas[1].IsSelected);
        }

        /// <inheritdoc/>
        [TestMethod]
        public void MoveShapeWhenStateIsPointer()
        {
            DrawerModel model = new DrawerModel(_shapeFactory);
            TestUtilities.CreateShape(model, ShapeType.Circle, new Point(1, 4), new Point(9, 7));
            TestUtilities.CreateShape(model, ShapeType.Line, new Point(0, 3), new Point(5, 6));
            model.SetPointerState();
            model.SelectOrCreateShape(new Point(2, 5));

            model.UpdateShape(new Point(3, 7));

            Assert.AreEqual("(1, 4), (9, 7)", model.ShapeDatas[0].Information);
            Assert.AreEqual("(1, 5), (6, 8)", model.ShapeDatas[1].Information);
        }

        /// <inheritdoc/>
        [TestMethod]
        public void SaveShapeWhenStateIsPointer()
        {
            DrawerModel model = new DrawerModel(_shapeFactory);
            TestUtilities.CreateShape(model, ShapeType.Circle, new Point(1, 4), new Point(9, 7));
            TestUtilities.CreateShape(model, ShapeType.Line, new Point(0, 3), new Point(5, 6));
            model.SetPointerState();
            model.SelectOrCreateShape(new Point(2, 5));

            model.SaveShape(new Point(3, 7));

            Assert.AreEqual("(1, 4), (9, 7)", model.ShapeDatas[0].Information);
            Assert.AreEqual("(1, 5), (6, 8)", model.ShapeDatas[1].Information);
        }

        /// <inheritdoc/>
        [TestMethod]
        public void ShapesListUpdatedShouldNotifyAfterSelectShape()
        {
            DrawerModel model = new DrawerModel(_shapeFactory);
            int notifyCount = 0;

            model._shapesListUpdated += () => {
                notifyCount++;
            };
            model.SelectOrCreateShape(new Point(20, 20));

            Assert.AreEqual(1, notifyCount);
        }
        
        /// <inheritdoc/>
        [TestMethod]
        public void ShapesListUpdatedShouldBeNotifyAfterMoveSelectedShape()
        {
            DrawerModel model = new DrawerModel(_shapeFactory);
            int notifyCount = 0;
            model.SelectOrCreateShape(new Point(20, 20));

            model._shapesListUpdated += () => {
                notifyCount++;
            };
            model.UpdateShape(new Point(20, 20));

            Assert.AreEqual(1, notifyCount);
        }

        /// <inheritdoc/>
        [TestMethod]
        public void ShapesListUpdatedShouldBeNotifyAfterSaveSelectedShape()
        {
            DrawerModel model = new DrawerModel(_shapeFactory);
            int notifyCount = 0;
            model.SelectOrCreateShape(new Point(20, 20));

            model._shapesListUpdated += () => {
                notifyCount++;
            };
            model.SaveShape(new Point(20, 20));

            Assert.AreEqual(1, notifyCount);
        }

        /// <inheritdoc/>
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
    }
}
