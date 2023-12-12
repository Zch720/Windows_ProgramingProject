namespace Drawer.Model.Command
{
    public interface ICommand
    {
        void Execute();
        void Unexecute();
    }
}
