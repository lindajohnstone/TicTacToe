using System;
using System.Collections.Generic;

namespace TicTacToe2D.Tests
{
    public class StubInputParser : IInputParser
    {
        public Position GetPlayerMove(string input)
        {
            var inputArray = SplitInput(input);
                if (IsValidInput(inputArray))
                {
                    return new Position(Int32.Parse(inputArray[0]), Int32.Parse(inputArray[1]));
                }
                throw new InvalidMoveSyntaxException();    
        }

        private string[] SplitInput(string input)
        {
            return input.Split(',', StringSplitOptions.RemoveEmptyEntries);
        }
        
        private bool IsValidInput(string[] input)
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

        public bool PlayerEndsGame(char input)
        {
            throw new NotImplementedException();
        }
    }
}