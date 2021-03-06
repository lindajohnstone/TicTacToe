using System;
using System.Collections.Generic;
using TicTacToe2D.Exceptions;

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
                var dimensionList = new List<int>();
                for (int i = 0; i < inputArray.Length; i++)
                {
                    dimensionList.Add(Int32.Parse(inputArray[i])); 
                }
                return Position.Factory_FromPlayerInput(dimensionList);
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

        public static void PlayerEndsGame(Player player, string playerInput)
        {
            if (playerInput == "q")
            {
                throw new PlayerAbortsGameException();
            }
        }
    }
}