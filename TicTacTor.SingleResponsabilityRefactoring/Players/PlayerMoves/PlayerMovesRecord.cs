namespace TicTacTor.SingleResponsabilityRefactoring.Players.Result
{
    internal record PlayerMovesRecord
    {
        public int Row { get; }
        public int Column { get; }

        public PlayerMovesRecord(int row, int column)
        {
            this.Row = row;
            this.Column = column;
        }
    }
}
