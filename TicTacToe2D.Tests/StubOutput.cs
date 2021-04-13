using System;

namespace TicTacToe2D.Tests
{
    public class StubOutput : IOutput
    {
        public void ConsoleWrite(string value)
        {
            Console.Write(value);
        }

        public void ConsoleWriteLine(string value)
        {
            Console.WriteLine(value);
        }
    }
}