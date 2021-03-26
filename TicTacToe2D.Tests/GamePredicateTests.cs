using System;
using Xunit;

namespace TicTacToe2D.Tests
{
    public class GamePredicateTests
    {
        [Theory]
        [InlineData(0, 0, 1, 0, 2, 0, true)]
        [InlineData(0, 1, 1, 1, 2, 1, true)]
        [InlineData(0, 2, 1, 2, 2, 2, true)]
        public void GamePredicate_Is_a_winning_column_Player_X(int x1, int y1, int x2, int y2, int x3, int y3, bool expected)
        {
            var win = new GamePredicate();
            var board = new Board(3);
            // win if position(0,0), position(1,0) && position(2,0) all have FieldContents == 'x'
            // pos.y
            var player = Player.X;
            var pos1 = new Position(x1, y1);
            var pos2 = new Position(x2, y2);
            var pos3 = new Position(x3, y3);
            board.Dictionary[pos1] = FieldContents.x;
            board.Dictionary[pos2] = FieldContents.x;
            board.Dictionary[pos3] = FieldContents.x;
            var result = win.IsAWinningColumn(board, player);
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(0, 0, 1, 0, 2, 0, true)]
        [InlineData(0, 1, 1, 1, 2, 1, true)]
        [InlineData(0, 2, 1, 2, 2, 2, true)]
        public void GamePredicate_Is_a_winning_column_Player_Y(int x1, int y1, int x2, int y2, int x3, int y3, bool expected)
        {
            var win = new GamePredicate();
            var board = new Board(3);
            // win if position(0,0), position(1,0) && position(2,0) all have FieldContents == 'x'
            var pos1 = new Position(x1, y1);
            var pos2 = new Position(x2, y2);
            var pos3 = new Position(x3, y3);
            //var player = new Player();
            var player = Player.O;
            board.Dictionary[pos1] = FieldContents.y;
            board.Dictionary[pos2] = FieldContents.y;
            board.Dictionary[pos3] = FieldContents.y;
            var result = win.IsAWinningColumn(board, player);
            Assert.Equal(expected, result);
        }
        [Fact]
        public void GamePredicate_Is_a_winning_column_not_either_player()
        {
            var win = new GamePredicate();
            var board = new Board(3);
            board.Dictionary[new Position(0, 0)] = FieldContents.x;
            board.Dictionary[new Position(0, 1)] = FieldContents.y;
            board.Dictionary[new Position(0, 2)] = FieldContents.x;
            board.Dictionary[new Position(1, 1)] = FieldContents.x;
            board.Dictionary[new Position(1, 2)] = FieldContents.y;
            board.Dictionary[new Position(2, 0)] = FieldContents.y;
            board.Dictionary[new Position(2, 1)] = FieldContents.x;
            board.Dictionary[new Position(2, 2)] = FieldContents.y;
            Assert.Equal(false, win.IsAWinningColumn(board, Player.X));
            Assert.Equal(false, win.IsAWinningColumn(board, Player.O));
        }

        [Fact]
        public void GamePredicate_Is_a_winning_column_3_PlayerX_3PlayerY()
        {
            var win = new GamePredicate();
            var board = new Board(3);
            var pos1 = new Position(0, 0);
            board.Dictionary[pos1] = FieldContents.x;
            board.Dictionary[new Position(0, 1)] = FieldContents.y;
            board.Dictionary[new Position(0, 2)] = FieldContents.x;
            board.Dictionary[new Position(1, 1)] = FieldContents.x;
            board.Dictionary[new Position(1, 2)] = FieldContents.y;
            board.Dictionary[new Position(2, 0)] = FieldContents.y;
            
            //Assert.Equal(0, pos1.X);
            //Assert.Equal(false, win.IsAWinningColumn(board, Player.X));
            Assert.Equal(false, win.IsAWinningColumn(board, Player.O));
        }
    }
}