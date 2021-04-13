using System;

namespace TicTacToe2D.Tests
{
    public class StubConsoleInput : IInput
    {
        public ConsoleKeyInfo ConsoleReadKey()
        {
            throw new NotImplementedException();
        }

        public string ConsoleReadLine()
        {
            throw new NotImplementedException();
        }
    }
}