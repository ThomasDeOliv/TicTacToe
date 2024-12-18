using TicTacTor.SingleResponsabilityRefactoring.Models.GameModel;

namespace TicTacTor.SingleResponsabilityRefactoring
{
    internal enum GameSymbol
    {
        X = 'X',
        O = 'O'
    }

    internal static class Program
    {
        internal static void Main(string[] args)
        {
            Game gameSession = Game.CreateGame();
            gameSession.InitGameSession();
            gameSession.StartGameSession();
        }
    }
}
