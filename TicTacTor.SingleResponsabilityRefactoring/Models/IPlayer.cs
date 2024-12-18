using TicTacTor.SingleResponsabilityRefactoring.DTOs;
using TicTacTor.SingleResponsabilityRefactoring.Models.Implementations;

namespace TicTacTor.SingleResponsabilityRefactoring.Models
{
    internal enum GameSymbol
    {
        X = 'X',
        O = 'O'
    }

    internal interface IPlayer
    {
        char GetCurrentPlayer();
        ResultDTO<IPlayerMovesRecord> GetNextMove(string? input);
    }
}
