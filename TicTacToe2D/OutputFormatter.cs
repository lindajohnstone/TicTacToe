using System;
using System.Collections.Generic;

namespace TicTacToe2D
{
    public static class OutputFormatter 
    {
        // print instructions to console
        // print board to console
        // print win (which player) or draw 
        public static void DrawBoard(Board board, IOutput output)
        {
            for (var column = 0; column < board.Width; column++)
            {
                for (var row = 0; row < board.Width; row++)
                {
                    var position = board.GetField(new Position(column, row));
                    switch (position)
                    {
                        case (FieldContents.y):
                            output.ConsoleWrite("O  ");
                            break;
                        case (FieldContents.x):
                            output.ConsoleWrite("X  ");
                            break;
                        case (FieldContents.empty):
                            output.ConsoleWrite(".  ");
                            break;
                    }
                }
                output.ConsoleWrite(Environment.NewLine);
            }
        }

        public static void PrintBoard(Board board, IOutput output)
        {
            output.ConsoleWriteLine("Here's the current board:");
            DrawBoard(board, output);
        }

        public static List<string> PrintInstructions(Player player, IOutput output)
        {
            var instructions = new List<string>();
            var playerId = (int)player;
            var message = String.Format("Player {0} enter a coord x,y to place your {1} or enter 'q' to give up: ", playerId, player);
            output.ConsoleWrite(message);
            return instructions;
        }

        public static List<string> PrintEndGame(Player player, IOutput output)
        {
            var list = new List<string>();
            var message = String.Format("Player {0} has ended the game.", player);
            output.ConsoleWriteLine(message);
            return list;
        }

        private static void PrintPlayerMove(ConsoleOutput output)
        {
            throw new NotImplementedException();
        }
    }
}