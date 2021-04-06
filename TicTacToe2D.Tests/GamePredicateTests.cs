using System;
using System.Collections.Generic;
using Xunit;

namespace TicTacToe2D.Tests
{
    public class GamePredicateTests
    {
        [Theory] //TODO: update to new format
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
        [Fact]
        public void BoardYWinningCentreRow()
        {
            var board = new Board(SourceData.BoardYWinningCentreRow());
            var win = new GamePredicate();
            var result = win.IsWinningBoard(board, board.GetWinningLines(), FieldContents.y);
            Assert.True(result);
        }
        
        [Fact]
        public void BoardXWinningTopRow()
        {
            var board = new Board(SourceData.BoardXWinningTopRow());
            var win = new GamePredicate();
            var result = win.IsWinningBoard(board, board.GetWinningLines(), FieldContents.x);
            Assert.True(result);
        }

        [Fact]
        public void IsWinningBoard_true()
        {
            var board = new Board(SourceData.BoardIsWinningBoardTrue());
            var win = new GamePredicate();
            Assert.True(win.IsWinningBoard(board, board.GetWinningLines(), FieldContents.x));
            Assert.True(win.IsWinningBoard(board, board.GetWinningLines(), FieldContents.y));
        }

        [Theory]//TODO: update to new format
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
        public void GamePredicate_neither_player_wins()
        {
            var win = new GamePredicate();
            var board = new Board(SourceData.BoardNeitherXNorYWins());
            Assert.False(win.IsWinningBoard(board, board.GetWinningLines(), FieldContents.x));
            Assert.False(win.IsWinningBoard(board, board.GetWinningLines(), FieldContents.y));
        }

        [Fact]
        public void GamePredicate_Is_a_winning_column_3_PlayerX_3PlayerY()
        {
            var win = new GamePredicate();
            var board = new Board(SourceData.BoardYWinsXWins());
            Assert.False(win.IsWinningBoard(board, board.GetWinningLines(), FieldContents.x));
            Assert.False(win.IsWinningBoard(board, board.GetWinningLines(), FieldContents.y));
        }

        [Fact]
        public void GamePredicate_Y_wins_X_loses()
        {
            var win = new GamePredicate();
            var board = new Board(SourceData.BoardYWinsXLoses());
            Assert.False(win.IsWinningBoard(board, board.GetWinningLines(), FieldContents.x));
            Assert.True(win.IsWinningBoard(board, board.GetWinningLines(), FieldContents.y));
        }

        [Fact]
        public void IsWinningBoard_false()
        {
            var board = new Board(SourceData.BoardIsWinningBoardFalse());
            var win = new GamePredicate();
            Assert.False(win.IsWinningBoard(board, board.GetWinningLines(), FieldContents.x));
            Assert.False(win.IsWinningBoard(board, board.GetWinningLines(), FieldContents.y));
        }

        [Theory]//TODO: update to new format
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

        [Fact]//TODO: update to new format
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
            Assert.False(result);
        }
        [Fact]
        public void IsWinningBoard_X_wins()
        {
            var board = new Board(SourceData.BoardIsWinningBoardXWinningColumn());
            var win = new GamePredicate();
            Assert.True(win.IsWinningBoard(board, board.GetWinningLines(), FieldContents.x));
        }
        [Fact]
        public void IsWinningBoard_Y_wins()
        {
            var board = new Board(SourceData.BoardIsWinningBoardYWinningColumn());
            var win = new GamePredicate();
            Assert.True(win.IsWinningBoard(board, board.GetWinningLines(), FieldContents.y));
        }
    }
}