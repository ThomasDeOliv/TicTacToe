using System.Threading;
using System.Threading.Tasks;
using TicTacToe.SingleResponsabilityRefactoring.DTO;
using TicTacToe.SingleResponsabilityRefactoring.Models.PlayerModel.PlayerMoveModel;

namespace TicTacToe.SingleResponsabilityRefactoring.Models.PlayerModel
{
    public interface IPlayer
    {
        bool IsAI { get; }
        char Symbol { get; set; }
        ResultDTO<IPlayerMove> GetNextMove();
        Task<ResultDTO<IPlayerMove>> GetNextMoveAsync(CancellationToken cancellationToken = default);
    }
}
