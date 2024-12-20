using System.Threading;
using System.Threading.Tasks;
using TicTacToe.DTO;
using TicTacToe.Models.PlayerModel.PlayerMoveModel;

namespace TicTacToe.Models.PlayerModel
{
    public interface IPlayer
    {
        bool IsAI { get; }
        char Symbol { get; }
        ResultDTO<IPlayerMove> GetNextMove();
        Task<ResultDTO<IPlayerMove>> GetNextMoveAsync(CancellationToken cancellationToken = default);
    }
}
