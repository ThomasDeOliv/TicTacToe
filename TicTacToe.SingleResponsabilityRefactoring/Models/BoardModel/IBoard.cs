using TicTacToe.SingleResponsabilityRefactoring.Models.PlayerModel;

namespace TicTacToe.SingleResponsabilityRefactoring.Models.BoardModel
{
    public interface IBoard
    {
        IPlayer CurrentPlayer { get; }
        void ChangePlayer();
        bool PlayOnGameBoard(int targetRow, int targetColumn);
        bool IsGameBoardWin();
        bool IsGameBoardFull();
        void DisplayGameBoard();
        void SetPlayerSymbol(GameSymbol gameSymbol);
        void SetAIPlayerSymbol(GameSymbol gameSymbol);
    }
}
