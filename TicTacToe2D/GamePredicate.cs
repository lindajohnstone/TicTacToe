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
        public bool IsAWinningColumn(Board board)
        {
            for (int column = 0; column < board.Height; column++)
            {
                //var row = 0;
                var position1 = new Position(0, column);//TODO: more efficient way to find these
                var position2 = new Position(1, column);
                var position3 = new Position(2, column);
                if (board.GetField(position1).Equals(board.GetField(position2)) && board.GetField(position2).Equals(board.GetField(position3)))
                {
                    return AreAllSame(position1, position2, position3);
                }
            }
            return false;
        }

        public bool IsWinningBoard(Board board, List<List<Position>> winningLines, FieldContents fieldContents)
        {
            return winningLines.Any((line) => IsWinningLine(board, fieldContents, line));
        }

        public bool IsWinningLine(Board board, FieldContents fieldContents, List<Position> positions)
        {
            return positions.All((x) => board.GetField(x) == fieldContents);
        }

        public bool AreAllSame(Position position1, Position position2, Position position3)
        {
            if (position1.Y == position2.Y && position2.Y == position3.Y)
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