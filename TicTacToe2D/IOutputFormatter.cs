namespace TicTacToe2D
{
    public interface IOutputFormatter
    {
        public string DrawBoard(Board board, IOutput output);
        public string PrintInstructions(Player player);
    }
}