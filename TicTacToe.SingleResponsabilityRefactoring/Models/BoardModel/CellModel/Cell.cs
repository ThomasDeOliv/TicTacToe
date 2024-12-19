namespace TicTacToe.SingleResponsabilityRefactoring.Models.BoardModel.CellModel
{
    public class Cell : ICell
    {
        public int Row { get; private set; }
        public int Column { get; private set; }
        public char? Value { get; private set; }

        protected Cell(int row, int column, char? value)
        {
            Row = row;
            Column = column;
            Value = value;
        }

        protected Cell(int row, int column)
        {
            Row = row;
            Column = column;
            Value = null;
        }

        public void UpdateValue(char value)
        {
            Value = value;
        }

        public static Cell Create(int row, int column, char? value)
            => new Cell(row, column, value);
    }

}