using Drawer.Model;

namespace DrawerTests.FakeObjects
{
    public class FakeStorage : IStorage
    {
        private string _data = "";

        public string Load()
        {
            return _data;
        }

        public void Save(string data)
        {
            _data = data;
        }
    }
}
