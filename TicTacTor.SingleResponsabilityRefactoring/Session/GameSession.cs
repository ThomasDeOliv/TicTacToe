using System;
using TicTacTor.SingleResponsabilityRefactoring.Board;

namespace TicTacTor.SingleResponsabilityRefactoring.Session
{
    internal static class GameSession
    {
        internal static void StartGameSession()
        {
            BoardGame board = BoardGame.CreateBoardGame();

            while (true)
            {
                board.DisplayGameBoard();

                Console.WriteLine($"Player {board.CurrentPlayer} - Enter row (1-3) and column (1-3), separated by a space, or 'q' to quit...");
                string? input = Console.ReadLine();

                if (Helpers.IsQuitInstruction(input))
                    break;

                if (!input.TryGetCoordinates(out (int, int)? coordinates) || !coordinates.HasValue)
                {
                    Console.WriteLine("Invalid input provided.");
                    continue;
                }

                if (!Helpers.EnsureValidCoordinates(coordinates.Value.Item1))
                {
                    Console.WriteLine("Invalid target cell row must be betwen 1 and 3");
                    continue;
                }

                if (!Helpers.EnsureValidCoordinates(coordinates.Value.Item2))
                {
                    Console.WriteLine("Invalid target cell column must be betwen 1 and 3");
                    continue;
                }

                if (board.IsGameBoardWin())
                {
                    Console.WriteLine($"Player {board.CurrentPlayer} has won the game !!!!");
                    break;
                }

                if (board.IsGameBoardFull())
                {
                    Console.WriteLine($"It's a draw");
                    break;
                }

                board.ChangePlayer();

                Console.Clear();
            }
        }
    }
}
