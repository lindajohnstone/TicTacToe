using System.Collections.Generic;

namespace TicTacToe2D
{
    public interface IOutputFormatter
    {
        public List<string> DrawBoard(Board board, IOutput output);
        public string PrintInstructions(Player player);
    }
}