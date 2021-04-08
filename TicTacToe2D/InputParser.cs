using System;
using System.Collections.Generic;

namespace TicTacToe2D
{
    public static class InputParser
    {
        // receive player position
        // end game if player presses 'q'

        private static string[] SplitInput(string input)
        {
            return input.Split(',', StringSplitOptions.RemoveEmptyEntries);
        }

        private static bool IsValidInput(string[] input)
        {
            var list = new List<int>();
            foreach (var value in input)
            {
                bool success = Int32.TryParse(value, out var number);
                if (success)
                {
                    return true;
                }
            }
            return false;
        }

        public static void PlayerEndsGame(ConsoleInput input)
        {
            throw new NotImplementedException();
        }

        public static Position GetPlayerMove(ConsoleInput input)
        {
            var playerMove = input.ConsoleReadLine();
            var inputArray = SplitInput(playerMove);
            if (IsValidInput(inputArray))
            {
                return new Position(Int32.Parse(inputArray[0]), Int32.Parse(inputArray[1]));
            }
            throw new InvalidMoveSyntaxException();

        }
    }
}