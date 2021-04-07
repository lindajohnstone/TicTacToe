namespace TicTacToe2D.Tests
{
    public static class SourceData
    {
        public static Board BoardIsWinningBoardTrue()
        {
            var initData = new FieldContents[][] 
            {
                new []{FieldContents.x, FieldContents.y, FieldContents.empty},
                new []{FieldContents.x, FieldContents.y, FieldContents.empty},
                new []{FieldContents.x, FieldContents.y, FieldContents.empty}
            };
            return new Board(initData);
        }
        public static Board BoardIsInitialized()
        {
            var initData = new FieldContents[][] 
            {
                new []{FieldContents.empty, FieldContents.empty, FieldContents.empty},
                new []{FieldContents.empty, FieldContents.empty, FieldContents.empty},
                new []{FieldContents.empty, FieldContents.empty, FieldContents.empty}
            };
            return new Board(initData);
        }
        public static Board BoardXFirstMove()
        {
            var initData = new FieldContents[][] 
            {
                new []{FieldContents.empty, FieldContents.x, FieldContents.empty},
                new []{FieldContents.empty, FieldContents.empty, FieldContents.empty},
                new []{FieldContents.empty, FieldContents.empty, FieldContents.empty}
            };
            return new Board(initData);
        }
        
        public static Board BoardIsWinningBoardFalse()
        {
            var initData = new FieldContents[][] 
            {
                new []{FieldContents.x,     FieldContents.x,     FieldContents.empty},
                new []{FieldContents.y,     FieldContents.empty, FieldContents.y},
                new []{FieldContents.empty, FieldContents.x,     FieldContents.y}
            };
            return new Board(initData);
        }

        public static Board BoardIsWinningBoardXWinningColumn()
        {
            var initData = new FieldContents[][] 
            {
                new []{FieldContents.x, FieldContents.y, FieldContents.empty},
                new []{FieldContents.x, FieldContents.y, FieldContents.empty},
                new []{FieldContents.x, FieldContents.empty, FieldContents.empty}
            };
            return new Board(initData);
        }
        public static Board BoardIsWinningBoardYWinningColumn()
        {
            var initData = new FieldContents[][] 
            {
                new []{FieldContents.x,     FieldContents.y, FieldContents.empty},
                new []{FieldContents.x,     FieldContents.y, FieldContents.x},
                new []{FieldContents.empty, FieldContents.y, FieldContents.empty}
            };
            return new Board(initData);
        }

        public static Board BoardYWinsXLoses()
        {
            var initData = new FieldContents[][] 
            {
                new []{FieldContents.x,     FieldContents.empty,    FieldContents.y},
                new []{FieldContents.y,     FieldContents.y,        FieldContents.y},
                new []{FieldContents.empty, FieldContents.x,        FieldContents.y}
            };
            return new Board(initData);
        }

        public static Board BoardYWinsXWins()
        {
            var initData = new FieldContents[][] 
            {
                new []{FieldContents.x,     FieldContents.y,        FieldContents.x},
                new []{FieldContents.empty, FieldContents.x,        FieldContents.y},
                new []{FieldContents.y,     FieldContents.empty,    FieldContents.empty}
            };
            return new Board(initData);
        }

        public static Board BoardNeitherXNorYWins()
        {
            var initData = new FieldContents[][]
            {
                new [] {FieldContents.x,    FieldContents.y,    FieldContents.x},
                new []{FieldContents.empty, FieldContents.x,    FieldContents.y},
                new []{FieldContents.y,     FieldContents.x,    FieldContents.y}
            };
            return new Board(initData);
        }
        public static Board BoardXWinningTopRow()
        {
            var initData = new FieldContents[][]
            {
                new []  {FieldContents.x,       FieldContents.x,    FieldContents.x},
                new []  {FieldContents.empty,   FieldContents.y,    FieldContents.y},
                new []  {FieldContents.y,       FieldContents.x,    FieldContents.y}
            };
            return new Board(initData);
        }

        public static Board BoardYWinningCentreRow()
        {
            var initData = new FieldContents[][]
            {
                new []  {FieldContents.y,   FieldContents.x,    FieldContents.x},
                new []  {FieldContents.y,   FieldContents.y,    FieldContents.y},
                new []  {FieldContents.x,   FieldContents.x,    FieldContents.empty}
            };
            return new Board(initData);
        }

        public static Board BoardWinningRow3()
        {
            var initData = new FieldContents[][]
            {
                new []  {FieldContents.empty, FieldContents.x,    FieldContents.empty},
                new []  {FieldContents.y,     FieldContents.y,    FieldContents.y},
                new []  {FieldContents.x,     FieldContents.x,    FieldContents.x}
            };
            return new Board(initData);
        }

        public static Board BoardWinningDiagonalLR()
        {
            var initData = new FieldContents[][]
            {
                new []  {FieldContents.x,   FieldContents.y,    FieldContents.empty},
                new []  {FieldContents.y,   FieldContents.x,    FieldContents.y},
                new []  {FieldContents.x,   FieldContents.y,    FieldContents.x}
            };
            return new Board(initData);
        }

        public static Board BoardWinningDiagonalRL()
        {
            var initData = new FieldContents[][]
            {
                new []  {FieldContents.empty,   FieldContents.y,    FieldContents.x},
                new []  {FieldContents.y,   FieldContents.x,    FieldContents.y},
                new []  {FieldContents.x,   FieldContents.y,    FieldContents.x}
            };
            return new Board(initData);
        }
    }
}