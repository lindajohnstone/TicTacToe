using System;
using Xunit;

namespace TicTacToe2D.Tests
{
    public class ValidationsTests
    {
        [Theory]
        [InlineData(0,1)]
        [InlineData(1,0)]
        [InlineData(1,1)]
        [InlineData(1,2)]
        [InlineData(2,1)]
        public void Player_input_is_ValidTurn_true(int x, int y)
        {
            var board = SourceData.BoardValidTurn();
            var position = new Position(x, y);
            var result = Validations.ValidTurn(board, position);
            Assert.True(result);
        }

        [Theory]
        [InlineData(0, 0)]
        [InlineData(0, 2)]
        [InlineData(2, 0)]
        [InlineData(2, 2)]
        public void Player_input_is_ValidTurn_false(int x, int y)
        {
            var board = SourceData.BoardValidTurn();
            var position = new Position(x, y);
            var result = Assert.Throws<InvalidMoveEntryException>(() => Validations.ValidTurn(board, position));
            Assert.Equal("Oh no, a piece is already at this place! Try again...", result.Message);
        }
    }
}