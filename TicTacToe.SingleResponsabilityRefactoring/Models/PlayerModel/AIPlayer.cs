using System;
using System.Threading;
using System.Threading.Tasks;
using TicTacToe.SingleResponsabilityRefactoring.DTO;
using TicTacToe.SingleResponsabilityRefactoring.Models.PlayerModel.PlayerMoveModel;

namespace TicTacToe.SingleResponsabilityRefactoring.Models.PlayerModel
{
    public class AIPlayer : Player
    {
        private readonly Random _rnd;

        public override bool IsAI { get; }

        protected AIPlayer() : base()
        {
            this._rnd = new Random();
            this.IsAI = true;
        }

        public override ResultDTO<IPlayerMove> GetNextMove(string? input = null)
        {
            int row = this._rnd.Next(1, 4);
            int column = this._rnd.Next(1, 4);
            return ResultDTO<IPlayerMove>.CreateSuccessdResult(PlayerMove.Create(row, column));
        }

        public override async Task<ResultDTO<IPlayerMove>> GetNextMoveAsync(Func<ValueTask> waitingAsyncCallback, string? input, CancellationToken cancellationToken = default)
        {
            await waitingAsyncCallback.Invoke();
            return this.GetNextMove(input);
        }

        public static AIPlayer Create()
        {
            return new AIPlayer();
        }
    }
}
