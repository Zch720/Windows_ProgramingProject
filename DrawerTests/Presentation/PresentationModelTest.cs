using Drawer.Model;
using Drawer.Model.ShapeObjects;
using DrawerTests;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.ComponentModel;

namespace Drawer.Presentation.Tests
{
    [TestClass]
    public class PresentationModelTest
    {
        private static readonly string LINE_STR = "線";
        private static readonly string RECTANGLE_STR = "矩形";
        private static readonly string CIRCLE_STR = "圓";

        private DrawerModel _model;

        /// <inheritdoc/>
        [TestInitialize]
        public void SetUp()
        {
            ShapeFactory factory = new ShapeFactory();
            _model = new DrawerModel(factory);

            TestUtilities.CreateShape(_model, ShapeType.Rectangle, new Point(3, 2), new Point(1, 5));
            TestUtilities.CreateShape(_model, ShapeType.Circle, new Point(2, 7), new Point(16, 30));
        }

        /// <inheritdoc/>
        [TestMethod]
        public void SetScalePointSize()
        {
            PresentationModel presentationModel = new PresentationModel(_model);
            presentationModel.ScalePointSize = 3;
        }
        
        /// <inheritdoc/>
        [TestMethod]
        public void GetHasPreviousCommandFromModel()
        {
            PresentationModel presentationModel = new PresentationModel(_model);
            Assert.IsTrue(presentationModel.HasPreviousCommand);
        }
        
        /// <inheritdoc/>
        [TestMethod]
        public void GetHasNextCommandFromModel()
        {
            PresentationModel presentationModel = new PresentationModel(_model);
            Assert.IsFalse(presentationModel.HasNextCommand);
        }

        /// <inheritdoc/>
        [TestMethod]
        public void InvokeModelShapesListUpdatedEventHandler()
        {
            PresentationModel presentationModel = new PresentationModel(_model);
            PrivateObject privatePresentationModel = new PrivateObject(presentationModel);
            int notifyCount = 0;

            presentationModel._modelShapesListUpdated += () =>
            {
                notifyCount++;
            };
            privatePresentationModel.Invoke("NotifyModelShapesListUpdated");

            Assert.AreEqual(1, notifyCount);
        }

        /// <inheritdoc/>
        [TestMethod]
        public void InvokeTempShapeUpdatedEventHandler()
        {
            PresentationModel presentationModel = new PresentationModel(_model);
            PrivateObject privatePresentationModel = new PrivateObject(presentationModel);
            int notifyCount = 0;

            presentationModel._tempShapeUpdated += () =>
            {
                notifyCount++;
            };
            privatePresentationModel.Invoke("NotifyTempShapeUpdated");

            Assert.AreEqual(1, notifyCount);
        }

        /// <inheritdoc/>
        [TestMethod]
        public void InvokePropertyChangedEventHandler()
        {
            PresentationModel presentationModel = new PresentationModel(_model);
            PrivateObject privatePresentationModel = new PrivateObject(presentationModel);
            int notifyCount = 0;

            presentationModel.PropertyChanged += (object obj, PropertyChangedEventArgs args) =>
            {
                notifyCount++;
            };
            privatePresentationModel.Invoke("NotifyPropertyChange", "propName");

            Assert.AreEqual(1, notifyCount);
        }

        /// <inheritdoc/>
        [TestMethod]
        public void ClickCreateShapeButtonToCreateLine()
        {
            PresentationModel presentationModel = new PresentationModel(_model);

            presentationModel.ClickCreateShapeButton(LINE_STR);

            Assert.AreEqual(3, presentationModel.ShapeDatas.Count);
            Assert.AreEqual(RECTANGLE_STR, presentationModel.ShapeDatas[0].ShapeName);
            Assert.AreEqual(CIRCLE_STR, presentationModel.ShapeDatas[1].ShapeName);
            Assert.AreEqual(LINE_STR, presentationModel.ShapeDatas[2].ShapeName);
        }

        /// <inheritdoc/>
        [TestMethod]
        public void ClickCreateShapeButtonToCreateRectangle()
        {
            PresentationModel presentationModel = new PresentationModel(_model);

            presentationModel.ClickCreateShapeButton(RECTANGLE_STR);

            Assert.AreEqual(3, presentationModel.ShapeDatas.Count);
            Assert.AreEqual(RECTANGLE_STR, presentationModel.ShapeDatas[0].ShapeName);
            Assert.AreEqual(CIRCLE_STR, presentationModel.ShapeDatas[1].ShapeName);
            Assert.AreEqual(RECTANGLE_STR, presentationModel.ShapeDatas[2].ShapeName);
        }

