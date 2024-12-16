using TicTacTor.SingleResponsabilityRefactoring.DTOs;
using TicTacTor.SingleResponsabilityRefactoring.Players.Result;

namespace TicTacTor.SingleResponsabilityRefactoring.Players
{
    internal class Player : IPlayer
    {
        private readonly char _symbol;

        private Player(GameSymbol gameSymbol)
        {
            this._symbol = (char)gameSymbol;
        }

        internal static Player CreatePlayer(GameSymbol gameSymbol)
        {
            return new Player(gameSymbol);
        }

        public char GetCurrentPlayer()
        {
            return this._symbol;
        }

        public ResultDTO GetNextMove(string? input)
        {
            string[]? splittedInput = input?.Split(' ');

            if (int.TryParse(splittedInput?[0], out int targetRow) is false ||
                targetRow < 1 || targetRow > 3)
            {
                return new FailResult("Invalid target cell row must be betwen 1 and 3");
            }

            if (int.TryParse(splittedInput?[1], out int targetColumn) is false ||
                targetColumn < 1 || targetColumn > 3)
            {
                return new FailResult("Invalid target cell column must be betwen 1 and 3");
            }

            return new SuccessResult<PlayerMovesRecord>(new PlayerMovesRecord(targetRow, targetColumn));
        }
    }
}
