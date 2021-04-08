using System;

namespace TicTacToe2D
{
    public interface IInput
    {
        // remove console input
        // stub used for testing
        public string ConsoleReadLine();
        public ConsoleKeyInfo ConsoleReadKey(); // q for quit
    }
}