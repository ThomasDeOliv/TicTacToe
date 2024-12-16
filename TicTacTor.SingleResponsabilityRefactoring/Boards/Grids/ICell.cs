namespace TicTacTor.SingleResponsabilityRefactoring.Boards.Grids
{
    internal interface ICell
    {
        int Row { get; }
        int Column { get; }
        char? Value { get; }
        void UpdateValue(char value);
    }
}
