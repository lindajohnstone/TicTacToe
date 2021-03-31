using System;
using Xunit;
using FluentAssertions;
using System.Collections.Generic;

namespace TicTacToe2D.Tests
{
    public class BoardTests
    {
        public Board BoardIsWinningBoardTrue() {
            var initData = new FieldContents[][] {
                new []{FieldContents.x, FieldContents.y, FieldContents.empty},
                new []{FieldContents.x, FieldContents.y, FieldContents.empty},
                new []{FieldContents.x, FieldContents.y, FieldContents.empty}
            };
            return new Board(initData);
        }
        
        public Board BoardIsWinningBoardFalse() {
            var initData = new FieldContents[][] {
                new []{FieldContents.x,     FieldContents.x,     FieldContents.empty},
                new []{FieldContents.y,     FieldContents.empty, FieldContents.y},
                new []{FieldContents.empty, FieldContents.x,     FieldContents.y}
            };
            return new Board(initData);
        }

        public Board BoardIsWinningBoardXWinningColumn()
        {
            var initData = new FieldContents[][] {
                new []{FieldContents.x, FieldContents.y, FieldContents.empty},
                new []{FieldContents.x, FieldContents.y, FieldContents.empty},
                new []{FieldContents.x, FieldContents.empty, FieldContents.empty}
            };
            return new Board(initData);
        }

        public Board BoardIsWinningBoardYWinningColumn()
        {
            var initData = new FieldContents[][] {
                new []{FieldContents.x,     FieldContents.y, FieldContents.empty},
                new []{FieldContents.x,     FieldContents.y, FieldContents.x},
                new []{FieldContents.empty, FieldContents.y, FieldContents.empty}
            };
            return new Board(initData);
        }

        [Theory]
        [InlineData(3)]
        public void Board_dimensions(int dimensionLength)
        {
            var expected = dimensionLength;
            var result = new Board(dimensionLength);
            Assert.Equal(expected, result.Width);
            Assert.Equal(expected, result.Height);
        }

        [Theory]
        [InlineData(0, 0, FieldContents.x)]
        [InlineData(0, 1, FieldContents.y)]
        [InlineData(0, 2, FieldContents.empty)]
        [InlineData(1, 0, FieldContents.x)]
        [InlineData(1, 1, FieldContents.y)]
        [InlineData(1, 2, FieldContents.empty)]
        [InlineData(2, 0, FieldContents.x)]
        [InlineData(2, 1, FieldContents.y)]
        [InlineData(2, 2, FieldContents.empty)]
        public void Board_has_valid_fields(int x, int y, FieldContents expected)
        {
            var position = new Position(x, y);
            var result = BoardIsWinningBoardTrue().GetField(position);
            Assert.Equal(expected, result);
        }

        [Fact]
        public void IsWinningBoard_true()
        {
            var board = new Board(BoardIsWinningBoardTrue());
            var win = new GamePredicate();
            Assert.Equal(true, win.IsWinningBoard(board, board.GetWinningLines(), FieldContents.x));
            Assert.Equal(true, win.IsWinningBoard(board, board.GetWinningLines(), FieldContents.y));
        }

        [Fact]
        public void IsWinningBoard_false()
        {
            var board = new Board(BoardIsWinningBoardFalse());
            var win = new GamePredicate();
            Assert.Equal(false, win.IsWinningBoard(board, board.GetWinningLines(), FieldContents.x));
            Assert.Equal(false, win.IsWinningBoard(board, board.GetWinningLines(), FieldContents.y));
        }

        [Fact] 
        public void Board_invalid_Y_position()
        {
            var position = new Position(1, 3);
            var board = new Board(3);
            var result = Assert.Throws<ArgumentException>(() => board.GetField(position));
            Assert.Equal("Position Y coordinate is out of range", result.Message);
        }

        [Fact]
        public void Board_invalid_X_position()
        {
            var position = new Position(6, 0);
            var board = new Board(3);
            var result = Assert.Throws<ArgumentException>(() => board.GetField(position));
            Assert.Equal("Position X coordinate is out of range", result.Message);
        }

        [Fact]
        public void IsWinningBoard_X_wins()
        {
            var board = new Board(BoardIsWinningBoardXWinningColumn());
            var win = new GamePredicate();
            Assert.Equal(true, win.IsWinningBoard(board, board.GetWinningLines(), FieldContents.x));
        }

        [Fact]
        public void IsWinningBoard_Y_wins()
        {
            var board = new Board(BoardIsWinningBoardYWinningColumn());
            var win = new GamePredicate();
            Assert.Equal(true, win.IsWinningBoard(board, board.GetWinningLines(), FieldContents.y));
        }

        [Fact]
        public void Board_position_Y()
        {
            var pos1 = new Position(0, 0);
            var pos2 = new Position(1, 0);
            var pos3 = new Position(2, 0);
            var positions = new[] { new Position(0, 0), pos2, pos3 };
            var count = 0;
            Assert.Equal(pos1.Y, pos2.Y);
            foreach (var position in positions)
            {
                if (position.Y == 0)
                {
                    count++;
                }
            }
            Assert.Equal(3, count);
        }
    }
}
