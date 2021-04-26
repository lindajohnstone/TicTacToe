using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace TicTacToe2D.Tests
{
    public class GameContextTests
    {
        [Fact]
        public void GameContext_has_players()
        {
            var board = new Board(3);
            var players = new List<Player> { Player.X, Player.O }; 
            var result = new GameContext(board, players).Players;
            Assert.Equal(Player.X, result[0]);
            Assert.Equal(Player.O, result[1]);
        }

        [Fact]
        public void GameContext_has_board()
        {
            var board = new Board(3);
            var players = new List<Player> { Player.X, Player.O };
            var result = new GameContext(board, players).GameBoard;
            Assert.Equal(3, result.Width);
            Assert.Equal(3, result.Height);
        }

        [Fact]
        public void GameContext_get_current_player()  
        {
            var board = new Board(3);
            var players = new List<Player> { Player.X, Player.O };
            var game = new GameContext(board, players);
            var result = game.GetCurrentPlayer();
            var expected = Player.X;
            Assert.Equal(expected, result);
        }

        [Fact]
        public void Check_count_of_empty_fields()
        {
            var board = SourceData.BoardIsInitialized();
            var result = board.GetAllPositions().Where((x) => board.GetField(x) == FieldContents.empty);
            Assert.Equal(9, result.Count());
        }

        [Fact]
        public void GetPlayers_from_Player_enum()
        {
            var board = new Board(3);
            var players = new List<Player>();
            var game = new GameContext(board, players);
            var result = game.GetPlayers();
            var expected = new List<Player>() { Player.X, Player.O };
            Assert.Equal(expected, result);
        }
    }
}