using System;

namespace TicTacToe2D
{
    public class Position3D : Position
    {
        // inherits Position to set the position for the 3D Board
        public Position3D(int x, int y, int z) : base(x, y, z)
        {
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
            if (obj1.X == obj2.X && obj1.Y == obj2.Y && obj1.Z == obj2.Z)
            {
                return true;
            }
            return false;
        }

        public override bool Equals(object obj)
        {
            return obj is Position3D d &&
                   X == d.X &&
                   Y == d.Y &&
                   Z == d.Z;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(X, Y, Z);
        }

        public static bool operator ==(Position3D obj1, Position obj2)
        {
            if (OperatorOverride(obj1, obj2))
            {
                return true;
            }
            return false;
        }

        public static bool operator !=(Position3D obj1, Position obj2)
        {
            if (!OperatorOverride(obj1, obj2))
            {
                return false;
            }
            return true;
        }
    }
}