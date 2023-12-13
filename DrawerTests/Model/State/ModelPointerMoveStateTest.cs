using Drawer.Model.ShapeObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Drawer.Model.State.Tests
{
    [TestClass]
    public class ModelPointerMoveStateTest
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
            Assert.IsNotNull(_shapes);
            _shapes.CreateShape(ShapeType.Line, new Point(1), new Point(5));
        }
        
        /// <inheritdoc/>
        [TestMethod]
        public void CurrentScalePointIsAlwaysNone()
        {
            ModelPointerMoveState state = new ModelPointerMoveState(_model, _shapes);

            Assert.AreEqual(ScalePoint.None, state.CurrentScalePoint);
        }
        
        /// <inheritdoc/>
        [TestMethod]
        public void SelectOrCreateShape()
        {
            ModelPointerMoveState state = new ModelPointerMoveState(_model, _shapes);

            state.SelectOrCreateShape(new Point(3));

            Assert.IsTrue(_shapes.ShapeDatas[0].IsSelected);
        }

        /// <inheritdoc/>
        [TestMethod]
        public void UpdateShape()
        {
            ModelPointerMoveState state = new ModelPointerMoveState(_model, _shapes);
            state.SelectOrCreateShape(new Point(3));

            state.UpdateShape(new Point(4));

            Assert.AreEqual("(2, 2), (6, 6)", _shapes.ShapeDatas[0].Information); ;
        }

        /// <inheritdoc/>
        [TestMethod]
        public void UpdateShapeWithNoShapeSelected()
        {
            ModelPointerMoveState state = new ModelPointerMoveState(_model, _shapes);
            state.SelectOrCreateShape(new Point(0));

            state.UpdateShape(new Point(4));

            Assert.AreEqual("(1, 1), (5, 5)", _shapes.ShapeDatas[0].Information); ;
        }
        
        /// <inheritdoc/>
        [TestMethod]
        public void SaveShape()
        {
            ModelPointerMoveState state = new ModelPointerMoveState(_model, _shapes);
            state.SelectOrCreateShape(new Point(3));

            state.SaveShape(new Point(4));

            Assert.AreEqual("(2, 2), (6, 6)", _shapes.ShapeDatas[0].Information); ;
        }
        
        /// <inheritdoc/>
        [TestMethod]
        public void SaveShapeWithNoShapeSelected()
        {
            ModelPointerMoveState state = new ModelPointerMoveState(_model, _shapes);
            state.SelectOrCreateShape(new Point(0));

            state.SaveShape(new Point(4));

            Assert.AreEqual("(1, 1), (5, 5)", _shapes.ShapeDatas[0].Information); ;
        }
    }
}
