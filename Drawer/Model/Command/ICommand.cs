namespace Drawer.Model.Command
{
    public interface ICommand
    {
        /// <summary>
        /// Execute the command.
        /// </summary>
        void Execute();

        /// <summary>
        /// Unexecute the command.
        /// </summary>
        void CancelExecute();
    }
}
