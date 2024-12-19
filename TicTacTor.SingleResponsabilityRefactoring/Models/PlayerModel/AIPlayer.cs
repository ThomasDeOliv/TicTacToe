﻿using System;
using TicTacTor.SingleResponsabilityRefactoring.DTO;
using TicTacTor.SingleResponsabilityRefactoring.Models.PlayerModel.PlayerMoveModel;

namespace TicTacTor.SingleResponsabilityRefactoring.Models.PlayerModel
{
    internal class AIPlayer : Player
    {
        private readonly Random _rnd;

        protected AIPlayer() : base()
        {
            this._rnd = new Random();
        }

        public override ResultDTO<IPlayerMove> GetNextMove(string? input = null)
        {
            int row = this._rnd.Next(0, 4);
            int column = this._rnd.Next(0, 4);
            return ResultDTO<IPlayerMove>.CreateSuccessdResult(PlayerMove.CreatePlayerMove(row, column));
        }

        public static AIPlayer CreateAIPlayer()
        {
            return new AIPlayer();
        }
    }
}
