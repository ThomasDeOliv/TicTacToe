using System;
using TicTacToe.Board;

namespace TicTacToe
{
    internal class Program
    {
        internal static void Main(string[] args)
        {
            try
            {
                BoardGame boardGame = new BoardGame();
            }
            catch (Exception e)
            {
                Console.Error.WriteLine(e.Message);
            }
        }
    }
}
