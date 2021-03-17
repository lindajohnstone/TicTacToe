using System;

namespace TicTacToe2D
{
    public class GamePredicate
    {
        // handles the win and draw conditions
        // horizontal, vertical and both diagonal winning conditions
        // plus if the board is full, the game  is drawn
        // should this be an interface?
        // pass in gamecontext return bool
        public GamePredicate()
        {
            GameContext game = new GameContext();
        }
        public GameContext IsAWinningColumn(bool winningColumn)
        {
            throw new NotImplementedException();
        }

        public GameContext IsAWinningRow(bool winningRow)
        {
            throw new NotImplementedException();
        }

        public GameContext IsAWinningDiagonal(bool winningDiagonal)
        {
            throw new NotImplementedException();
        }

        public GameContext IsADraw(bool draw)
        {
            throw new NotImplementedException();
        }
    }
}