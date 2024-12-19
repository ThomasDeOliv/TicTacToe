using System.Threading;
using System.Threading.Tasks;

namespace TicTacToe.SingleResponsabilityRefactoring.Models.GameModel
{
    public interface IGame
    {
        void Init();
        void Play();
        Task PlayAync(CancellationToken cancellationToken = default);
    }
}
