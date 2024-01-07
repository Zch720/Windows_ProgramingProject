using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drawer.Model
{
    public interface IStorage
    {
        void Save(string data);
        string Load();
    }
}
