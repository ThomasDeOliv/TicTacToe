using TicTacTor.SingleResponsabilityRefactoring.Models.PlayerModel;

namespace TicTacTor.SingleResponsabilityRefactoring.Models.BoardModel
{
    internal interface IBoard
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
