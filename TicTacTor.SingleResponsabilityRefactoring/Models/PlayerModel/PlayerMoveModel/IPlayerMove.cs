namespace TicTacTor.SingleResponsabilityRefactoring.Models.PlayerModel.PlayerMoveModel
{
    internal interface IPlayerMove
    {
        int Row { get; }
        int Column { get; }
    }
}
