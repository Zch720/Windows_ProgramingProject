using Drawer.Model.ShapeObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Drawer.Model.State.Tests
{
    [TestClass]
    public class ModelDrawingStateTest
    {
        private const string LINE_STR = "線";
        private const string RECTANGLE_STR = "矩形";
        private const string CIRCLE_STR = "圓";

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
            _pages[0].CreateShape(ShapeType.Rectangle, new Point(15, 13), new Point(12, 14));
        }

        /// <inheritdoc/>
        [TestMethod]
        public void CurrentScalePointShouldAlwaysBeNull()
        {
            ModelDrawingState state = new ModelDrawingState(_model, ShapeType.Line);

            Assert.IsNull(state.CurrentScalePoint);
        }

        /// <inheritdoc/>
        [TestMethod]
        public void CreateLineTempShapeInShapes()
        {
            ModelDrawingState state = new ModelDrawingState(_model, ShapeType.Line);

            state.SelectOrCreateShape(new Point(50, 50));

            Assert.AreEqual(LINE_STR, GetTempShapeFromModel().Name);
        }

        /// <inheritdoc/>
        [TestMethod]
        public void CreateRectangleTempShapeInShapes()
        {
            ModelDrawingState state = new ModelDrawingState(_model, ShapeType.Rectangle);

            state.SelectOrCreateShape(new Point(50, 50));

            Assert.AreEqual(RECTANGLE_STR, GetTempShapeFromModel().Name);
        }

        /// <inheritdoc/>
        [TestMethod]
        public void CreateCircleTempShapeInShapes()
        {
            ModelDrawingState state = new ModelDrawingState(_model, ShapeType.Circle);

            state.SelectOrCreateShape(new Point(50, 50));

            Assert.AreEqual(CIRCLE_STR, GetTempShapeFromModel().Name);
        }

        /// <inheritdoc/>
        [TestMethod]
        public void UpdateTempShape()
        {
            ModelDrawingState state = new ModelDrawingState(_model, ShapeType.Line);
            state.SelectOrCreateShape(new Point(50, 50));

            state.UpdateShape(new Point(30, 70));

            Assert.AreEqual("(50, 50), (30, 70)", GetTempShapeFromModel().Info);
        }

        /// <inheritdoc/>
        [TestMethod]
        public void UpdateShapeDoNothingIfNotCreateShape()
        {
            ModelDrawingState state = new ModelDrawingState(_model, ShapeType.Line);

            state.UpdateShape(new Point(30, 70));

            Assert.IsNull(GetTempShapeFromModel());
            Assert.AreEqual(3, _pages[0].ShapeDatas.Count);
        }

        /// <inheritdoc/>
        [TestMethod]
        public void SaveTempShape()
        {
            ModelDrawingState state = new ModelDrawingState(_model, ShapeType.Line);
            state.SelectOrCreateShape(new Point(50, 50));

            state.SaveShape(new Point(30, 70));

            Assert.IsNull(GetTempShapeFromModel());
            Assert.AreEqual(4, _pages[0].ShapeDatas.Count);
            Assert.AreEqual(LINE_STR, _pages[0].ShapeDatas[3].ShapeName);
            Assert.AreEqual("(50, 50), (30, 70)", _pages[0].ShapeDatas[3].Information);
        }

        /// <inheritdoc/>
        [TestMethod]
        public void SaveTempShapeDoNothingIfNotCreateShape()
        {
            ModelDrawingState state = new ModelDrawingState(_model, ShapeType.Line);

            state.SaveShape(new Point(30, 70));

            Assert.IsNull(GetTempShapeFromModel());
            Assert.AreEqual(3, _pages[0].ShapeDatas.Count);
        }

        /// <summary>
        /// Get the private object _tempShape in shapes.
        /// </summary>
        /// <returns>The temp shape.</returns>
        private Shape GetTempShapeFromModel()
        {
            PrivateObject privateModel = new PrivateObject(_model);
            return privateModel.GetField("_tempShape") as Shape;
        }
    }
}
