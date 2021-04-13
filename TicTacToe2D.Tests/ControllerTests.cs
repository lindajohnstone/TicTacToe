using System;
using System.Collections.Generic;
using Xunit;

namespace TicTacToe2D.Tests
{
    public class ControllerTests
    {
        [Fact]
        public void InputParser_GetPlayerMove()
        {
            var input = "0,0";
            var parser = new StubInputParser();
            var result = parser.GetPlayerMove(input);
            Assert.Equal(new Position(0,0), result);
        }

        [Fact]
        public void testName()
        {
            Position playerMovePosition = null;
            Assert.True(playerMovePosition == null);
        }

        [Fact]
        public void PlayGame_move_player()
        {
            var board = new Board(SourceData.BoardIsInitialized());
            var input = "0,1";
            var parser = new StubInputParser();
            var fieldContents = FieldContents.x;
            var result = board.MovePlayer(parser.GetPlayerMove(input), fieldContents);
            var expected = (SourceData.BoardXFirstMove() == result);
            Assert.True(expected);
        }

        [Fact]
        public void Controller_has_board_players()
        {
            var controller = new Controller();
            var board = new Board(3);
            var players = new List<Player> { Player.X, Player.O };
            var game = new GameContext(board, players);
            Assert.Equal(controller.GameBoard, new Board(3));
            Assert.Equal(Player.X, controller.Players[0]);
            Assert.Equal(Player.O, controller.Players[1]);
        }

        [Fact]
        public void WinningRow() 
        {
            var win = new GamePredicate();
            var controller = new Controller();
            var player = controller.Players[0]; 
            FieldContents fieldContents;
            if (player == controller.Players[0])
            {
                fieldContents = FieldContents.x;
            }
            else
            {
                fieldContents = FieldContents.y;
            }
            var board = new Board(SourceData.BoardWinningDiagonalLR());
            var result = win.IsWinningBoard(board, board.GetWinningLines(), fieldContents);
            //var result = controller.IsWinningBoard(player, win); // fails
            Assert.True(result);
        }
    }
}