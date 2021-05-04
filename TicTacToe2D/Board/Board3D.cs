using System;
using System.Collections.Generic;
using System.Linq;

namespace TicTacToe2D
{
    public class Board3D : Board
    {
        // inherits Board to set up 3D Board 
        // name cannot be 3DBoard 

        public int Depth { get; set; }
        public Board3D()
        {
        }

        public Board3D(int boardSize) : base(boardSize)
        {
        }

        public Board3D(Board sourceBoard) : base(sourceBoard)
        {
        }
        public Board3D(FieldContents[][][] sourceData)
        {
            Initialize(sourceData.Length, BoardInitializer(sourceData));
        }
        protected override void Initialize(int boardSize, Dictionary<Position, FieldContents> fieldDictionary)
        {
            Depth = boardSize;
            base.Initialize(boardSize, fieldDictionary);
        }

        public static Dictionary<Position, FieldContents> BoardInitializer(FieldContents[][][] sourceData)
        {
            var boardSize = sourceData.Length;
            var FieldDictionary = new Dictionary<Position, FieldContents>();
            for (int x = 0; x < boardSize; x++)
            {
                if (sourceData[x].Length != boardSize)
                {
                    throw new ArgumentOutOfRangeException("sourceData should be a square array");
                }
                for (int y = 0; y < boardSize; y++)
                {
                    for (int z = 0; z < boardSize; z++)
                    {
                        var position = new Position3D(x, y, z);
                        FieldDictionary.Add(position, sourceData[x][y][z]);
                    }
                }
            }
            return FieldDictionary;
        }
        protected override Dictionary<Position, FieldContents> BoardInitializer(int boardSize)
        {
            var FieldDictionary = new Dictionary<Position, FieldContents>();
            for (int x = 0; x < boardSize; x++)
            {
                for (int y = 0; y < boardSize; y++)
                {
                    for (int z = 0; z < boardSize; z++)
                    {
                        var position = new Position3D(x, y, z);
                        FieldDictionary.Add(position, FieldContents.empty);
                    }
                }
            }
            return FieldDictionary;
        }
        
        protected override void EnsureValidPosition(Position position)
        {
            if (position.Z < 0 || position.Z >= Depth)
            {
                throw new ArgumentException("Position Z coordinate is out of range. Please try again...");
            }
            base.EnsureValidPosition(position);
        }

        public static bool OperatorOverride(Board3D obj1, Board3D obj2)
        {
            if (obj1.Width == obj2.Width && obj1.Height == obj2.Height && obj1.Depth == obj2.Depth)
            {
                return obj1.GetAllPositions().All((x) => obj1.GetField(x) == obj2.GetField(x));
            }
            return false;
        }
        
        public static bool operator ==(Board3D obj1, Board3D obj2)
        {
            if (OperatorOverride(obj1, obj2))
            {
                return true;
            }
            return false;
        }

        public static bool operator !=(Board3D obj1, Board3D obj2)
        {
            if (!OperatorOverride(obj1, obj2))
            {
                return false;
            }
            return true;
        }
        protected override Board Clone()
        {
            return new Board3D(this);
        }

        public override bool Equals(object obj)
        {
            return obj is Board3D d &&
                   base.Equals(obj) &&
                   Width == d.Width &&
                   Height == d.Height &&
                   Depth == d.Depth;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(base.GetHashCode(), Width, Height, Depth);
        }
    }
}