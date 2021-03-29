using System;
using System.Collections.Generic;

namespace TicTacToe2D
{
    public class Board
    {
        // container of fields
        private Dictionary<Position, FieldContents> Dictionary { get; set; }
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
                    SetField(position, FieldContents.empty);
                }
            }
        }

        public FieldContents GetField(Position position)
        {
            EnsureValidPosition(position);
            return this.Dictionary[position];
        }

        public void SetField(Position position, FieldContents fieldContents)
        {
            EnsureValidPosition(position);
            this.Dictionary[position] = fieldContents;
        }

        private void EnsureValidPosition(Position position)
        {
            if (position.X < 0 || position.X > Width) {
                throw new KeyNotFoundException("Position X coordinate is out of range");
            }
            if (position.Y < 0 || position.Y > Height) {
                throw new ArgumentOutOfRangeException("Position Y coordinate is out of range");// Actual:   The given key 'TicTacToe2D.Position' was not present in the dictionary.
            }
        }
    }
}