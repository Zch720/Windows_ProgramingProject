using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace DrawerTests.FakeObjects
{
    [TestClass]
    public class FakeStateTest
    {
        /// <inheritdoc/>
        [TestMethod]
        public void FakeStateSelectedShapeTypeNoImplement()
        {
            FakeState state = new FakeState();
            Assert.ThrowsException<NotImplementedException>(() => state.SelectedShapeType);
        }
    }
}
