using TicTacTor.SingleResponsabilityRefactoring.Sessions;

namespace TicTacTor.SingleResponsabilityRefactoring
{
    internal static class Program
    {
        internal static void Main(string[] args)
        {
            Session gameSession = Session.CreateGame();
            gameSession.StartGameSession();
        }
    }
}
