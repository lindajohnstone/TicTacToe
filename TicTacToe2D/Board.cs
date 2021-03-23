using System;
using System.Collections.Generic;

namespace TicTacToe2D
{
    public class Board
    {
        // container of fields
        // Dictionary with position as key, fieldcontents as value??
        public Dictionary<Position, FieldContents> Dictionary { get; private set; }
        public int Width { get; private set; }
        public int Height { get; private set; }

        public Board(int boardSize) 
        {
            // implement population of dictionary with position and fieldContents based on 3x3 fieldContents.
            Width = boardSize;
            Height = boardSize;
            Dictionary = new Dictionary<Position, FieldContents>();
            for (int row = 0; row < Width; row++)
            {
                for (int column = 0; column < Height; column++)
                {
                    var position = new Position(row, column);
                    Dictionary.Add(position, FieldContents.empty);// Field.0
                }
            }
        }  

        
        // another method to draw new board when player inputs valid position
    }
}