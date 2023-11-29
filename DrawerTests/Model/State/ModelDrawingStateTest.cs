using Drawer.Model.ShapeObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Drawer.Model.State.Tests
{
    [TestClass]
    public class ModelDrawingStateTest
    {
        private const string LINE_STR = "線";
        private const string RECTANGLE_STR = "矩形";
        private const string CIRCLE_STR = "圓";

        private Shapes _shapes;

        [TestInitialize]
        public void SetUp()
        {
            ShapeFactory shapeFactory = new ShapeFactory();
            _shapes = new Shapes(shapeFactory);
            _shapes.CreateShape(ShapeType.Line, new Point(3, 7), new Point(5, 12));
            _shapes.CreateShape(ShapeType.Circle, new Point(7, 9), new Point(5, 8));
            _shapes.CreateShape(ShapeType.Rectangle, new Point(15, 13), new Point(12, 14));
        }

        [TestMethod]
        public void CurrentScalePointShouldAlwaysBeNull()
        {
            ModelDrawingState state = new ModelDrawingState(_shapes, ShapeType.Line);

            Assert.IsNull(state.CurrentScalePoint);
        }

        [TestMethod]
        public void CreateLineTempShapeInShapes()
        {
            ModelDrawingState state = new ModelDrawingState(_shapes, ShapeType.Line);

            state.SelectedOrCreateShape(new Point(50, 50));

            Assert.AreEqual(LINE_STR, GetTempShapeFromShapes().Name);
        }

        [TestMethod]
        public void CreateRectangleTempShapeInShapes()
        {
            ModelDrawingState state = new ModelDrawingState(_shapes, ShapeType.Rectangle);

            state.SelectedOrCreateShape(new Point(50, 50));

            Assert.AreEqual(RECTANGLE_STR, GetTempShapeFromShapes().Name);
        }

        [TestMethod]
        public void CreateCircleTempShapeInShapes()
        {
            ModelDrawingState state = new ModelDrawingState(_shapes, ShapeType.Circle);

            state.SelectedOrCreateShape(new Point(50, 50));

            Assert.AreEqual(CIRCLE_STR, GetTempShapeFromShapes().Name);
        }

        [TestMethod]
        public void ShapeSelectedOrCreatedShouldBeNotifyAfterCreateShape()
        {
            ModelDrawingState state = new ModelDrawingState(_shapes, ShapeType.Line);
            int notifyCount = 0;

            state._shapeSelectedOrCreated += () => {
                notifyCount++;
            };
            state.SelectedOrCreateShape(new Point(50, 50));

            Assert.AreEqual(1, notifyCount);
        }

        [TestMethod]
        public void UpdateTempShape()
        {
            ModelDrawingState state = new ModelDrawingState(_shapes, ShapeType.Line);
            state.SelectedOrCreateShape(new Point(50, 50));

            state.UpdateShape(new Point(30, 70));

            Assert.AreEqual("(50, 50), (30, 70)", GetTempShapeFromShapes().Info);
        }

        [TestMethod]
        public void UpdateShapeDoNothingIfNotCreateShape()
        {
            ModelDrawingState state = new ModelDrawingState(_shapes, ShapeType.Line);

            state.UpdateShape(new Point(30, 70));

            Assert.IsNull(GetTempShapeFromShapes());
            Assert.AreEqual(3, _shapes.ShapeDatas.Count);
        }

        [TestMethod]
        public void ShapeUpdatedShouldBeNotifyAfterUpdateShape()
        {
            ModelDrawingState state = new ModelDrawingState(_shapes, ShapeType.Line);
            int notifyCount = 0;
            state.SelectedOrCreateShape(new Point(50, 50));

            state._shapeUpdated += () => {
                notifyCount++;
            };
            state.UpdateShape(new Point(30, 70));

            Assert.AreEqual(1, notifyCount);
        }

        [TestMethod]
        public void SaveTempShape()
        {
            ModelDrawingState state = new ModelDrawingState(_shapes, ShapeType.Line);
            state.SelectedOrCreateShape(new Point(50, 50));

            state.SaveShape(new Point(30, 70));

            Assert.IsNull(GetTempShapeFromShapes());
            Assert.AreEqual(4, _shapes.ShapeDatas.Count);
            Assert.AreEqual(LINE_STR, _shapes.ShapeDatas[3].ShapeName);
            Assert.AreEqual("(50, 50), (30, 70)", _shapes.ShapeDatas[3].Information);
        }

        [TestMethod]
        public void SaveTempShapeDoNothingIfNotCreateShape()
        {
            ModelDrawingState state = new ModelDrawingState(_shapes, ShapeType.Line);

            state.SaveShape(new Point(30, 70));

            Assert.IsNull(GetTempShapeFromShapes());
            Assert.AreEqual(3, _shapes.ShapeDatas.Count);
        }

        [TestMethod]
        public void ShapeSavedShouldBeNotifyAfterSaveShape()
        {
            ModelDrawingState state = new ModelDrawingState(_shapes, ShapeType.Line);
            int notifyCount = 0;
            state.SelectedOrCreateShape(new Point(50, 50));

            state._shapeSaved += () => {
                notifyCount++;
            };
            state.SaveShape(new Point(30, 70));

            Assert.AreEqual(1, notifyCount);
        }

        private Shape GetTempShapeFromShapes()
        {
            PrivateObject privateShapes = new PrivateObject(_shapes);
            return privateShapes.GetField("_tempShape") as Shape;
        }
    }
}
