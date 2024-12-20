using Connect4.Models.BoardModel.ColumnModel.CellModel;

namespace Connect4.Models.BoardModel.ColumnModel
{
    public interface IColumn
    {
        int ColIndex { get; }
        int CurrentSize { get; }
        void Push(ICell cell);
        ICell? FinCell(int index);
    }
}
