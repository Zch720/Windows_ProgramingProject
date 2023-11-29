using Drawer.Model.ShapeObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Drawer.Model.State.Tests
{
    [TestClass]
    public class ModelPointerStateTest
    {
        private Shapes _shapes;

        /// <inheritdoc/>
        [TestInitialize]
        public void SetUp()
        {
            ShapeFactory shapeFactory = new ShapeFactory();
            _shapes = new Shapes(shapeFactory);
            _shapes.CreateShape(ShapeType.Line, new Point(3, 7), new Point(5, 12));
            _shapes.CreateShape(ShapeType.Circle, new Point(7, 9), new Point(5, 8));
            _shapes.CreateShape(ShapeType.Rectangle, new Point(25, 13), new Point(12, 24));
        }

        /// <inheritdoc/>
        [TestMethod]
        public void SelectedShapeInShapes()
        {
            ModelPointerState state = new ModelPointerState(_shapes);

            state.SelectOrCreateShape(new Point(4, 8));

            Assert.IsTrue(_shapes.ShapeDatas[0].IsSelected);
            Assert.IsFalse(_shapes.ShapeDatas[1].IsSelected);
            Assert.IsFalse(_shapes.ShapeDatas[2].IsSelected);
        }

        /// <inheritdoc/>
        [TestMethod]
        public void ShapeSelectedOrCreatedShouldBeNotifyAfterSelectShape()
        {
            ModelPointerState state = new ModelPointerState(_shapes);
            int notifyCount = 0;

            state._shapeSelectedOrCreated += () => {
                notifyCount++;
            };
            state.SelectOrCreateShape(new Point(4, 8));

            Assert.AreEqual(1, notifyCount);
        }

        /// <inheritdoc/>
        [TestMethod]
        public void UpdateSelectedShape()
        {
            ModelPointerState state = new ModelPointerState(_shapes);
            state.SelectOrCreateShape(new Point(4, 8));

            state.UpdateShape(new Point(6, 11));

            Assert.AreEqual("(5, 10), (7, 15)", _shapes.ShapeDatas[0].Information);
            Assert.AreEqual("(5, 8), (7, 9)", _shapes.ShapeDatas[1].Information);
            Assert.AreEqual("(12, 13), (25, 24)", _shapes.ShapeDatas[2].Information);
        }

        /// <inheritdoc/>
        [TestMethod]
        public void ShapeUpdatedShouldBeNotifyAfterUpdateShape()
        {
            ModelPointerState state = new ModelPointerState(_shapes);
            state.SelectOrCreateShape(new Point(4, 8));
            int notifyCount = 0;

            state._shapeUpdated += () => {
                notifyCount++;
            };
            state.UpdateShape(new Point(6, 11));

            Assert.AreEqual(1, notifyCount);
        }

        /// <inheritdoc/>
        [TestMethod]
        public void SaveSelectedShape()
        {
            ModelPointerState state = new ModelPointerState(_shapes);
            state.SelectOrCreateShape(new Point(4, 8));

            state.SaveShape(new Point(6, 11));

            Assert.AreEqual("(5, 10), (7, 15)", _shapes.ShapeDatas[0].Information);
            Assert.AreEqual("(5, 8), (7, 9)", _shapes.ShapeDatas[1].Information);
            Assert.AreEqual("(12, 13), (25, 24)", _shapes.ShapeDatas[2].Information);
        }

        /// <inheritdoc/>
        [TestMethod]
        public void ShapeSavedShouldBeNotifyAfterSaveShape()
        {
            ModelPointerState state = new ModelPointerState(_shapes);
            state.SelectOrCreateShape(new Point(4, 8));
            int notifyCount = 0;

            state._shapeSaved += () => {
                notifyCount++;
            };
            state.SaveShape(new Point(6, 11));

            Assert.AreEqual(1, notifyCount);
        }

        /// <inheritdoc/>
        [TestMethod]
        public void SelectScalePointOfSelectedShape()
        {
            ModelPointerState state = new ModelPointerState(_shapes);
            state.SelectOrCreateShape(new Point(13, 13));

            state.SelectOrCreateShape(new Point(25, 24));

            Assert.AreEqual(ScalePoint.LowerRight, state.CurrentScalePoint);
        }

        /// <inheritdoc/>
        [TestMethod]
        public void ScaleSelectedShape()
        {
            ModelPointerState state = new ModelPointerState(_shapes);
            state.SelectOrCreateShape(new Point(13, 13));
            state.SelectOrCreateShape(new Point(25, 24));

            state.UpdateShape(new Point(20, 37));

            Assert.AreEqual("(3, 7), (5, 12)", _shapes.ShapeDatas[0].Information);
            Assert.AreEqual("(5, 8), (7, 9)", _shapes.ShapeDatas[1].Information);
            Assert.AreEqual("(12, 13), (20, 37)", _shapes.ShapeDatas[2].Information);
        }

        /// <inheritdoc/>
        [TestMethod]
        public void SaveScaledShape()
        {
            ModelPointerState state = new ModelPointerState(_shapes);
            state.SelectOrCreateShape(new Point(13, 13));
            state.SelectOrCreateShape(new Point(25, 24));
            state.UpdateShape(new Point(20, 37));

            state.SaveShape(new Point(25, 31));

            Assert.AreEqual("(3, 7), (5, 12)", _shapes.ShapeDatas[0].Information);
            Assert.AreEqual("(5, 8), (7, 9)", _shapes.ShapeDatas[1].Information);
            Assert.AreEqual("(12, 13), (25, 31)", _shapes.ShapeDatas[2].Information);
        }
    }
}
