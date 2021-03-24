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
        private GameContext _game;
        public GamePredicate(GameContext game)
        {
            _game = game;
        }
        public bool IsAWinningColumn(GameContext game)
        {
            // TODO: if dictionary contains position (0,0) & its value is FieldContents.x
            // & if dictionary contains position (1,0) & its' value is FieldContents.x
            // & if dictionary contains position (2,0) & its' value is FieldContents.x
            // return true
            return false;
        }

        public bool IsAWinningRow(GameContext game)
        {
            throw new NotImplementedException();
        }

        public bool IsAWinningDiagonal(GameContext game)
        {
            throw new NotImplementedException();
        }

        public GameContext IsADraw(bool draw)
        {
            throw new NotImplementedException();
        }
    }
}