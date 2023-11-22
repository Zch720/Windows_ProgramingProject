using Drawer.Model;
using Drawer.Model.ShapeObjects;
using Drawer.Presentation.State;
using DrawerTests;
using Microsoft.VisualStudio.TestTools.UnitTesting;
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

        [TestInitialize]
        public void SetUp()
        {
            ShapeFactory factory = new ShapeFactory();
            _model = new DrawerModel(factory);

            TestUtilities.CreateShape(_model, ShapeType.Rectangle, new Point(3, 2), new Point(1, 5));
            TestUtilities.CreateShape(_model, ShapeType.Circle, new Point(2, 7), new Point(6, 10));
        }

        [TestMethod]
        public void DefaultStateIsPointerState()
        {
            PresentationModel presentationModel = new PresentationModel(_model);
            PrivateObject privatePresentationModel = new PrivateObject(presentationModel);

            IState state = privatePresentationModel.GetField("_state") as IState;

            Assert.IsNotNull(state);
            Assert.IsTrue(state is PointerState);
        }

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

        [TestMethod]
        public void ClickCreateShapeButtonToCreateLine()
        {
            PresentationModel presentationModel = new PresentationModel(_model);

            presentationModel.ClickCreateShapeButton(LINE_STR, new Point(100, 100));

            Assert.AreEqual(3, presentationModel.ShapeDatas.Count);
            Assert.AreEqual(RECTANGLE_STR, presentationModel.ShapeDatas[0].ShapeName);
            Assert.AreEqual(CIRCLE_STR, presentationModel.ShapeDatas[1].ShapeName);
            Assert.AreEqual(LINE_STR, presentationModel.ShapeDatas[2].ShapeName);
        }

        [TestMethod]
        public void ClickCreateShapeButtonToCreateRectangle()
        {
            PresentationModel presentationModel = new PresentationModel(_model);

            presentationModel.ClickCreateShapeButton(RECTANGLE_STR, new Point(100, 100));

            Assert.AreEqual(3, presentationModel.ShapeDatas.Count);
            Assert.AreEqual(RECTANGLE_STR, presentationModel.ShapeDatas[0].ShapeName);
            Assert.AreEqual(CIRCLE_STR, presentationModel.ShapeDatas[1].ShapeName);
            Assert.AreEqual(RECTANGLE_STR, presentationModel.ShapeDatas[2].ShapeName);
        }

        [TestMethod]
        public void ClickCreateShapeButtonToCreateCircle()
        {
            PresentationModel presentationModel = new PresentationModel(_model);

            presentationModel.ClickCreateShapeButton(CIRCLE_STR, new Point(100, 100));

            Assert.AreEqual(3, presentationModel.ShapeDatas.Count);
            Assert.AreEqual(RECTANGLE_STR, presentationModel.ShapeDatas[0].ShapeName);
            Assert.AreEqual(CIRCLE_STR, presentationModel.ShapeDatas[1].ShapeName);
            Assert.AreEqual(CIRCLE_STR, presentationModel.ShapeDatas[2].ShapeName);
        }

        [TestMethod]
        public void DeleteShapeByDataGridView()
        {
            PresentationModel presentationModel = new PresentationModel(_model);

            presentationModel.ClickShapeDataGridCell(0, 0);

            Assert.AreEqual(1, presentationModel.ShapeDatas.Count);
            Assert.AreEqual(CIRCLE_STR, presentationModel.ShapeDatas[0].ShapeName);
        }

        [TestMethod]
        public void DoNothingWhenClickWrongColumnOfDataGridView()
        {
            PresentationModel presentationModel = new PresentationModel(_model);

            presentationModel.ClickShapeDataGridCell(1, 0);

            Assert.AreEqual(2, presentationModel.ShapeDatas.Count);
            Assert.AreEqual(RECTANGLE_STR, presentationModel.ShapeDatas[0].ShapeName);
            Assert.AreEqual(CIRCLE_STR, presentationModel.ShapeDatas[1].ShapeName);
        }

        [TestMethod]
        public void DefaultToolBarStatusIsCursorChecked()
        {
            PresentationModel presentationModel = new PresentationModel(_model);

            Assert.IsFalse(presentationModel.ToolBarLineButtonChecked);
            Assert.IsFalse(presentationModel.ToolBarRectangleButtonChecked);
            Assert.IsFalse(presentationModel.ToolBarCircleButtonChecked);
            Assert.IsTrue(presentationModel.ToolBarCursorButtonChecked);
        }

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

        [TestMethod]
        public void CursorStyleShouldBePointerSelectedCursorWhenEnterDrawArea()
        {
            PresentationModel presentationModel = new PresentationModel(_model);

            presentationModel.ClearToolBarButtonChecked();
            presentationModel.MouseEnterDrawArea();

            Assert.AreEqual(PresentationModel.CursorStatus.Pointer, presentationModel.CursorStyle);
        }

        [TestMethod]
        public void CursorStyleShouldBeCrossSelectedLineWhenEnterDrawArea()
        {
            PresentationModel presentationModel = new PresentationModel(_model);

            presentationModel.ClickToolBarLineButton();
            presentationModel.MouseEnterDrawArea();

            Assert.AreEqual(PresentationModel.CursorStatus.Cross, presentationModel.CursorStyle);
        }

        [TestMethod]
        public void CursorStyleShouldBeCrossSelectedRectangleWhenEnterDrawArea()
        {
            PresentationModel presentationModel = new PresentationModel(_model);

            presentationModel.ClickToolBarRectangleButton();
            presentationModel.MouseEnterDrawArea();

            Assert.AreEqual(PresentationModel.CursorStatus.Cross, presentationModel.CursorStyle);
        }

        [TestMethod]
        public void CursorStyleShouldBeCrossSelectedCircleWhenEnterDrawArea()
        {
            PresentationModel presentationModel = new PresentationModel(_model);

            presentationModel.ClickToolBarCircleButton();
            presentationModel.MouseEnterDrawArea();

            Assert.AreEqual(PresentationModel.CursorStatus.Cross, presentationModel.CursorStyle);
        }

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

        [TestMethod]
        public void CursorStyleShouldBePointerSelectCursorWhenLeaveDrawArea()
        {
            PresentationModel presentationModel = new PresentationModel(_model);

            presentationModel.ClearToolBarButtonChecked();
            presentationModel.MouseLeaveDrawArea();

            Assert.AreEqual(PresentationModel.CursorStatus.Pointer, presentationModel.CursorStyle);
        }

        [TestMethod]
        public void CursorStyleShouldBePointerSelectLineWhenLeaveDrawArea()
        {
            PresentationModel presentationModel = new PresentationModel(_model);

            presentationModel.ClickToolBarLineButton();
            presentationModel.MouseLeaveDrawArea();

            Assert.AreEqual(PresentationModel.CursorStatus.Pointer, presentationModel.CursorStyle);
        }

        [TestMethod]
        public void CursorStyleShouldBePointerSelectRectangleWhenLeaveDrawArea()
        {
            PresentationModel presentationModel = new PresentationModel(_model);

            presentationModel.ClickToolBarRectangleButton();
            presentationModel.MouseLeaveDrawArea();

            Assert.AreEqual(PresentationModel.CursorStatus.Pointer, presentationModel.CursorStyle);
        }

        [TestMethod]
        public void CursorStyleShouldBePointerSelectCircleWhenLeaveDrawArea()
        {
            PresentationModel presentationModel = new PresentationModel(_model);

            presentationModel.ClickToolBarCircleButton();
            presentationModel.MouseLeaveDrawArea();

            Assert.AreEqual(PresentationModel.CursorStatus.Pointer, presentationModel.CursorStyle);
        }

        [TestMethod]
        public void StateHandleMouseDownShouldBeCallWhenMouseDownInDrawArea()
        {
            FakeState state = new FakeState();
            PresentationModel presentationModel = new PresentationModel(_model);
            PrivateObject privatePresentationModel = new PrivateObject(presentationModel);
            privatePresentationModel.SetField("_state", state);

            presentationModel.MouseDownInDrawArea(0, 0);

            Assert.AreEqual(1, state.NotifyMouseDownCount);
            Assert.AreEqual(0, state.NotifyMouseMoveCount);
            Assert.AreEqual(0, state.NotifyMouseUpCount);
        }

        [TestMethod]
        public void StateHandleMouseMoveShouldBeCallWhenMouseMoveInDrawArea()
        {
            FakeState state = new FakeState();
            PresentationModel presentationModel = new PresentationModel(_model);
            PrivateObject privatePresentationModel = new PrivateObject(presentationModel);
            privatePresentationModel.SetField("_state", state);

            presentationModel.MouseMoveInDrawArea(0, 0);

            Assert.AreEqual(0, state.NotifyMouseDownCount);
            Assert.AreEqual(1, state.NotifyMouseMoveCount);
            Assert.AreEqual(0, state.NotifyMouseUpCount);
        }

        [TestMethod]
        public void StateHandleMouseUpShouldBeCallWhenMouseUpInDrawArea()
        {
            FakeState state = new FakeState();
            PresentationModel presentationModel = new PresentationModel(_model);
            PrivateObject privatePresentationModel = new PrivateObject(presentationModel);
            privatePresentationModel.SetField("_state", state);

            presentationModel.MouseUpInDrawArea(0, 0);

            Assert.AreEqual(0, state.NotifyMouseDownCount);
            Assert.AreEqual(0, state.NotifyMouseMoveCount);
            Assert.AreEqual(1, state.NotifyMouseUpCount);
        }

        [TestMethod]
        public void DrawWithTemp()
        {
            FakeGraphics graphics = new FakeGraphics();
            PresentationModel presentationModel = new PresentationModel(_model);
            _model.CreateTempShape(ShapeType.Line, new Point(1, 5));

            presentationModel.DrawWithTemp(graphics);

            Assert.AreEqual(1, graphics.NotifyDrawLineCount);
            Assert.AreEqual(1, graphics.NotifyDrawRectangleCount);
            Assert.AreEqual(1, graphics.NotifyDrawCircleCount);
        }

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

        [TestMethod]
        public void DoNothingWhenAnyKeyDownExceptDelete()
        {
            PresentationModel presentationModel = new PresentationModel(_model);
            presentationModel.MouseDownInDrawArea(1, 2);

            presentationModel.HandleFormKeyDown("A");

            Assert.AreEqual(RECTANGLE_STR, presentationModel.ShapeDatas[0].ShapeName);
            Assert.AreEqual(CIRCLE_STR, presentationModel.ShapeDatas[1].ShapeName);
        }

        [TestMethod]
        public void DeleteShapeWhenDeleteKeyDown()
        {
            PresentationModel presentationModel = new PresentationModel(_model);
            presentationModel.MouseDownInDrawArea(1, 2);

            presentationModel.HandleFormKeyDown("Delete");

            Assert.AreEqual(CIRCLE_STR, presentationModel.ShapeDatas[0].ShapeName);
        }
    }
}
