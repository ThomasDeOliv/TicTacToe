namespace Connect4.Models.BoardModel.ColumnModel.CellModel
{
    public class Cell : ICell
    {
        public CellState Value { get; private set; }
        public int RowIndex { get; private set; }
        public int ColumnIndex { get; private set; }

        protected Cell(CellState value, int row, int column)
        {
            Value = value;
            RowIndex = row;
            ColumnIndex = column;
        }

        public static Cell Create(CellState value, int row, int column)
        {
            return new Cell(value, row, column);
        }
    }

}