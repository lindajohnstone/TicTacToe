using FluentAssertions;
using Xunit;

namespace TicTacToe2D.Tests
{
    public class PositionTests
    {
        [Theory]
        [InlineData(1, 2)]
        [InlineData(0, 2)]
        [InlineData(1, 5)]
        [InlineData(0, 0)]
        [InlineData(1, 1)]
        [InlineData(100, 300000)]
        [InlineData(-10, -30)]
        public void Position(int x, int y)
        {
            var input = new[] { x, y };
            var result = new Position2D(input[0], input[1]);
            var expected = input;
            Assert.Equal(expected[0], result.X);
            Assert.Equal(expected[1], result.Y);
        }

        [Theory]
        [InlineData(1, 2, 1, 2, true)]
        [InlineData(2, 3, 2, 3, true)]
        [InlineData(1000, 2000, 1000, 2000, true)]
        [InlineData(133, 32, 33, 32, false)]
        [InlineData(1000, 2000, 2000, 2000, false)]
        [InlineData(1, 3, 2, 3, false)]
        public void Position_equals(int x1, int y1, int x2, int y2, bool expected)
        {
            var one = new Position2D(x1, y1);
            var two = new Position2D(x2, y2);
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
            var one = new Position2D(x1, y1);
            var two = new Position2D(x2, y2);
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
            var one = new Position2D(x1, y1);
            var two = new Position2D(x2, y2);
            if (expected) one.Should().Be(two);
            else one.Should().NotBe(two);
        }
    }
}