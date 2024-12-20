using Connect4.Models.BoardModel.ColumnModel;
using System.Collections.Generic;

namespace Connect4.Models.BoardModel
{
    public class Board : IBoard
    {
        private const int COLUMN_MAX_LENGTH = 6;

        private readonly ICollection<IColumn> _grid;

        protected Board()
        {
            this._grid = new List<IColumn>();

            for (int i = 1; i <= COLUMN_MAX_LENGTH; i++)
            {
                this._grid.Add(Column.Create(i));
            }
        }

        public static Board Create()
        {
            return new Board();
        }
    }
}
