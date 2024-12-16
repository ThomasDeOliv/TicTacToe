using TicTacTor.SingleResponsabilityRefactoring.DTOs;

namespace TicTacTor.SingleResponsabilityRefactoring.Players
{
    internal enum GameSymbol
    {
        X = 'X',
        O = 'O'
    }

    internal interface IPlayer
    {
        char GetCurrentPlayer();
        ResultDTO GetNextMove(string input);
    }
}
