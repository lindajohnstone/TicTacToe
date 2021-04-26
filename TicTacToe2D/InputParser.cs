using System;
using System.Collections.Generic;

namespace TicTacToe2D
{
    public static class InputParser
    {
        // receive player position
        // end game if player presses 'q'

        public static Position GetPlayerMove(string playerInput) 
        {
            var inputArray = SplitInput(playerInput);
            if (IsValidInput(inputArray))
            {
                return new Position(Int32.Parse(inputArray[0]), Int32.Parse(inputArray[1]));
            }
            throw new InvalidMoveSyntaxException();
        }
        private static string[] SplitInput(string input)
        {
            return input.Split(',', StringSplitOptions.RemoveEmptyEntries);
        }

        private static bool IsValidInput(string[] input)
        {
            var list = new List<int>();
            var count = 0;
            foreach (var value in input)
            {
                bool success = Int32.TryParse(value, out var number);
                if (success)
                {
                    count++;
                }
            }
            if (count == 2)
            {
                return true;
            }
            return false;
        }

        public static bool PlayerEndsGame(Player player, string playerInput, IOutput output)
        {
            if (playerInput == "q")
            {
                OutputFormatter.PrintEndGame(player, output);
                return true;
            }
            return false;
        }
    }
}