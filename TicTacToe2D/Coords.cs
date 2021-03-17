using System;
using System.Collections.Generic;

namespace TicTacToe2D
{
    public class Coords
    {
        // store location of field
        // (0,1)
    
        public int X { get; set; }
        public int Y { get; set; }
        public Coords(int x, int y)
        {
            X = x;
            Y = y;
        }
        public Coords StoreLocation(int x, int y) // TODO: int x, int y as parameters?; return position(x,y)
        {
            throw new NotImplementedException();
        }
    }
}