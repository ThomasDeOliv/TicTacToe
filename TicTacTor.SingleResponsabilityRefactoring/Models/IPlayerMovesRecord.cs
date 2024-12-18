namespace TicTacTor.SingleResponsabilityRefactoring.Models
{
    internal interface IPlayerMovesRecord
    {
        int Row { get; }
        int Column { get; }
    }
}
