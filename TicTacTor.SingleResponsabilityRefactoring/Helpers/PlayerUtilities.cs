using System;

namespace TicTacTor.SingleResponsabilityRefactoring.Helpers
{
    internal static class PlayerUtilities
    {
        public static bool IsQuitInstruction(string? input)
        {
            return string.Compare(input, "q", StringComparison.OrdinalIgnoreCase) == 0;
        }

        public static bool TryGetCoordinates(this string? input, out (int, int)? coordinates)
        {
            coordinates = null;
            string[]? splittedInput = input?.Split(' ');

            if (!int.TryParse(splittedInput?[0], out int targetRow) || !int.TryParse(splittedInput?[1], out int targetColumn))
            {
                return false;
            }

            coordinates = (targetRow, targetColumn);
            return true;
        }

        public static bool EnsureValidCoordinates(int rowOrColumnCoordinates)
        {
            return rowOrColumnCoordinates >= 1 && rowOrColumnCoordinates <= 3;
        }
    }
}
