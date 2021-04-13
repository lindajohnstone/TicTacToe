using System;
using System.Collections.Generic;

namespace TicTacToe2D.Tests
{
    public class StubOutputFormatter : IOutputFormatter
    {
        public List<string> DrawBoard(Board board, IOutput output)
        {
            var boardList = new List<string>();
            for (var column = 0; column < board.Width; column++)
            {
                for (var row = 0; row < board.Width; row++)
                {
                    var position = board.GetField(new Position(column, row));
                    if (position == FieldContents.y)
                    {
                        output.ConsoleWrite("O  ");
                    }
                    if (position == FieldContents.x)
                    {
                        output.ConsoleWrite("X  ");
                    }
                    if (position == FieldContents.empty)
                    {
                        output.ConsoleWrite(".  ");
                    }
                }
                output.ConsoleWrite(Environment.NewLine);
            }
            return boardList;
        }

        public string PrintInstructions(Player player)
        {
            //var output = new StubOutput();
            var playerId = (int)player;
            var message = String.Format("Player {0} enter a coord x,y to place your {1} or enter 'q' to give up: ", playerId, player);
            return message;
        }
    }
}