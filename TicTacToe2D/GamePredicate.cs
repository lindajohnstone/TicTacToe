using System;
using System.Linq;

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
            //1st check if 3 or more x in dictionary
            // where position.Y = 0 & position range?? is (0,3)(start, end +1)
            // return true
            var value = game.GameBoard.Dictionary;
            var pos1 = new Position(0, 0);
            var pos2 = new Position(1, 0);
            var pos3 = new Position(2, 0);
            var count = 0;
            if (value.ElementAt(0).Value == FieldContents.x)
            {
                count++;
            }
            if (value.ElementAt(3).Value == FieldContents.x)
            {
                count++;
            }
            if (value.ElementAt(6).Value == FieldContents.x)
            {
                count++;
            }
            if (count == 3) return true;
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