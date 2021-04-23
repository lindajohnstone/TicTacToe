using System;
using System.Collections.Generic;

namespace TicTacToe2D
{
    public static class OutputFormatter 
    {
        // print instructions to console
        // print board to console
        // print win (which player) or draw 

        public static void PrintWelcome(Board board, IOutput output)
        {
            output.ConsoleWriteLine("Welcome to Tic Tac Toe!\n");
            PrintBoard(board, output);
            output.ConsoleWriteLine("");
        }
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

        public static void PrintInstructions(Player player, IOutput output)
        {
            var message = String.Format("Player {0} enter a coord x,y to place your {1} or enter 'q' to give up: ", (int)player + 1, player);
            output.ConsoleWrite(message);
        }

        public static void PrintNewBoard(Board board, IOutput output)
        {
            output.ConsoleWriteLine("Move accepted. Here's the current board: ");
            DrawBoard(board, output);
            output.ConsoleWriteLine("");
        }

        public static void PrintEndGame(Player player, IOutput output)
        {
            var message = String.Format("Player {0} has ended the game.", (int)player + 1);
            output.ConsoleWriteLine(message);
        }

        public static void PrintWinGame(Player player, IOutput output)
        {
            var message = String.Format("Hooray! Player {0} has won the game!", (int)player + 1);
            output.ConsoleWriteLine(message);
        }

        public static void PrintDrawnGame(IOutput output)
        {
            output.ConsoleWriteLine("Game is drawn. Better luck next time.");
        }
    }
}