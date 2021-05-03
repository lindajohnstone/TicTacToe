namespace TicTacToe2D.Tests
{
    public static class SourceData
    {
        public static Board2D BoardIsWinningBoardTrue()
        {
            var initData = new FieldContents[][] 
            {
                new []{FieldContents.x, FieldContents.y, FieldContents.empty},
                new []{FieldContents.x, FieldContents.y, FieldContents.empty},
                new []{FieldContents.x, FieldContents.y, FieldContents.empty}
            };
            return new Board2D(initData);
        }
        public static Board2D BoardIsInitialized()
        {
            var initData = new FieldContents[][] 
            {
                new []{FieldContents.empty, FieldContents.empty, FieldContents.empty},
                new []{FieldContents.empty, FieldContents.empty, FieldContents.empty},
                new []{FieldContents.empty, FieldContents.empty, FieldContents.empty}
            };
            return new Board2D(initData);
        }
        public static Board2D BoardXFirstMove()
        {
            var initData = new FieldContents[][] 
            {
                new []{FieldContents.empty, FieldContents.x, FieldContents.empty},
                new []{FieldContents.empty, FieldContents.empty, FieldContents.empty},
                new []{FieldContents.empty, FieldContents.empty, FieldContents.empty}
            };
            return new Board2D(initData);
        }
        
        public static Board2D BoardIsWinningBoardFalse()
        {
            var initData = new FieldContents[][] 
            {
                new []{FieldContents.x,     FieldContents.x,     FieldContents.empty},
                new []{FieldContents.y,     FieldContents.empty, FieldContents.y},
                new []{FieldContents.empty, FieldContents.x,     FieldContents.y}
            };
            return new Board2D(initData);
        }

        public static Board2D BoardIsWinningBoardXWinningColumn()
        {
            var initData = new FieldContents[][] 
            {
                new []{FieldContents.x, FieldContents.y, FieldContents.empty},
                new []{FieldContents.x, FieldContents.y, FieldContents.empty},
                new []{FieldContents.x, FieldContents.empty, FieldContents.empty}
            };
            return new Board2D(initData);
        }
        public static Board2D BoardIsWinningBoardYWinningColumn()
        {
            var initData = new FieldContents[][] 
            {
                new []{FieldContents.x,     FieldContents.y, FieldContents.empty},
                new []{FieldContents.x,     FieldContents.y, FieldContents.x},
                new []{FieldContents.empty, FieldContents.y, FieldContents.empty}
            };
            return new Board2D(initData);
        }

        public static Board2D BoardYWinsXLoses()
        {
            var initData = new FieldContents[][] 
            {
                new []{FieldContents.x,     FieldContents.empty,    FieldContents.y},
                new []{FieldContents.y,     FieldContents.y,        FieldContents.y},
                new []{FieldContents.empty, FieldContents.x,        FieldContents.y}
            };
            return new Board2D(initData);
        }

        public static Board2D BoardYWinsXWins()
        {
            var initData = new FieldContents[][] 
            {
                new []{FieldContents.x,     FieldContents.y,        FieldContents.x},
                new []{FieldContents.empty, FieldContents.x,        FieldContents.y},
                new []{FieldContents.y,     FieldContents.empty,    FieldContents.empty}
            };
            return new Board2D(initData);
        }

        public static Board2D BoardNeitherXNorYWins()
        {
            var initData = new FieldContents[][]
            {
                new [] {FieldContents.x,    FieldContents.y,    FieldContents.x},
                new []{FieldContents.empty, FieldContents.x,    FieldContents.y},
                new []{FieldContents.y,     FieldContents.x,    FieldContents.y}
            };
            return new Board2D(initData);
        }
        public static Board2D BoardXWinningTopRow()
        {
            var initData = new FieldContents[][]
            {
                new []  {FieldContents.x,       FieldContents.x,    FieldContents.x},
                new []  {FieldContents.empty,   FieldContents.y,    FieldContents.y},
                new []  {FieldContents.y,       FieldContents.x,    FieldContents.y}
            };
            return new Board2D(initData);
        }

        public static Board2D BoardYWinningCentreRow()
        {
            var initData = new FieldContents[][]
            {
                new []  {FieldContents.y,   FieldContents.x,    FieldContents.x},
                new []  {FieldContents.y,   FieldContents.y,    FieldContents.y},
                new []  {FieldContents.x,   FieldContents.x,    FieldContents.empty}
            };
            return new Board2D(initData);
        }

        public static Board2D BoardWinningRow3()
        {
            var initData = new FieldContents[][]
            {
                new []  {FieldContents.empty, FieldContents.x,    FieldContents.empty},
                new []  {FieldContents.y,     FieldContents.y,    FieldContents.y},
                new []  {FieldContents.x,     FieldContents.x,    FieldContents.x}
            };
            return new Board2D(initData);
        }

        public static Board2D BoardWinningDiagonalLR()
        {
            var initData = new FieldContents[][]
            {
                new []  {FieldContents.x,   FieldContents.y,    FieldContents.empty},
                new []  {FieldContents.y,   FieldContents.x,    FieldContents.y},
                new []  {FieldContents.x,   FieldContents.y,    FieldContents.x}
            };
            return new Board2D(initData);
        }

        public static Board2D BoardWinningDiagonalRL()
        {
            var initData = new FieldContents[][]
            {
                new []  {FieldContents.empty,   FieldContents.y,    FieldContents.x},
                new []  {FieldContents.y,   FieldContents.x,    FieldContents.y},
                new []  {FieldContents.x,   FieldContents.y,    FieldContents.x}
            };
            return new Board2D(initData);
        }

        public static Board2D BoardMovePlayer()
        {
            var initData = new FieldContents[][]
            {
                new []{FieldContents.x,     FieldContents.empty, FieldContents.empty},
                new []{FieldContents.empty, FieldContents.empty, FieldContents.empty},
                new []{FieldContents.empty, FieldContents.empty, FieldContents.empty}
            };
            return new Board2D(initData);
        }

        public static Board2D BoardIsADraw()
        {
            var initData = new FieldContents[][]
            {
                new [] { FieldContents.x,   FieldContents.y,    FieldContents.x},
                new [] { FieldContents.x,   FieldContents.y,    FieldContents.y},
                new [] { FieldContents.y,   FieldContents.x,    FieldContents.x}
            };
            return new Board2D(initData);
        }
        
        public static Board2D BoardIsNotADraw()// next move is a draw
        {
            var initData = new FieldContents[][]
            {
                new [] { FieldContents.x,       FieldContents.y,    FieldContents.x},
                new [] { FieldContents.empty,   FieldContents.y,    FieldContents.y},
                new [] { FieldContents.y,       FieldContents.x,    FieldContents.x}
            };
            return new Board2D(initData);
        }

        public static Board2D BoardIsNotADrawV2()// next move is a win
        {
            var initData = new FieldContents[][]
            {
                new [] { FieldContents.x,       FieldContents.y,    FieldContents.y},
                new [] { FieldContents.empty,   FieldContents.x,    FieldContents.x},
                new [] { FieldContents.y,       FieldContents.y,    FieldContents.x}
            };
            return new Board2D(initData);
        }

        public static Board2D BoardValidTurn()
        {
            var initData = new FieldContents[][]
            {
                new [] { FieldContents.x,       FieldContents.empty,    FieldContents.y},
                new [] { FieldContents.empty,   FieldContents.empty,    FieldContents.empty},
                new [] { FieldContents.y,       FieldContents.empty,    FieldContents.x}
            };
            return new Board2D(initData);
        }

        public static Board2D BoardMovePlayerY()
        {
            var initData = new FieldContents[][]
            {
                new []{FieldContents.x,     FieldContents.y,        FieldContents.empty},
                new []{FieldContents.empty, FieldContents.empty,    FieldContents.empty},
                new []{FieldContents.empty, FieldContents.empty,    FieldContents.empty}
            };
            return new Board2D(initData);
        }
    }
}