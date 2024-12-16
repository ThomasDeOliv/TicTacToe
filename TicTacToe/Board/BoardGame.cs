using System;
using System.Text;

namespace TicTacToe.Board
{
    internal class BoardGame
    {
        private char[,] _grid;

        internal BoardGame()
        {
            this._grid = new char[3, 3]
            {
                { ' ', ' ', ' ' },
                { ' ', ' ', ' ' },
                { ' ', ' ', ' ' },
            };
        }

        internal void DisplayGameBoard()
        {
            Console.WriteLine("|-----|-----|-----|");

            for (int i = 0; i < this._grid.GetLength(0); i++)
            {
                for (int j = 0; j < this._grid.GetLength(1); j++)
                {
                    Console.Write($"|  {this._grid[i, j]}  ");
                }

                Console.Write($"|\n");
                Console.WriteLine("|-----|-----|-----|");
            }
        }

        internal void SetCell(char value, int rowIndex, int columnIndex)
        {
            bool overRow = rowIndex >= this._grid.GetLength(0);
            bool overColumn = rowIndex >= this._grid.GetLength(1);

            if (overRow || overColumn)
            {
                StringBuilder builder = new StringBuilder(100);

                if (overRow)
                {
                    builder.Append($"Row index out of range (Max index : {this._grid.GetLength(0) - 1}). ");
                }

                if (overColumn)
                {
                    builder.Append($"Column index out of range (Max index : {this._grid.GetLength(0) - 1}). ");
                }

                throw new ArgumentOutOfRangeException(builder.ToString());
            }

            this._grid[rowIndex, columnIndex] = value;
        }

        internal bool IsFinished()
        {
            bool notFound = true;

            foreach(char c in this._grid)
            {
                if (c == ' ')
                {
                    notFound = false;
                    break;
                }
            }

            return notFound;
        }
    }
}