        /// <inheritdoc/>
        [TestMethod]
        public void ClickCreateShapeButtonToCreateCircle()
        {
            PresentationModel presentationModel = new PresentationModel(_model);

            presentationModel.ClickCreateShapeButton(CIRCLE_STR);

            Assert.AreEqual(3, presentationModel.ShapeDatas.Count);
            Assert.AreEqual(RECTANGLE_STR, presentationModel.ShapeDatas[0].ShapeName);
            Assert.AreEqual(CIRCLE_STR, presentationModel.ShapeDatas[1].ShapeName);
            Assert.AreEqual(CIRCLE_STR, presentationModel.ShapeDatas[2].ShapeName);
        }

        /// <inheritdoc/>
        [TestMethod]
        public void DeleteShapeByDataGridView()
        {
            PresentationModel presentationModel = new PresentationModel(_model);

            presentationModel.ClickShapeDataGridCell(0, 0);

            Assert.AreEqual(1, presentationModel.ShapeDatas.Count);
            Assert.AreEqual(CIRCLE_STR, presentationModel.ShapeDatas[0].ShapeName);
        }

        /// <inheritdoc/>
        [TestMethod]
        public void DoNothingWhenClickWrongColumnOfDataGridView()
        {
            PresentationModel presentationModel = new PresentationModel(_model);

            presentationModel.ClickShapeDataGridCell(1, 0);

            Assert.AreEqual(2, presentationModel.ShapeDatas.Count);
            Assert.AreEqual(RECTANGLE_STR, presentationModel.ShapeDatas[0].ShapeName);
            Assert.AreEqual(CIRCLE_STR, presentationModel.ShapeDatas[1].ShapeName);
        }

        /// <inheritdoc/>
        [TestMethod]
        public void DefaultToolBarStatusIsCursorChecked()
        {
            PresentationModel presentationModel = new PresentationModel(_model);

            Assert.IsFalse(presentationModel.ToolBarLineButtonChecked);
            Assert.IsFalse(presentationModel.ToolBarRectangleButtonChecked);
            Assert.IsFalse(presentationModel.ToolBarCircleButtonChecked);
            Assert.IsTrue(presentationModel.ToolBarCursorButtonChecked);
        }

        /// <inheritdoc/>
        [TestMethod]
        public void ClickToolBarLineButton()
        {
            PresentationModel presentationModel = new PresentationModel(_model);

            presentationModel.ClickToolBarLineButton();

            Assert.IsTrue(presentationModel.ToolBarLineButtonChecked);
            Assert.IsFalse(presentationModel.ToolBarRectangleButtonChecked);
            Assert.IsFalse(presentationModel.ToolBarCircleButtonChecked);
            Assert.IsFalse(presentationModel.ToolBarCursorButtonChecked);
        }

        /// <inheritdoc/>
        [TestMethod]
        public void ClickToolBarRectangleButton()
        {
            PresentationModel presentationModel = new PresentationModel(_model);

            presentationModel.ClickToolBarRectangleButton();

            Assert.IsFalse(presentationModel.ToolBarLineButtonChecked);
            Assert.IsTrue(presentationModel.ToolBarRectangleButtonChecked);
            Assert.IsFalse(presentationModel.ToolBarCircleButtonChecked);
            Assert.IsFalse(presentationModel.ToolBarCursorButtonChecked);
        }

        /// <inheritdoc/>
        [TestMethod]
        public void ClickToolBarCircleButton()
        {
            PresentationModel presentationModel = new PresentationModel(_model);

            presentationModel.ClickToolBarCircleButton();

            Assert.IsFalse(presentationModel.ToolBarLineButtonChecked);
            Assert.IsFalse(presentationModel.ToolBarRectangleButtonChecked);
            Assert.IsTrue(presentationModel.ToolBarCircleButtonChecked);
            Assert.IsFalse(presentationModel.ToolBarCursorButtonChecked);
        }

        /// <inheritdoc/>
        [TestMethod]
        public void ToolBarShouldCheckedOneShapeAtSameTime()
        {
            PresentationModel presentationModel = new PresentationModel(_model);

            presentationModel.ClickToolBarCircleButton();
            presentationModel.ClickToolBarLineButton();

            Assert.IsTrue(presentationModel.ToolBarLineButtonChecked);
            Assert.IsFalse(presentationModel.ToolBarRectangleButtonChecked);
            Assert.IsFalse(presentationModel.ToolBarCircleButtonChecked);
            Assert.IsFalse(presentationModel.ToolBarCursorButtonChecked);
        }

