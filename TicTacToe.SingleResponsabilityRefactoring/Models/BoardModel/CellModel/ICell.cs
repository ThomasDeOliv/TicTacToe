namespace TicTacToe.SingleResponsabilityRefactoring.Models.BoardModel.CellModel
{
    public interface ICell
    {
        int Row { get; }
        int Column { get; }
        char? Value { get; }
        void UpdateValue(char value);
    }
}
