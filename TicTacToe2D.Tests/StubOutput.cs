namespace TicTacToe2D.Tests
{
    public class StubOutput : IOutput
    {
        public void ConsoleWrite(string value)
        {
            throw new System.NotImplementedException();
        }

        public void ConsoleWriteLine(string value)
        {
            throw new System.NotImplementedException();
        }
    }
}