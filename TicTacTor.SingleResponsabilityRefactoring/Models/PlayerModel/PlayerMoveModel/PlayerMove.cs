namespace TicTacTor.SingleResponsabilityRefactoring.Models.PlayerModel.PlayerMoveModel
{
    internal record PlayerMove : IPlayerMove
    {
        public int Row { get; }
        public int Column { get; }

        public PlayerMove(int row, int column)
        {
            this.Row = row;
            this.Column = column;
        }
    }
}
