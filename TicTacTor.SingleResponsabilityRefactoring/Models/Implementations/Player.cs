using TicTacTor.SingleResponsabilityRefactoring.DTOs;
using TicTacTor.SingleResponsabilityRefactoring.Models.Helpers;

namespace TicTacTor.SingleResponsabilityRefactoring.Models.Implementations
{
    internal partial class Player : IPlayer
    {
        private readonly char _symbol;

        private Player(GameSymbol gameSymbol)
        {
            _symbol = (char)gameSymbol;
        }

        internal static Player CreatePlayer(GameSymbol gameSymbol)
        {
            return new Player(gameSymbol);
        }

        public char GetCurrentPlayer()
        {
            return _symbol;
        }

        public ResultDTO<IPlayerMovesRecord> GetNextMove(string? input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return ResultDTO<IPlayerMovesRecord>.FailedResult("Empty");
            }

            if (PlayerUtilities.IsQuitInstruction(input))
            {
                return ResultDTO<IPlayerMovesRecord>.FailedResult("Quit");
            }

            if (!input.TryGetCoordinates(out (int, int)? coordinates) || !coordinates.HasValue)
            {
                return ResultDTO<IPlayerMovesRecord>.FailedResult("InvalidInput");
            }

            if (!PlayerUtilities.EnsureValidCoordinates(coordinates.Value.Item1))
            {
                return ResultDTO<IPlayerMovesRecord>.FailedResult("OutOfRangeRow");
            }

            if (!PlayerUtilities.EnsureValidCoordinates(coordinates.Value.Item2))
            {
                return ResultDTO<IPlayerMovesRecord>.FailedResult("OutOfRangeColumn");
            }

            return ResultDTO<IPlayerMovesRecord>.SuccessdResult(new PlayerMovesRecord(coordinates.Value.Item1, coordinates.Value.Item2));
        }
    }
}
