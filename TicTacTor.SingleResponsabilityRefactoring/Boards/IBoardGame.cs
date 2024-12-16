using TicTacTor.SingleResponsabilityRefactoring.Players;

namespace TicTacTor.SingleResponsabilityRefactoring.Boards
{
    internal interface IBoardGame
    {
        IPlayer CurrentPlayer { get; }
        void ChangePlayer();
        bool PlayOnGameBoard(int targetRow, int targetColumn);
        bool IsGameBoardWin();
        bool IsGameBoardFull();
        void DisplayGameBoard();
    }
}
