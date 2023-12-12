using Drawer.Model.ShapeObjects;
using System.Collections.Generic;

namespace Drawer.Model.Command
{
    public class CommandManager
    {
        private List<ICommand> _commands;
        private int _currentIndex;
        private readonly Shapes _shapes;

        public CommandManager(Shapes shapes)
        {
            _commands = new List<ICommand>();
            _currentIndex = -1;
            _shapes = shapes;
        }

        public void Undo()
        {
            if (_currentIndex == -1)
                return;
            _commands[_currentIndex--].Unexecute();
        }

        public void Redo()
        {
            if (_currentIndex == _commands.Count - 1)
                return;
            _commands[++_currentIndex].Execute();
        }

        public void CreateRandomShape(string shapeType, Point drawArea)
        {
            CommandFirstExecute(new CreateRandomCommand(_shapes, shapeType, drawArea));
        }

        public void CreateShape(ShapeType type, Point point1, Point point2)
        {
            CommandFirstExecute(new CreateCommand(_shapes, type, point1, point2));
        }

        public void DeleteShape(int index)
        {
            CommandFirstExecute(new DeleteCommand(_shapes, index));
        }

        public void MoveShape(int index, ShapeData originShape)
        {
            CommandFirstExecute(new MoveCommand(_shapes, index, originShape));
        }

        public void ScaleShape(int index, ShapeData originShape)
        {
            CommandFirstExecute(new ScaleCommand(_shapes, index, originShape));
        }

        private void CommandFirstExecute(ICommand command)
        {
            ClearCommandsAfterCurrentIndex();
            _commands.Add(command);
            _currentIndex++;
            command.Execute();
        }

        private void ClearCommandsAfterCurrentIndex()
        {
            _commands = _commands.GetRange(0, _currentIndex + 1);
        }
    }
}
