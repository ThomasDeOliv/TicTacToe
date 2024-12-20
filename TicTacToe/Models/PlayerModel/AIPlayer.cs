using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using TicTacToe.DTO;
using TicTacToe.Models.BoardModel;
using TicTacToe.Models.BoardModel.CellModel;
using TicTacToe.Models.PlayerModel.PlayerMoveModel;
using TicTacToe.Services.InOut;

namespace TicTacToe.Models.PlayerModel
{
    public class AIPlayer : Player
    {
        private readonly IInOutService _inOutService;
        private readonly Random _rnd;

        public override bool IsAI { get; }

        protected AIPlayer(IBoard board, IInOutService inOutService, GameSymbol gameSymbol) : base(board, gameSymbol)
        {
            this._inOutService = inOutService;
            this._rnd = new Random();
            this.IsAI = true;
        }

        public override ResultDTO<IPlayerMove> GetNextMove()
        {
            IReadOnlyList<ICell> emptyCells = this._board.GetEmptyCells();
            ICell randomCell = emptyCells[this._rnd.Next(0, emptyCells.Count)];
            return ResultDTO<IPlayerMove>.CreateSuccessdResult(PlayerMove.Create(randomCell.Row, randomCell.Column));
        }

        public override async Task<ResultDTO<IPlayerMove>> GetNextMoveAsync(CancellationToken cancellationToken = default)
        {
            await this._inOutService.AIWaitingCallbackAsync(this);
            return await Task.FromResult(this.GetNextMove());
        }

        public static AIPlayer Create(IBoard board, IInOutService inOutService, GameSymbol gameSymbol)
        {
            return new AIPlayer(board, inOutService, gameSymbol);
        }
    }
}
