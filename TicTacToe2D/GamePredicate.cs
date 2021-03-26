using System;
using System.Collections.Generic;
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
        public GamePredicate()
        {
            
        }
        public bool IsAWinningColumn(Board board, Player player)
        {
            var values = board.Dictionary;
            var count = 0;
            var keys = new List<int>();
            foreach (KeyValuePair<Position, FieldContents> value in values)
            {
                var key = value.Key;
                var fieldContents = new FieldContents();
                if (player == Player.X)
                {
                    fieldContents = FieldContents.x;
                }
                else
                {
                    fieldContents = FieldContents.y;
                }
                if (value.Value == fieldContents)
                {
                    count++;
                    keys.Add(key.Y);
                }
            }
            var numKeys = keys.Distinct();
            if (count == 3 &&  numKeys.Count() == 1)
            {
                return true;
            }
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