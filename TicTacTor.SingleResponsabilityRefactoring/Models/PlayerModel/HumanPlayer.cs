using System;
using TicTacTor.SingleResponsabilityRefactoring.DTO;
using TicTacTor.SingleResponsabilityRefactoring.Models.PlayerModel.PlayerMoveModel;

namespace TicTacTor.SingleResponsabilityRefactoring.Models.PlayerModel
{
    internal partial class HumanPlayer : Player
    {
        public HumanPlayer() : base()
        {
            
        }

        public override ResultDTO<IPlayerMove> GetNextMove(string? input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return ResultDTO<IPlayerMove>.FailedResult("Empty");
            }

            if (HumanPlayer.IsQuitInstruction(input))
            {
                return ResultDTO<IPlayerMove>.FailedResult("Quit");
            }

            if (!HumanPlayer.TryGetCoordinates(input, out (int, int)? coordinates) || !coordinates.HasValue)
            {
                return ResultDTO<IPlayerMove>.FailedResult("InvalidInput");
            }

            if (!HumanPlayer.EnsureValidCoordinates(coordinates.Value.Item1))
            {
                return ResultDTO<IPlayerMove>.FailedResult("OutOfRangeRow");
            }

            if (!HumanPlayer.EnsureValidCoordinates(coordinates.Value.Item2))
            {
                return ResultDTO<IPlayerMove>.FailedResult("OutOfRangeColumn");
            }

            return ResultDTO<IPlayerMove>.SuccessdResult(new PlayerMove(coordinates.Value.Item1, coordinates.Value.Item2));
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
    }
}
