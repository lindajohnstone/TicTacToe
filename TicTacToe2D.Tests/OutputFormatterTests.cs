using System;
using Xunit;

namespace TicTacToe2D.Tests
{
    public class OutputFormatterTests
    {
        [Fact]
        public void PrintInstruction_as_string()
        {
            var player = Player.X;
            var outputFormatter = new StubOutputFormatter();
            var result = outputFormatter.PrintInstructions(player);
            var expected = "Player 1 enter a coord x,y to place your X or enter 'q' to give up: ";
            Assert.Equal(expected, result);
        }

        [Fact]
        public void DrawGame_as_string()
        {
            var output = new StubOutput();
            var outputFormatter = new StubOutputFormatter();
            var board = new Board(SourceData.BoardIsInitialized());
            var expected = ".  .  .\n.  .  .\n.  .  .";
            var result = outputFormatter.DrawBoard(board, output);
            Assert.Equal(expected, result);
        }
    }
}