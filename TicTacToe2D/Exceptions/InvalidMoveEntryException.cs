using System;

namespace TicTacToe2D
{
    public class InvalidMoveEntryException : Exception
    {
        public InvalidMoveEntryException()
            : base("Oh no, a piece is already at this place! Try again...")
        {
        }

        public InvalidMoveEntryException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}