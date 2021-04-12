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

        public override bool Equals(object obj)
        {

            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }
  
            else
            {
                Position position = (Position)obj;
                return X == position.X && Y == position.Y;
            }
        }

        public static Position operator +(Position obj1, Position obj2)
        {
            return new Position((obj1.X + obj2.X), (obj1.Y + obj2.Y));
        }

        public override int GetHashCode()
        {
            return X ^ Y;
        }
        
        public static bool OperatorOverride(Position obj1, Position obj2)
        {
            if ((object)obj1 == null && (object)obj2 == null)
            {
                return true;
            }
            if ((object)obj1 == null || (object)obj2 == null)
            {
                return false;
            }
            if (obj1.X == obj2.X && obj1.Y == obj2.Y)
            {
                return true;
            }
            return false;
        }
        public static bool operator == (Position obj1, Position obj2)
        {
            if (OperatorOverride(obj1, obj2))
            {
                return true;
            }
            return false;
        }

        // TODO: method Compare to do all calcs, checks, edge cases
        // TODO: merge operator methods - one calls other
        public static bool operator != (Position obj1, Position obj2)
        {
            if (!OperatorOverride(obj1, obj2))
            {
                return false;
            }
            return true;
        }  
    }
}