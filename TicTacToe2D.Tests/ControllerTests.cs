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
        public void EndGame_win_output_message() 
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
            var game = new GameContext(board, new List<Player>() { Player.X, Player.O });
            var position = new Position(0, 1);
            var fieldContents = FieldContents.x;
            var result = controller.GameBoard.MovePlayer(position, fieldContents);
            var expected = (SourceData.BoardXFirstMove() == result);
            Assert.True(expected);
        }

        [Fact]
        public void PlayGame() // TODO: how to set user input??
        {
            var input = new StubConsoleInput();
            var playerInput = input.WithReadLine("0,1");
            var position = InputParser.GetPlayerMove(playerInput);
            var output = new StubOutput();
            var board = new Board(3);
            var game = new GameContext(board, new List<Player>() { Player.X, Player.O });
            board.MovePlayer(position, FieldContents.x);
            var controller = new Controller(board);
            controller.PlayGame(game, output, input);
            Assert.Equal("Hooray! Player 1 has won the game!", output.GetWriteLine());
        }
        /*
            TicTacToe2D.Tests.ControllerTests.PlayGame:
    Outcome: Failed
    Error Message:
    System.NullReferenceException : Object reference not set to an instance of an object.
    Stack Trace:
       at TicTacToe2D.InputParser.SplitInput(String input) in /Users/Linda.Johnstone/Documents/fma/TicTacToe2D/TicTacToe2D/InputParser.cs:line 22
   at TicTacToe2D.InputParser.GetPlayerMove(String playerInput) in /Users/Linda.Johnstone/Documents/fma/TicTacToe2D/TicTacToe2D/InputParser.cs:line 13
   at TicTacToe2D.Controller.ImplementTurn(GameContext game, IOutput output, IInput input) in /Users/Linda.Johnstone/Documents/fma/TicTacToe2D/TicTacToe2D/Controller.cs:line 64
   at TicTacToe2D.Controller.PlayGame(GameContext game, IOutput output, IInput input) in /Users/Linda.Johnstone/Documents/fma/TicTacToe2D/TicTacToe2D/Controller.cs:line 33
   at TicTacToe2D.Tests.ControllerTests.PlayGame() in /Users/Linda.Johnstone/Documents/fma/TicTacToe2D/TicTacToe2D.Tests/ControllerTests.cs:line 182
    
    Total tests: 1. Passed: 0. Failed: 1. Skipped: 0
        */
    }
}