using System;

namespace TicTacToe2D
{
    public class OutputFormatter2D : OutputFormatter
    {
        // public void DrawBoard(Board2D board, IOutput output)
        // {
        //     for (var column = 0; column < board.Width; column++)
        //     {
        //         for (var row = 0; row < board.Width; row++)
        //         {
        //             var position = board.GetField(new Position2D(column, row));
        //             switch (position)
        //             {
        //                 case (FieldContents.y):
        //                     output.ConsoleWrite("O  ");
        //                     break;
        //                 case (FieldContents.x):
        //                     output.ConsoleWrite("X  ");
        //                     break;
        //                 case (FieldContents.empty):
        //                     output.ConsoleWrite(".  ");
        //                     break;
        //             }
        //         }
        //         PrintNewLine(output);
        //     }
        // }

        // public void PrintBoard(Board2D board, IOutput output)
        // {
        //     output.ConsoleWriteLine("Here's the current board:");
        //     DrawBoard(board, output);
        // }


        // public void PrintNewBoard(Board board, IOutput output)
        // {
        //     output.ConsoleWriteLine("Move accepted. Here's the current board: ");
        //     DrawBoard(board, output);
        // }
    }
}