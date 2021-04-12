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

        public bool IsWinningBoard(Board board, List<List<Position>> winningLines, FieldContents fieldContents)
        {
            return winningLines.Any((line) => IsWinningLine(board, fieldContents, line));
        }

        private bool IsWinningLine(Board board, FieldContents fieldContents, List<Position> positions)
        {
            return positions.All((x) => board.GetField(x) == fieldContents);
        }

        public bool IsADraw(Board board)
        {
            return board.GetAllPositions().All((x) => board.GetField(x) != FieldContents.empty);
        }
    }
}