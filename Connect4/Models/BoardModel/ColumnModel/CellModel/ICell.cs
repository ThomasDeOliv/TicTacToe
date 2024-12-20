namespace Connect4.Models.BoardModel.ColumnModel.CellModel
{
    public enum CellState
    {
        YELLOW,
        RED,
    }

    public interface ICell
    {
        int RowIndex { get; }
        int ColumnIndex { get; }
        CellState Value { get; }
    }
}
