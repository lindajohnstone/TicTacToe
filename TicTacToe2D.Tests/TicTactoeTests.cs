using System;
using Xunit;
using FluentAssertions;
using System.Collections.Generic;

namespace TicTacToe2D.Tests
{
    public class TicTactoeTests
    {
        [Theory]
        [InlineData(1,2)]
        [InlineData(0,2)]
        [InlineData(1,5)]
        [InlineData(0,0)]
        [InlineData(1,1)]
        [InlineData(100, 300000)]
        [InlineData(-10, -30)]
        public void Position(int x, int y)
        {
            var input = new[] { x, y };
            var result = new Position(input[0], input[1]);
            var expected = input;
            Assert.Equal(expected[0], result.X);
            Assert.Equal(expected[1], result.Y);
        }

        [Theory]
        [InlineData(1,2,1,2, true)]
        [InlineData(2,3,2,3,true)]
        [InlineData(1000, 2000, 1000, 2000, true)]
        [InlineData(133, 32, 33, 32, false)]
        [InlineData(1000, 2000, 2000, 2000, false)]
        [InlineData(1,3,2,3,false)]
        public void Position_equals(int x1, int y1, int x2, int y2, bool expected)
        {
            var one = new Position(x1, y1);
            var two = new Position(x2, y2);
            var result = (one.Equals(two));
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(1, 2, 1, 2, true)]
        [InlineData(2, 3, 2, 3, true)]
        [InlineData(1000, 2000, 1000, 2000, true)]
        [InlineData(133, 32, 33, 32, false)]
        [InlineData(1000, 2000, 2000, 2000, false)]
        [InlineData(1, 3, 2, 3, false)]
        public void Position_equals_operator(int x1, int y1, int x2, int y2, bool expected)
        {
            var one = new Position(x1, y1);
            var two = new Position(x2, y2);
            var result = (one == two);
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(1, 2, 1, 2, true)]
        [InlineData(2, 3, 2, 3, true)]
        [InlineData(1000, 2000, 1000, 2000, true)]
        [InlineData(133, 32, 33, 32, false)]
        [InlineData(1000, 2000, 2000, 2000, false)]
        [InlineData(1, 3, 2, 3, false)]
        public void Position_equals_using_fluentassertions(int x1, int y1, int x2, int y2, bool expected)
        {
            var one = new Position(x1, y1);
            var two = new Position(x2, y2);
            if(expected) one.Should().Be(two);
            else one.Should().NotBe(two);
        }

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
        public void GamePredicate_Is_a_winning_column()
        {
            var game = new GameContext();
            var win = new GamePredicate(game);
            var board = new Board(3);
            // win if position(0,0), position(1,0) && position(2,0) all have FieldContents == 'x'
            var pos1 = new Position(0, 0);
            var pos2 = new Position(1, 0);
            var pos3 = new Position(2, 0);
            board.Dictionary[pos1] = FieldContents.x;
            board.Dictionary[pos2] = FieldContents.x;
            board.Dictionary[pos3] = FieldContents.x;
            var result = win.IsAWinningColumn(game);
            Assert.Equal(true, result);
        }
    }
}
