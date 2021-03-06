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

        public List<int> DimensionLength { get; private set; } // stores the length for each dimension separately
        public List<int> DimensionList { get; private set; }
        public Board(int dimensionCount, int boardSize)
        {
            // implement population of dictionary with position and fieldContents based on 3x3 fieldContents.
            var dimensionList = DimensionInitializer(dimensionCount);
            var allPositions = AllPositionsInitializer(dimensionList, boardSize);
            Initialize(dimensionList, allPositions, boardSize, BoardInitializer(allPositions));
        }
        
        public Board(int dimensionCount, int boardSize, Dictionary<Position, FieldContents> sourceData)
        {
            var dimensionList = DimensionInitializer(dimensionCount);
            var allPositions = AllPositionsInitializer(dimensionList, boardSize);
            Initialize(dimensionList, allPositions, boardSize, sourceData);
        }
        
        public Board(Board sourceBoard)
        {
            var dimensionCount = sourceBoard.DimensionLength.Count;
            var boardsize = sourceBoard.DimensionLength[0];  
            var fd = new Dictionary<Position, FieldContents>(sourceBoard.FieldDictionary);
            var dimensionList = DimensionInitializer(dimensionCount);
            var allPositions = new List<Position>(sourceBoard.AllPositions);
            Initialize(dimensionList, allPositions, sourceBoard.DimensionLength[0], fd); 
        }

        public void Initialize(List<int> dimensionList, List<Position> allPositions, int boardSize, Dictionary<Position, FieldContents> fieldDictionary)
        {
            DimensionList = dimensionList;
            DimensionLength = new List<int>();
            for (var i = 0; i < boardSize; i++)
            {
                DimensionLength.Add(boardSize);
            }
            FieldDictionary = fieldDictionary;
            WinningLines = CreateWinningLines(boardSize);
            AllPositions = allPositions;
        }
        protected List<int> DimensionInitializer(int dimensionCount)
        {
            var dimensionList = new List<int>();
            for (var i = 0; i < dimensionCount; i++)
            {
                dimensionList.Add(i);
            }
            return dimensionList;
        }

        protected List<Position> AllPositionsInitializer(List<int> dimensionList, int boardSize)
        {
            var positions = new List<Position>();
            RecursiveAllPositionsInitializer(boardSize, dimensionList, new List<DimensionValue>(), positions);
            return positions;
        }

        protected static void RecursiveAllPositionsInitializer(int boardSize, List<int> dimensionsList, List<DimensionValue> setDimensionsList, List<Position> positions)
        {
            if (dimensionsList.Count == 0)
            {
                positions.Add(new Position(setDimensionsList));
                return;
            }
            int head = dimensionsList[0];
            List<int> tail = dimensionsList.GetRange(1, dimensionsList.Count - 1);
            for (var i = 0; i < boardSize; i++)
            {
                var newSetDimensionsList = new List<DimensionValue>(setDimensionsList);
                newSetDimensionsList.Add(new DimensionValue(head, i));
                RecursiveAllPositionsInitializer(boardSize, tail, newSetDimensionsList, positions);
            }
        }

        protected Dictionary<Position, FieldContents> BoardInitializer(List<Position> allPositions)
        {
            var boardContents = new Dictionary<Position, FieldContents>();
            foreach(var position in allPositions)
            {
                boardContents.Add(position, FieldContents.empty);
            }
            return boardContents;
        }


        private static List<List<Position>> CreateWinningLines(int boardSize)
        {
            var WinningLines = new List<List<Position>>();
            // add all winning rows
            for (var row = 0; row < boardSize; row++)
            {
                var line = CreateWinningLine(Position.Factory_2DPosition(0, row), Position.Factory_2DPosition(1, 0), boardSize);
                WinningLines.Add(line);
            }

            // add all winning columns
            for (var column = 0; column < boardSize; column++)
            {
                var line = CreateWinningLine(Position.Factory_2DPosition(column, 0), Position.Factory_2DPosition(0, 1), boardSize);
                WinningLines.Add(line);
            }

            // add winning diagonals 
            
            var line1 = CreateWinningLine(Position.Factory_2DPosition(0, 0), Position.Factory_2DPosition(1, 1), boardSize);
            WinningLines.Add(line1);
        
            var line2 = CreateWinningLine(Position.Factory_2DPosition((boardSize - 1), 0), Position.Factory_2DPosition(-1, 1), boardSize);
            WinningLines.Add(line2);
           
            return WinningLines;
        }

        private static List<Position> CreateWinningLine(Position start, Position delta, int boardSize)
        {
            var line = new List<Position>();
            var currentPosition = start;
            for (var i = 0; i < boardSize; i++)
            {
                line.Add(currentPosition);
                currentPosition += delta;
            }
            return line;
        }

        public List<List<Position>> GetWinningLines()
        {
            return WinningLines;
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

        public static bool OperatorOverride(Board obj1, Board obj2)
        {
            for (int i = 0; i < obj1.DimensionLength.Count; i++)
            {
                if (obj1.DimensionLength[i] == obj2.DimensionLength[i])
                {
                    return true;
                }
            }
            return false;
        }

        public static bool operator ==(Board obj1, Board obj2 )
        {
            if (OperatorOverride(obj1, obj2))
            {
                return true;
            }
            return false;
        }

        public static bool operator !=(Board obj1, Board obj2)
        {
            if (!OperatorOverride(obj1, obj2))
            {
                return false;
            }
            return true;
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }
            else
            {
                return OperatorOverride(this, (Board)obj);
            }
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(FieldDictionary, WinningLines, AllPositions);
        }
        public static Board Factory_2DBoard(FieldContents[][] fc, int boardSize) 
        {
            var fd = new Dictionary<Position, FieldContents>();
            for (int x = 0; x < boardSize; x++)
            {
                for (int y = 0; y < boardSize; y++)
                {
                    fd.Add(Position.Factory_2DPosition(x, y), fc[y][x]);
                }
            }
            return new Board(2, boardSize, fd);
        }

        public static Board Factory_3DBoard(FieldContents[][][] fc, int boardSize)
        {
            var fd = new Dictionary<Position, FieldContents>();
            for (int x = 0; x < boardSize; x++)
            {
                for (int y = 0; y < boardSize; y++)
                {
                    for (int z = 0; z < boardSize; z++)
                    {
                        fd.Add(Position.Factory_3DPosition(x, y, z), fc[z][y][x]);
                    }
                }
            }
            return new Board(3, boardSize, fd);
        }
    }
}