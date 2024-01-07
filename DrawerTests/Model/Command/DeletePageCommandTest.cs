using Drawer.Model.ShapeObjects;
using DrawerTests.FakeObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Drawer.Model.Command.Tests
{
    [TestClass]
    public class DeletePageCommandTest
    {
        DrawerModel _model;

        /// <inheritdoc/>
        [TestInitialize]
        public void SetUp()
        {
            ShapeFactory shapeFactory = new ShapeFactory();
            _model = new DrawerModel(shapeFactory, new FakeStorage());
            _model.CreateNewPage(1);
        }

        [TestMethod]
        public void ExecuteCreatePageCommand()
        {
            DeletePageCommand command = new DeletePageCommand(_model, 1);

            command.Execute();

            PrivateObject privateModel = new PrivateObject(_model);
            List<Shapes> pages = privateModel.GetField("_pages") as List<Shapes>;
            Assert.IsNotNull(pages);
            Assert.AreEqual(1, pages.Count);
        }

        [TestMethod]
        public void CancelExecuteCreatePageCommand()
        {
            DeletePageCommand command = new DeletePageCommand(_model, 1);
            command.Execute();

            command.CancelExecute();

            PrivateObject privateModel = new PrivateObject(_model);
            List<Shapes> pages = privateModel.GetField("_pages") as List<Shapes>;
            Assert.IsNotNull(pages);
            Assert.AreEqual(2, pages.Count);
        }

        [TestMethod]
        public void CancelExecuteCreatePageCommandWithShapesInPage()
        {
            _model.SelectedPage = 1;
            _model.CreateShape(ShapeType.Circle, new Point(1), new Point(100));
            DeletePageCommand command = new DeletePageCommand(_model, 1);
            command.Execute();

            command.CancelExecute();

            PrivateObject privateModel = new PrivateObject(_model);
            List<Shapes> pages = privateModel.GetField("_pages") as List<Shapes>;
            Assert.IsNotNull(pages);
            Assert.AreEqual(2, pages.Count);
            _model.SelectedPage = 1;
            Assert.AreEqual("(1, 1), (100, 100)", _model.ShapeDatas[0].Information);
        }
    }
}
