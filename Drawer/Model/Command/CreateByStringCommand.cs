using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drawer.Model.Command
{
    public class CreateByStringCommand : ICommand
    {
        DrawerModel _model;
        string _type;
        Point _point1;
        Point _point2;
        int _currentShapesIndex;

        public CreateByStringCommand(DrawerModel model, string type, Point point1, Point point2)
        {
            _model = model;
            _type = type;
            _point1 = point1;
            _point2 = point2;
            _currentShapesIndex = model.SelectedPage;
        }

        /// <inheritdoc/>
        public void Execute()
        {
            _model.SelectedPage = _currentShapesIndex;
            _model.CurrentShapes.CreateShape(_type, _point1, _point2);
        }

        /// <inheritdoc/>
        public void CancelExecute()
        {
            _model.SelectedPage = _currentShapesIndex;
            _model.CurrentShapes.DeleteLastShape();
        }
    }
}
