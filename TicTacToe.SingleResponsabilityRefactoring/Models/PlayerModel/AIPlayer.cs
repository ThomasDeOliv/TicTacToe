using System;
using System.Threading;
using System.Threading.Tasks;
using TicTacToe.SingleResponsabilityRefactoring.DTO;
using TicTacToe.SingleResponsabilityRefactoring.Models.PlayerModel.PlayerMoveModel;
using TicTacToe.SingleResponsabilityRefactoring.Services.InOut;

namespace TicTacToe.SingleResponsabilityRefactoring.Models.PlayerModel
{
    public class AIPlayer : Player
    {
        private readonly IInOutService _inOutService;
        private readonly Random _rnd;

        public override bool IsAI { get; }

        protected AIPlayer(IInOutService inOutService) : base()
        {
            this._inOutService = inOutService;
            this._rnd = new Random();
            this.IsAI = true;
        }

        public override ResultDTO<IPlayerMove> GetNextMove()
        {
            int row = this._rnd.Next(1, 4);
            int column = this._rnd.Next(1, 4);
            return ResultDTO<IPlayerMove>.CreateSuccessdResult(PlayerMove.Create(row, column));
        }

        public override async Task<ResultDTO<IPlayerMove>> GetNextMoveAsync(CancellationToken cancellationToken = default)
        {
            await this._inOutService.AIWaitingCallbackAsync(this);
            return this.GetNextMove();
        }

        public static AIPlayer Create(IInOutService inOutService)
        {
            return new AIPlayer(inOutService);
        }
    }
}
