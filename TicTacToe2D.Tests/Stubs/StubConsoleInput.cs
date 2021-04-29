using System;
using System.Collections.Generic;

namespace TicTacToe2D.Tests
{
    public class StubConsoleInput : IInput
    {
        private Queue<string> _queue;
        public StubConsoleInput()
        {
            _queue = new Queue<string>();
        }
        public ConsoleKeyInfo ConsoleReadKey(bool value)
        {
            throw new NotImplementedException();
        }

        public string ConsoleReadLine()
        {
            return _queue.Dequeue();
        }
        public void WithReadLine(string value)
        {
            _queue.Enqueue(value);
        }
    }
}