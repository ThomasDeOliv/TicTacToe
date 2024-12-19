using System;
using System.Collections.Generic;
using System.Linq;
using TicTacToe.SingleResponsabilityRefactoring.Models.BoardModel.CellModel;
using TicTacToe.SingleResponsabilityRefactoring.Models.PlayerModel;

namespace TicTacToe.SingleResponsabilityRefactoring.Models.BoardModel
{
    public class Board : IBoard
    {
        private const int ROW_MAX_LENGTH = 3;
        private const int COLUMN_MAX_LENGTH = 3;

        private readonly ICollection<ICell> _grid;
        private readonly IPlayer _humanPlayer;
        private readonly IPlayer _aIPlayer;

        private IPlayer _currentPlayer;

        protected Board(IPlayer humanPlayer, IPlayer aIPlayer)
        {
            this._grid = new List<ICell>();
            
            for (int i = 1; i <= ROW_MAX_LENGTH; i++)
            {
                for (int j = 1; j<= COLUMN_MAX_LENGTH; j++)
                {
                    this._grid.Add(Cell.Create(i, j, null));
                }
            };

            this._humanPlayer = humanPlayer;
            this._aIPlayer = aIPlayer;

            this._currentPlayer = _humanPlayer;
        }

        private ICell? GetCell(int row, int column)
            => this._grid.Where(cell => cell.Row == row)
                .Where(cell => cell.Column == column)
                .FirstOrDefault();

        private char GetCellContent(int row, int column)
        {
            ICell? currentCell = GetCell(row, column);

            if (currentCell is not null
                && currentCell.Value.HasValue)
            {
                return (char)currentCell.Value;
            }

            return ' ';
        }

        private void DisplayGameBoardLine(char leftCell, char middleCell, char rightCell)
            => Console.WriteLine($"|  {leftCell}  |  {middleCell}  |  {rightCell}  |");

        public IPlayer CurrentPlayer
        {
            get => this._currentPlayer;
        }

        public void ChangePlayer()
            => this._currentPlayer = this._currentPlayer == this._aIPlayer ?
                this._humanPlayer : this._aIPlayer;

        public bool PlayOnGameBoard(int targetRow, int targetColumn)
        {
            ICell? cell = GetCell(targetRow, targetColumn);

            if (cell == null || cell.Value == (char)GameSymbol.X || cell.Value == (char)GameSymbol.O)
            {
                return false;
            }

            cell.UpdateValue(this._currentPlayer.Symbol);

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
        public bool IsGameBoardFull()
            => _grid.All(cell => cell.Value.HasValue);

        public void DisplayGameBoard()
        {
            Console.WriteLine(new string('=', Console.WindowWidth));
            Console.WriteLine(".NET MAUI".PadLeft(Console.WindowWidth / 2));
            Console.WriteLine(new string('=', Console.WindowWidth));

            Console.WriteLine($"|-----------------|");
            DisplayGameBoardLine(GetCellContent(1, 1), GetCellContent(1, 2), GetCellContent(1, 3));
            Console.WriteLine($"|-----|-----|-----|");
            DisplayGameBoardLine(GetCellContent(2, 1), GetCellContent(2, 2), GetCellContent(2, 3));
            Console.WriteLine($"|-----|-----|-----|");
            DisplayGameBoardLine(GetCellContent(3, 1), GetCellContent(3, 2), GetCellContent(3, 3));
            Console.WriteLine($"|-----------------|");
        }

        public void SetPlayerSymbol(GameSymbol gameSymbol)
        {
            this._humanPlayer.Symbol = (char)gameSymbol;
        }

        public void SetAIPlayerSymbol(GameSymbol gameSymbol)
        {
            this._aIPlayer.Symbol = (char)gameSymbol;
        }

        public static Board Create(IPlayer humanPlayer, IPlayer aIPlayer)
        {
            return new Board(humanPlayer, aIPlayer);
        }
    }
}
