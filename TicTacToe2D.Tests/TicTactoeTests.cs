using System;
using Xunit;

namespace TicTacToe2D.Tests
{
    public class TicTactoeTests
    {
        [Theory]
        [InlineData(1,2)]
        [InlineData(0,2)]
        [InlineData(1,2)]
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
        public void Position_equals(int x1, int y1, int x2, int y2, bool expected)
        {
            var one = new Position(x1, y1);
            var two = new Position(x2, y2);
            var result = (one == two);
            Assert.Equal(expected, result);
        }
    }
}