        /// <inheritdoc/>
        [TestMethod]
        public void ToolBarCheckedCursorAfterClickCursor()
        {
            PresentationModel presentationModel = new PresentationModel(_model);

            presentationModel.ClickToolBarCircleButton();
            presentationModel.ClearToolBarButtonChecked();

            Assert.IsFalse(presentationModel.ToolBarLineButtonChecked);
            Assert.IsFalse(presentationModel.ToolBarRectangleButtonChecked);
            Assert.IsFalse(presentationModel.ToolBarCircleButtonChecked);
            Assert.IsTrue(presentationModel.ToolBarCursorButtonChecked);
        }

        /// <inheritdoc/>
        [TestMethod]
        public void CursorStyleUpdatedShouldBeNotifyAfterClearToolBarButtonChecked()
        {
            PresentationModel presentationModel = new PresentationModel(_model);
            int notifyCount = 0;

            presentationModel._cursorStyleUpdated += () => {
                notifyCount++;
            };
            presentationModel.ClearToolBarButtonChecked();

            Assert.AreEqual(1, notifyCount);
            Assert.AreEqual(PresentationModel.CursorStatus.Pointer, presentationModel.CursorStyle);
        }
        
        /// <inheritdoc/>
        [TestMethod]
        public void ClickToolBarUndoButtonInvokeModelUndo()
        {
            PresentationModel presentationModel = new PresentationModel(_model);
            presentationModel.ClickToolBarUndoButton();
        }
        
        /// <inheritdoc/>
        [TestMethod]
        public void ClickToolBarUndoButtonInvokeModelRedo()
        {
            PresentationModel presentationModel = new PresentationModel(_model);
            presentationModel.ClickToolBarRedoButton();
        }

        /// <inheritdoc/>
        [TestMethod]
        public void CursorStyleUpdatedShouldBeNotifyAfterMouseEnterDrawArea()
        {
            PresentationModel presentationModel = new PresentationModel(_model);
            int notifyCount = 0;

            presentationModel._cursorStyleUpdated += () => {
                notifyCount++;
            };
            presentationModel.MouseEnterDrawArea();

            Assert.AreEqual(1, notifyCount);
        }

        /// <inheritdoc/>
        [TestMethod]
        public void CursorStyleShouldBePointerSelectedCursorWhenEnterDrawArea()
        {
            PresentationModel presentationModel = new PresentationModel(_model);

            presentationModel.ClearToolBarButtonChecked();
            presentationModel.MouseEnterDrawArea();

            Assert.AreEqual(PresentationModel.CursorStatus.Pointer, presentationModel.CursorStyle);
        }

        /// <inheritdoc/>
        [TestMethod]
        public void CursorStyleShouldBeCrossSelectedLineWhenEnterDrawArea()
        {
            PresentationModel presentationModel = new PresentationModel(_model);

            presentationModel.ClickToolBarLineButton();
            presentationModel.MouseEnterDrawArea();

            Assert.AreEqual(PresentationModel.CursorStatus.Cross, presentationModel.CursorStyle);
        }

        /// <inheritdoc/>
        [TestMethod]
        public void CursorStyleShouldBeCrossSelectedRectangleWhenEnterDrawArea()
        {
            PresentationModel presentationModel = new PresentationModel(_model);

            presentationModel.ClickToolBarRectangleButton();
            presentationModel.MouseEnterDrawArea();

            Assert.AreEqual(PresentationModel.CursorStatus.Cross, presentationModel.CursorStyle);
        }

        /// <inheritdoc/>
        [TestMethod]
        public void CursorStyleShouldBeCrossSelectedCircleWhenEnterDrawArea()
        {
            PresentationModel presentationModel = new PresentationModel(_model);

            presentationModel.ClickToolBarCircleButton();
            presentationModel.MouseEnterDrawArea();

            Assert.AreEqual(PresentationModel.CursorStatus.Cross, presentationModel.CursorStyle);
        }

        /// <inheritdoc/>
        [TestMethod]
        public void CursorStyleUpdatedShouldBeNotifyAfterMouseLeaveDrawArea()
        {
            PresentationModel presentationModel = new PresentationModel(_model);
            int notifyCount = 0;

            presentationModel._cursorStyleUpdated += () =>
            {
                notifyCount++;
            };
            presentationModel.MouseLeaveDrawArea();

            Assert.AreEqual(1, notifyCount);
        }

