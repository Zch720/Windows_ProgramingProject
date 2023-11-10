using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Drawer
{
    public partial class DoubleBufferdPanel : Panel
    {
        public DoubleBufferdPanel()
        {
            DoubleBuffered = true;
        }
    }
}
