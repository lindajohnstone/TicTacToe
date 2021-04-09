using System;
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

        // [Fact]
        // public void testName()
        // {
        //     Position playerMovePosition = null;
        //     Assert.True(playerMovePosition.Equals(null));
        // }

        [Fact]
        public void testName()
        {
            throw new NotImplementedException();
        }
    }
}