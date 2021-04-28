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

        [Fact]
        public void PrintWelcome_as_string()
        {
            var output = new StubOutput();
            var board = new Board(3);
            var expected = "Welcome to Tic Tac Toe!\nHere's the current board:.  .  .  \n.  .  .  \n.  .  .  \n";
            OutputFormatter.PrintWelcome(board, output);
            Assert.Equal(expected, output.GetWriteLine());
        }

        [Fact]
        public void PrintBoard_as_string()
        {
            var output = new StubOutput();
            var board = new Board(3);
            var expected = "Here's the current board:.  .  .  \n.  .  .  \n.  .  .  \n";
            OutputFormatter.PrintBoard(board, output);
            Assert.Equal(expected, output.GetWriteLine());
        }

        [Fact]
        public void PrintNewBoard_as_string()
        {
            var output = new StubOutput();
            var board = new Board(3);
            var expected = "Move accepted. Here's the current board: .  .  .  \n.  .  .  \n.  .  .  \n";
            OutputFormatter.PrintNewBoard(board, output);
            Assert.Equal(expected, output.GetWriteLine());
        }
    }
}