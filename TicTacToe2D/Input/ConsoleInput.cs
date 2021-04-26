using System;
using System.Diagnostics.CodeAnalysis;

namespace TicTacToe2D
{
    [ExcludeFromCodeCoverage]
    public class ConsoleInput : IInput
    {
        // returns console input 
        // inherits from IInput
        public string ConsoleReadLine()
        {
            return Console.ReadLine();
        }

        public ConsoleKeyInfo ConsoleReadKey(bool value)
        {
            return Console.ReadKey(value);
        }
    }
}