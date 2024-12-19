using TicTacToe.SingleResponsabilityRefactoring.DTO;
using TicTacToe.SingleResponsabilityRefactoring.Models.PlayerModel.PlayerMoveModel;

namespace TicTacToe.SingleResponsabilityRefactoring.Models.PlayerModel
{
    public abstract class Player : IPlayer
    {
        public char Symbol { get; set; }

        protected Player()
        {

        }

        public abstract ResultDTO<IPlayerMove> GetNextMove(string? input);
    }
}
