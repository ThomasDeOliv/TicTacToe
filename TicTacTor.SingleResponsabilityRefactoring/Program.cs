using TicTacTor.SingleResponsabilityRefactoring.Models.Implementations;

namespace TicTacTor.SingleResponsabilityRefactoring
{
    internal static class Program
    {
        internal static void Main(string[] args)
        {
            Game gameSession = Game.CreateGame();
            gameSession.StartGameSession();
        }
    }
}
