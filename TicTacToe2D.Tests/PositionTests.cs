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
            var result = TicTacToe2D.Position.Factory_2DPosition(input[0], input[1]);
            var expected = input;
            Assert.Equal(expected[0], result.GetPosition(0));
            Assert.Equal(expected[1], result.GetPosition(1));
            Assert.Equal(2, result.DimensionCount);
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
            var one = TicTacToe2D.Position.Factory_2DPosition(x1, y1);
            var two = TicTacToe2D.Position.Factory_2DPosition(x2, y2);
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
            var one = TicTacToe2D.Position.Factory_2DPosition(x1, y1);
            var two = TicTacToe2D.Position.Factory_2DPosition(x2, y2);
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
        public void Position2D_equals_using_fluentassertions(int x1, int y1, int x2, int y2, bool expected)
        {
            var one = TicTacToe2D.Position.Factory_2DPosition(x1, y1);
            var two = TicTacToe2D.Position.Factory_2DPosition(x2, y2);
            if (expected) one.Should().Equal(two);
            else one.Should().NotEqual(two);
        }

        [Theory]
        [InlineData(1, 2, 3)]
        [InlineData(0, 2, 4)]
        [InlineData(1, 5, 2)]
        [InlineData(0, 0, 0)]
        [InlineData(1, 1, 0)]
        [InlineData(100, 300000, 9)]
        [InlineData(-10, -30, -100)]
        public void Position_3D(int x, int y, int z)
        {
            var input = new[] { x, y, z };
            var result = TicTacToe2D.Position.Factory_3DPosition(input[0], input[1], input[2]);
            var expected = input;
            Assert.Equal(expected[0], result.GetPosition(0));
            Assert.Equal(expected[1], result.GetPosition(1));
            Assert.Equal(expected[2], result.GetPosition(2));
            Assert.Equal(3, result.DimensionCount);
        }

        [Theory]
        [InlineData(1, 2, 3, 1, 2, 3, true)]
        [InlineData(2, 3, 4, 2, 3, 4, true)]
        [InlineData(1000, 2000, 3000, 1000, 2000, 3000, true)]
        [InlineData(133, 32, 13, 33, 32, 13, false)]
        [InlineData(1000, 2000, 2000, 2000, 2000, 2000, false)]
        [InlineData(1, 3, 2, 3, 2, 1, false)]
        public void Position_equals_operator_3D(int x1, int y1, int z1, int x2, int y2, int z2, bool expected)
        {
            var one = TicTacToe2D.Position.Factory_3DPosition(x1, y1, z1);
            var two = TicTacToe2D.Position.Factory_3DPosition(x2, y2, z2);
            var result = (one == two);
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(0,0,0,0,0,1,false)]
        [InlineData(1, 2, 3, 1, 2, 3, true)]
        [InlineData(2, 3, 4, 2, 3, 4, true)]
        [InlineData(1000, 2000, 3000, 1000, 2000, 3000, true)]
        [InlineData(133, 32, 13, 33, 32, 13, false)]
        [InlineData(1000, 2000, 2000, 2000, 2000, 2000, false)]
        [InlineData(1, 3, 2, 3, 2, 1, false)]
        public void Position_equals_using_fluentassertions_3D(int x1, int y1, int z1, int x2, int y2, int z2, bool expected)
        {
            var one = TicTacToe2D.Position.Factory_3DPosition(x1, y1, z1);
            var two = TicTacToe2D.Position.Factory_3DPosition(x2, y2, z2);
            if (expected) one.Should().Equal(two);
            else one.Should().NotEqual(two);
        }
    }
}