using System;

namespace TicTacToe2D
{
    public static class InputParser
    {
        // receive player position
        // end game if player presses 'q'
        public static string ValidatePlayerInput(string input)
        {
            var inputArray = SplitInput(input);
            if (IsValidInput(inputArray))
            {
                return input;
            }
            return "Invalid coords. Please enter a coord x,y to place your X";
        }

        private static string[] SplitInput(string input)
        {
            return input.Split(',');
        }

        private static bool IsValidInput(string[] input)
        {
            foreach (var value in input)
            {
                int.Parse(value);
            }
            return false;
        }

        public static void PlayerEndsGame(ConsoleInput input)
        {
            throw new NotImplementedException();
        }
    }
}