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
        // override ToString() method instead?
        /*
            represent integers as 00, 01, 02, 10, 11, 12, 20, 21, 22 
            or up to 10 x 10: 90, 91, 92, 93, 94, 95, 96, 97, 98, 99
             
            x = num 1 & 2, y = num 3 & 4
        */
        public Coords StoreLocation(int x, int y) // TODO: int x, int y as parameters?; return position(x,y) Method name ?
        {
            throw new NotImplementedException();
        }
    }
}