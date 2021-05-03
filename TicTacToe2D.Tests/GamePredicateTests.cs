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
            var board = new Board2D(SourceData.BoardWinningRow3());
            var result = GamePredicate.IsWinningBoard(board, board.GetWinningLines(), FieldContents.x);
            Assert.True(result);
        }
        [Fact]
        public void BoardYWinningCentreRow() 
        {
            var board = new Board2D(SourceData.BoardYWinningCentreRow());
            var result = GamePredicate.IsWinningBoard(board, board.GetWinningLines(), FieldContents.y);
            Assert.True(result);
        }
        
        [Fact]
        public void BoardXWinningTopRow() 
        {
            var board = new Board2D(SourceData.BoardXWinningTopRow());
            var result = GamePredicate.IsWinningBoard(board, board.GetWinningLines(), FieldContents.x);
            Assert.True(result);
        }

        [Fact]
        public void IsWinningBoard_true() 
        {
            var board = new Board2D(SourceData.BoardIsWinningBoardTrue());
            Assert.True(GamePredicate.IsWinningBoard(board, board.GetWinningLines(), FieldContents.x));
            Assert.True(GamePredicate.IsWinningBoard(board, board.GetWinningLines(), FieldContents.y));
        }
        
        [Fact]
        public void GamePredicate_neither_player_wins() 
        {
            var board = new Board2D(SourceData.BoardNeitherXNorYWins());
            Assert.False(GamePredicate.IsWinningBoard(board, board.GetWinningLines(), FieldContents.x));
            Assert.False(GamePredicate.IsWinningBoard(board, board.GetWinningLines(), FieldContents.y));
        }

        [Fact]
        public void GamePredicate_Is_not_a_winning_column_3_PlayerX_3_PlayerY() 
        {
            var board = new Board2D(SourceData.BoardYWinsXWins());
            Assert.False(GamePredicate.IsWinningBoard(board, board.GetWinningLines(), FieldContents.x));
            Assert.False(GamePredicate.IsWinningBoard(board, board.GetWinningLines(), FieldContents.y));
        }

        [Fact]
        public void GamePredicate_Y_column3_wins_X_loses() 
        {
            var board = new Board2D(SourceData.BoardYWinsXLoses());
            Assert.False(GamePredicate.IsWinningBoard(board, board.GetWinningLines(), FieldContents.x));
            Assert.True(GamePredicate.IsWinningBoard(board, board.GetWinningLines(), FieldContents.y));
        }

        [Fact]
        public void IsWinningBoard_false()
        {
            var board = new Board2D(SourceData.BoardIsWinningBoardFalse());
            Assert.False(GamePredicate.IsWinningBoard(board, board.GetWinningLines(), FieldContents.x));
            Assert.False(GamePredicate.IsWinningBoard(board, board.GetWinningLines(), FieldContents.y));
        }

        [Fact]
        public void IsWinningBoard_X_wins_column1() 
        {
            var board = new Board2D(SourceData.BoardIsWinningBoardXWinningColumn());
            Assert.True(GamePredicate.IsWinningBoard(board, board.GetWinningLines(), FieldContents.x));
        }

        [Fact]
        public void IsWinningBoard_Y_wins_Column3() 
        {
            var board = new Board2D(SourceData.BoardIsWinningBoardYWinningColumn());
            Assert.True(GamePredicate.IsWinningBoard(board, board.GetWinningLines(), FieldContents.y));
        }

        [Fact]
        public void BoardWinningDiagonalLR()  
        {
            var board = new Board2D(SourceData.BoardWinningDiagonalLR());
            Assert.True(GamePredicate.IsWinningBoard(board, board.GetWinningLines(), FieldContents.x));
        }

        [Fact]
        public void BoardWinningDiagonalRL() 
        {
            var board = new Board2D(SourceData.BoardWinningDiagonalRL());
            Assert.True(GamePredicate.IsWinningBoard(board, board.GetWinningLines(), FieldContents.x));
        }

        [Fact]
        public void BoardIsADraw()
        {
            var board = new Board2D(SourceData.BoardIsADraw());
            Assert.True(GamePredicate.IsADraw(board));
        }

        [Fact]
        public void BoardIsNotADraw()
        {
            var board = new Board2D(SourceData.BoardIsNotADraw());
            Assert.False(GamePredicate.IsADraw(board));
        }

        [Fact]
        public void BoardIsNotADrawV2()
        {
            var board = new Board2D(SourceData.BoardIsNotADrawV2());
            Assert.False(GamePredicate.IsADraw(board));
        }
    }
}