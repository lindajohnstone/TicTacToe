using Xunit;

namespace TicTacToe2D.Tests
{
    public class GamePredicateTests
    {
        [Fact]
        public void GamePredicate_Is_a_winning_column()
        {
            var game = new GameContext();
            var win = new GamePredicate(game);
            var board = new Board(3);
            // win if position(0,0), position(1,0) && position(2,0) all have FieldContents == 'x'
            var pos1 = new Position(0, 0);
            var pos2 = new Position(1, 0);
            var pos3 = new Position(2, 0);
            board.Dictionary[pos1] = FieldContents.x;
            board.Dictionary[pos2] = FieldContents.x;
            board.Dictionary[pos3] = FieldContents.x;
            var result = win.IsAWinningColumn(game);
            Assert.Equal(true, result);
        }
    }
}