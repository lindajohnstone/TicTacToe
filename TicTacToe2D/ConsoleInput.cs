using System;

namespace TicTacToe2D
{
    public class ConsoleInput : IInput
    {
        // returns console input 
        // inherits from IInput
        public string ConsoleReadLine()
        {
            return Console.ReadLine();
        }

        public ConsoleKeyInfo ConsoleReadKey()
        {
            throw new NotImplementedException();
        }

        
    }
}