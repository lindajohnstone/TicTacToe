using System;
using System.Diagnostics.CodeAnalysis;

namespace TicTacToe2D
{
    [ExcludeFromCodeCoverage]
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