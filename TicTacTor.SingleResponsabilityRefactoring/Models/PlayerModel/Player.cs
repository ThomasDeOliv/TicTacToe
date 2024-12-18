using TicTacTor.SingleResponsabilityRefactoring.DTO;
using TicTacTor.SingleResponsabilityRefactoring.Helpers;
using TicTacTor.SingleResponsabilityRefactoring.Models.PlayerModel.PlayerMoveModel;

namespace TicTacTor.SingleResponsabilityRefactoring.Models.PlayerModel
{
    internal partial class Player : IPlayer
    {
        protected Player()
        {

        }

        public char Symbol { get; set; }

        public virtual ResultDTO<IPlayerMove> GetNextMove(string? input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return ResultDTO<IPlayerMove>.FailedResult("Empty");
            }

            if (PlayerUtilities.IsQuitInstruction(input))
            {
                return ResultDTO<IPlayerMove>.FailedResult("Quit");
            }

            if (!input.TryGetCoordinates(out (int, int)? coordinates) || !coordinates.HasValue)
            {
                return ResultDTO<IPlayerMove>.FailedResult("InvalidInput");
            }

            if (!PlayerUtilities.EnsureValidCoordinates(coordinates.Value.Item1))
            {
                return ResultDTO<IPlayerMove>.FailedResult("OutOfRangeRow");
            }

            if (!PlayerUtilities.EnsureValidCoordinates(coordinates.Value.Item2))
            {
                return ResultDTO<IPlayerMove>.FailedResult("OutOfRangeColumn");
            }

            return ResultDTO<IPlayerMove>.SuccessdResult(new PlayerMove(coordinates.Value.Item1, coordinates.Value.Item2));
        }

        public static Player CreatePlayer()
        {
            return new Player();
        }
    }
}
