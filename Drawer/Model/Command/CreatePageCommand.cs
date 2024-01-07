using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drawer.Model.Command
{
    public class CreatePageCommand : ICommand
    {
        private DrawerModel _model;
        private int _createIndex;

        public CreatePageCommand(DrawerModel model, int createIndex)
        {
            _model = model;
            _createIndex = createIndex;
        }

        public void Execute()
        {
            _model.CreateNewPage(_createIndex);
        }

        public void CancelExecute()
        {
            _model.DeletePage(_createIndex);
        }
    }
}
