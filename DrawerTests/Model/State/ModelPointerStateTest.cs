using Drawer.Model.ShapeObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Drawer.Model.State.Tests
{
    [TestClass]
    public class ModelPointerStateTest
    {
        private DrawerModel _model;
        private List<Shapes> _pages;

        /// <inheritdoc/>
        [TestInitialize]
        public void SetUp()
        {
            ShapeFactory shapeFactory = new ShapeFactory();
            _model = new DrawerModel(shapeFactory);
            PrivateObject privateModel = new PrivateObject(_model);
            _pages = privateModel.GetField("_pages") as List<Shapes>;

            _pages[0].CreateShape(ShapeType.Line, new Point(3, 7), new Point(5, 12));
            _pages[0].CreateShape(ShapeType.Circle, new Point(7, 9), new Point(5, 8));
            _pages[0].CreateShape(ShapeType.Rectangle, new Point(25, 13), new Point(12, 24));
        }

        /// <inheritdoc/>
        [TestMethod]
        public void SelectedShapeInShapes()
        {
            ModelPointerState state = new ModelPointerState(_model);

            state.SelectOrCreateShape(new Point(4, 8));

            PrivateObject privateModel = new PrivateObject(_model);
            IState pointerMoveState = privateModel.GetField("_state") as ModelPointerMoveState;
            Assert.IsNotNull(pointerMoveState);
        }

        /// <inheritdoc/>
        [TestMethod]
        public void SelectScalePointOfSelectedShape()
        {
            ModelPointerState state = new ModelPointerState(_model);
            state.SelectOrCreateShape(new Point(13, 13));

            state.SelectOrCreateShape(new Point(25, 24));

            PrivateObject privateModel = new PrivateObject(_model);
            IState pointerScaleState = privateModel.GetField("_state") as ModelPointerScaleState;
            Assert.IsNotNull(pointerScaleState);
        }
    }
}
