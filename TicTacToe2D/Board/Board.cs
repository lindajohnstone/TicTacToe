using System;
using System.Collections.Generic;
using System.Linq;

namespace TicTacToe2D
{
    public class Board
    {
        // container of fields
        private Dictionary<Position, FieldContents> FieldDictionary { get; set; }

        private List<List<Position>> WinningLines { get; set; }

        private List<Position> AllPositions { get; set; }

        public int Width { get; private set; }
        
        public int Height { get; private set; }

        public List<int> DimensionLength { get; private set; }

        public Board(int boardSize)
        {
            // implement population of dictionary with position and fieldContents based on 3x3 fieldContents.
            Initialize(boardSize, BoardInitializer(boardSize));
        }

        // public Board(FieldContents[][] sourceData)
        // {
        //     Initialize(sourceData.Length, BoardInitializer(sourceData));
        // }
        
        public Board(Board sourceBoard)
        {
            Initialize(sourceBoard.Width, sourceBoard.FieldDictionary);
        }

        public void Initialize(int boardSize, Dictionary<Position, FieldContents> fieldDictionary)
        {
            Width = boardSize;
            Height = boardSize;
            FieldDictionary = fieldDictionary;
            WinningLines = CreateWinningLines(boardSize);
            AllPositions = CreateAllPositions(boardSize);
        }

        protected Dictionary<Position, FieldContents> BoardInitializer(int boardSize)
        {
            var positions = new Dictionary<Position, FieldContents>();
            return positions;
        }

        private static List<List<Position>> CreateWinningLines(int boardSize)
        {
            var WinningLines = new List<List<Position>>();
            // // add all winning rows
            // for (var row = 0; row < boardSize; row++)
            // {
            //     var line = CreateWinningLine(new Position(0, row), new Position2D(1, 0), boardSize);
            //     WinningLines.Add(line);
            // }

            // // add all winning columns
            // for (var column = 0; column < boardSize; column++)
            // {
            //     var line = CreateWinningLine(new Position(column, 0), new Position2D(0, 1), boardSize);
            //     WinningLines.Add(line);
            // }

            // // add winning diagonals 
            
            // var line1 = CreateWinningLine(new Position(0, 0), new Position2D(1, 1), boardSize);
            // WinningLines.Add(line1);
        
            // var line2 = CreateWinningLine(new Position((boardSize - 1), 0), new Position2D(-1, 1), boardSize);
            // WinningLines.Add(line2);
           
            return WinningLines;
        }

        private static List<Position> CreateWinningLine(Position start, Position delta, int boardSize)
        {
            var line = new List<Position>();
            var currentPosition = start;
            for (var i = 0; i < boardSize; i++)
            {
                line.Add(currentPosition);
                //currentPosition += delta;
            }
            return line;
        }

        public List<List<Position>> GetWinningLines()
        {
            return WinningLines;
        }

        protected List<Position> CreateAllPositions(int boardSize)
        {
            var positions = new List<Position>();
            return positions;
        }


        public List<Position> GetAllPositions()
        {
            return AllPositions;
        }

        protected Board Clone()
        {
            var board = new Board(this);
            return board;
        }
        
        public Board MovePlayer(Position position, FieldContents fieldContents)
        {
            var board = Clone();
            board.SetField(position, fieldContents);
            return board;
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

        protected void EnsureValidPosition(Position position) 
        {
            if(!position.All((x) => x.Value < DimensionLength[x.Dimension]))
            {
                throw new ArgumentException("Position coordinate is out of range. Please try again...");
            }
        }

        // public static bool OperatorOverride(Board obj1, Board obj2)
        // {
        //     if (obj1.Width == obj2.Width && obj1.Height == obj2.Height)
        //     {
        //         return obj1.GetAllPositions().All((x) => obj1.GetField(x) == obj2.GetField(x));
        //     }
        //     return false;
        // }

        // public static bool operator ==(Board obj1, Board obj2 )
        // {
        //     if (OperatorOverride(obj1, obj2))
        //     {
        //         return true;
        //     }
        //     return false;
        // }

        // public static bool operator !=(Board obj1, Board obj2)
        // {
        //     if (!OperatorOverride(obj1, obj2))
        //     {
        //         return false;
        //     }
        //     return true;
        // }

        // public override bool Equals(object obj)
        // {
        //     if (obj == null || GetType() != obj.GetType())
        //     {
        //         return false;
        //     }
        //     else
        //     {
        //         return OperatorOverride(this, (Board)obj);
        //     }
        // }

        // public override int GetHashCode()
        // {
        //     return HashCode.Combine(FieldDictionary, WinningLines, AllPositions, Width, Height);
        // }
        // public static void Factory_2DBoard(Position position, int boardSize) // what return type?
        // {
        //     var fd = new Dictionary<Position, FieldContents>();
        //     //{
        //     for (int row = 0; row < boardSize; row++)
        //     {
        //         for (int column = 0; column < boardSize; column++)
        //         {
        //             fd.Add(Position.Factory_2DPosition(row, column), FieldContents.empty);
        //         }
        //     }
        //     // return fd;
        //     //};
        // }
    }
}