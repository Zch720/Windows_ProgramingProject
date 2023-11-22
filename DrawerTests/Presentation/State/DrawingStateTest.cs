using Drawer.Model;
using Drawer.Model.ShapeObjects;
using DrawerTests;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Drawer.Presentation.State.Tests
{
    [TestClass]
    public class DrawingStateTest
    {
        private DrawerModel _model;

        [TestInitialize]
        public void SetUp()
        {
            ShapeFactory factory = new ShapeFactory();
            _model = new DrawerModel(factory);

            TestUtilities.CreateShape(_model, ShapeType.Line, new Point(10, 5), new Point(3, 7));
            TestUtilities.CreateShape(_model, ShapeType.Circle, new Point(5, 9), new Point(11, 13));
        }

        [TestMethod]
        public void SetShapeTypeToLine()
        {
            DrawingState state = new DrawingState(_model, ShapeType.Line, () => {});

            Assert.AreEqual(ShapeType.Line, state.SelectedShapeType);
        }

        [TestMethod]
        public void SetShapeTypeToRectangle()
        {
            DrawingState state = new DrawingState(_model, ShapeType.Rectangle, () => {});

            Assert.AreEqual(ShapeType.Rectangle, state.SelectedShapeType);
        }

        [TestMethod]
        public void SetShapeTypeToCircle()
        {
            DrawingState state = new DrawingState(_model, ShapeType.Circle, () => {});

            Assert.AreEqual(ShapeType.Circle, state.SelectedShapeType);
        }

        [TestMethod]
        public void ThereShouldBeOneTempShapeAfterMouseDown()
        {
            DrawingState state = new DrawingState(_model, ShapeType.Line, () => {});

            state.HandleMouseDown(3, 5);

            FakeGraphics graphics = new FakeGraphics();
            _model.DrawWithTemp(graphics);
            Assert.AreEqual(2, graphics.NotifyDrawLineCount);
            Assert.AreEqual("(10, 5), (3, 7)", graphics.LineDrawHistories[0]);
            Assert.AreEqual("(3, 5), (3, 5)", graphics.LineDrawHistories[1]);
            Assert.AreEqual(0, graphics.NotifyDrawRectangleCount);
            Assert.AreEqual(1, graphics.NotifyDrawCircleCount);
            Assert.AreEqual("(5, 9), (11, 13)", graphics.CircleDrawHistories[0]);
            Assert.AreEqual(0, graphics.NotifyDrawSelectBoxCount);
        }

        [TestMethod]
        public void Point2OfTempShouldBeUpdatedAfterMouseMove()
        {
            DrawingState state = new DrawingState(_model, ShapeType.Rectangle, () => {});
            state.HandleMouseDown(13, 5);

            state.HandleMouseMove(7, 10);

            FakeGraphics graphics = new FakeGraphics();
            _model.DrawWithTemp(graphics);
            Assert.AreEqual(1, graphics.NotifyDrawLineCount);
            Assert.AreEqual("(10, 5), (3, 7)", graphics.LineDrawHistories[0]);
            Assert.AreEqual(1, graphics.NotifyDrawRectangleCount);
            Assert.AreEqual("(7, 5), (13, 10)", graphics.RectangleDrawHistories[0]);
            Assert.AreEqual(1, graphics.NotifyDrawCircleCount);
            Assert.AreEqual("(5, 9), (11, 13)", graphics.CircleDrawHistories[0]);
            Assert.AreEqual(0, graphics.NotifyDrawSelectBoxCount);
        }

        [TestMethod]
        public void DoNothingWhenMouseMoveWithoutMouseDown()
        {
            DrawingState state = new DrawingState(_model, ShapeType.Rectangle, () => { });

            state.HandleMouseMove(7, 10);

            FakeGraphics graphics = new FakeGraphics();
            _model.DrawWithTemp(graphics);
            Assert.AreEqual(1, graphics.NotifyDrawLineCount);
            Assert.AreEqual("(10, 5), (3, 7)", graphics.LineDrawHistories[0]);
            Assert.AreEqual(0, graphics.NotifyDrawRectangleCount);
            Assert.AreEqual(1, graphics.NotifyDrawCircleCount);
            Assert.AreEqual("(5, 9), (11, 13)", graphics.CircleDrawHistories[0]);
            Assert.AreEqual(0, graphics.NotifyDrawSelectBoxCount);
        }
        
        [TestMethod]
        public void CreateShapeWhenMouseUpAfterMouseDown()
        {
            DrawingState state = new DrawingState(_model, ShapeType.Rectangle, () => {});
            state.HandleMouseDown(13, 5);

            state.HandleMouseUp(7, 10);

            Assert.AreEqual(3, _model.ShapeDatas.Count);
            Assert.AreEqual("(10, 5), (3, 7)", _model.ShapeDatas[0].Information);
            Assert.AreEqual("(5, 9), (11, 13)", _model.ShapeDatas[1].Information);
            Assert.AreEqual("(7, 5), (13, 10)", _model.ShapeDatas[2].Information);
        }

        [TestMethod]
        public void DoNothingWhenMouseUpWithoutMouseDown()
        {
            DrawingState state = new DrawingState(_model, ShapeType.Rectangle, () => {});

            state.HandleMouseUp(7, 10);

            Assert.AreEqual(2, _model.ShapeDatas.Count);
            Assert.AreEqual("(10, 5), (3, 7)", _model.ShapeDatas[0].Information);
            Assert.AreEqual("(5, 9), (11, 13)", _model.ShapeDatas[1].Information);
        }
    }
}
