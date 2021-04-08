using System;
using Xunit;

namespace TicTacToe2D.Tests
{
    public class ControllerTests
    {
        // [Fact]
        // public void Controller_implement_turn()
        // {
        //     var game = new GameContext();
        //     var controller = new Controller();
        //     var result = controller.ImplementTurn(game);
        //     var expected = SourceData.BoardMovePlayer();
        //     Assert.Equal(expected, result.GameBoard);
        // }

        [Fact]
        public void InputParser_PlayerPosition()
        {
            var input = "0,0";
            var result = InputParser.ValidatePlayerInput(input);
            Assert.Equal(input, result);
        }
    }
}