using System;
using Xunit;
using FluentAssertions;
using System.Collections.Generic;

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

        // [Fact]
        // public void Board()
        // {
        //     var expected = new Board(3);
        //     var result = new Board(3);
        //     Assert.Equal(expected, result);
        // }

        [Theory]
        [InlineData(0, 0, FieldContents.empty)]
        [InlineData(0, 1, FieldContents.empty)]
        [InlineData(0, 2, FieldContents.empty)]
        [InlineData(1, 0, FieldContents.empty)]
        [InlineData(1, 1, FieldContents.empty)]
        [InlineData(1, 2, FieldContents.empty)]
        [InlineData(2, 0, FieldContents.empty)]
        [InlineData(2, 1, FieldContents.empty)]
        [InlineData(2, 2, FieldContents.empty)]
        public void Board_contents_field_valid(int x, int y, FieldContents expected)
        {
            var position = new Position(x, y);
            var result = new Board(3).GetField(position);
            Assert.Equal(expected, result);
        }

        // [Fact] //TODO: throws a keynotfoundexception
        // public void Board_invalid_Y_position()
        // {
        //     var position = new Position(1, 3);
        //     var board = new Board(3);
        //     var result = Assert.Throws<ArgumentException>(() => board.GetField(position));
        //     Assert.Equal("Position Y coordinate is out of range", result.Message);
        // }

        // [Fact]//TODO: throws a keynotfoundexception
        // public void Board_invalid_X_position()
        // {
        //     var position = new Position(1, 3);
        //     var board = new Board(3);
        //     var result = Assert.Throws<ArgumentException>(() => board.GetField(position));
        //     Assert.Equal("Position X coordinate is out of range", result.Message);
        // }

        // [Fact]
        // public void Board_dictionary_count()
        // {
        //     var result = new Board(3).;
        //     Assert.Equal(9, result.Count);
        // }

        [Fact]
        public void Board_position_Y()
        {
            var pos1 = new Position(0, 0);
            var pos2 = new Position(1, 0);
            var pos3 = new Position(2, 0);
            var positions = new[] { pos1, pos2, pos3 };
            var count = 0;
            Assert.Equal(pos1.Y, pos2.Y);
            foreach (var position in positions)
            {
                if (position.Y == 0)
                {
                    count++;
                }
            }
            Assert.Equal(3, count);
        }
    }
}
