using System;
using System.Linq;
using System.Text.RegularExpressions;
using Microsoft.VisualBasic.CompilerServices;

namespace Battleships.App.Utils
{
    public static class StringExtensions
    {
        /// <summary>
        /// Validates proper coordinates format of input string from the user.
        /// </summary>
        /// <param name="shot">User input string</param>
        /// <returns>The method returns bool</returns>
        public static bool IsProperShot(this string? shot, int size)
        {
            if (shot is null) return false;
            if (shot.Length <= 1 || shot.Length >= 4) return false;
            if (!char.IsLetter(shot[0])) return false;
            if (!char.IsUpper(shot[0])) return false;
            if (!Regex.IsMatch(shot, $"^[A-{(char) ('A' + (size - 1))}].*")) return false;
            if (!char.IsDigit(shot[1])) return false;
            if (size > 10 && shot.Length == 3)
            {
                if (!char.IsDigit(shot[2])) return false;
                var rowString = shot.Substring(1);
                var rowInt = Convert.ToInt32(rowString);
                if (rowInt > size - 1) return false;
                if (shot[1] == '0') return false;
            }

            return true;
        }

        /// <summary>
        /// Validates proper size of the input string from a user
        /// </summary>
        /// <param name="size">input string</param>
        /// <returns>The method returns bool</returns>
        public static bool IsProperSize(this string? size)
        {
            if (size is null) return false;
            if (size.Length == 0) return false;
            foreach (var sizeChar in size)
            {
                if (!char.IsDigit(sizeChar)) return false;
            }
            int sizeInt = Convert.ToInt32(size);
            if (sizeInt <= 0 || sizeInt >= 27) return false;
            if (!Regex.IsMatch(size,"^[1-9].*")) return false;

            return true;
        }

        /// <summary>
        /// Validates if number of ships is proper
        /// </summary>
        /// <param name="number">user input of ships number</param>
        /// <returns>The method returns bool</returns>
        public static bool IsProperShipsNumber(this string? number)
        {
            if (number is null) return false;
            if (number.Length != 1) return false;
            if (!char.IsDigit(number[0])) return false;

            return true;
        }
    }
}