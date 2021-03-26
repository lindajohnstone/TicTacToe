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
    
        [Fact]
        public void Board()
        {
            var expected = new Board(3).Dictionary;
            var result = new Board(3).Dictionary;
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(0,0, true)]
        [InlineData(1,2, true)]
        [InlineData(2,0, true)]
        [InlineData(1,3, false)]
        [InlineData(6,9, false)]
        public void Board_contents(int x, int y, bool expected)
        {
            var position = new Position(x, y);
            var result = new Board(3).Dictionary.ContainsKey(position);
            Assert.Equal(expected, result);
        }

        [Fact]
        public void Board_dictionary_count()
        {
            var result = new Board(3).Dictionary;
            Assert.Equal(9, result.Count);
        }

        [Fact]
        public void Board_check_if_empty_field()
        {
            var result = new Board(3).Dictionary.ContainsValue(FieldContents.empty);
            Assert.Equal(true, result);
        }

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
        public void Board_dictionary_key_value_match_using_fluent_assertions(int x, int y, FieldContents value)
        {
            var position = new Position(x, y);
            var board = new Board(3).Dictionary;
            foreach (KeyValuePair<Position, FieldContents> kvp in board)
            {
                board.Should().Contain(position, value);
            }
        }

        [Fact]
        public void testName()
        {
            var board = new Board(3).Dictionary;
            var pos1 = new Position(0, 0);
            var pos2 = new Position(1, 0);
            var pos3 = new Position(2, 0);
            var count = 0;
            Assert.Equal(pos1.Y, pos2.Y);
            foreach (var position in board)
            {
                if (position.Key.Y == 0)
                {
                    count++;
                }
            }
            Assert.Equal(3, count);
        }
    }
}
