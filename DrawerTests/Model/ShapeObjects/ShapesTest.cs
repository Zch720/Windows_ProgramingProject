using DrawerTests;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Drawer.Model.ShapeObjects.Tests
{
    [TestClass]
    public class ShapesTest
    {
        private ShapeFactory shapeFactory = new ShapeFactory();

        /// <inheritdoc/>
        [TestMethod]
        public void CreateOneRandomShape()
        {
            Shapes shapes = new Shapes(shapeFactory);
            PrivateObject shapesPrivate = new PrivateObject(shapes);

            shapes.CreateRandomShape("線", new Point(100, 100));

            List<Shape> shapesList = shapesPrivate.GetField("_shapes") as List<Shape>;
            Assert.IsNotNull(shapesList);
            Assert.AreEqual(1, shapesList.Count);
            Assert.AreEqual(1, shapes.ShapeDatas.Count);
            Assert.AreEqual(ShapeType.Line, shapesList[0].Type);
        }

        /// <inheritdoc/>
        [TestMethod]
        public void CreateTwoRandomShape()
        {
            Shapes shapes = new Shapes(shapeFactory);
            PrivateObject shapesPrivate = new PrivateObject(shapes);

            shapes.CreateRandomShape("圓", new Point(100, 100));
            shapes.CreateRandomShape("矩形", new Point(100, 100));

            List<Shape> shapesList = shapesPrivate.GetField("_shapes") as List<Shape>;
            Assert.IsNotNull(shapesList);
            Assert.AreEqual(2, shapesList.Count);
            Assert.AreEqual(2, shapes.ShapeDatas.Count);
            Assert.AreEqual(ShapeType.Circle, shapesList[0].Type);
            Assert.AreEqual(ShapeType.Rectangle, shapesList[1].Type);
        }

        /// <inheritdoc/>
        [TestMethod]
        public void CreateOneShape()
        {
            Shapes shapes = new Shapes(shapeFactory);
            PrivateObject shapesPrivate = new PrivateObject(shapes);

            shapes.CreateShape(ShapeType.Line, new Point(0, 1), new Point(5, 3));

            List<Shape> shapesList = shapesPrivate.GetField("_shapes") as List<Shape>;
            Assert.IsNotNull(shapesList);
            Assert.AreEqual(1, shapesList.Count);
            Assert.AreEqual(1, shapes.ShapeDatas.Count);
            Assert.AreEqual(ShapeType.Line, shapesList[0].Type);
        }

        /// <inheritdoc/>
        [TestMethod]
        public void CreateTwoShape()
        {
            Shapes shapes = new Shapes(shapeFactory);
            PrivateObject shapesPrivate = new PrivateObject(shapes);

            shapes.CreateShape(ShapeType.Circle, new Point(0, 1), new Point(5, 3));
            shapes.CreateShape(ShapeType.Rectangle, new Point(0, 1), new Point(5, 3));

            List<Shape> shapesList = shapesPrivate.GetField("_shapes") as List<Shape>;
            Assert.IsNotNull(shapesList);
            Assert.AreEqual(2, shapesList.Count);
            Assert.AreEqual(2, shapes.ShapeDatas.Count);
            Assert.AreEqual(ShapeType.Circle, shapesList[0].Type);
            Assert.AreEqual(ShapeType.Rectangle, shapesList[1].Type);
        }

        /// <inheritdoc/>
        [TestMethod]
        public void DeleteFirstShape()
        {
            Shapes shapes = new Shapes(shapeFactory);
            PrivateObject shapesPrivate = new PrivateObject(shapes);
            shapes.CreateRandomShape("圓", new Point(100, 100));
            shapes.CreateRandomShape("矩形", new Point(100, 100));
            shapes.CreateRandomShape("線", new Point(100, 100));

            shapes.DeleteShape(0);

            List<Shape> shapesList = shapesPrivate.GetField("_shapes") as List<Shape>;
            Assert.IsNotNull(shapesList);
            Assert.AreEqual(2, shapesList.Count);
            Assert.AreEqual(2, shapes.ShapeDatas.Count);
            Assert.AreEqual(ShapeType.Rectangle, shapesList[0].Type);
            Assert.AreEqual(ShapeType.Line, shapesList[1].Type);
        }

        /// <inheritdoc/>
        [TestMethod]
        public void DeleteLastShape()
        {
            Shapes shapes = new Shapes(shapeFactory);
            PrivateObject shapesPrivate = new PrivateObject(shapes);
            shapes.CreateRandomShape("圓", new Point(100, 100));
            shapes.CreateRandomShape("矩形", new Point(100, 100));
            shapes.CreateRandomShape("線", new Point(100, 100));

            shapes.DeleteShape(2);

            List<Shape> shapesList = shapesPrivate.GetField("_shapes") as List<Shape>;
            Assert.IsNotNull(shapesList);
            Assert.AreEqual(2, shapesList.Count);
            Assert.AreEqual(2, shapes.ShapeDatas.Count);
            Assert.AreEqual(ShapeType.Circle, shapesList[0].Type);
            Assert.AreEqual(ShapeType.Rectangle, shapesList[1].Type);
        }

        /// <inheritdoc/>
        [TestMethod]
        public void DeleteMiddleShape()
        {
            Shapes shapes = new Shapes(shapeFactory);
            PrivateObject shapesPrivate = new PrivateObject(shapes);
            shapes.CreateRandomShape("圓", new Point(100, 100));
            shapes.CreateRandomShape("矩形", new Point(100, 100));
            shapes.CreateRandomShape("線", new Point(100, 100));

            shapes.DeleteShape(1);

            List<Shape> shapesList = shapesPrivate.GetField("_shapes") as List<Shape>;
            Assert.IsNotNull(shapesList);
            Assert.AreEqual(2, shapesList.Count);
            Assert.AreEqual(2, shapes.ShapeDatas.Count);
            Assert.AreEqual(ShapeType.Circle, shapesList[0].Type);
            Assert.AreEqual(ShapeType.Line, shapesList[1].Type);
        }

        /// <inheritdoc/>
        [TestMethod]
        public void DeleteShapeIndexOverflow()
        {
            Shapes shapes = new Shapes(shapeFactory);
            PrivateObject shapesPrivate = new PrivateObject(shapes);
            shapes.CreateRandomShape("圓", new Point(100, 100));
            shapes.CreateRandomShape("矩形", new Point(100, 100));
            shapes.CreateRandomShape("線", new Point(100, 100));

            shapes.DeleteShape(3);

            List<Shape> shapesList = shapesPrivate.GetField("_shapes") as List<Shape>;
            Assert.IsNotNull(shapesList);
            Assert.AreEqual(3, shapesList.Count);
            Assert.AreEqual(3, shapes.ShapeDatas.Count);
            Assert.AreEqual(ShapeType.Circle, shapesList[0].Type);
            Assert.AreEqual(ShapeType.Rectangle, shapesList[1].Type);
            Assert.AreEqual(ShapeType.Line, shapesList[2].Type);
        }

        /// <inheritdoc/>
        [TestMethod]
        public void DeleteShapeIndexUnderflow()
        {
            Shapes shapes = new Shapes(shapeFactory);
            PrivateObject shapesPrivate = new PrivateObject(shapes);
            shapes.CreateRandomShape("圓", new Point(100, 100));
            shapes.CreateRandomShape("矩形", new Point(100, 100));
            shapes.CreateRandomShape("線", new Point(100, 100));

            shapes.DeleteShape(-2);

            List<Shape> shapesList = shapesPrivate.GetField("_shapes") as List<Shape>;
            Assert.IsNotNull(shapesList);
            Assert.AreEqual(3, shapesList.Count);
            Assert.AreEqual(3, shapes.ShapeDatas.Count);
            Assert.AreEqual(ShapeType.Circle, shapesList[0].Type);
            Assert.AreEqual(ShapeType.Rectangle, shapesList[1].Type);
            Assert.AreEqual(ShapeType.Line, shapesList[2].Type);
        }
        
        /// <inheritdoc/>
        [TestMethod]
        public void DeleteShapeIndexIsSelected()
        {
            Shapes shapes = new Shapes(shapeFactory);
            PrivateObject privateShapes = new PrivateObject(shapes);
            shapes.CreateShape(ShapeType.Line, new Point(1), new Point(5));
            shapes.SelectedShapeAtPoint(new Point(3));
            Assert.AreEqual(0, (int)privateShapes.GetField("_selectedShape"));

            shapes.DeleteShape(0);

            Assert.AreEqual(-1, (int)privateShapes.GetField("_selectedShape"));
        }
        
        /// <inheritdoc/>
        [TestMethod]
        public void DeleteShapeIndexSmallThanSelectedShape()
        {
            Shapes shapes = new Shapes(shapeFactory);
            PrivateObject privateShapes = new PrivateObject(shapes);
            shapes.CreateShape(ShapeType.Line, new Point(11), new Point(15));
            shapes.CreateShape(ShapeType.Line, new Point(1), new Point(5));
            shapes.SelectedShapeAtPoint(new Point(3));
            Assert.AreEqual(1, (int)privateShapes.GetField("_selectedShape"));

            shapes.DeleteShape(0);

            Assert.AreEqual(0, (int)privateShapes.GetField("_selectedShape"));
        }

        /// <inheritdoc/>
        [TestMethod]
        public void DeleteShapeIndexBiggerThanSelectedShape()
        {
            Shapes shapes = new Shapes(shapeFactory);
            PrivateObject privateShapes = new PrivateObject(shapes);
            shapes.CreateShape(ShapeType.Line, new Point(1), new Point(5));
            shapes.CreateShape(ShapeType.Line, new Point(11), new Point(15));
            shapes.SelectedShapeAtPoint(new Point(3));
            Assert.AreEqual(0, (int)privateShapes.GetField("_selectedShape"));

            shapes.DeleteShape(1);

            Assert.AreEqual(0, (int)privateShapes.GetField("_selectedShape"));
        }

        /// <inheritdoc/>
        [TestMethod]
        public void CreateTempLine()
        {
            Shapes shapes = new Shapes(shapeFactory);
            PrivateObject shapesPrivate = new PrivateObject(shapes);

            shapes.CreateTempShape(ShapeType.Line, new Point(2, 6));

            Shape tempShape = shapesPrivate.GetField("_tempShape") as Shape;
            Assert.IsNotNull(tempShape);
            Assert.IsTrue(tempShape is Line);
            Assert.AreEqual(2,tempShape.Point1.X);
            Assert.AreEqual(6, tempShape.Point1.Y);
            Assert.AreEqual(2, tempShape.Point2.X);
            Assert.AreEqual(6, tempShape.Point2.Y);
        }

        /// <inheritdoc/>
        [TestMethod]
        public void CreateTempRectangle()
        {
            Shapes shapes = new Shapes(shapeFactory);
            PrivateObject shapesPrivate = new PrivateObject(shapes);

            shapes.CreateTempShape(ShapeType.Rectangle, new Point(2, 6));

            Shape tempShape = shapesPrivate.GetField("_tempShape") as Shape;
            Assert.IsNotNull(tempShape);
            Assert.IsTrue(tempShape is Rectangle);
            Assert.AreEqual(2, tempShape.Point1.X);
            Assert.AreEqual(6, tempShape.Point1.Y);
            Assert.AreEqual(2, tempShape.Point2.X);
            Assert.AreEqual(6, tempShape.Point2.Y);
        }

        /// <inheritdoc/>
        [TestMethod]
        public void CreateTempCircle()
        {
            Shapes shapes = new Shapes(shapeFactory);
            PrivateObject shapesPrivate = new PrivateObject(shapes);

            shapes.CreateTempShape(ShapeType.Circle, new Point(2, 6));

            Shape tempShape = shapesPrivate.GetField("_tempShape") as Shape;
            Assert.IsNotNull(tempShape);
            Assert.IsTrue(tempShape is Circle);
            Assert.AreEqual(2, tempShape.Point1.X);
            Assert.AreEqual(6, tempShape.Point1.Y);
            Assert.AreEqual(2, tempShape.Point2.X);
            Assert.AreEqual(6, tempShape.Point2.Y);
        }

        /// <inheritdoc/>
        [TestMethod]
        public void UpdateTempShape()
        {
            Shapes shapes = new Shapes(shapeFactory);
            PrivateObject shapesPrivate = new PrivateObject(shapes);
            shapes.CreateTempShape(ShapeType.Circle, new Point(2, 6));

            shapes.UpdateTempShape(new Point(5, 4));

            Shape tempShape = shapesPrivate.GetField("_tempShape") as Shape;
            Assert.IsNotNull(tempShape);
            Assert.IsTrue(tempShape is Circle);
            Assert.AreEqual(2, tempShape.Point1.X);
            Assert.AreEqual(6, tempShape.Point1.Y);
            Assert.AreEqual(5, tempShape.Point2.X);
            Assert.AreEqual(4, tempShape.Point2.Y);
        }

        /// <inheritdoc/>
        [TestMethod]
        public void UpdateTempShapeButIsNoTempShape()
        {
            Shapes shapes = new Shapes(shapeFactory);

            shapes.UpdateTempShape(new Point(1, 0));
        }

        /// <inheritdoc/>
        [TestMethod]
        public void SaveTempShapeToEmptyShapeList()
        {
            Shapes shapes = new Shapes(shapeFactory);
            PrivateObject shapesPrivate = new PrivateObject(shapes);
            shapes.CreateTempShape(ShapeType.Circle, new Point(2, 6));
            shapes.UpdateTempShape(new Point(5, 4));
            Assert.AreEqual(0, shapes.ShapeDatas.Count);

            shapes.SaveTempShape();

            Shape tempShape = shapesPrivate.GetField("_tempShape") as Shape;
            List<Shape> shapesList = shapesPrivate.GetField("_shapes") as List<Shape>;
            Assert.IsNull(tempShape);
            Assert.IsNotNull(shapesList);
            Assert.AreEqual(1, shapesList.Count);
            Assert.AreEqual(1, shapes.ShapeDatas.Count);
            Assert.AreEqual(ShapeType.Circle, shapesList[0].Type);
        }

        /// <inheritdoc/>
        [TestMethod]
        public void SaveTempShapeButIsNoTempShape()
        {
            Shapes shapes = new Shapes(shapeFactory);
            PrivateObject shapesPrivate = new PrivateObject(shapes);

            shapes.SaveTempShape();

            List<Shape> shapesList = shapesPrivate.GetField("_shapes") as List<Shape>;
            Assert.AreEqual(0, shapesList.Count);
        }

        /// <inheritdoc/>
        [TestMethod]
        public void SaveTempShapeToShapeListAlreadyHasShape()
        {
            Shapes shapes = new Shapes(shapeFactory);
            PrivateObject shapesPrivate = new PrivateObject(shapes);
            shapes.CreateRandomShape("線", new Point(100, 100));
            shapes.CreateTempShape(ShapeType.Circle, new Point(2, 6));
            shapes.UpdateTempShape(new Point(5, 4));

            shapes.SaveTempShape();

            Shape tempShape = shapesPrivate.GetField("_tempShape") as Shape;
            List<Shape> shapesList = shapesPrivate.GetField("_shapes") as List<Shape>;
            Assert.IsNull(tempShape);
            Assert.IsNotNull(shapesList);
            Assert.AreEqual(2, shapesList.Count);
            Assert.AreEqual(2, shapes.ShapeDatas.Count);
            Assert.AreEqual(ShapeType.Line, shapesList[0].Type);
            Assert.AreEqual(ShapeType.Circle, shapesList[1].Type);
        }

        /// <inheritdoc/>
        [TestMethod]
        public void DrawShapesWithNoTempShape()
        {
            FakeGraphics graphics = new FakeGraphics();
            Shapes shapes = new Shapes(shapeFactory);
            shapes.CreateRandomShape("線", new Point(100, 100));

            shapes.DrawWithTemp(graphics);

            Assert.AreEqual(1, graphics.NotifyDrawLineCount);
            Assert.AreEqual(0, graphics.NotifyDrawRectangleCount);
            Assert.AreEqual(0, graphics.NotifyDrawCircleCount);
            Assert.AreEqual(0, graphics.NotifyDrawSelectBoxCount);
        }

        /// <inheritdoc/>
        [TestMethod]
        public void DrawShapesWithTempShape()
        {
            FakeGraphics graphics = new FakeGraphics();
            Shapes shapes = new Shapes(shapeFactory);
            shapes.CreateRandomShape("線", new Point(100, 100));
            shapes.CreateTempShape(ShapeType.Circle, new Point(2, 6));
            shapes.UpdateTempShape(new Point(5, 4));

            shapes.DrawWithTemp(graphics);

            Assert.AreEqual(1, graphics.NotifyDrawLineCount);
            Assert.AreEqual(0, graphics.NotifyDrawRectangleCount);
            Assert.AreEqual(1, graphics.NotifyDrawCircleCount);
            Assert.AreEqual(0, graphics.NotifyDrawSelectBoxCount);
        }

        /// <inheritdoc/>
        [TestMethod]
        public void SelectShape()
        {
            Shapes shapes = new Shapes(shapeFactory);
            PrivateObject shapesPrivate = new PrivateObject(shapes);
            shapes.CreateShape(ShapeType.Line, new Point(1, 1), new Point(3, 5));
            shapes.CreateShape(ShapeType.Line, new Point(6, 8), new Point(5, 7));

            shapes.SelectedShapeAtPoint(new Point(2, 2));

            List<Shape> shapesList = shapesPrivate.GetField("_shapes") as List<Shape>;
            Assert.IsTrue(shapesList[0].IsSelected);
            Assert.IsTrue(shapes.ShapeDatas[0].IsSelected);
            Assert.IsFalse(shapesList[1].IsSelected);
            Assert.IsFalse(shapes.ShapeDatas[1].IsSelected);
        }

        /// <inheritdoc/>
        [TestMethod]
        public void SelectShapeOverlap()
        {
            Shapes shapes = new Shapes(shapeFactory);
            PrivateObject shapesPrivate = new PrivateObject(shapes);
            shapes.CreateShape(ShapeType.Line, new Point(1, 1), new Point(5, 3));
            shapes.CreateShape(ShapeType.Line, new Point(3, 2), new Point(6, 7));

            shapes.SelectedShapeAtPoint(new Point(4, 4));

            List<Shape> shapesList = shapesPrivate.GetField("_shapes") as List<Shape>;
            Assert.IsFalse(shapesList[0].IsSelected);
            Assert.IsFalse(shapes.ShapeDatas[0].IsSelected);
            Assert.IsTrue(shapesList[1].IsSelected);
            Assert.IsTrue(shapes.ShapeDatas[1].IsSelected);
        }

        /// <inheritdoc/>
        [TestMethod]
        public void CancelSelectShape()
        {
            Shapes shapes = new Shapes(shapeFactory);
            PrivateObject shapesPrivate = new PrivateObject(shapes);
            shapes.CreateShape(ShapeType.Line, new Point(1, 1), new Point(5, 3));
            shapes.CreateShape(ShapeType.Line, new Point(3, 2), new Point(6, 7));
            shapes.SelectedShapeAtPoint(new Point(4, 4));

            List<Shape> shapesList = shapesPrivate.GetField("_shapes") as List<Shape>;
            Assert.IsFalse(shapesList[0].IsSelected);
            Assert.IsFalse(shapes.ShapeDatas[0].IsSelected);
            Assert.IsTrue(shapesList[1].IsSelected);
            Assert.IsTrue(shapes.ShapeDatas[1].IsSelected);

            shapes.SelectedShapeAtPoint(new Point(0, 0));

            shapesList = shapesPrivate.GetField("_shapes") as List<Shape>;
            Assert.IsFalse(shapesList[0].IsSelected);
            Assert.IsFalse(shapes.ShapeDatas[0].IsSelected);
            Assert.IsFalse(shapesList[1].IsSelected);
            Assert.IsFalse(shapes.ShapeDatas[1].IsSelected);
        }

        /// <inheritdoc/>
        [TestMethod]
        public void MoveSelectedShape()
        {
            Shapes shapes = new Shapes(shapeFactory);
            PrivateObject shapesPrivate = new PrivateObject(shapes);
            shapes.CreateShape(ShapeType.Line, new Point(1, 1), new Point(5, 3));
            shapes.CreateShape(ShapeType.Line, new Point(3, 2), new Point(6, 7));
            shapes.SelectedShapeAtPoint(new Point(4, 4));

            shapes.MoveSelectedShape(new Point(1, 1));

            List<Shape> shapesList = shapesPrivate.GetField("_shapes") as List<Shape>;
            Assert.AreEqual(1, shapesList[0].Point1.X);
            Assert.AreEqual(1, shapesList[0].Point1.Y);
            Assert.AreEqual(5, shapesList[0].Point2.X);
            Assert.AreEqual(3, shapesList[0].Point2.Y);
            Assert.AreEqual(4, shapesList[1].Point1.X);
            Assert.AreEqual(3, shapesList[1].Point1.Y);
            Assert.AreEqual(7, shapesList[1].Point2.X);
            Assert.AreEqual(8, shapesList[1].Point2.Y);
        }

        /// <inheritdoc/>
        [TestMethod]
        public void MoveWithNoShapeIsSelected()
        {
            Shapes shapes = new Shapes(shapeFactory);
            PrivateObject shapesPrivate = new PrivateObject(shapes);
            shapes.CreateShape(ShapeType.Line, new Point(1, 1), new Point(5, 3));
            shapes.CreateShape(ShapeType.Line, new Point(3, 2), new Point(6, 7));

            shapes.MoveSelectedShape(new Point(1, 1));

            List<Shape> shapesList = shapesPrivate.GetField("_shapes") as List<Shape>;
            Assert.AreEqual(1, shapesList[0].Point1.X);
            Assert.AreEqual(1, shapesList[0].Point1.Y);
            Assert.AreEqual(5, shapesList[0].Point2.X);
            Assert.AreEqual(3, shapesList[0].Point2.Y);
            Assert.AreEqual(3, shapesList[1].Point1.X);
            Assert.AreEqual(2, shapesList[1].Point1.Y);
            Assert.AreEqual(6, shapesList[1].Point2.X);
            Assert.AreEqual(7, shapesList[1].Point2.Y);
        }

        /// <inheritdoc/>
        [TestMethod]
        public void DeleteSelectedShape()
        {
            Shapes shapes = new Shapes(shapeFactory);
            PrivateObject shapesPrivate = new PrivateObject(shapes);
            shapes.CreateShape(ShapeType.Line, new Point(1, 1), new Point(5, 3));
            shapes.CreateShape(ShapeType.Circle, new Point(3, 2), new Point(6, 7));
            shapes.SelectedShapeAtPoint(new Point(4, 4));

            shapes.DeleteSelectedShape();

            List<Shape> shapesList = shapesPrivate.GetField("_shapes") as List<Shape>;
            Assert.AreEqual(1, shapesList.Count);
            Assert.AreEqual(ShapeType.Line, shapesList[0].Type);
        }

        /// <inheritdoc/>
        [TestMethod]
        public void DeleteWithNoShapeIsSelected()
        {
            Shapes shapes = new Shapes(shapeFactory);
            PrivateObject shapesPrivate = new PrivateObject(shapes);
            shapes.CreateShape(ShapeType.Line, new Point(1, 1), new Point(5, 3));
            shapes.CreateShape(ShapeType.Circle, new Point(3, 2), new Point(6, 7));

            shapes.DeleteSelectedShape();

            List<Shape> shapesList = shapesPrivate.GetField("_shapes") as List<Shape>;
            Assert.AreEqual(2, shapesList.Count);
        }
        
        /// <inheritdoc/>
        [TestMethod]
        public void IsPointOnSelectedShapeScalePoint()
        {
            Shapes shapes = new Shapes(shapeFactory);
            shapes.CreateShape(ShapeType.Rectangle, new Point(5), new Point(25));
            shapes.SelectedShapeAtPoint(new Point(15));

            Assert.AreEqual(ScalePoint.UpperLeft, shapes.IsPointOnSelectedShape(new Point(5)));
            Assert.AreEqual(ScalePoint.UpperRight, shapes.IsPointOnSelectedShape(new Point(25, 5)));
            Assert.AreEqual(ScalePoint.LowerLeft, shapes.IsPointOnSelectedShape(new Point(5, 25)));
            Assert.AreEqual(ScalePoint.LowerRight, shapes.IsPointOnSelectedShape(new Point(25)));
            Assert.AreEqual(ScalePoint.None, shapes.IsPointOnSelectedShape(new Point(1)));
            Assert.AreEqual(ScalePoint.None, shapes.IsPointOnSelectedShape(new Point(15)));
        }
        
        /// <inheritdoc/>
        [TestMethod]
        public void SelectShapeSelectedScalePoint()
        {
            Shapes shapes = new Shapes(shapeFactory);
            PrivateObject privateShapes = new PrivateObject(shapes);
            shapes.CreateShape(ShapeType.Rectangle, new Point(5), new Point(25));
            shapes.SelectedShapeAtPoint(new Point(15));
            
            shapes.SetSelectedShapeScalePoint(ScalePoint.LowerRight);

            List<Shape> shapeList = privateShapes.GetField("_shapes") as List<Shape>;
            Assert.IsNotNull(shapeList);
            Assert.AreEqual(1, shapeList.Count);
            Assert.IsTrue(shapeList[0].IsSelected);
            Assert.AreEqual(ScalePoint.LowerRight, shapeList[0].SelectedScalePoint);
        }
        
        /// <inheritdoc/>
        [TestMethod]
        public void ScaleSelectedShape()
        {
            Shapes shapes = new Shapes(shapeFactory);
            shapes.CreateShape(ShapeType.Rectangle, new Point(5), new Point(25));
            shapes.SelectedShapeAtPoint(new Point(15));
            shapes.SetSelectedShapeScalePoint(ScalePoint.LowerRight);

            shapes.ScaleSelectedShape(new Point(20, 13));

            Assert.AreEqual(1, shapes.ShapeDatas.Count);
            Assert.AreEqual("(5, 5), (20, 13)", shapes.ShapeDatas[0].Information);
        }
        
        /// <inheritdoc/>
        [TestMethod]
        public void SaveScaledShape()
        {
            Shapes shapes = new Shapes(shapeFactory);
            PrivateObject privateShapes = new PrivateObject(shapes);
            shapes.CreateShape(ShapeType.Rectangle, new Point(5), new Point(25));
            shapes.SelectedShapeAtPoint(new Point(15));
            shapes.SetSelectedShapeScalePoint(ScalePoint.LowerRight);
            shapes.ScaleSelectedShape(new Point(20, 13));

            shapes.SaveScaledShape();

            List<Shape> shapeList = privateShapes.GetField("_shapes") as List<Shape>;
            Assert.IsNotNull(shapeList);
            Assert.AreEqual(1, shapeList.Count);
            Assert.AreEqual(ScalePoint.None, shapeList[0].SelectedScalePoint);
        }
    }
}
