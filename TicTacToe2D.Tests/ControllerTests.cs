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
        public void InputParser_GetPlayerMove()
        {
            var input = "0,0";
            var parser = new StubInputParser();
            var result = parser.GetPlayerMove(input);
            Assert.Equal(new Position(0,0), result);
        }
    }
}