using System;

namespace TicTacToe2D
{
    public class ConsoleOutput : IOutput
    {
        // returns console output
        // inherits from IOutput
        public string ConsoleWrite()
        {
            throw new System.NotImplementedException();
        }

        public string ConsoleWriteLine()
        {
            throw new System.NotImplementedException();
        }
        public void DrawBoard(Board board)
        {
            throw new NotImplementedException();
        }
    }
}