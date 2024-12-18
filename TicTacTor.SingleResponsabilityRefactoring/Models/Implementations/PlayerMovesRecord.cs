namespace TicTacTor.SingleResponsabilityRefactoring.Models.Implementations
{
    internal record PlayerMovesRecord : IPlayerMovesRecord
    {
        public int Row { get; }
        public int Column { get; }

        public PlayerMovesRecord(int row, int column)
        {
            Row = row;
            Column = column;
        }
    }
}
