using System;

namespace TicTacToe2D
{
    public class ConsoleOutput : IOutput
    {
        // returns console output
        // inherits from IOutput
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