using Drawer.Model.ShapeObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Drawer.Model.State.Tests
{
    [TestClass]
    public class ModelPointerStateTest
    {
        private DrawerModel _model;
        private Shapes _shapes;

        /// <inheritdoc/>
        [TestInitialize]
        public void SetUp()
        {
            ShapeFactory shapeFactory = new ShapeFactory();
            _model = new DrawerModel(shapeFactory);
            PrivateObject privateModel = new PrivateObject(_model);
            _shapes = privateModel.GetField("_shapes") as Shapes;

            _shapes.CreateShape(ShapeType.Line, new Point(3, 7), new Point(5, 12));
            _shapes.CreateShape(ShapeType.Circle, new Point(7, 9), new Point(5, 8));
            _shapes.CreateShape(ShapeType.Rectangle, new Point(25, 13), new Point(12, 24));
        }

        /// <inheritdoc/>
        [TestMethod]
        public void SelectedShapeInShapes()
        {
            ModelPointerState state = new ModelPointerState(_model, _shapes);

            state.SelectOrCreateShape(new Point(4, 8));

            PrivateObject privateModel = new PrivateObject(_model);
            IState pointerMoveState = privateModel.GetField("_state") as ModelPointerMoveState;
            Assert.IsNotNull(pointerMoveState);
            //Assert.IsTrue(_shapes.ShapeDatas[0].IsSelected);
            //Assert.IsFalse(_shapes.ShapeDatas[1].IsSelected);
            //Assert.IsFalse(_shapes.ShapeDatas[2].IsSelected);
        }

        ///// <inheritdoc/>
        //[TestMethod]
        //public void UpdateSelectedShape()
        //{
        //    ModelPointerState state = new ModelPointerState(_model, _shapes);
        //    state.SelectOrCreateShape(new Point(4, 8));

        //    state.UpdateShape(new Point(6, 11));

        //    Assert.AreEqual("(5, 10), (7, 15)", _shapes.ShapeDatas[0].Information);
        //    Assert.AreEqual("(5, 8), (7, 9)", _shapes.ShapeDatas[1].Information);
        //    Assert.AreEqual("(12, 13), (25, 24)", _shapes.ShapeDatas[2].Information);
        //}

        ///// <inheritdoc/>
        //[TestMethod]
        //public void SaveSelectedShape()
        //{
        //    ModelPointerState state = new ModelPointerState(_model, _shapes);
        //    state.SelectOrCreateShape(new Point(4, 8));

        //    state.SaveShape(new Point(6, 11));

        //    Assert.AreEqual("(5, 10), (7, 15)", _shapes.ShapeDatas[0].Information);
        //    Assert.AreEqual("(5, 8), (7, 9)", _shapes.ShapeDatas[1].Information);
        //    Assert.AreEqual("(12, 13), (25, 24)", _shapes.ShapeDatas[2].Information);
        //}

        /// <inheritdoc/>
        [TestMethod]
        public void SelectScalePointOfSelectedShape()
        {
            ModelPointerState state = new ModelPointerState(_model, _shapes);
            state.SelectOrCreateShape(new Point(13, 13));

            state.SelectOrCreateShape(new Point(25, 24));

            PrivateObject privateModel = new PrivateObject(_model);
            IState pointerScaleState = privateModel.GetField("_state") as ModelPointerScaleState;
            Assert.IsNotNull(pointerScaleState);
            //Assert.AreEqual(ScalePoint.LowerRight, state.CurrentScalePoint);
        }

        ///// <inheritdoc/>
        //[TestMethod]
        //public void ScaleSelectedShape()
        //{
        //    ModelPointerState state = new ModelPointerState(_model, _shapes);
        //    state.SelectOrCreateShape(new Point(13, 13));
        //    state.SelectOrCreateShape(new Point(25, 24));

        //    state.UpdateShape(new Point(20, 37));

        //    Assert.AreEqual("(3, 7), (5, 12)", _shapes.ShapeDatas[0].Information);
        //    Assert.AreEqual("(5, 8), (7, 9)", _shapes.ShapeDatas[1].Information);
        //    Assert.AreEqual("(12, 13), (20, 37)", _shapes.ShapeDatas[2].Information);
        //}

        ///// <inheritdoc/>
        //[TestMethod]
        //public void SaveScaledShape()
        //{
        //    ModelPointerState state = new ModelPointerState(_model, _shapes);
        //    state.SelectOrCreateShape(new Point(13, 13));
        //    state.SelectOrCreateShape(new Point(25, 24));
        //    state.UpdateShape(new Point(20, 37));

        //    state.SaveShape(new Point(25, 31));

        //    Assert.AreEqual("(3, 7), (5, 12)", _shapes.ShapeDatas[0].Information);
        //    Assert.AreEqual("(5, 8), (7, 9)", _shapes.ShapeDatas[1].Information);
        //    Assert.AreEqual("(12, 13), (25, 31)", _shapes.ShapeDatas[2].Information);
        //}
    }
}
