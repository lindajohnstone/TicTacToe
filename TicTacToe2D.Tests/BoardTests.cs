using System;
using System.Collections.Generic;
using Xunit;

namespace TicTacToe2D.Tests
{
    public class BoardTests
    {
        [Theory]
        [InlineData(3)]
        public void Board_dimensions(int boardSize)
        {
            var expected = boardSize;
            var result = new Board(2, boardSize);
            Assert.Equal(expected, result.DimensionLength[0]);
            Assert.Equal(expected, result.DimensionLength[1]);
        }

        [Theory]
        [InlineData(0, 0, FieldContents.x)]
        [InlineData(0, 1, FieldContents.x)]
        [InlineData(0, 2, FieldContents.x)]
        [InlineData(1, 0, FieldContents.y)]
        [InlineData(1, 1, FieldContents.y)]
        [InlineData(1, 2, FieldContents.y)]
        [InlineData(2, 0, FieldContents.empty)]
        [InlineData(2, 1, FieldContents.empty)]
        [InlineData(2, 2, FieldContents.empty)]
        public void Board_2D_has_valid_fields(int x, int y, FieldContents expected)
        {
            var position = TicTacToe2D.Position.Factory_2DPosition(x, y);
            var result = SourceData.BoardIsWinningBoardTrue().GetField(position);
            Assert.Equal(expected, result);
        }

        [Fact] 
        public void Board_invalid_Y_position()
        {
            var position = TicTacToe2D.Position.Factory_2DPosition(1, 3);
            var board = new Board(2, 3);
            var result = Assert.Throws<ArgumentException>(() => board.GetField(position));
            Assert.Equal("Position coordinate is out of range. Please try again...", result.Message);
        }

        [Fact]
        public void Board_invalid_X_position()
        {
            var position = TicTacToe2D.Position.Factory_2DPosition(6, 0);
            var board = new Board(2, 3);
            var result = Assert.Throws<ArgumentException>(() => board.GetField(position));
            Assert.Equal("Position coordinate is out of range. Please try again...", result.Message);
        }

        [Fact]
        public void Board_is_initialized()
        {
            var board = new Board(SourceData.BoardIsInitialized());
            Assert.True(board == (new Board(2, 3)));
            Assert.True(board.Equals(new Board(2, 3)));
        }

        [Fact]
        public void Board_X_MovePlayer()
        {
            var board = new Board(SourceData.BoardIsInitialized()); 
            var position = TicTacToe2D.Position.Factory_2DPosition(1, 0);
            var fieldContents = FieldContents.x;
            var result = board.MovePlayer(position, fieldContents);
            var expected = (SourceData.BoardXFirstMove() == result);
            Assert.True(expected);
        }

        [Theory]
        [InlineData(3)]
        public void Board_dimensions_3D(int boardSize)
        {
            var expected = boardSize;
            var result = new Board(3, boardSize);
            Assert.Equal(expected, result.DimensionLength[0]);
            Assert.Equal(expected, result.DimensionLength[1]);
            Assert.Equal(expected, result.DimensionLength[2]);
        }

        [Fact]
        public void Board_invalid_Y_position_3D()
        {
            var position = TicTacToe2D.Position.Factory_3DPosition(1, 3, 1);
            var board = new Board(3, 3);
            var result = Assert.Throws<ArgumentException>(() => board.GetField(position));
            Assert.Equal("Position coordinate is out of range. Please try again...", result.Message);
        }

        [Fact]
        public void Board_invalid_X_position_3D()
        {
            var position = TicTacToe2D.Position.Factory_3DPosition(1, 1, 3);
            var board = new Board(3, 3);
            var result = Assert.Throws<ArgumentException>(() => board.GetField(position));
            Assert.Equal("Position coordinate is out of range. Please try again...", result.Message);
        }

        [Fact]
        public void Board_invalid_Z_position_3D()
        {
            var position = TicTacToe2D.Position.Factory_3DPosition(3, 1, 1);
            var board = new Board(3, 3);
            var result = Assert.Throws<ArgumentException>(() => board.GetField(position));
            Assert.Equal("Position coordinate is out of range. Please try again...", result.Message);
        }

        [Fact]
        public void Board_is_initialized_3D()
        {
            var board = new Board(SourceData.Board3DIsInitialized());
            Assert.True(board == (new Board(3, 3)));
            Assert.True(board.Equals(new Board(3, 3)));
        }

        [Theory]
        [InlineData(0, 0, 0, FieldContents.x)]
        [InlineData(0, 0, 1, FieldContents.empty)]
        [InlineData(0, 0, 2, FieldContents.empty)]
        [InlineData(0, 1, 0, FieldContents.empty)]
        [InlineData(0, 1, 1, FieldContents.x)]
        [InlineData(0, 1, 2, FieldContents.empty)]
        [InlineData(0, 2, 0, FieldContents.empty)]
        [InlineData(0, 2, 1, FieldContents.empty)]
        [InlineData(0, 2, 2, FieldContents.x)]
        [InlineData(1, 0, 0, FieldContents.y)]
        [InlineData(1, 0, 1, FieldContents.empty)]
        [InlineData(1, 0, 2, FieldContents.empty)]
        [InlineData(1, 1, 0, FieldContents.empty)]
        [InlineData(1, 1, 1, FieldContents.y)]
        [InlineData(1, 1, 2, FieldContents.empty)]
        [InlineData(1, 2, 0, FieldContents.empty)]
        [InlineData(1, 2, 1, FieldContents.empty)]
        [InlineData(1, 2, 2, FieldContents.y)]
        [InlineData(2, 0, 0, FieldContents.empty)]
        [InlineData(2, 0, 1, FieldContents.empty)]
        [InlineData(2, 0, 2, FieldContents.empty)]
        [InlineData(2, 1, 0, FieldContents.empty)]
        [InlineData(2, 1, 1, FieldContents.empty)]
        [InlineData(2, 1, 2, FieldContents.empty)]
        [InlineData(2, 2, 0, FieldContents.empty)]
        [InlineData(2, 2, 1, FieldContents.empty)]
        [InlineData(2, 2, 2, FieldContents.empty)]
        public void Board_3D_has_valid_fields(int x, int y, int z, FieldContents expected)
        {
            var position = TicTacToe2D.Position.Factory_3DPosition(x, y, z);
            var result = SourceData.Board3DFirstBoard().GetField(position);
            Assert.Equal(expected, result);
        }

        [Fact]
        public void Board_all_positions_list_created()
        {
            var dimension = 2;
            var positions = new List<Position>();
            var board = new Board(dimension, 3);
            var expected = 9;
            var result = board.GetAllPositions();
            Assert.Equal(expected, result.Count);
        }
    }
}
