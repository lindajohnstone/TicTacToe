    using System;
using System.Collections.Generic;

namespace TicTacToe2D
{
    public class Board
    {
        // container of fields
        private Dictionary<Position, FieldContents> FieldDictionary { get; set; }

        private List<List<Position>> WinningLines { get; set; }
        public int Width { get; private set; }
        public int Height { get; private set; }

        public Board(int boardSize)
        {
            // implement population of dictionary with position and fieldContents based on 3x3 fieldContents.
            Width = boardSize;
            Height = boardSize;
            FieldDictionary = new Dictionary<Position, FieldContents>();
            for (int row = 0; row < Width; row++)
            {
                for (int column = 0; column < Height; column++)
                {
                    var position = new Position(row, column);
                    SetField(position, FieldContents.empty);
                }
            }
        }

        private void InitializeWinningLines(int boardSize)
        {
            // add all winning rows
            for (var y = 0; y < boardSize; y++)
            {
                var line = new List<Position>();
                for (var x = 0; x < boardSize; x++)
                {
                    line.Add(new Position(x, y));
                }
                WinningLines.Add(line);
            }
            // add all winning columns
            // add all winning diagonals            
        }

        public FieldContents GetField(Position position)
        {
            EnsureValidPosition(position);
            return this.FieldDictionary[position];
        }

        public void SetField(Position position, FieldContents fieldContents)
        {
            EnsureValidPosition(position);
            this.FieldDictionary[position] = fieldContents;
        }

        private void EnsureValidPosition(Position position)
        {
            if (position.X < 0 || position.X >= Width)
            {
                throw new ArgumentException("Position X coordinate is out of range");
            }
            if (position.Y < 0 || position.Y >= Height)
            {
                throw new ArgumentException("Position Y coordinate is out of range");
            }
        }
    }
}