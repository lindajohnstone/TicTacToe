using System;
using Xunit;

namespace TicTacToe2D.Tests
{
    public class OutputFormatterTests
    {
        [Fact]
        public void PrintInstruction_as_string()
        {
            var output = new StubOutput();
            var player = Player.X;
            var expected = "Player 1 enter a coord x,y to place your X or enter 'q' to give up: ";
            OutputFormatter.PrintInstructions(player, output);
            Assert.Equal(expected, output.GetWriteLine());
        }

        [Fact]
        public void DrawGame_as_string()
        {
            var output = new StubOutput();
            var board = new Board(SourceData.BoardIsInitialized());
            var expected = ".  .  .  \n.  .  .  \n.  .  .  \n";
            OutputFormatter.DrawBoard(board, output);
            Assert.Equal(expected, output.GetWriteLine());
        }

        [Fact]
        public void DrawGame_as_string_playerX()
        {
            var output = new StubOutput();
            var board = new Board(SourceData.BoardMovePlayer());
            var expected = "X  .  .  \n.  .  .  \n.  .  .  \n";
            OutputFormatter.DrawBoard(board, output);
            Assert.Equal(expected, output.GetWriteLine());
        }

        [Fact]
        public void DrawGame_as_string_playerY()
        {
            var output = new StubOutput();
            var board = new Board(SourceData.BoardMovePlayerY());
            var expected = "X  O  .  \n.  .  .  \n.  .  .  \n";
            OutputFormatter.DrawBoard(board, output);
            Assert.Equal(expected, output.GetWriteLine());
        }
    }
}