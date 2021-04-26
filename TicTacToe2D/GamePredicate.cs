using System;
using System.Collections.Generic;
using System.Linq;

namespace TicTacToe2D
{
    public static class GamePredicate
    {
        // handles the win and draw conditions
        // horizontal, vertical and both diagonal winning conditions
        // plus if the board is full, the game  is drawn
        // should this be an interface?
        // pass in gamecontext return bool
        static GamePredicate()
        {
            
        }

        public static bool IsWinningBoard(GameContext game)
        {
            return IsWinningBoard(game.GameBoard, game.GameBoard.GetWinningLines(), game.PlayerFieldContents(game.GetCurrentPlayer()));
        }
        public static bool IsWinningBoard(Board board, List<List<Position>> winningLines, FieldContents fieldContents)
        {
            return winningLines.Any((line) => IsWinningLine(board, fieldContents, line));
        }

        private static bool IsWinningLine(Board board, FieldContents fieldContents, List<Position> positions)
        {
            return positions.All((x) => board.GetField(x) == fieldContents);
        }

        public static bool IsADraw(Board board)
        {
            return board.GetAllPositions().All((x) => board.GetField(x) != FieldContents.empty);
        }
        public static bool IsADraw(GameContext game)
        {
            return IsADraw(game.GameBoard);
        }
    }
}