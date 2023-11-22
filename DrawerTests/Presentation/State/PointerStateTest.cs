using Drawer.Model;
using Drawer.Model.ShapeObjects;
using DrawerTests;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Drawer.Presentation.State.Tests
{
    [TestClass]
    public class PointerStateTest
    {
        private DrawerModel _model;

        [TestInitialize]
        public void SetUp()
        {
            ShapeFactory factory = new ShapeFactory();
            _model = new DrawerModel(factory);

            TestUtilities.CreateShape(_model, ShapeType.Line, new Point(5, 4), new Point(1, 0));
            TestUtilities.CreateShape(_model, ShapeType.Rectangle, new Point(11, 13), new Point(15, 30));
            TestUtilities.CreateShape(_model, ShapeType.Line, new Point(3, 5), new Point(7, 1));
        }

        [TestMethod]
        public void SelectedShapeTypeInPointerStateShouldAlwaysBeNone()
        {
            PointerState state = new PointerState(_model);
            Assert.AreEqual(ShapeType.None, state.SelectedShapeType);
        }

        [TestMethod]
        public void SelectShapeWhenMouseDown()
        {
            PointerState state = new PointerState(_model);

            state.HandleMouseDown(1, 1);

            Assert.IsTrue(_model.ShapeDatas[0].IsSelected);
            Assert.IsFalse(_model.ShapeDatas[1].IsSelected);
            Assert.IsFalse(_model.ShapeDatas[2].IsSelected);
        }

        [TestMethod]
        public void SelectShapeOverlapWhenMouseDown()
        {
            PointerState state = new PointerState(_model);

            state.HandleMouseDown(4, 2);

            Assert.IsFalse(_model.ShapeDatas[0].IsSelected);
            Assert.IsFalse(_model.ShapeDatas[1].IsSelected);
            Assert.IsTrue(_model.ShapeDatas[2].IsSelected);
        }

        [TestMethod]
        public void CancelSelectShapeWhenMouseDown()
        {
            PointerState state = new PointerState(_model);
            state.HandleMouseDown(4, 2);
            Assert.IsTrue(_model.ShapeDatas[2].IsSelected);

            state.HandleMouseDown(-1, 20);
            Assert.IsFalse(_model.ShapeDatas[0].IsSelected);
            Assert.IsFalse(_model.ShapeDatas[1].IsSelected);
            Assert.IsFalse(_model.ShapeDatas[2].IsSelected);
        }

        [TestMethod]
        public void MoveShapeWhenMouseMoveAfterMouseDown()
        {
            PointerState state = new PointerState(_model);
            state.HandleMouseDown(4, 2);
            Assert.AreEqual("(3, 5), (7, 1)", _model.ShapeDatas[2].Information);

            state.HandleMouseMove(14, 12);

            Assert.AreEqual("(5, 4), (1, 0)", _model.ShapeDatas[0].Information);
            Assert.AreEqual("(11, 13), (15, 30)", _model.ShapeDatas[1].Information);
            Assert.AreEqual("(13, 15), (17, 11)", _model.ShapeDatas[2].Information);
        }

        [TestMethod]
        public void DoNothingWhenMouseMoveWithNoMouseDown()
        {
            PointerState state = new PointerState(_model);

            state.HandleMouseMove(10, 10);

            Assert.AreEqual("(5, 4), (1, 0)", _model.ShapeDatas[0].Information);
            Assert.AreEqual("(11, 13), (15, 30)", _model.ShapeDatas[1].Information);
            Assert.AreEqual("(3, 5), (7, 1)", _model.ShapeDatas[2].Information);
        }

        [TestMethod]
        public void MoveShapeWhenMouseUpAfterMouseDown()
        {
            PointerState state = new PointerState(_model);
            state.HandleMouseDown(4, 2);
            Assert.AreEqual("(3, 5), (7, 1)", _model.ShapeDatas[2].Information);

            state.HandleMouseUp(14, 12);

            Assert.AreEqual("(5, 4), (1, 0)", _model.ShapeDatas[0].Information);
            Assert.AreEqual("(11, 13), (15, 30)", _model.ShapeDatas[1].Information);
            Assert.AreEqual("(13, 15), (17, 11)", _model.ShapeDatas[2].Information);
        }

        [TestMethod]
        public void DoNothingWhenMouseUpWithNoMouseDown()
        {
            PointerState state = new PointerState(_model);

            state.HandleMouseUp(10, 10);

            Assert.AreEqual("(5, 4), (1, 0)", _model.ShapeDatas[0].Information);
            Assert.AreEqual("(11, 13), (15, 30)", _model.ShapeDatas[1].Information);
            Assert.AreEqual("(3, 5), (7, 1)", _model.ShapeDatas[2].Information);
        }
    }
}
