using System;
using System.Collections;
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
            var board = new Board(3);
            var controller = new Controller(board);
            var players = new List<Player> { Player.X, Player.O };
            var game = new GameContext(board, players);
            Assert.Equal(controller.GameBoard, new Board(3));
            Assert.Equal(Player.X, controller.Players[0]);
            Assert.Equal(Player.O, controller.Players[1]);
        }

        [Fact]
        public void WinningRow() 
        {
            var board = new Board(SourceData.BoardWinningDiagonalLR());
            var controller = new Controller(board);
            var player = controller.Players[0]; 
            var result = GamePredicate.IsWinningBoard(board, board.GetWinningLines(), FieldContents.x);
            Assert.True(result);
        }

        [Fact]
        public void End_game_win_output_message() 
        {
            var output = new StubOutput();
            var board = new Board(SourceData.BoardWinningDiagonalLR());
            var controller = new Controller(board);
            var player = controller.Players[0];
            var expected = "Hooray! Player 1 has won the game!";
            OutputFormatter.PrintWinGame(player, output);
            Assert.Equal(expected, output.GetWriteLine());
        }

        [Fact]
        public void End_game_user_ends_game_output_message()
        {
            var output = new StubOutput();
            var player = Player.X;
            var expected = "Player 1 has ended the game.";
            OutputFormatter.PrintEndGame(player, output);
            Assert.Equal(expected, output.GetWriteLine());
        }

        [Fact]
        public void End_game_drawn_game_output_message()
        {
            var output = new StubOutput();
            var board = new Board(SourceData.BoardIsADraw());
            var expected = "Game is drawn. Better luck next time.";
            OutputFormatter.PrintDrawnGame(output);
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
        public void TurnQueue_GetCurrentPlayer_true()
        {
            var players = new List<Player>() { Player.X, Player.O };
            var turnQueue = new TurnQueue(players);
            var result = turnQueue.GetCurrentPlayer();
            Assert.Equal(Player.X, result);
        }

        [Fact]
        public void TurnQueue_GetCurrentPlayer_false()
        {
            var players = new List<Player>() { Player.X, Player.O };
            var turnQueue = new TurnQueue(players);
            var result = turnQueue.GetCurrentPlayer();
            Assert.NotEqual(Player.O, result);
        }

        [Fact]
        public void TurnQueue_SetNextPlayer_true()
        {
            var players = new List<Player>() { Player.X, Player.O };
            var turnQueue = new TurnQueue(players);
            var result = turnQueue.SetNextPlayer();
            Assert.Equal(Player.O, result);
        }

        [Fact]
        public void TurnQueue_SetNextPlayer_false()
        {
            var players = new List<Player>() { Player.X, Player.O };
            var turnQueue = new TurnQueue(players);
            var result = turnQueue.GetCurrentPlayer();
            Assert.NotEqual(Player.O, result);
        }        
        
        [Theory]
        [InlineData("0,2")]
        [InlineData("q")]
        public void Input_WithReadLine(string value)
        {
            var input = new StubConsoleInput();
            Assert.Equal(value, input.WithReadLine(value));
        }

        [Fact]
        public void ImplementTurn() // TODO: is this a valid test - doesn't use PlayGame or ImplementTurn
        {
            var board = new Board(3);
            var input = new StubConsoleInput();
            var output = new StubOutput();
            var controller = new Controller(board);
            var position = new Position(0, 1);
            var fieldContents = FieldContents.x;
            var result = controller.GameBoard.MovePlayer(position, fieldContents);
            var expected = (SourceData.BoardXFirstMove() == result);
            Assert.True(expected);
        }

        [Fact]
        public void Controller_position_field_contents() // TODO: is this a valid test - doesn't use PlayGame or ImplementTurn
        {
            var input = new StubConsoleInput();
            var output = new StubOutput();
            var board = new Board(SourceData.BoardWinningDiagonalLR());
            var controller = new Controller(board);
            var position = new Position(0, 0);
            var result = controller.Game.GameBoard.GetField(position);
            Assert.Equal(FieldContents.x, result);
        }

        
    }
}