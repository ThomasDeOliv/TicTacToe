using System;
using TicTacTor.SingleResponsabilityRefactoring.DTOs;

namespace TicTacTor.SingleResponsabilityRefactoring.Models.Implementations
{
    internal class Game : IGame
    {
        private readonly IBoard _boardGame;
        private bool _played;

        private Game()
        {
            _boardGame = Board.CreateBoardGame();
            _played = false;
        }

        public static Game CreateGame()
        {
            return new Game();
        }

        public void StartGameSession()
        {
            if (!_played)
            {
                _boardGame.DisplayGameBoard();

                while (true)
                {
                    Console.Write($"Player {_boardGame.CurrentPlayer.GetCurrentPlayer()} - Enter row (1-3) and column (1-3), separated by a space, or 'q' to quit... ");

                    string? input = Console.ReadLine();

                    ResultDTO<IPlayerMovesRecord> result = _boardGame.CurrentPlayer.GetNextMove(input);

                    if (!result.Success)
                    {
                        bool shouldContinue = false;

                        switch (result.Reason)
                        {
                            case "Quit":
                                Console.WriteLine("Invalid target cell row must be betwen 1 and 3.");
                                break;
                            case "Empty":
                                shouldContinue = true;
                                Console.WriteLine("No input provided, try again.");
                                break;
                            case "InvalidInput":
                                shouldContinue = true;
                                Console.WriteLine("The provided coordinates are not valids.");
                                break;
                            case "OutOfRangeRow":
                                shouldContinue = true;
                                Console.WriteLine("Invalid target cell row must be betwen 1 and 3.");
                                break;
                            case "OutOfRangeColumn":
                                shouldContinue = true;
                                Console.WriteLine("Invalid target cell column must be betwen 1 and 3.");
                                break;
                            default:
                                Console.WriteLine("An error occured.");
                                break;
                        };

                        if (shouldContinue)
                        {
                            continue;
                        }

                        break;
                    }

                    // Play
                    if (result.Value is not null && result.HasValue && !_boardGame.PlayOnGameBoard(result.Value.Row, result.Value.Column))
                    {
                        Console.WriteLine("Invalid move");
                        continue;
                    }

                    // Clear console
                    Console.Clear();

                    // Refresh view
                    _boardGame.DisplayGameBoard();

                    // Check if win
                    if (_boardGame.IsGameBoardWin())
                    {
                        Console.WriteLine($"Player {_boardGame.CurrentPlayer.GetCurrentPlayer()} has won the game !!!!");
                        break;
                    }

                    // Check if board is full
                    if (_boardGame.IsGameBoardFull())
                    {
                        Console.WriteLine($"It's a draw");
                        break;
                    }

                    // Change player
                    _boardGame.ChangePlayer();
                }

                _played = true;
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
                _boardGame.DisplayGameBoard();
            }
        }
    }
}
