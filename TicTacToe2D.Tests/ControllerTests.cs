using System;
using System.Collections;
using System.Collections.Generic;
using TicTacToe2D.Exceptions;
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
            Assert.Equal(TicTacToe2D.Position.Factory_2DPosition(0, 0), result);
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
            var board = new Board(2, 3);
            var controller = new Controller(board);
            var players = new List<Player> { Player.X, Player.O };
            var game = new GameContext(board, players);
            Assert.Equal(controller.GameBoard, new Board(2, 3));
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
            var outputFormatter = new OutputFormatter();
            outputFormatter.PrintWinGame(player, output);
            Assert.Equal(expected, output.GetWriteLine());
        }

        [Fact]
        public void End_game_user_ends_game_output_message()
        {
            var output = new StubOutput();
            var player = Player.X;
            var expected = "Player 1 has ended the game.";
            var outputFormatter = new OutputFormatter();
            outputFormatter.PrintEndGame(player, output);
            Assert.Equal(expected, output.GetWriteLine());
        }

        [Fact]
        public void End_game_drawn_game_output_message()
        {
            var output = new StubOutput();
            var board = new Board(SourceData.BoardIsADraw());
            var expected = "Game is drawn. Better luck next time.";
            var outputFormatter = new OutputFormatter();
            outputFormatter.PrintDrawnGame(output);
            Assert.Equal(expected, output.GetWriteLine());
        }

        [Fact]
        public void PlayerEndsGame_user_input_as_string_q_ends_game_outputs_message()
        {
            var output = new StubOutput();
            var player = Player.X;
            var playerInput = "q";
            Assert.Throws<PlayerAbortsGameException>(() => InputParser.PlayerEndsGame(player, playerInput));
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

        [Fact]
        public void Controller_check_move_player() 
        {
            var board = new Board(2, 3);
            var input = new StubConsoleInput();
            var output = new StubOutput();
            var controller = new Controller(board);
            var position = TicTacToe2D.Position.Factory_2DPosition(0, 1);
            var fieldContents = FieldContents.x;
            var result = controller.GameBoard.MovePlayer(position, fieldContents);
            var expected = (SourceData.BoardXFirstMove() == result);
            Assert.True(expected);
        }

        [Fact]
        public void Controller_position_field_contents() 
        {
            var input = new StubConsoleInput();
            var output = new StubOutput();
            var board = new Board(SourceData.BoardWinningDiagonalLR());
            var controller = new Controller(board);
            var position = TicTacToe2D.Position.Factory_2DPosition(0, 0);
            var result = controller.Game.GameBoard.GetField(position);
            Assert.Equal(FieldContents.x, result);
        }

        [Theory]
        [InlineData("0,2")]
        [InlineData("q")]
        public void Input_ConsoleReadLine(string value)
        {
            var input = new StubConsoleInput();
            input.WithReadLine(value);
            Assert.Equal(value, input.ConsoleReadLine());
        }

        [Fact]
        public void ImplementTurn_player_move_position() 
        {
            var input = new StubConsoleInput();
            var playerInput = "0,1";
            input.WithReadLine(playerInput);
            var output = new StubOutput();
            var board = new Board(2, 3);
            var game = new GameContext(board, new List<Player>() { Player.X, Player.O });
            var controller = new Controller(board);
            controller.ImplementTurn(game, output, input);
            Assert.Equal(Player.X, game.GetCurrentPlayer());
            Assert.Equal(Player.O, game.SetNextPlayer());
        }

        // TODO: why do some tests using input have to use 'input.WithReadLine("q")' to not throw a 'ThrowForEmptyQueue'
        [Fact]
        public void ImplementTurn_returns_InvalidMoveSyntaxException_message()
        {
            var input = new StubConsoleInput();
            input.WithReadLine("0;1");
            input.WithReadLine("q");
            var output = new StubOutput();
            var board = new Board(SourceData.BoardMovePlayerY());
            var game = new GameContext(board, new List<Player>() { Player.X, Player.O });
            var controller = new Controller(board);
            Assert.Throws<PlayerAbortsGameException>(() => controller.ImplementTurn(game, output, input));
            Assert.Equal("Invalid format. Please try again...", output.GetWriteLine());
        }

        [Fact]
        public void ImplementTurn_throws_ArgumentException_Y()
        {
            var input = new StubConsoleInput();
            input.WithReadLine("0,9");
            input.WithReadLine("q");
            var output = new StubOutput();
            var board = new Board(SourceData.BoardMovePlayerY());
            var game = new GameContext(board, new List<Player>() { Player.X, Player.O });
            var controller = new Controller(board);
            Assert.Throws<PlayerAbortsGameException>(() => controller.ImplementTurn(game, output, input));
            Assert.Equal("Position coordinate is out of range. Please try again...", output.GetWriteLine());
        }

        [Fact]
        public void ImplementTurn_throws_ArgumentException_X()
        {
            var input = new StubConsoleInput();
            input.WithReadLine("9,0");
            input.WithReadLine("q");
            var output = new StubOutput();
            var board = new Board(SourceData.BoardMovePlayerY());
            var game = new GameContext(board, new List<Player>() { Player.X, Player.O });
            var controller = new Controller(board);
            Assert.Throws<PlayerAbortsGameException>(() => controller.ImplementTurn(game, output, input));
            Assert.Equal("Position coordinate is out of range. Please try again...", output.GetWriteLine());
        }

        // [Fact]
        // public void PlayGame_write_welcome() // failing
        // {
        //     var input = new StubConsoleInput();
        //     input.WithReadLine("0,0");
        //     input.WithReadLine("q");
        //     var output = new StubOutput();
        //     var board = new Board(2, 3);
        //     var controller = new Controller(board);
        //     var game = new GameContext(board, new List<Player>() { Player.X, Player.O });
        //     var outputFormatter = new OutputFormatter();
        //     controller.PlayGame(game, output, input, outputFormatter);
        //     Assert.Contains("Welcome to Tic Tac Toe!\nHere's the current board:.  .  .  \n.  .  .  \n.  .  .  \n", output.GetWriteLine());
        // }

        [Fact]
        public void PlayGame_player_ends_game() // failing
        {
            var input = new StubConsoleInput();
            input.WithReadLine("0,0");
            input.WithReadLine("q");
            var output = new StubOutput();
            var board = new Board(2, 3);
            var controller = new Controller(board);
            var game = new GameContext(board, new List<Player>() { Player.X, Player.O });
            var outputFormatter = new OutputFormatter();
            controller.PlayGame(game, output, input, outputFormatter);
            Assert.Contains("Player 2 has ended the game.", output.GetWriteLine());
        }

        [Fact]
        public void PlayGame_drawn_game()
        {
            var input = new StubConsoleInput();
            input.WithReadLine("0,0");
            input.WithReadLine("0,1");
            input.WithReadLine("0,2");
            input.WithReadLine("1,1");
            input.WithReadLine("1,0");
            input.WithReadLine("1,2");
            input.WithReadLine("2,1");
            input.WithReadLine("2,0");
            input.WithReadLine("2,2");
            var output = new StubOutput();
            var board = new Board(2, 3);
            var controller = new Controller(board);
            var game = new GameContext(board, new List<Player>() { Player.X, Player.O });
            var outputFormatter = new OutputFormatter();
            controller.PlayGame(game, output, input, outputFormatter);
            Assert.Contains("Game is drawn. Better luck next time.", output.GetWriteLine());
        }

        // [Fact]
        // public void PlayGame_drawn_game_v2() // TODO: failing 
        // {
        //     var input = new StubConsoleInput();
        //     input.WithReadLine("1,0");
        //     input.WithReadLine("q");
        //     var output = new StubOutput();
        //     var board = new Board(SourceData.BoardIsNotADraw());
        //     var controller = new Controller(board);
        //     var game = new GameContext(board, new List<Player>() { Player.X, Player.O });
        //     var outputFormatter = new OutputFormatter();
        //     controller.PlayGame(game, output, input, outputFormatter);
        //     Assert.Contains("Game is drawn. Better luck next time.", output.GetWriteLine());
        // }

        // [Fact]
        // public void PlayGame_X_wins_game() 
        // {
        //     var input = new StubConsoleInput();
        //     input.WithReadLine("0,0");
        //     input.WithReadLine("0,1");
        //     input.WithReadLine("0,2");
        //     input.WithReadLine("1,1");
        //     input.WithReadLine("1,0");
        //     input.WithReadLine("1,2");
        //     input.WithReadLine("2,0");
        //     input.WithReadLine("q");
        //     var output = new StubOutput();
        //     var board = new Board(2, 3);
        //     var controller = new Controller(board);
        //     var game = new GameContext(board, new List<Player>() { Player.X, Player.O });
        //     var outputFormatter = new OutputFormatter();
        //     controller.PlayGame(game, output, input, outputFormatter);
        //     Assert.Contains("Hooray! Player 1 has won the game!", output.GetWriteLine());
        // }

        // [Fact]
        // public void PlayGame_X_wins_game_v2() // TODO: failing due to not reading sourceboard
        // {
        //     var input = new StubConsoleInput();
        //     input.WithReadLine("1,0");
        //     input.WithReadLine("q");
        //     var output = new StubOutput();
        //     var board = new Board(SourceData.BoardIsNotADrawV2());
        //     var controller = new Controller(board);
        //     var game = new GameContext(board, new List<Player>() { Player.X, Player.O });
        //     var outputFormatter = new OutputFormatter();
        //     controller.PlayGame(game, output, input, outputFormatter);
        //     Assert.Contains("Hooray! Player 1 has won the game!", output.GetWriteLine());
        // }
    }
}