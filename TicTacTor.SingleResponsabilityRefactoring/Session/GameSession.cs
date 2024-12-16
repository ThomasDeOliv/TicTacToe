using System;
using TicTacTor.SingleResponsabilityRefactoring.Board;

namespace TicTacTor.SingleResponsabilityRefactoring.Session
{
    internal static class GameSession
    {
        internal static void StartGameSession()
        {
            // Create board
            BoardGame board = BoardGame.CreateBoardGame();

            while (true)
            {
                // Display game
                board.DisplayGameBoard();

                // Message to play
                Console.WriteLine($"Player {board.CurrentPlayer} - Enter row (1-3) and column (1-3), separated by a space, or 'q' to quit...");
                string? input = Console.ReadLine(); // User input

                // Quit instruction
                if (Helpers.IsQuitInstruction(input))
                {
                    break;
                }

                // Extract coordinates and validation
                if (!input.TryGetCoordinates(out (int, int)? coordinates) || !coordinates.HasValue)
                {
                    Console.WriteLine("Invalid input provided.");
                    continue;
                }

                // Check row
                if (!Helpers.EnsureValidCoordinates(coordinates.Value.Item1))
                {
                    Console.WriteLine("Invalid target cell row must be betwen 1 and 3");
                    continue;
                }

                // Check column
                if (!Helpers.EnsureValidCoordinates(coordinates.Value.Item2))
                {
                    Console.WriteLine("Invalid target cell column must be betwen 1 and 3");
                    continue;
                }

                // Play
                if (!board.PlayOnGameBoard(coordinates.Value.Item1, coordinates.Value.Item2))
                {
                    Console.WriteLine("Invalid move");
                    continue;
                }

                // Check if win
                if (board.IsGameBoardWin())
                {
                    Console.WriteLine($"Player {board.CurrentPlayer} has won the game !!!!");
                    break;
                }

                // Check if board is full
                if (board.IsGameBoardFull())
                {
                    Console.WriteLine($"It's a draw");
                    break;
                }

                // Change player
                board.ChangePlayer();

                // Clear output
                Console.Clear();
            }
        }
    }
}
