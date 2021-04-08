using System;
using System.Collections.Generic;
using Xunit;

namespace TicTacToe2D.Tests
{
    public class GameContextTests
    {
        [Fact]
        public void GameContext_has_players()
        {
            var result = new GameContext().Players;
            Assert.Equal(Player.X, result[0]);
            Assert.Equal(Player.O, result[1]);
        }

        [Fact]
        public void GameContext_has_board()
        {
            var result = new GameContext().GameBoard;
            Assert.Equal(3, result.Width);
            Assert.Equal(3, result.Height);
        }


    }
}