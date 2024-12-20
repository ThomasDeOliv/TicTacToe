using System.Collections.Generic;
using TicTacToe.Models.BoardModel.CellModel;

namespace TicTacToe.Models.BoardModel
{
    public interface IBoard
    {
        bool WriteInCell(int targetRow, int targetColumn, char symbol);
        bool IsGameBoardWin();
        bool IsGameBoardFull();
        char GetCellContent(int row, int column);
        IReadOnlyList<ICell> GetEmptyCells();
    }
}
