namespace TicTacTor.SingleResponsabilityRefactoring.Models
{
    internal interface IBoard
    {
        IPlayer CurrentPlayer { get; }
        void ChangePlayer();
        bool PlayOnGameBoard(int targetRow, int targetColumn);
        bool IsGameBoardWin();
        bool IsGameBoardFull();
        void DisplayGameBoard();
    }
}