        /// <inheritdoc/>
        [TestMethod]
        public void CursorStyleShouldBePointerSelectCursorWhenLeaveDrawArea()
        {
            PresentationModel presentationModel = new PresentationModel(_model);

            presentationModel.ClearToolBarButtonChecked();
            presentationModel.MouseLeaveDrawArea();

            Assert.AreEqual(PresentationModel.CursorStatus.Pointer, presentationModel.CursorStyle);
        }

        /// <inheritdoc/>
        [TestMethod]
        public void CursorStyleShouldBePointerSelectLineWhenLeaveDrawArea()
        {
            PresentationModel presentationModel = new PresentationModel(_model);

            presentationModel.ClickToolBarLineButton();
            presentationModel.MouseLeaveDrawArea();

            Assert.AreEqual(PresentationModel.CursorStatus.Pointer, presentationModel.CursorStyle);
        }

        /// <inheritdoc/>
        [TestMethod]
        public void CursorStyleShouldBePointerSelectRectangleWhenLeaveDrawArea()
        {
            PresentationModel presentationModel = new PresentationModel(_model);

            presentationModel.ClickToolBarRectangleButton();
            presentationModel.MouseLeaveDrawArea();

            Assert.AreEqual(PresentationModel.CursorStatus.Pointer, presentationModel.CursorStyle);
        }

        /// <inheritdoc/>
        [TestMethod]
        public void CursorStyleShouldBePointerSelectCircleWhenLeaveDrawArea()
        {
            PresentationModel presentationModel = new PresentationModel(_model);

            presentationModel.ClickToolBarCircleButton();
            presentationModel.MouseLeaveDrawArea();

            Assert.AreEqual(PresentationModel.CursorStatus.Pointer, presentationModel.CursorStyle);
        }

        /// <inheritdoc/>
        [TestMethod]
        public void DrawWithTemp()
        {
            FakeGraphics graphics = new FakeGraphics();
            PresentationModel presentationModel = new PresentationModel(_model);
            _model.SetDrawingState(ShapeType.Line);
            _model.SelectOrCreateShape(new Point(1, 5));

            presentationModel.DrawWithTemp(graphics);

            Assert.AreEqual(1, graphics.NotifyDrawLineCount);
            Assert.AreEqual(1, graphics.NotifyDrawRectangleCount);
            Assert.AreEqual(1, graphics.NotifyDrawCircleCount);
        }

        /// <inheritdoc/>
        [TestMethod]
        public void DrawWithNoTemp()
        {
            FakeGraphics graphics = new FakeGraphics();
            PresentationModel presentationModel = new PresentationModel(_model);

            presentationModel.DrawWithTemp(graphics);

            Assert.AreEqual(0, graphics.NotifyDrawLineCount);
            Assert.AreEqual(1, graphics.NotifyDrawRectangleCount);
            Assert.AreEqual(1, graphics.NotifyDrawCircleCount);
        }

        /// <inheritdoc/>
        [TestMethod]
        public void DoNothingWhenAnyKeyDownExceptDelete()
        {
            PresentationModel presentationModel = new PresentationModel(_model);
            presentationModel.MouseDownInDrawArea(1, 2, 1920, 1080);

            presentationModel.HandleFormKeyDown("A");

            Assert.AreEqual(RECTANGLE_STR, presentationModel.ShapeDatas[0].ShapeName);
            Assert.AreEqual(CIRCLE_STR, presentationModel.ShapeDatas[1].ShapeName);
        }

        /// <inheritdoc/>
        [TestMethod]
        public void DeleteShapeWhenDeleteKeyDown()
        {
            PresentationModel presentationModel = new PresentationModel(_model);
            presentationModel.MouseDownInDrawArea(1, 2, 1920, 1080);

            presentationModel.HandleFormKeyDown("Delete");

            Assert.AreEqual(CIRCLE_STR, presentationModel.ShapeDatas[0].ShapeName);
        }

        /// <inheritdoc/>
        [TestMethod]
        public void ShapeListUpdatedShouldBeNotifyAfterMouseDownWhenModelIsPointerState()
        {
            PresentationModel presentationModel = new PresentationModel(_model);
            int notifyCount = 0;

            presentationModel._modelShapesListUpdated += () => {
                notifyCount++;
            };
            presentationModel.MouseDownInDrawArea(1, 2, 1920, 1080);

            Assert.AreEqual(1, notifyCount);
        }

