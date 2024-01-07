using DrawerTests;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace Drawer.Model.ShapeObjects.Tests
{
    [TestClass]
    public class ShapesTest
    {
        private ShapeFactory shapeFactory = new ShapeFactory();
        
        /// <inheritdoc/>
        [TestMethod]
        public void SetScalePointSize()
        {
            Shapes shapes = new Shapes(shapeFactory);

            shapes.ScalePointSize = 5;

            PrivateObject privateShapes = new PrivateObject(shapes);
            int scalePointSize = (int)privateShapes.GetField("_scalePointSize");
            Assert.AreEqual(5, scalePointSize);
        }

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
        public void CreateShapeByString()
        {
            Shapes shapes = new Shapes(shapeFactory);
            PrivateObject shapesPrivate = new PrivateObject(shapes);

            shapes.CreateShape("線", new Point(0, 1), new Point(5, 3));

            List<Shape> shapesList = shapesPrivate.GetField("_shapes") as List<Shape>;
            Assert.IsNotNull(shapesList);
            Assert.AreEqual(1, shapesList.Count);
            Assert.AreEqual(1, shapes.ShapeDatas.Count);
            Assert.AreEqual(ShapeType.Line, shapesList[0].Type);
        }

        /// <inheritdoc/>
        [TestMethod]
        public void CreateShapeFromData()
        {
            Shapes shapes = new Shapes(shapeFactory);
            ShapeData shapeData = new ShapeData(new Line(new Point(3), new Point(5)));

            shapes.CreateFromData(shapeData);

            Assert.AreEqual(1, shapes.ShapeDatas.Count);
            Assert.AreEqual("線", shapes.ShapeDatas[0].ShapeName);
            Assert.AreEqual("(3, 3), (5, 5)", shapes.ShapeDatas[0].Information);
        }

        /// <inheritdoc/>
        [TestMethod]
        public void InsertShapeFromData()
        {
            Shapes shapes = new Shapes(shapeFactory);
            shapes.CreateRandomShape("圓", new Point(100, 100));
            shapes.CreateRandomShape("矩形", new Point(100, 100));
            ShapeData shapeData = new ShapeData(new Line(new Point(3), new Point(5)));

            shapes.InsertShapeFromData(shapeData, 1);

            Assert.AreEqual(3, shapes.ShapeDatas.Count);
            Assert.AreEqual("圓", shapes.ShapeDatas[0].ShapeName);
            Assert.AreEqual("線", shapes.ShapeDatas[1].ShapeName);
            Assert.AreEqual("矩形", shapes.ShapeDatas[2].ShapeName);
        }

        /// <inheritdoc/>
        [TestMethod]
        public void InsertShapeFromDataBeforeSelectedShape()
        {
            Shapes shapes = new Shapes(shapeFactory);
            shapes.CreateShape(ShapeType.Circle, new Point(3), new Point(7));
            shapes.CreateShape(ShapeType.Rectangle, new Point(10), new Point(13));
            shapes.SelectedShapeAtPoint(new Point(5));
            ShapeData shapeData = new ShapeData(new Line(new Point(3), new Point(5)));

            shapes.InsertShapeFromData(shapeData, 1);

            Assert.AreEqual(0, shapes.SelectedShapeIndex);
        }

        /// <inheritdoc/>
        [TestMethod]
        public void InsertShapeFromDataAfterSelectedShape()
        {
            Shapes shapes = new Shapes(shapeFactory);
            shapes.CreateShape(ShapeType.Circle, new Point(3), new Point(7));
            shapes.CreateShape(ShapeType.Rectangle, new Point(10), new Point(13));
            shapes.SelectedShapeAtPoint(new Point(11));
            ShapeData shapeData = new ShapeData(new Line(new Point(3), new Point(5)));

            shapes.InsertShapeFromData(shapeData, 1);

            Assert.AreEqual(2, shapes.SelectedShapeIndex);
        }

        /// <inheritdoc/>
        [TestMethod]
        public void DeleteFirstShapeByIndex()
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
        public void DeleteLastShapeByIndex()
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
        public void DeleteLastShape()
        {
            Shapes shapes = new Shapes(shapeFactory);
            PrivateObject shapesPrivate = new PrivateObject(shapes);
            shapes.CreateRandomShape("圓", new Point(100, 100));
            shapes.CreateRandomShape("矩形", new Point(100, 100));
            shapes.CreateRandomShape("線", new Point(100, 100));

            shapes.DeleteLastShape();

            List<Shape> shapesList = shapesPrivate.GetField("_shapes") as List<Shape>;
            Assert.IsNotNull(shapesList);
            Assert.AreEqual(2, shapesList.Count);
            Assert.AreEqual(2, shapes.ShapeDatas.Count);
            Assert.AreEqual(ShapeType.Circle, shapesList[0].Type);
            Assert.AreEqual(ShapeType.Rectangle, shapesList[1].Type);
        }

        /// <inheritdoc/>
        [TestMethod]
        public void SetShapeAtIndex()
        {
            Shapes shapes = new Shapes(shapeFactory);
            shapes.CreateRandomShape("圓", new Point(100, 100));
            ShapeData shapeData = new ShapeData(new Rectangle());

            shapes.SetShapeAtIndex(0, shapeData);

            Assert.AreEqual("矩形", shapes.ShapeDatas[0].ShapeName);
            Assert.AreEqual("(0, 0), (0, 0)", shapes.ShapeDatas[0].Information);
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
        public void DrawShapesWithNoTempShape()
        {
            FakeGraphics graphics = new FakeGraphics();
            Shapes shapes = new Shapes(shapeFactory);
            shapes.CreateRandomShape("線", new Point(100, 100));

            shapes.Draw(graphics);

            Assert.AreEqual(1, graphics.NotifyDrawLineCount);
            Assert.AreEqual(0, graphics.NotifyDrawRectangleCount);
            Assert.AreEqual(0, graphics.NotifyDrawCircleCount);
            Assert.AreEqual(0, graphics.NotifyDrawSelectBoxCount);
        }
        
        /// <inheritdoc/>
        [TestMethod]
        public void SelectShapeAtIndex()
        {
            Shapes shapes = new Shapes(shapeFactory);
            shapes.CreateShape(ShapeType.Line, new Point(3), new Point(9));

            shapes.SelectShapeAtIndex(0);

            Assert.IsTrue(shapes.ShapeDatas[0].IsSelected);
        }
        
        /// <inheritdoc/>
        [TestMethod]
        public void SelectDifferentShapeAtIndex()
        {
            Shapes shapes = new Shapes(shapeFactory);
            shapes.CreateShape(ShapeType.Line, new Point(3), new Point(9));
            shapes.CreateShape(ShapeType.Line, new Point(3), new Point(9));
            shapes.SelectShapeAtIndex(0);

            shapes.SelectShapeAtIndex(1);

            Assert.IsFalse(shapes.ShapeDatas[0].IsSelected);
            Assert.IsTrue(shapes.ShapeDatas[1].IsSelected);
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
        public void SelectShapeSelectedScalePointByPointButNotOnShape()
        {
            Shapes shapes = new Shapes(shapeFactory);
            PrivateObject privateShapes = new PrivateObject(shapes);
            shapes.CreateShape(ShapeType.Rectangle, new Point(5), new Point(25));
            shapes.SelectedShapeAtPoint(new Point(15));

            shapes.SetSelectedShapeScalePoint(new Point(0));

            List<Shape> shapeList = privateShapes.GetField("_shapes") as List<Shape>;
            Assert.IsNotNull(shapeList);
            Assert.AreEqual(1, shapeList.Count);
            Assert.IsTrue(shapeList[0].IsSelected);
            Assert.AreEqual(ScalePoint.None, shapeList[0].SelectedScalePoint);
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
