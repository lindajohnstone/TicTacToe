using System;
using Xunit;

namespace TicTacToe2D.Tests
{
    public class GameContextTests
    {
        [Fact]
        public void GameContext_has_board()
        {
            var player = new Player();
            var board = new Board(3);
            var validations = new Validations();
            var conditions = new GamePredicate();
            var result = new GameContext(player, board, validations, conditions);
            Assert.Equal(player, result.Player);
            Assert.Equal(3, board.Width);
            Assert.Equal(3, board.Height);
        }
    }
}