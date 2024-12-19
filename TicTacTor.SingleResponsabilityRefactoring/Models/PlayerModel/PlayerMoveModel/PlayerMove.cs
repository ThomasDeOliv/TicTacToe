namespace TicTacTor.SingleResponsabilityRefactoring.Models.PlayerModel.PlayerMoveModel
{
    internal record PlayerMove : IPlayerMove
    {
        public int Row { get; }
        public int Column { get; }

        protected PlayerMove(int row, int column)
        {
            this.Row = row;
            this.Column = column;
        }

        public static PlayerMove CreatePlayerMove(int row, int column)
        {
            return new PlayerMove(row, column);
        }
    }
}
