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
            var result = InputParser.GetPlayerMove(input);
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
            var fieldContents = FieldContents.x;
            var result = board.MovePlayer(InputParser.GetPlayerMove(input), fieldContents);
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
            var result = Assert.Throws<InvalidMoveSyntaxException>(() => InputParser.GetPlayerMove(input));
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
        public void WinningRow() 
        {
            var win = new GamePredicate();
            var controller = new Controller();
            var player = controller.Players[0]; 
            var board = new Board(SourceData.BoardWinningDiagonalLR());
            var result = win.IsWinningBoard(board, board.GetWinningLines(), FieldContents.x);
            Assert.True(result);
        }

        [Fact]
        public void EndGame_win_output_message() //TODO: valid test? check if a win before printing?
        {
            var output = new StubOutput();
            var controller = new Controller();
            var condition = new GamePredicate();
            var player = controller.Players[0];
            var board = new Board(SourceData.BoardWinningDiagonalLR());
            var expected = "Hooray! Player 1 has won the game!";
            OutputFormatter.PrintWinGame(player, output);
            Assert.Equal(expected, output.GetWriteLine());
        }

        [Fact]
        public void EndGame_user_ends_game_output_message()
        {
            var output = new StubOutput();
            var player = Player.X;
            var expected = "Player 1 has ended the game.";
            OutputFormatter.PrintEndGame(player, output);
            Assert.Equal(expected, output.GetWriteLine());
        }

        [Fact]
        public void EndGame_drawn_game_output_message()
        {
            var output = new StubOutput();
            var draw = new GamePredicate();
            var board = new Board(SourceData.BoardIsADraw());
            var expected = "Game is drawn. Better luck next time.";
            OutputFormatter.PrintDrawnGame(board, draw, output);
            Assert.Equal(expected, output.GetWriteLine());
        }

        [Fact]
        public void PlayerEndsGame_user_input_as_string_q_ends_game_outputs_message()
        {
            var output = new StubOutput();
            var player = Player.X;
            var playerInput = "q";
            var expected = "Player 1 has ended the game.";
            InputParser.PlayerEndsGame(player, playerInput, output);
            Assert.Equal(expected, output.GetWriteLine());
            Assert.True(InputParser.PlayerEndsGame(player, playerInput, output));
        }

        [Fact]
        public void PlayerEndsGame_user_input_q_ends_game_outputs_message()
        {
            var output = new StubOutput();
            var player = Player.X;
            var playerInput = "q";
            var input = new StubConsoleInput().WithReadLine(playerInput);
            var expected = "Player 1 has ended the game.";
            InputParser.PlayerEndsGame(player, input, output);
            Assert.Equal(expected, output.GetWriteLine());
            Assert.True(InputParser.PlayerEndsGame(player, input, output));
        }
    }
}