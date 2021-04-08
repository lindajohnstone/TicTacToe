using System;

namespace TicTacToe2D
{
    class Program
    {
        static void Main(string[] args)
        {
            var controller = new Controller();
            var game = new GameContext();
            controller.PlayGame(game);
        }
    }
}
