using System.Collections.Generic;

namespace TicTacToe2D
{
    public class Board3D : Board
    {
        // inherits Board to set up 3D Board 
        // name cannot be 3DBoard 
        public Board3D()
        {
        }

        public Board3D(int boardSize) : base(boardSize)
        {
        }

        public Board3D(Board sourceBoard) : base(sourceBoard)
        {
        }

        protected override Dictionary<Position, FieldContents> BoardInitializer(int boardSize)
        {
            throw new System.NotImplementedException();
        }

        protected override Board2D Clone()
        {
            throw new System.NotImplementedException();
        }
    }
}