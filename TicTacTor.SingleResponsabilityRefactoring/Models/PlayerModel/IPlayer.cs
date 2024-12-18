using TicTacTor.SingleResponsabilityRefactoring.DTO;
using TicTacTor.SingleResponsabilityRefactoring.Models.PlayerModel.PlayerMoveModel;

namespace TicTacTor.SingleResponsabilityRefactoring.Models.PlayerModel
{
    internal interface IPlayer
    {
        char Symbol { get; set; }
        ResultDTO<IPlayerMove> GetNextMove(string? input);
    }
}
