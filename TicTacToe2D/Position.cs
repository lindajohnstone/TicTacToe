using System;
using System.Collections.Generic;

namespace TicTacToe2D
{
    public class Position
    {
        // store location of field
        // (0,1)

        public int X { get; set; }
        public int Y { get; set; }
        public Position(int x, int y)
        {
            X = x;
            Y = y;
        }
        /*
            class name options:
            Coords - exact position of a field. Pair
            Position - where something has been located
            Point - particular place - no - Point is a class, may cause confusion

        */

        // override object.Equals
        public override bool Equals(object obj)
        {
            //
            // See the full list of guidelines at
            //   http://go.microsoft.com/fwlink/?LinkID=85237
            // and also the guidance for operator== at
            //   http://go.microsoft.com/fwlink/?LinkId=85238
            //

            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            // TODO: write your implementation of Equals() here.  
            else
            {
                Position position = (Position)obj;
                return ( X == position.X) && (Y == position.Y);
            }
            // return base.Equals (obj);
        }

        // override object.GetHashCode
        public override int GetHashCode()
        {
            // TODO: write your implementation of GetHashCode() here. uncomment return
            throw new System.NotImplementedException();
            //return base.GetHashCode();
        }
    }
}