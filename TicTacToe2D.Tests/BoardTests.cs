using System;
using Xunit;

namespace TicTacToe2D.Tests
{
    public class BoardTests
    {
        [Theory]
        [InlineData(3)]
        public void Board_dimensions(int dimensionLength)
        {
            var expected = dimensionLength;
            var result = new Board(dimensionLength);
            Assert.Equal(expected, result.Width);
            Assert.Equal(expected, result.Height);
        }

        [Theory]
        [InlineData(0, 0, FieldContents.x)]
        [InlineData(0, 1, FieldContents.y)]
        [InlineData(0, 2, FieldContents.empty)]
        [InlineData(1, 0, FieldContents.x)]
        [InlineData(1, 1, FieldContents.y)]
        [InlineData(1, 2, FieldContents.empty)]
        [InlineData(2, 0, FieldContents.x)]
        [InlineData(2, 1, FieldContents.y)]
        [InlineData(2, 2, FieldContents.empty)]
        public void Board_has_valid_fields(int x, int y, FieldContents expected)
        {
            var position = new Position(x, y);
            var result = SourceData.BoardIsWinningBoardTrue().GetField(position);
            Assert.Equal(expected, result);
        }
        
        [Fact] 
        public void Board_invalid_Y_position()
        {
            var position = new Position(1, 3);
            var board = new Board(3);
            var result = Assert.Throws<ArgumentException>(() => board.GetField(position));
            Assert.Equal("Position Y coordinate is out of range. Please try again...", result.Message);
        }

        [Fact]
        public void Board_invalid_X_position()
        {
            var position = new Position(6, 0);
            var board = new Board(3);
            var result = Assert.Throws<ArgumentException>(() => board.GetField(position));
            Assert.Equal("Position X coordinate is out of range. Please try again...", result.Message);
        }

        [Fact]
        public void Board_is_initialized()
        {
            var board = new Board(SourceData.BoardIsInitialized());
            Assert.True(board == (new Board(3)));
            Assert.True(board.Equals(new Board(3)));
        }

        [Fact]
        public void Board_X_MovePlayer()
        {
            var board = new Board(SourceData.BoardIsInitialized());
            var position = new Position(0, 1);
            var fieldContents = FieldContents.x;
            var result = board.MovePlayer(position, fieldContents);
            var expected = (SourceData.BoardXFirstMove() == result);
            Assert.True(expected);
        }
    }
}
