using System;
using System.Threading;
using System.Threading.Tasks;
using TicTacToe.SingleResponsabilityRefactoring.DTO;
using TicTacToe.SingleResponsabilityRefactoring.Models.PlayerModel.PlayerMoveModel;

namespace TicTacToe.SingleResponsabilityRefactoring.Models.PlayerModel
{
    public abstract class Player : IPlayer
    {
        public abstract bool IsAI { get; }
        public char Symbol { get; set; }

        protected Player()
        {

        }

        public abstract ResultDTO<IPlayerMove> GetNextMove(string? input);
        public abstract Task<ResultDTO<IPlayerMove>> GetNextMoveAsync(Func<ValueTask> waitingAsyncCallback, string? input, CancellationToken cancellationToken = default);
    }
}
