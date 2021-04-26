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
            var controller = new Controller();
            var board = new Board(3);
            var players = new List<Player> { Player.X, Player.O };
            var game = new GameContext(board, players);
            controller.PlayGame(game);
        }
    }
}
