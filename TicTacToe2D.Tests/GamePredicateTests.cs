using System;
using System.Collections.Generic;
using Xunit;

namespace TicTacToe2D.Tests
{
    public class GamePredicateTests
    {
        [Fact]
        public void BoardWinningRow3() 
        {
            var win = new GamePredicate();
            var board = new Board(SourceData.BoardWinningRow3());
            var result = win.IsWinningBoard(board, board.GetWinningLines(), FieldContents.x);
            Assert.True(result);
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
        
        [Fact]
        public void GamePredicate_neither_player_wins() 
        {
            var win = new GamePredicate();
            var board = new Board(SourceData.BoardNeitherXNorYWins());
            Assert.False(win.IsWinningBoard(board, board.GetWinningLines(), FieldContents.x));
            Assert.False(win.IsWinningBoard(board, board.GetWinningLines(), FieldContents.y));
        }

        [Fact]
        public void GamePredicate_Is_not_a_winning_column_3_PlayerX_3_PlayerY() 
        {
            var win = new GamePredicate();
            var board = new Board(SourceData.BoardYWinsXWins());
            Assert.False(win.IsWinningBoard(board, board.GetWinningLines(), FieldContents.x));
            Assert.False(win.IsWinningBoard(board, board.GetWinningLines(), FieldContents.y));
        }

        [Fact]
        public void GamePredicate_Y_column3_wins_X_loses() 
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
        public void IsWinningBoard_X_wins_column1() 
        {
            var board = new Board(SourceData.BoardIsWinningBoardXWinningColumn());
            var win = new GamePredicate();
            Assert.True(win.IsWinningBoard(board, board.GetWinningLines(), FieldContents.x));
        }

        [Fact]
        public void IsWinningBoard_Y_wins_Column3() 
        {
            var board = new Board(SourceData.BoardIsWinningBoardYWinningColumn());
            var win = new GamePredicate();
            Assert.True(win.IsWinningBoard(board, board.GetWinningLines(), FieldContents.y));
        }

        [Fact]
        public void BoardWinningDiagonalLR()  
        {
            var board = new Board(SourceData.BoardWinningDiagonalLR());
            var win = new GamePredicate();
            Assert.True(win.IsWinningBoard(board, board.GetWinningLines(), FieldContents.x));
        }

        [Fact]
        public void BoardWinningDiagonalRL() 
        {
            var board = new Board(SourceData.BoardWinningDiagonalRL());
            var win = new GamePredicate();
            Assert.True(win.IsWinningBoard(board, board.GetWinningLines(), FieldContents.x));
        }

        [Fact]
        public void BoardIsADraw()
        {
            var board = new Board(SourceData.BoardIsADraw());
            var condition = new GamePredicate();
            Assert.True(condition.IsADraw(board));
        }

        [Fact]
        public void BoardIsNotADraw()
        {
            var board = new Board(SourceData.BoardIsNotADraw());
            var condition = new GamePredicate();
            Assert.False(condition.IsADraw(board));
        }

        [Fact]
        public void BoardIsNotADrawV2()
        {
            var board = new Board(SourceData.BoardIsNotADrawV2());
            var condition = new GamePredicate();
            Assert.False(condition.IsADraw(board));
        }
    }
}