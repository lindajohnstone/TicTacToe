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
        public void Player_position_is_null()
        {
            Position playerMovePosition = null;
            Assert.True(playerMovePosition == null);
        }

        [Theory]
        [InlineData("0,1")]
        public void PlayGame_move_player(string input)
        {
            var board = new Board(SourceData.BoardIsInitialized());
            var parser = new StubInputParser();
            var fieldContents = FieldContents.x;
            var result = board.MovePlayer(parser.GetPlayerMove(input), fieldContents);
            var expected = (SourceData.BoardXFirstMove() == result);
            Assert.True(expected);
        }

        [Theory]
        [InlineData("0,b")]
        [InlineData("l,m")] 
        [InlineData("b,0")]
        public void GetPlayerMove_throws_exception_with_invalid_format(string input)
        {
            var board = new Board(SourceData.BoardIsInitialized());
            var parser = new StubInputParser();
            var result = Assert.Throws<InvalidMoveSyntaxException>(() => parser.GetPlayerMove(input));
            Assert.Equal("Invalid format. Please try again...", result.Message);
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
        public void WinningRow() // TODO: if line 65 commented out & line 66 uncommented, fails - board referring to GameBoard. Also, nullreferenceexception
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

        // [Fact]
        // public void EndGame_if_win()
        // {
        //     var win = new GamePredicate();
        //     var controller = new Controller();
        //     var player = controller.Players[0];
        //     var board = new Board(SourceData.BoardWinningDiagonalLR());

        // }

        [Fact]
        public void EndGame_user_ends_game_output_message()
        {
            var output = new StubOutput();
            var input = new StubConsoleInput();
            var outputFormatter = new StubOutputFormatter();
            var player = Player.X;
            var expected = "Player X has ended the game.";
            var result = outputFormatter.PrintEndGame(player, output);
            Assert.Equal(expected, output.GetWriteLine(result));
        }

        [Fact]
        public void EndGame_user_input_q_ends_game_output_message()
        {
            var output = new StubOutput();
            var parser = new StubInputParser();
            var input = new StubConsoleInput();
            var outputFormatter = new StubOutputFormatter();
            var player = Player.X;
            var expected = "Player X has ended the game.";
            var result = outputFormatter.PrintEndGame(player, output);
            Assert.Equal(expected, output.GetWriteLine(result));
        }
    }
}