using Connect4.Models.BoardModel.ColumnModel.CellModel;
using System.Collections.Generic;

namespace Connect4.Models.BoardModel.ColumnModel
{
    public class Column : IColumn
    {
        private const int ROW_MAX_LENGTH = 7;
        private readonly Stack<ICell> _cells;

        public int ColIndex { get; }
        public int CurrentSize { get => this._cells.Count; }

        protected Column(int colIndex)
        {
            this.ColIndex = colIndex;
            this._cells = new Stack<ICell>();
        }

        public static Column Create(int colIndex)
        {
            return new Column(colIndex);
        }

        public void Push(ICell cell)
        {
            if (this.CurrentSize <= ROW_MAX_LENGTH && cell.ColumnIndex == this.ColIndex)
            {
                this._cells.Push(cell);
            }
        }

        public ICell? FinCell(int rowIndex)
        {
            ICell[] cells = this._cells.ToArray();

            if (rowIndex < 0 || cells.Length <= rowIndex)
            {
                return null;
            }

            return cells[rowIndex];
        }
    }
}
