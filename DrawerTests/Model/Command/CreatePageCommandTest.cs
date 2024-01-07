using Drawer.Model.ShapeObjects;
using DrawerTests.FakeObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Drawer.Model.Command.Tests
{
    [TestClass]
    public class CreatePageCommandTest
    {
        DrawerModel _model;

        /// <inheritdoc/>
        [TestInitialize]
        public void SetUp()
        {
            ShapeFactory shapeFactory = new ShapeFactory();
            _model = new DrawerModel(shapeFactory, new FakeStorage());
        }

        [TestMethod]
        public void ExecuteCreatePageCommand()
        {
            CreatePageCommand command = new CreatePageCommand(_model, 1);

            command.Execute();

            PrivateObject privateModel = new PrivateObject(_model);
            List<Shapes> pages = privateModel.GetField("_pages") as List<Shapes>;
            Assert.IsNotNull(pages);
            Assert.AreEqual(2, pages.Count);
        }

        [TestMethod]
        public void CancelExecuteCreatePageCommand()
        {
            CreatePageCommand command = new CreatePageCommand(_model, 1);
            command.Execute();

            command.CancelExecute();

            PrivateObject privateModel = new PrivateObject(_model);
            List<Shapes> pages = privateModel.GetField("_pages") as List<Shapes>;
            Assert.IsNotNull(pages);
            Assert.AreEqual(1, pages.Count);
        }
    }
}
