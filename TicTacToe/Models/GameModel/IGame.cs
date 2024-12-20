using System.Threading;
using System.Threading.Tasks;
using TicTacToe.Models.PlayerModel;

namespace TicTacToe.Models.GameModel
{
    public interface IGame
    {
        IPlayer CurrentPlayer { get; }
        void ChangePlayer();
        void Play();
        Task PlayAync(CancellationToken cancellationToken = default);
    }
}