        /// <inheritdoc/>
        [TestMethod]
        public void CursorStyleNotifyShouldNotBeNotifyWhenDrawing()
        {
            PresentationModel presentationModel = new PresentationModel(_model);
            int notifyCount = 0;
            _model.SetDrawingState(ShapeType.Line);

            presentationModel._cursorStyleUpdated += () =>
            {
                notifyCount++;
            };
            presentationModel.MouseMoveInDrawArea(1, 1, 1920, 1080);

            Assert.AreEqual(0, notifyCount);
        }

        /// <inheritdoc/>
        [TestMethod]
        public void CursorNotOnSelectedShapeScalePoint()
        {
            PresentationModel presentationModel = new PresentationModel(_model);
            presentationModel.MouseDownInDrawArea(13, 20, 1920, 1080);
            presentationModel.MouseUpInDrawArea(13, 20, 1920, 1080);

            presentationModel.MouseMoveInDrawArea(0, 0, 1920, 1080);

            Assert.AreEqual(PresentationModel.CursorStatus.Pointer, presentationModel.CursorStyle);
        }

        /// <inheritdoc/>
        [TestMethod]
        public void CursorOnSelectedShapeUpperLeftScalePoint()
        {
            PresentationModel presentationModel = new PresentationModel(_model);
            presentationModel.MouseDownInDrawArea(13, 20, 1920, 1080);
            presentationModel.MouseUpInDrawArea(13, 20, 1920, 1080);

            presentationModel.MouseMoveInDrawArea(2, 7, 1920, 1080);

            Assert.AreEqual(PresentationModel.CursorStatus.SizeUpperLeft, presentationModel.CursorStyle);
        }

        /// <inheritdoc/>
        [TestMethod]
        public void CursorOnSelectedShapeUpperRightScalePoint()
        {
            PresentationModel presentationModel = new PresentationModel(_model);
            presentationModel.MouseDownInDrawArea(13, 20, 1920, 1080);
            presentationModel.MouseUpInDrawArea(13, 20, 1920, 1080);

            presentationModel.MouseMoveInDrawArea(16, 7, 1920, 1080);

            Assert.AreEqual(PresentationModel.CursorStatus.SizeUpperRight, presentationModel.CursorStyle);
        }

        /// <inheritdoc/>
        [TestMethod]
        public void CursorOnSelectedShapeLowerLeftScalePoint()
        {
            PresentationModel presentationModel = new PresentationModel(_model);
            presentationModel.MouseDownInDrawArea(13, 20, 1920, 1080);
            presentationModel.MouseUpInDrawArea(13, 20, 1920, 1080);

            presentationModel.MouseMoveInDrawArea(2, 30, 1920, 1080);

            Assert.AreEqual(PresentationModel.CursorStatus.SizeUpperRight, presentationModel.CursorStyle);
        }

        /// <inheritdoc/>
        [TestMethod]
        public void CursorOnSelectedShapeLowerRightScalePoint()
        {
            PresentationModel presentationModel = new PresentationModel(_model);
            presentationModel.MouseDownInDrawArea(13, 20, 1920, 1080);
            presentationModel.MouseUpInDrawArea(13, 20, 1920, 1080);

            presentationModel.MouseMoveInDrawArea(16, 30, 1920, 1080);

            Assert.AreEqual(PresentationModel.CursorStatus.SizeUpperLeft, presentationModel.CursorStyle);
        }

        /// <inheritdoc/>
        [TestMethod]
        public void DoNothingAfterMuseMoveWithoutMouseDown()
        {
            PresentationModel presentationModel = new PresentationModel(_model);
            int notifyCount = 0;

            presentationModel._modelShapesListUpdated += () => {
                notifyCount++;
            };
            presentationModel.MouseMoveInDrawArea(3, 3, 1920, 1080);

            Assert.AreEqual(0, notifyCount);
        }

        /// <inheritdoc/>
        [TestMethod]
        public void DoNothingAfterMuseUpWithoutMouseDown()
        {
            PresentationModel presentationModel = new PresentationModel(_model);
            int notifyCount = 0;

            presentationModel._modelShapesListUpdated += () => {
                notifyCount++;
            };
            presentationModel.MouseUpInDrawArea(3, 3, 1920, 1080);

            Assert.AreEqual(0, notifyCount);
        }
    }
}
