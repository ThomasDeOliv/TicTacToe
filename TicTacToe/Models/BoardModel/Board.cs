using System.Collections.Generic;
using System.Linq;
using TicTacToe.Models.BoardModel.CellModel;

namespace TicTacToe.Models.BoardModel
{
    public class Board : IBoard
    {
        private const int ROW_MAX_LENGTH = 3;
        private const int COLUMN_MAX_LENGTH = 3;

        private readonly ICollection<ICell> _grid;

        protected Board()
        {
            this._grid = new List<ICell>();

            for (int i = 1; i <= ROW_MAX_LENGTH; i++)
            {
                for (int j = 1; j <= COLUMN_MAX_LENGTH; j++)
                {
                    this._grid.Add(Cell.Create(i, j, null));
                }
            };
        }

        public static Board Create()
        {
            return new Board();
        }

        private ICell? GetCell(int row, int column)
        {
            return this._grid.Where(cell => cell.Row == row)
                .Where(cell => cell.Column == column)
                .FirstOrDefault();
        }

        public IReadOnlyList<ICell> GetEmptyCells()
        {
            IReadOnlyList<ICell> emptyCellsList = new List<ICell>(this._grid.Where((c) => !c.Value.HasValue));
            return emptyCellsList;
        }

        public bool WriteInCell(int targetRow, int targetColumn, char symbol)
        {
            ICell? cell = GetCell(targetRow, targetColumn);

            if (cell == null || cell.Value == (char)GameSymbol.X || cell.Value == (char)GameSymbol.O)
            {
                return false;
            }

            cell.UpdateValue(symbol);

            return true;
        }

        public bool IsGameBoardWin()
        {
            IEnumerable<IGrouping<int, ICell>> rows = this._grid
                .GroupBy(cell => cell.Row);

            if (rows.Any(row =>
                row.All(cell => cell.Value == (char)GameSymbol.X) ||
                row.All(cell => cell.Value == (char)GameSymbol.O)))
            {
                return true;
            }

            IEnumerable<IGrouping<int, ICell>> columns = _grid
                .GroupBy(cell => cell.Column);

            if (columns.Any(column =>
                column.All(cell => cell.Value == (char)GameSymbol.X) ||
                column.All(cell => cell.Value == (char)GameSymbol.O)))
            {
                return true;
            }

            IEnumerable<ICell> firstDiagonal = this._grid.Where(c => c.Row == c.Column);

            IEnumerable<ICell> secondDiagonal = this._grid.Where(c => c.Row + c.Column == 4);

            List<IEnumerable<ICell>> diagonals = new List<IEnumerable<ICell>>()
            {
                firstDiagonal,
                secondDiagonal
            };

            if (diagonals.Any(diagonal =>
                diagonal.All(cell => cell.Value == (char)GameSymbol.X) ||
                diagonal.All(cell => cell.Value == (char)GameSymbol.O)))
            {
                return true;
            }

            return false;
        }

        public char GetCellContent(int row, int column)
        {
            ICell? currentCell = GetCell(row, column);

            if (currentCell is not null
                && currentCell.Value.HasValue)
            {
                return (char)currentCell.Value;
            }

            return ' ';
        }

        public bool IsGameBoardFull()
        {
            return this._grid.All(cell => cell.Value.HasValue);
        }
    }
}
