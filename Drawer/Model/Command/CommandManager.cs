using Drawer.Model.ShapeObjects;
using System.Collections.Generic;

namespace Drawer.Model.Command
{
    public class CommandManager
    {
        private List<ICommand> _commands;
        private int _currentIndex;
        private readonly DrawerModel _model;

        public bool HasPreviousCommand
        {
            get
            {
                return _currentIndex != -1;
            }
        }

        public bool HasNextCommand
        {
            get
            {
                return _currentIndex != _commands.Count - 1;
            }
        }

        public CommandManager(DrawerModel model)
        {
            _commands = new List<ICommand>();
            _currentIndex = -1;
            _model = model;
        }

        /// <summary>
        /// Undo last command.
        /// </summary>
        public void Undo()
        {
            if (_currentIndex == -1)
                return;
            _commands[_currentIndex--].CancelExecute();
        }

        /// <summary>
        /// Redo last undo command.
        /// </summary>
        public void Redo()
        {
            if (_currentIndex == _commands.Count - 1)
                return;
            _commands[++_currentIndex].Execute();
        }

        /// <summary>
        /// Execute create random shape command.
        /// </summary>
        /// <param name="shapeType">The shape type to create.</param>
        /// <param name="drawArea">The size of draw area.</param>
        public void CreateRandomShape(string shapeType, Point drawArea)
        {
            CommandFirstExecute(new CreateRandomCommand(_model, shapeType, drawArea));
        }

        /// <summary>
        /// Execute create shape command.
        /// </summary>
        /// <param name="type">The shape type to create.</param>
        /// <param name="point1">The point1 of shape.</param>
        /// <param name="point2">The point2 of shape.</param>
        public void CreateShape(ShapeType type, Point point1, Point point2)
        {
            CommandFirstExecute(new CreateCommand(_model, type, point1, point2));
        }

        /// <summary>
        /// Execute delete shape command.
        /// </summary>
        /// <param name="index">The index of the shape want to delete.</param>
        public void DeleteShape(int index)
        {
            CommandFirstExecute(new DeleteCommand(_model, index));
        }

        /// <summary>
        /// Execute move shape command.
        /// </summary>
        /// <param name="index">The index the shape moved.</param>
        /// <param name="originShape">The origin shape data before move.</param>
        public void MoveShape(int index, ShapeData originShape)
        {
            CommandFirstAdd(new MoveCommand(_model, index, originShape));
        }

        /// <summary>
        /// Execute scale shape command.
        /// </summary>
        /// <param name="index">The index the shape scaled.</param>
        /// <param name="originShape">The origin shape data before scale.</param>
        public void ScaleShape(int index, ShapeData originShape)
        {
            CommandFirstAdd(new ScaleCommand(_model, index, originShape));
        }

        /// <summary>
        /// Add the command to command list.
        /// </summary>
        /// <param name="command">The command need to add.</param>
        private void CommandFirstAdd(ICommand command)
        {
            ClearCommandsAfterCurrentIndex();
            _commands.Add(command);
            _currentIndex++;
        }

        /// <summary>
        /// Execute the command and add to command list.
        /// </summary>
        /// <param name="command">The command need to execute.</param>
        private void CommandFirstExecute(ICommand command)
        {
            CommandFirstAdd(command);
            command.Execute();
        }

        /// <summary>
        /// Clear the commands in command list after current index.
        /// </summary>
        private void ClearCommandsAfterCurrentIndex()
        {
            _commands = _commands.GetRange(0, _currentIndex + 1);
        }
    }
}
