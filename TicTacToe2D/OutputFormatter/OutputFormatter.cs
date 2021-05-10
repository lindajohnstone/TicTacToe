using System;
using System.Collections.Generic;

namespace TicTacToe2D
{
    public class OutputFormatter 
    {
        // print instructions to console
        // print board to console
        // print win (which player) or draw 

        public void PrintWelcome(IOutput output)
        {
            output.ConsoleWriteLine("Welcome to Tic Tac Toe!\n");
        }
        public void DrawBoard(Board board, IOutput output)
        {
            for (var column = 0; column < board.Width; column++)
            {
                for (var row = 0; row < board.Width; row++)
                {
                    var position = board.GetField(Position.Factory_2DPosition(column, row));
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
                PrintNewLine(output);
            }
        }

        public void PrintBoard(Board board, IOutput output)
        {
            output.ConsoleWriteLine("Here's the current board:");
            DrawBoard(board, output);
        }

        public void PrintInstructions(Player player, IOutput output)
        {
            var message = String.Format("Player {0} enter a coord x,y to place your {1} or enter 'q' to give up: ", (int)player + 1, player);
            output.ConsoleWrite(message);
        }

        public void PrintNewBoard(Board board, IOutput output)
        {
            output.ConsoleWriteLine("Move accepted. Here's the current board: ");
            DrawBoard(board, output);
        }

        public void PrintEndGame(Player player, IOutput output)
        {
            var message = String.Format("Player {0} has ended the game.", (int)player + 1);
            output.ConsoleWriteLine(message);
        }

        public void PrintWinGame(Player player, IOutput output)
        {
            var message = String.Format("Hooray! Player {0} has won the game!", (int)player + 1);
            output.ConsoleWriteLine(message);
        }

        public void PrintDrawnGame(IOutput output)
        {
            output.ConsoleWriteLine("Game is drawn. Better luck next time.");
        }

        public void PrintNewLine(IOutput output)
        {
            output.ConsoleWrite(Environment.NewLine);
        }
    }
}