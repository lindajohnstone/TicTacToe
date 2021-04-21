using System;

namespace TicTacToe2D.Tests
{
    public class StubConsoleInput : IInput
    {
        private string _readLine;

        public ConsoleKeyInfo ConsoleReadKey(bool value)
        {
            throw new NotImplementedException();
        }

        public string ConsoleReadLine()
        {
            return _readLine;
        }

        public StubConsoleInput WithReadLine(string value)
        {
            _readLine = value;
            return this;
        }
    }
}