using System;

namespace TicTacToe2D.Tests
{
    public class StubInput : IInput
    {
        public ConsoleKeyInfo ConsoleReadKey(bool value)
        {
            throw new NotImplementedException();
        }

        public string ConsoleReadLine()
        {
            throw new NotImplementedException();
        }
    }
}