namespace CarsFromConsole
{
    // Interface with
    internal interface ICommand
    {
        void Execute();
        void Execute(string label);
    }
}
