using TicTacTor.SingleResponsabilityRefactoring.DTO;
using TicTacTor.SingleResponsabilityRefactoring.Models.PlayerModel.PlayerMoveModel;

namespace TicTacTor.SingleResponsabilityRefactoring.Models.PlayerModel
{
    internal abstract class Player : IPlayer
    {
        public char Symbol { get; set; }
        public abstract ResultDTO<IPlayerMove> GetNextMove(string? input);
    }
}
