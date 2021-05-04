using System;
using Xunit;

namespace TicTacToe2D.Tests
{
    public class BoardTests
    {
        [Theory]
        [InlineData(3)]
        public void Board2D_dimensions(int dimensionLength)
        {
            var expected = dimensionLength;
            var result = new Board2D(dimensionLength);
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
        public void Board2D_has_valid_fields(int x, int y, FieldContents expected)
        {
            var position = new Position2D(x, y);
            var result = SourceData.BoardIsWinningBoardTrue().GetField(position);
            Assert.Equal(expected, result);
        }
        
        [Fact] 
        public void Board2D_invalid_Y_position()
        {
            var position = new Position2D(1, 3);
            var board = new Board2D(3);
            var result = Assert.Throws<ArgumentException>(() => board.GetField(position));
            Assert.Equal("Position Y coordinate is out of range. Please try again...", result.Message);
        }

        [Fact]
        public void Board2D_invalid_X_position()
        {
            var position = new Position2D(6, 0);
            var board = new Board2D(3);
            var result = Assert.Throws<ArgumentException>(() => board.GetField(position));
            Assert.Equal("Position X coordinate is out of range. Please try again...", result.Message);
        }

        [Fact]
        public void Board2D_is_initialized()
        {
            var board = new Board2D(SourceData.BoardIsInitialized());
            Assert.True(board == (new Board2D(3)));
            Assert.True(board.Equals(new Board2D(3)));
        }

        [Fact]
        public void Board2D_X_MovePlayer()
        {
            var board = new Board2D(SourceData.BoardIsInitialized());
            var position = new Position2D(0, 1);
            var fieldContents = FieldContents.x;
            var result = board.MovePlayer(position, fieldContents);
            var expected = (SourceData.BoardXFirstMove() == result);
            Assert.True(expected);
        }
        [Theory]
        [InlineData(3)]
        public void Board3D_dimensions(int dimensionLength)
        {
            var expected = dimensionLength;
            var result = new Board3D(dimensionLength);
            Assert.Equal(expected, result.Width);
            Assert.Equal(expected, result.Height);
        }
    }
}
