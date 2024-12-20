using System;
using System.Text;
using System.Threading.Tasks;
using TicTacToe.Models.BoardModel;
using TicTacToe.Models.PlayerModel;

namespace TicTacToe.Services.InOut
{
    public class InOutService : IInOutService
    {
        private readonly IBoard _board;

        protected InOutService(IBoard board)
        {
            this._board = board;
        }

        public static InOutService Create(IBoard board)
        {
            return new InOutService(board);
        }

        private static void DisplayGameBoardLine(char leftCell, char middleCell, char rightCell)
        {
            Console.WriteLine($"|  {leftCell}  |  {middleCell}  |  {rightCell}  |");
        }

        public string? GetHumanUserInput()
        {
            return Console.ReadLine();
        }

        public bool ShouldContinueAndHandleError(string? input)
        {
            bool shouldContinue = false;

            switch (input)
            {
                case "Quit":
                    Console.WriteLine("User ask to quit game.");
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

            return shouldContinue;
        }

        public async Task AIWaitingCallbackAsync(IPlayer player)
        {
            StringBuilder stringBuilder = new StringBuilder(50);

            for (int i = 0; i < 3; i++)
            {
                stringBuilder.Append($"Grande reflexion de la part de la part du joueur {player.Symbol}");
                Console.WriteLine(stringBuilder.ToString());

                for (int j = 0; j < 3; j++)
                {
                    await Task.Delay(200);
                    Console.SetCursorPosition(0, Console.CursorTop - 1);
                    stringBuilder.Append('.');
                    Console.WriteLine(stringBuilder.ToString());
                }

                await Task.Delay(200);
                stringBuilder.Clear();

                Console.SetCursorPosition(0, Console.CursorTop - 1);
                Console.WriteLine(new string(' ', Console.WindowWidth));
                Console.SetCursorPosition(0, Console.CursorTop - 1);
            }
            Console.WriteLine();
        }

        public void DisplayGameBoard()
        {
            Console.WriteLine(new string('=', Console.WindowWidth));
            Console.WriteLine(".NET MAUI".PadLeft(Console.WindowWidth / 2));
            Console.WriteLine(new string('=', Console.WindowWidth));

            Console.WriteLine($"|-----------------|");
            DisplayGameBoardLine(this._board.GetCellContent(1, 1), this._board.GetCellContent(1, 2), this._board.GetCellContent(1, 3));
            Console.WriteLine($"|-----|-----|-----|");
            DisplayGameBoardLine(this._board.GetCellContent(2, 1), this._board.GetCellContent(2, 2), this._board.GetCellContent(2, 3));
            Console.WriteLine($"|-----|-----|-----|");
            DisplayGameBoardLine(this._board.GetCellContent(3, 1), this._board.GetCellContent(3, 2), this._board.GetCellContent(3, 3));
            Console.WriteLine($"|-----------------|");
        }

        public void GetStartSentence(IPlayer currentPlayer)
        {
            Console.WriteLine($"Player {currentPlayer.Symbol} - Enter row (1-3) and column (1-3), separated by a space, or 'q' to quit... ");
        }

        public void AlreadyPlayed()
        {
            Console.WriteLine($"This game has already been played.");
            Console.WriteLine($"----------------------------------");
            Console.WriteLine($"Results :");
        }

        public void InvalidMove()
        {
            Console.WriteLine("Invalid move");
        }

        public void PlayerWonGame(IPlayer currentPlayer)
        {
            Console.WriteLine($"Player {currentPlayer.Symbol} has won the game !!!!");
        }

        public void Draw()
        {
            Console.WriteLine($"It's a draw");
        }

        public void Clear()
        {
            Console.Clear();
        }
    }
}
