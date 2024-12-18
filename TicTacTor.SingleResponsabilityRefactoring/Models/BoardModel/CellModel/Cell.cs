namespace TicTacTor.SingleResponsabilityRefactoring.Models.BoardModel.CellModel
{
    internal class Cell : ICell
    {
        public int Row { get; private set; }
        public int Column { get; private set; }
        public char? Value { get; private set; }

        public Cell(int row, int column, char value)
        {
            Row = row;
            Column = column;
            Value = value;
        }

        public Cell(int row, int column)
        {
            Row = row;
            Column = column;
            Value = null;
        }

        public void UpdateValue(char value)
        {
            Value = value;
        }

        public static Cell EmptyCell(int row, int column)
            => new Cell(row, column);
    }

}