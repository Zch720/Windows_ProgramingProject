using Drawer.Model.ShapeObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Drawer.Model.State.Tests
{
    [TestClass]
    public class ModelPointerScaleStateTest
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
            _shapes.CreateShape(ShapeType.Rectangle, new Point(1), new Point(11));
        }
        
        /// <inheritdoc/>
        [TestMethod]
        public void CurrentScalePointIsAlwaysNone()
        {
            ModelPointerScaleState state = new ModelPointerScaleState(_model, _shapes);

            Assert.AreEqual(ScalePoint.None, state.CurrentScalePoint);
        }

        /// <inheritdoc/>
        [TestMethod]
        public void SelectOrCreateShape()
        {
            ModelPointerScaleState state = new ModelPointerScaleState(_model, _shapes);
            _shapes.SelectShapeAtIndex(0);

            state.SelectOrCreateShape(new Point(1, 1));

            PrivateObject privateShapes = new PrivateObject(_shapes);
            List<Shape> shapeList = privateShapes.GetField("_shapes") as List<Shape>;
            Assert.IsNotNull(shapeList);
            Assert.AreEqual(ScalePoint.UpperLeft, shapeList[0].SelectedScalePoint);
        }
        
        /// <inheritdoc/>
        [TestMethod]
        public void UpdateShape()
        {
            ModelPointerScaleState state = new ModelPointerScaleState(_model, _shapes);
            _shapes.SelectShapeAtIndex(0);
            state.SelectOrCreateShape(new Point(1, 1));

            state.UpdateShape(new Point(3));

            Assert.AreEqual("(3, 3), (11, 11)", _shapes.ShapeDatas[0].Information);
        }
        
        /// <inheritdoc/>
        [TestMethod]
        public void SaveShape()
        {
            ModelPointerScaleState state = new ModelPointerScaleState(_model, _shapes);
            _shapes.SelectShapeAtIndex(0);
            state.SelectOrCreateShape(new Point(1, 1));

            state.SaveShape(new Point(3));

            Assert.AreEqual("(3, 3), (11, 11)", _shapes.ShapeDatas[0].Information);
        }
        
        /// <inheritdoc/>
        [TestMethod]
        public void SaveShapeButDidNotMove()
        {
            ModelPointerScaleState state = new ModelPointerScaleState(_model, _shapes);
            _shapes.SelectShapeAtIndex(0);
            state.SelectOrCreateShape(new Point(1, 1));

            state.SaveShape(new Point(1));

            Assert.AreEqual("(1, 1), (11, 11)", _shapes.ShapeDatas[0].Information);
        }
    }
}
