using System.Threading.Tasks;
using TicTacToe.Models.PlayerModel;

namespace TicTacToe.Services.InOut
{
    public interface IInOutService
    {
        string? GetHumanUserInput();
        Task AIWaitingCallbackAsync(IPlayer player);
        void DisplayGameBoard();
        bool ShouldContinueAndHandleError(string? input);
        void GetStartSentence(IPlayer currentPlayer);
        void AlreadyPlayed();
        void InvalidMove();
        void PlayerWonGame(IPlayer currentPlayer);
        void Draw();
        void Clear();
    }
}
