﻿using System;
using TicTacTor.SingleResponsabilityRefactoring.DTO;
using TicTacTor.SingleResponsabilityRefactoring.Models.BoardModel;
using TicTacTor.SingleResponsabilityRefactoring.Models.PlayerModel;
using TicTacTor.SingleResponsabilityRefactoring.Models.PlayerModel.PlayerMoveModel;

namespace TicTacTor.SingleResponsabilityRefactoring.Models.GameModel
{
    internal class Game : IGame
    {
        private readonly IBoard _boardGame;
        private bool _played;

        public Game()
        {
            this._boardGame = new Board();
            this._played = false;
        }

        public void InitGameSession()
        {
            Console.Write("Selectionnez votre équipe (X ou O) : ");
            string? input = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(input))
            {
                if (input.Equals("x", StringComparison.OrdinalIgnoreCase))
                {
                    this._boardGame.SetPlayerSymbol(GameSymbol.X);
                    this._boardGame.SetAIPlayerSymbol(GameSymbol.O);
                }
                else if (input.Equals("o", StringComparison.OrdinalIgnoreCase))
                {
                    this._boardGame.SetPlayerSymbol(GameSymbol.O);
                    this._boardGame.SetAIPlayerSymbol(GameSymbol.X);
                }
                else
                {
                    Console.Error.WriteLine("Invalid input provided.");
                    System.Environment.Exit(1);
                }
            }
            else
            {
                Console.Error.WriteLine("Empty input provided.");
                System.Environment.Exit(1);
            }
        }

        public void InitGame()
        {
            if (!this._played)
            {
                this._boardGame.DisplayGameBoard();

                while (true)
                {
                    Console.Write($"Player {this._boardGame.CurrentPlayer.Symbol} - Enter row (1-3) and column (1-3), separated by a space, or 'q' to quit... ");

                    string? input = this._boardGame.CurrentPlayer is AIPlayer ? null : Console.ReadLine();

                    ResultDTO<IPlayerMove> result = this._boardGame.CurrentPlayer.GetNextMove(input);

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
                    if (result.Value is not null && !this._boardGame.PlayOnGameBoard(result.Value.Row, result.Value.Column))
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
                        Console.WriteLine($"Player {this._boardGame.CurrentPlayer.Symbol} has won the game !!!!");
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
