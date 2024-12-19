namespace TicTacToe.SingleResponsabilityRefactoring.Models.PlayerModel.PlayerMoveModel
{
    public interface IPlayerMove
    {
        int Row { get; }
        int Column { get; }
    }
}
