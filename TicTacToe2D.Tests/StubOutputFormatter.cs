using System;

namespace TicTacToe2D.Tests
{
    public class StubOutputFormatter : IOutputFormatter
    {
        public void DrawBoard(Board board, ConsoleOutput output)
        {
            throw new System.NotImplementedException();
        }

        public string PrintInstructions(Player player)
        {
            //var output = new StubOutput();
            var playerId = (int)player;
            var message = String.Format("Player {0} enter a coord x,y to place your {1} or enter 'q' to give up: ", playerId, player);
            return message;
        }
    }
}