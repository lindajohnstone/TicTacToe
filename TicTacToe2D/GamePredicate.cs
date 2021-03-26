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
                fieldContents = GetFieldContents(player);
                if (value.Value == fieldContents)
                {
                    count++;
                    GetKey(player, keys, key);
                }
            }
            if (count == 3 &&  keys.Sum() % 3 == 0)
            {
                return true;
            }
            return false;
        }

        private static FieldContents GetFieldContents(Player player)
        {
            FieldContents fieldContents;
            if (player == Player.X)
            {
                fieldContents = FieldContents.x;
            }
            else
            {
                fieldContents = FieldContents.y;
            }

            return fieldContents;
        }

        private static void GetKey(Player player, List<int> keys, Position key)
        {
            if (player == Player.X)
            {
                keys.Add(key.X);
            }
            else
            {
                keys.Add(key.Y);
            }
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