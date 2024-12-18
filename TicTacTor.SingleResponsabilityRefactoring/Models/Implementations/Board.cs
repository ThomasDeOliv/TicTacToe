using System;
using System.Collections.Generic;
using System.Linq;

namespace TicTacTor.SingleResponsabilityRefactoring.Models.Implementations
{
    internal class Board : IBoard
    {
        private readonly List<ICell> _grid;
        private readonly IPlayer[] _players;
        private IPlayer _currentPlayer;

        private Board()
        {
            _grid = new List<ICell>()
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

            _players = new IPlayer[2]
            {
                Player.CreatePlayer(GameSymbol.O),
                Player.CreatePlayer(GameSymbol.X),
            };

            _currentPlayer = _players[0];
        }

        private ICell? GetCell(int row, int column)
            => _grid.Where(cell => cell.Row == row)
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

        public static Board CreateBoardGame()
            => new Board();

        public IPlayer CurrentPlayer
        {
            get => _currentPlayer;
        }

        public void ChangePlayer()
            => _currentPlayer = _currentPlayer == _players[0] ?
                _players[1] : _players[0];

        public bool PlayOnGameBoard(int targetRow, int targetColumn)
        {
            ICell? cell = GetCell(targetRow, targetColumn);

            if (cell == null || cell.Value == (char)GameSymbol.X || cell.Value == (char)GameSymbol.O)
            {
                return false;
            }

            cell.UpdateValue(_currentPlayer.GetCurrentPlayer());

            return true;
        }

        public bool IsGameBoardWin()
        {
            IEnumerable<IGrouping<int, ICell>> rows = _grid
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

            IEnumerable<ICell> firstDiagonal = _grid.Where(c => c.Row == c.Column);

            IEnumerable<ICell> secondDiagonal = _grid.Where(c => c.Row + c.Column == 4);

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
    }
}
