using TicTacToe.SingleResponsabilityRefactoring.DTO;
using TicTacToe.SingleResponsabilityRefactoring.Models.PlayerModel.PlayerMoveModel;

namespace TicTacToe.SingleResponsabilityRefactoring.Models.PlayerModel
{
    public interface IPlayer
    {
        char Symbol { get; set; }
        ResultDTO<IPlayerMove> GetNextMove(string? input);
    }
}
