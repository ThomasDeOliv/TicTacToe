using System;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TicTacToe.SingleResponsabilityRefactoring.DTO;
using TicTacToe.SingleResponsabilityRefactoring.Models.BoardModel;
using TicTacToe.SingleResponsabilityRefactoring.Models.PlayerModel.PlayerMoveModel;

namespace TicTacToe.SingleResponsabilityRefactoring.Models.GameModel
{
    public class Game : IGame
    {
        private readonly IBoard _board;
        private bool _played;

        protected Game(IBoard board)
        {
            this._board = board;
            this._played = false;
        }

        public void Init()
        {
            Console.Write("Selectionnez votre équipe (X ou O) : ");
            string? input = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(input))
            {
                if (input.Equals("x", StringComparison.OrdinalIgnoreCase))
                {
                    this._board.SetPlayerSymbol(GameSymbol.X);
                    this._board.SetAIPlayerSymbol(GameSymbol.O);
                }
                else if (input.Equals("o", StringComparison.OrdinalIgnoreCase))
                {
                    this._board.SetPlayerSymbol(GameSymbol.O);
                    this._board.SetAIPlayerSymbol(GameSymbol.X);
                }
                else
                {
                    Console.Error.WriteLine("Invalid input provided.");
                    System.Environment.Exit(1);
                }

                Console.Clear();
            }
            else
            {
                Console.Error.WriteLine("Empty input provided.");
                System.Environment.Exit(1);
            }
        }

        public void Play()
        {
            if (!this._played)
            {
                this._board.DisplayGameBoard();

                while (true)
                {
                    Console.Write($"Player {this._board.CurrentPlayer.Symbol} - Enter row (1-3) and column (1-3), separated by a space, or 'q' to quit... ");

                    string? input = this._board.CurrentPlayer.IsAI ? null : Console.ReadLine();

                    ResultDTO<IPlayerMove> result = this._board.CurrentPlayer.GetNextMove(input);

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
                            case "OutOfRangeRowAndColumn":
                                shouldContinue = true;
                                Console.WriteLine("Invalid target cell row and column must be betwen 1 and 3.");
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
                    if (result.Value is not null && !this._board.PlayOnGameBoard(result.Value.Row, result.Value.Column))
                    {
                        Console.WriteLine("Invalid move");
                        continue;
                    }

                    Console.Clear();

                    this._board.DisplayGameBoard();

                    if (this._board.IsGameBoardWin())
                    {
                        Console.WriteLine($"Player {this._board.CurrentPlayer.Symbol} has won the game !!!!");
                        break;
                    }

                    if (this._board.IsGameBoardFull())
                    {
                        Console.WriteLine($"It's a draw");
                        break;
                    }

                    this._board.ChangePlayer();
                }

                this._played = true;
            }
            else
            {
                Console.Clear();

                Console.WriteLine($"This game has already been played.");
                Console.WriteLine($"----------------------------------");
                Console.WriteLine($"Results :");

                this._board.DisplayGameBoard();
            }
        }

        public async Task PlayAync(CancellationToken cancellationToken = default)
        {
            if (!this._played)
            {
                this._board.DisplayGameBoard();

                while (true)
                {
                    Console.Write($"Player {this._board.CurrentPlayer.Symbol} - Enter row (1-3) and column (1-3), separated by a space, or 'q' to quit... ");

                    string? input = this._board.CurrentPlayer.IsAI ? null : Console.ReadLine();

                    Console.WriteLine();

                    ResultDTO<IPlayerMove> result = await this._board.CurrentPlayer.GetNextMoveAsync(async () =>
                    {
                        if (this._board.CurrentPlayer.IsAI)
                        {
                            StringBuilder stringBuilder = new StringBuilder(50);
                            stringBuilder.Append($"Grande reflexion de la part de l'IA (joueur {this._board.CurrentPlayer.Symbol})");
                            Console.WriteLine(stringBuilder.ToString());
                            for (int i = 0; i < 3; i++)
                            {
                                await Task.Delay(500);
                                Console.SetCursorPosition(0, Console.CursorTop - 1);
                                stringBuilder.Append('.');
                                Console.WriteLine(stringBuilder.ToString());
                            }
                            Console.WriteLine();
                            await Task.Delay(1000);
                        }

                    }, input, cancellationToken);

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
                            case "OutOfRangeRowAndColumn":
                                shouldContinue = true;
                                Console.WriteLine("Invalid target cell row and column must be betwen 1 and 3.");
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
                    if (result.Value is not null && !this._board.PlayOnGameBoard(result.Value.Row, result.Value.Column))
                    {
                        Console.WriteLine("Invalid move");
                        continue;
                    }

                    Console.Clear();

                    this._board.DisplayGameBoard();

                    if (this._board.IsGameBoardWin())
                    {
                        Console.WriteLine($"Player {this._board.CurrentPlayer.Symbol} has won the game !!!!");
                        break;
                    }

                    if (this._board.IsGameBoardFull())
                    {
                        Console.WriteLine($"It's a draw");
                        break;
                    }

                    this._board.ChangePlayer();
                }

                this._played = true;
            }
            else
            {
                Console.Clear();

                Console.WriteLine($"This game has already been played.");
                Console.WriteLine($"----------------------------------");
                Console.WriteLine($"Results :");

                this._board.DisplayGameBoard();
            }
        }

        public static Game Create(IBoard board)
        {
            return new Game(board);
        }
    }
}
