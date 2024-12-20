using System;
using System.Threading;
using System.Threading.Tasks;
using TicTacToe.DTO;
using TicTacToe.Models.BoardModel;
using TicTacToe.Models.PlayerModel.PlayerMoveModel;
using TicTacToe.Services.InOut;

namespace TicTacToe.Models.PlayerModel
{
    public partial class HumanPlayer : Player
    {
        private readonly IInOutService _inOutService;
        public override bool IsAI { get; }

        protected HumanPlayer(IBoard board, IInOutService inOutService, GameSymbol gameSymbol) : base(board, gameSymbol)
        {
            this._inOutService = inOutService;
            this.IsAI = false;
        }

        public override ResultDTO<IPlayerMove> GetNextMove()
        {
            string? input = _inOutService.GetHumanUserInput();

            if (string.IsNullOrEmpty(input))
            {
                return ResultDTO<IPlayerMove>.CreateFailedResult("Empty");
            }

            if (HumanPlayer.IsQuitInstruction(input))
            {
                return ResultDTO<IPlayerMove>.CreateFailedResult("Quit");
            }

            if (!HumanPlayer.TryGetCoordinates(input, out (int, int)? coordinates) || !coordinates.HasValue)
            {
                return ResultDTO<IPlayerMove>.CreateFailedResult("InvalidInput");
            }

            bool isValidRow = HumanPlayer.EnsureValidCoordinates(coordinates.Value.Item1);
            bool isValidColumn = HumanPlayer.EnsureValidCoordinates(coordinates.Value.Item2);

            if (!isValidRow && !isValidColumn)
            {
                return ResultDTO<IPlayerMove>.CreateFailedResult("OutOfRangeRowAndColumn");
            }

            if (!isValidRow)
            {
                return ResultDTO<IPlayerMove>.CreateFailedResult("OutOfRangeRow");
            }

            if (!isValidColumn)
            {
                return ResultDTO<IPlayerMove>.CreateFailedResult("OutOfRangeColumn");
            }

            return ResultDTO<IPlayerMove>.CreateSuccessdResult(PlayerMove.Create(coordinates.Value.Item1, coordinates.Value.Item2));
        }

        public override async Task<ResultDTO<IPlayerMove>> GetNextMoveAsync(CancellationToken cancellationToken = default)
        {
            return await Task.FromResult(this.GetNextMove());
        }

        private static bool IsQuitInstruction(string? input)
        {
            return string.Compare(input, "q", StringComparison.OrdinalIgnoreCase) == 0;
        }

        private static bool TryGetCoordinates(string? input, out (int, int)? coordinates)
        {
            coordinates = null;
            string[]? splittedInput = input?.Split(' ');

            if (!int.TryParse(splittedInput?[0], out int targetRow) || !int.TryParse(splittedInput?[1], out int targetColumn))
            {
                return false;
            }

            coordinates = (targetRow, targetColumn);
            return true;
        }

        private static bool EnsureValidCoordinates(int rowOrColumnCoordinates)
        {
            return rowOrColumnCoordinates >= 1 && rowOrColumnCoordinates <= 3;
        }

        public static HumanPlayer Create(IBoard board, IInOutService inOutService, GameSymbol gameSymbol)
        {
            return new HumanPlayer(board, inOutService, gameSymbol);
        }
    }
}
