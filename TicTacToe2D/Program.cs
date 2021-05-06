using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace TicTacToe2D
{
    [ExcludeFromCodeCoverage]
    class Program
    {
        static void Main(string[] args)
        {
            var input = new ConsoleInput();
            var output = new ConsoleOutput();
            var outputFormatter = new OutputFormatter();
            var board = new Board(3);
            var controller = new Controller(board);
            var players = new List<Player> { Player.X, Player.O };
            var game = new GameContext(board, players);
            controller.PlayGame(game, output, input, outputFormatter);
        }
    }
}
