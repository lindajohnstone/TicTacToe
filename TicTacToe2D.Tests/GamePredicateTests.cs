using System;
using System.Collections.Generic;
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
            var pos1 = new Position(x1, y1);
            var pos2 = new Position(x2, y2);
            var pos3 = new Position(x3, y3);
            board.SetField(pos1, FieldContents.x);
            board.SetField(pos2, FieldContents.x);
            board.SetField(pos3, FieldContents.x);
            var result = win.IsWinningBoard(board, board.GetWinningLines(), FieldContents.x);
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
            var pos1 = new Position(x1, y1);
            var pos2 = new Position(x2, y2);
            var pos3 = new Position(x3, y3);
            board.SetField(pos1, FieldContents.y);
            board.SetField(pos2, FieldContents.y);
            board.SetField(pos3, FieldContents.y);
            var result = win.IsWinningBoard(board, board.GetWinningLines(), FieldContents.y);
            Assert.Equal(expected, result);
        }
        
        [Fact]
        public void GamePredicate_Is_a_winning_column_not_either_player()
        {
            var win = new GamePredicate();
            var board = new Board(3);
            board.SetField(new Position(0, 0), FieldContents.x);
            board.SetField(new Position(0, 1), FieldContents.y);
            board.SetField(new Position(0, 2), FieldContents.x);
            board.SetField(new Position(1, 1), FieldContents.x);
            board.SetField(new Position(1, 2), FieldContents.y);
            board.SetField(new Position(2, 0), FieldContents.y);
            board.SetField(new Position(2, 1), FieldContents.x);
            board.SetField(new Position(2, 2), FieldContents.y);
            Assert.Equal(false, win.IsWinningBoard(board, board.GetWinningLines(), FieldContents.x));
            Assert.Equal(false, win.IsWinningBoard(board, board.GetWinningLines(), FieldContents.y));
        }

        [Fact]
        public void GamePredicate_Is_a_winning_column_3_PlayerX_3PlayerY()
        {
            var win = new GamePredicate();
            var board = new Board(3);
            board.SetField(new Position(0, 0), FieldContents.x);
            board.SetField(new Position(0, 1), FieldContents.y);
            board.SetField(new Position(0, 2), FieldContents.x);
            board.SetField(new Position(1, 1), FieldContents.x);
            board.SetField(new Position(1, 2), FieldContents.y);
            board.SetField(new Position(2, 0), FieldContents.y);
            Assert.Equal(false, win.IsWinningBoard(board, board.GetWinningLines(), FieldContents.x));
            Assert.Equal(false, win.IsWinningBoard(board, board.GetWinningLines(), FieldContents.y));
        }

        [Fact]
        public void GamePredicate_Is_a_winning_column_v4()
        {
            var win = new GamePredicate();
            var board = new Board(3);
            board.SetField(new Position(0, 0), FieldContents.x);
            board.SetField(new Position(0, 2), FieldContents.y);
            board.SetField(new Position(1, 0), FieldContents.x);
            board.SetField(new Position(1, 1), FieldContents.y);
            board.SetField(new Position(1, 2), FieldContents.y);
            board.SetField(new Position(2, 1), FieldContents.x);
            board.SetField(new Position(2, 2), FieldContents.y);
            Assert.Equal(false, win.IsWinningBoard(board, board.GetWinningLines(), FieldContents.x));
            Assert.Equal(true, win.IsWinningBoard(board, board.GetWinningLines(), FieldContents.y));
        }

        [Theory]
        [InlineData(0, 0, 1, 0, 2, 0, FieldContents.x, true)]
        [InlineData(0, 0, 1, 0, 2, 0, FieldContents.y, false)]
        public void GamePredicate_IsWinningBoard_true(int x1, int y1, int x2, int y2, int x3, int y3, FieldContents fieldContents, bool expected)
        {
            var win = new GamePredicate();
            var board = new Board(3);
            var winningList = new List<Position>();
            winningList.Add(new Position(x1, y1));
            winningList.Add(new Position(x2, y2));
            winningList.Add(new Position(x3, y3));
            board.SetField(new Position(x1, y1), FieldContents.x);
            board.SetField(new Position(x2, y2), FieldContents.x);
            board.SetField(new Position(x3, y3), FieldContents.x);
            var result = win.IsWinningBoard(board, board.GetWinningLines(), fieldContents);
            Assert.Equal(expected, result);
        }

        [Fact]
        public void GamePredicate_IsWinningBoard_false()
        {
            var win = new GamePredicate();
            var board = new Board(3);
            var winningList = new List<Position>();
            winningList.Add(new Position(0, 0));
            winningList.Add(new Position(1, 0));
            winningList.Add(new Position(2, 0));
            board.SetField(new Position(0, 0), FieldContents.y);
            board.SetField(new Position(1, 0), FieldContents.y);
            board.SetField(new Position(2, 0), FieldContents.y);
            var result = win.IsWinningBoard(board, board.GetWinningLines(), FieldContents.x);
            Assert.Equal(false, result);
        }
    }
}