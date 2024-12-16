using System;
using System.Collections.Generic;
using System.Linq;

namespace TicTacTor.SingleResponsabilityRefactoring.Board
{
    internal enum GameSymbols
    {
        X = 'X',
        O = 'O'
    }

    internal class BoardGame
    {
        private GameSymbols _currentPlayer;
        private readonly List<Cell> _grid;

        private BoardGame()
        {
            this._currentPlayer = GameSymbols.O;
            this._grid = new List<Cell>()
            {
                Cell.EmptyCell(1, 1),
                Cell.EmptyCell(1, 2),
                Cell.EmptyCell(1, 3),
                Cell.EmptyCell(2, 1),
                Cell.EmptyCell(2, 2),
                Cell.EmptyCell(2, 3),
                Cell.EmptyCell(3, 1),
                Cell.EmptyCell(3, 2),
                Cell.EmptyCell(3, 3),
            };
        }

        internal static BoardGame CreateBoardGame()
            => new BoardGame();

        internal GameSymbols CurrentPlayer 
            => this._currentPlayer;

        internal void ChangePlayer()
            => this._currentPlayer = this._currentPlayer == GameSymbols.X ?
                GameSymbols.O : GameSymbols.X;

        private Cell? GetCell(int row, int column)
            => this._grid.Where(cell => cell.Row == row)
                .Where(cell => cell.Column == column)
                .FirstOrDefault();

        private char GetCellContent(int row, int column)
        {
            Cell? currentCell = GetCell(row, column);

            if (currentCell is not null 
                && currentCell.Value.HasValue)
            {
                return (char)currentCell.Value;
            }

            return ' ';
        }

        private void DisplayGameBoardLine(char leftCell, char middleCell, char rightCell)
            => Console.WriteLine($"|  {leftCell}  |  {middleCell}  |  {rightCell}  |");

        internal bool PlayOnGameBoard(int targetRow, int targetColumn)
        {
            Cell? cell = this.GetCell(targetRow, targetColumn);

            if (cell == null || cell.Value == (char)GameSymbols.X || cell.Value == (char)GameSymbols.O)
            {
                return false;
            }

            cell.UpdateValue((char)this.CurrentPlayer);
            
            return true;
        }

        internal bool IsGameBoardWin()
        {
            IEnumerable<IGrouping<int, Cell>> rows = this._grid
                .GroupBy(cell => cell.Row);

            if (rows.Any(row =>
                row.All(cell => cell.Value == (char)GameSymbols.X) ||
                row.All(cell => cell.Value == (char)GameSymbols.O)))
            {
                return true;
            }

            IEnumerable<IGrouping<int, Cell>> columns = this._grid
                .GroupBy(cell => cell.Column);

            if (columns.Any(column =>
                column.All(cell => cell.Value == (char)GameSymbols.X) ||
                column.All(cell => cell.Value == (char)GameSymbols.O)))
            {
                return true;
            }

            IEnumerable<Cell> firstDiagonal = this._grid.Where(c => c.Row == c.Column);

            IEnumerable<Cell> secondDiagonal = this._grid.Where(c => (c.Row + c.Column) == 4);

            List<IEnumerable<Cell>> diagonals = new List<IEnumerable<Cell>>()
            {
                firstDiagonal,
                secondDiagonal
            };

            if (diagonals.Any(diagonal =>
                diagonal.All(cell => cell.Value == (char)GameSymbols.X) ||
                diagonal.All(cell => cell.Value == (char)GameSymbols.O)))
            {
                return true;
            }

            return false;
        }
        internal bool IsGameBoardFull()
            => this._grid.All(cell => !cell.Value.HasValue);

        internal void DisplayGameBoard()
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
    }
}
