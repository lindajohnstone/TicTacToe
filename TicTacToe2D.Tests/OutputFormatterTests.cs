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
            var outputFormatter = new OutputFormatter();
            outputFormatter.PrintInstructions(player, output);
            Assert.Equal(expected, output.GetWriteLine());
        }

        // [Fact]
        // public void DrawGame_as_string()
        // {
        //     var output = new StubOutput();
        //     var board = new Board2D(SourceData.BoardIsInitialized());
        //     var expected = ".  .  .  \n.  .  .  \n.  .  .  \n";
        //     var outputFormatter = new OutputFormatter();
        //     outputFormatter.DrawBoard(board, output);
        //     Assert.Equal(expected, output.GetWriteLine());
        // }

        // [Fact]
        // public void DrawGame_as_string_playerX()
        // {
        //     var output = new StubOutput();
        //     var board = new Board2D(SourceData.BoardMovePlayer());
        //     var expected = "X  .  .  \n.  .  .  \n.  .  .  \n";
        //     var outputFormatter = new OutputFormatter();
        //     outputFormatter.DrawBoard(board, output);
        //     Assert.Equal(expected, output.GetWriteLine());
        // }

        // [Fact]
        // public void DrawGame_as_string_playerY()
        // {
        //     var output = new StubOutput();
        //     var board = new Board2D(SourceData.BoardMovePlayerY());
        //     var expected = "X  O  .  \n.  .  .  \n.  .  .  \n";
        //     var outputFormatter = new OutputFormatter();
        //     outputFormatter.DrawBoard(board, output);
        //     Assert.Equal(expected, output.GetWriteLine());
        // }

        [Fact]
        public void PrintWelcome_as_string()
        {
            var output = new StubOutput();
            var board = new Board2D(3);
            var expected = "Welcome to Tic Tac Toe!\n";
            var outputFormatter = new OutputFormatter();
            outputFormatter.PrintWelcome(output);
            Assert.Equal(expected, output.GetWriteLine());
        }

        // [Fact]
        // public void PrintBoard_as_string()
        // {
        //     var output = new StubOutput();
        //     var board = new Board2D(3);
        //     var expected = "Here's the current board:.  .  .  \n.  .  .  \n.  .  .  \n";
        //     var outputFormatter = new OutputFormatter();
        //     outputFormatter.PrintBoard(board, output);
        //     Assert.Equal(expected, output.GetWriteLine());
        // }

        // [Fact]
        // public void PrintNewBoard_as_string()
        // {
        //     var output = new StubOutput();
        //     var board = new Board2D(3);
        //     var expected = "Move accepted. Here's the current board: .  .  .  \n.  .  .  \n.  .  .  \n";
        //     var outputFormatter = new OutputFormatter();
        //     outputFormatter.PrintNewBoard(board, output);
        //     Assert.Equal(expected, output.GetWriteLine());
        // }

        [Fact]
        public void PrintNewLine()
        {
            var output = new StubOutput();
            var outputFormatter = new OutputFormatter();
            var expected = "\n";
            outputFormatter.PrintNewLine(output);
            Assert.Equal(expected, output.GetWriteLine());
        }
    }
}