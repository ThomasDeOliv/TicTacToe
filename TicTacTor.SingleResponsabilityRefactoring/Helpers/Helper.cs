using System;

namespace TicTacTor.SingleResponsabilityRefactoring.Helpers
{
    internal static class Helper
    {
        internal static bool IsQuitInstruction(string? input)
        {
            return string.Compare(input, "q", StringComparison.OrdinalIgnoreCase) == 0;
        }

        internal static bool TryGetCoordinates(this string? input, out (int, int)? coordinates)
        {
            string[]? splittedInput = input?.Split(' ');
            coordinates = null;

            if (!int.TryParse(splittedInput?[0], out int targetRow) || !int.TryParse(splittedInput?[1], out int targetColumn))
            {
                return false;
            }

            coordinates = (targetRow, targetColumn);
            return true;
        }

        internal static bool EnsureValidCoordinates(int rowOrColumnCoordinates)
        {
            if (rowOrColumnCoordinates < 1 || rowOrColumnCoordinates > 3)
            {
                return false;
            }

            return true;
        }
    }
}
