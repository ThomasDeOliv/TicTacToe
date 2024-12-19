using System;
using TicTacToe.SingleResponsabilityRefactoring.DTO;
using TicTacToe.SingleResponsabilityRefactoring.Models.PlayerModel.PlayerMoveModel;

namespace TicTacToe.SingleResponsabilityRefactoring.Models.PlayerModel
{
    public class AIPlayer : Player
    {
        private readonly Random _rnd;

        protected AIPlayer() : base()
        {
            this._rnd = new Random();
        }

        public override ResultDTO<IPlayerMove> GetNextMove(string? input = null)
        {
            int row = this._rnd.Next(1, 4);
            int column = this._rnd.Next(1, 4);
            return ResultDTO<IPlayerMove>.CreateSuccessdResult(PlayerMove.Create(row, column));
        }

        public static AIPlayer Create()
        {
            return new AIPlayer();
        }
    }
}
