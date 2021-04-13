namespace TicTacToe2D
{
    public interface IOutputFormatter
    {
        public void DrawBoard(Board board, ConsoleOutput output);
        public string PrintInstructions(Player player);
    }
}