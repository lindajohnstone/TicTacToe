using System;
using System.Collections.Generic;

namespace TicTacToe2D.Tests
{
    public class StubOutput : IOutput
    {
        List<string> _outputList;

        public StubOutput()
        {
            _outputList = new List<string>();
        }
        public void ConsoleWrite(string value)
        {
            _outputList.Add(value);
        }

        public void ConsoleWriteLine(string value)
        {
            _outputList.Add(value);
        }

        public string GetWriteLine(List<string> value)
        {
            return String.Join("", _outputList);
        }
    }
}