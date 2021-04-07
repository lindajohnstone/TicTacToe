using System;
using System.Collections.Generic;
using Xunit;

namespace TicTacToe2D.Tests
{
    public class GamePredicateTests
    {
        [Fact]
        public void BoardWinningRow3() // TODO: failing - ROW - "Position X coordinate is out of range"
        {
            var win = new GamePredicate();
            var board = new Board(SourceData.BoardWinningRow3());
            var result = win.IsWinningBoard(board, board.GetWinningLines(), FieldContents.x);
            Assert.True(result);
        }
        [Fact]
        public void BoardYWinningCentreRow() // TODO: failing - ROW
        {
            var board = new Board(SourceData.BoardYWinningCentreRow());
            var win = new GamePredicate();
            var result = win.IsWinningBoard(board, board.GetWinningLines(), FieldContents.y);
            Assert.True(result);
        }
        
        [Fact]
        public void BoardXWinningTopRow() // ROW
        {
            var board = new Board(SourceData.BoardXWinningTopRow());
            var win = new GamePredicate();
            var result = win.IsWinningBoard(board, board.GetWinningLines(), FieldContents.x);
            Assert.True(result);
        }

        [Fact]
        public void IsWinningBoard_true() // TODO: - failing line 41 - COLUMN
        {
            var board = new Board(SourceData.BoardIsWinningBoardTrue());
            var win = new GamePredicate();
            Assert.True(win.IsWinningBoard(board, board.GetWinningLines(), FieldContents.x));
            Assert.True(win.IsWinningBoard(board, board.GetWinningLines(), FieldContents.y));
        }
        
        [Fact]
        public void GamePredicate_neither_player_wins() //TODO: failing
        {
            var win = new GamePredicate();
            var board = new Board(SourceData.BoardNeitherXNorYWins());
            Assert.False(win.IsWinningBoard(board, board.GetWinningLines(), FieldContents.x));
            Assert.False(win.IsWinningBoard(board, board.GetWinningLines(), FieldContents.y));
        }

        [Fact]
        public void GamePredicate_Is_not_a_winning_column_3_PlayerX_3_PlayerY() // TODO: failing
        {
            var win = new GamePredicate();
            var board = new Board(SourceData.BoardYWinsXWins());
            Assert.False(win.IsWinningBoard(board, board.GetWinningLines(), FieldContents.x));
            Assert.False(win.IsWinningBoard(board, board.GetWinningLines(), FieldContents.y));
        }

        [Fact]
        public void GamePredicate_Y_column3_wins_X_loses() // TODO: failing - COLUMN
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

        [Fact]
        public void IsWinningBoard_X_wins_column1() // COLUMN
        {
            var board = new Board(SourceData.BoardIsWinningBoardXWinningColumn());
            var win = new GamePredicate();
            Assert.True(win.IsWinningBoard(board, board.GetWinningLines(), FieldContents.x));
        }

        [Fact]
        public void IsWinningBoard_Y_wins_Column3() // TODO: failing - COLUMN
        {
            var board = new Board(SourceData.BoardIsWinningBoardYWinningColumn());
            var win = new GamePredicate();
            Assert.True(win.IsWinningBoard(board, board.GetWinningLines(), FieldContents.y));
        }

        [Fact]
        public void BoardWinningDiagonalLR() // TODO: failing 
        {
            var board = new Board(SourceData.BoardWinningDiagonalLR());
            var win = new GamePredicate();
            Assert.True(win.IsWinningBoard(board, board.GetWinningLines(), FieldContents.x));
        }

        [Fact]
        public void BoardWinningDiagonalRL() // TODO: failing 
        {
            var board = new Board(SourceData.BoardWinningDiagonalRL());
            var win = new GamePredicate();
            Assert.True(win.IsWinningBoard(board, board.GetWinningLines(), FieldContents.x));
        }
    }
}