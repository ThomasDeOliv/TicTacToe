using System.Threading.Tasks;
using TicTacToe.SingleResponsabilityRefactoring.Models.PlayerModel;

namespace TicTacToe.SingleResponsabilityRefactoring.Services.InOut
{
    public interface IInOutService
    {
        string? GetHumanUserInput();
        Task AIWaitingCallbackAsync(IPlayer player);
    }
}
