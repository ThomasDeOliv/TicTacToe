namespace TicTacToe.SingleResponsabilityRefactoring.Models.PlayerModel.PlayerMoveModel
{
    public class PlayerMove : IPlayerMove
    {
        public int Row { get; }
        public int Column { get; }

        protected PlayerMove(int row, int column)
        {
            this.Row = row;
            this.Column = column;
        }

        public static PlayerMove Create(int row, int column)
        {
            return new PlayerMove(row, column);
        }
    }
}
