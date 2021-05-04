using System;
using System.Collections.Generic;

namespace TicTacToe2D
{
    public class Board2D : Board
    {
        public Board2D(int boardSize) : base(boardSize)
        {
            
        }

        public Board2D(FieldContents[][] sourceData)
        {
            Initialize(sourceData.Length, BoardInitializer(sourceData));
        }


        public Board2D(Board2D sourceBoard) : base(sourceBoard)
        {
    
        }

        public static Dictionary<Position, FieldContents> BoardInitializer(FieldContents[][] sourceData)
        {
            var boardSize = sourceData.Length;
            var FieldDictionary = new Dictionary<Position, FieldContents>();
            for (int row = 0; row < boardSize; row++)
            {
                if (sourceData[row].Length != boardSize)
                {
                    throw new ArgumentOutOfRangeException("sourceData should be a square array");
                }
                for (int column = 0; column < boardSize; column++)
                {
                    var position = new Position2D(row, column);
                    FieldDictionary.Add(position, sourceData[row][column]);
                }
            }
            return FieldDictionary;
        }

        

        protected override Dictionary<Position, FieldContents> BoardInitializer(int boardSize)
        {
            var FieldDictionary = new Dictionary<Position, FieldContents>();
            for (int row = 0; row < boardSize; row++)
            {
                for (int column = 0; column < boardSize; column++)
                {
                    var position = new Position2D(row, column);
                    FieldDictionary.Add(position, FieldContents.empty);
                }
            }
            return FieldDictionary;
        }

        protected override Board Clone()
        {
            return new Board2D(this);
        }
    }
}