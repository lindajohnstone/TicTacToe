using System;

namespace TicTacToe2D
{
    public class ConsoleInput : IInput
    {
        // returns console input 
        // inherits from IInput
        public string ConsoleReadLine()
        {
            throw new NotImplementedException();
        }

        public ConsoleKeyInfo ConsolReadKey()
        {
            throw new NotImplementedException();
        }

        
    }
}