using Drawer.Model.ShapeObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drawer.Model.Command
{
    public class DeletePageCommand : ICommand
    {
        private DrawerModel _model;
        private int _deleteIndex;
        private List<ShapeData> _shapeDatas;

        public DeletePageCommand(DrawerModel model, int deleteIndex)
        {
            _model = model;
            _deleteIndex = deleteIndex;
            _model.SelectedPage = deleteIndex;
            _shapeDatas = new List<ShapeData>(_model.CurrentShapes.ShapeDatas);
        }

        public void Execute()
        {
            _model.DeletePage(_deleteIndex);
        }

        public void CancelExecute()
        {
            _model.CreateNewPage(_deleteIndex);
            _model.SelectedPage = _deleteIndex;
            foreach (ShapeData data in _shapeDatas)
            {
                _model.CurrentShapes.CreateFromData(data);
            }
        }
    }
}
