using System;
using TicTacTor.SingleResponsabilityRefactoring.Boards;
using TicTacTor.SingleResponsabilityRefactoring.Helpers;

namespace TicTacTor.SingleResponsabilityRefactoring.Sessions
{
    internal class Session
    {
        private readonly IBoardGame _boardGame;
        private bool _played;

        private Session()
        {
            this._boardGame = BoardGame.CreateBoardGame();
            this._played = false;
        }

        internal static Session CreateGame()
        {
            return new Session();
        }

        internal void StartGameSession()
        {
            if (!this._played)
            {
                // Display game
                this._boardGame.DisplayGameBoard();

                // Game loop
                while (true)
                {
                    // Message to play
                    Console.Write($"Player {this._boardGame.CurrentPlayer.GetCurrentPlayer()} - Enter row (1-3) and column (1-3), separated by a space, or 'q' to quit... ");
                    string? input = Console.ReadLine(); // User input

                    // Quit instruction
                    if (Helper.IsQuitInstruction(input))
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
                    if (!Helper.EnsureValidCoordinates(coordinates.Value.Item1))
                    {
                        Console.WriteLine("Invalid target cell row must be betwen 1 and 3");
                        continue;
                    }

                    // Check column
                    if (!Helper.EnsureValidCoordinates(coordinates.Value.Item2))
                    {
                        Console.WriteLine("Invalid target cell column must be betwen 1 and 3");
                        continue;
                    }

                    // Play
                    if (!this._boardGame.PlayOnGameBoard(coordinates.Value.Item1, coordinates.Value.Item2))
                    {
                        Console.WriteLine("Invalid move");
                        continue;
                    }

                    // Clear console
                    Console.Clear();

                    // Refresh view
                    this._boardGame.DisplayGameBoard();

                    // Check if win
                    if (this._boardGame.IsGameBoardWin())
                    {
                        Console.WriteLine($"Player {this._boardGame.CurrentPlayer.GetCurrentPlayer()} has won the game !!!!");
                        break;
                    }

                    // Check if board is full
                    if (this._boardGame.IsGameBoardFull())
                    {
                        Console.WriteLine($"It's a draw");
                        break;
                    }

                    // Change player
                    this._boardGame.ChangePlayer();
                }

                this._played = true;
            }
            else
            {
                // Clear output
                Console.Clear();

                // Warning message
                Console.WriteLine($"This game has already been played.");
                Console.WriteLine($"----------------------------------");
                Console.WriteLine($"Results :");

                // Display game
                this._boardGame.DisplayGameBoard();
            }
        }
    }
}
