namespace TicTacTor.SingleResponsabilityRefactoring.Models.BoardModel.CellModel
{
    internal interface ICell
    {
        int Row { get; }
        int Column { get; }
        char? Value { get; }
        void UpdateValue(char value);
    }
}
