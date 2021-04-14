using System;

namespace TicTacToe2D
{
    public class InvalidMoveSyntaxException : Exception
    {
        public InvalidMoveSyntaxException()
            : base("Invalid format. Please try again...")
        {
        }

        public InvalidMoveSyntaxException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}