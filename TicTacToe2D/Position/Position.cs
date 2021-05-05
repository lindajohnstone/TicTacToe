using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace TicTacToe2D
{
    public class Position : IPosition
    {
        private List<DimensionValue> _dimensionValues;
        public int DimensionCount => _dimensionValues.Count;

        public Position(IEnumerable<DimensionValue> positions)
        {
            _dimensionValues = new List<DimensionValue>(positions);
        }

        public int GetPosition(int dimension)
        {
            return _dimensionValues[dimension].Value;
        }

        public IEnumerator<DimensionValue> GetEnumerator()
        {
            return _dimensionValues.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _dimensionValues.GetEnumerator();
        }

        public override bool Equals(object obj)
        {

            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            Position position = (Position)obj;
            if (position.DimensionCount != DimensionCount)
            {
                return false;
            }
            
            return _dimensionValues.All((x) => position.GetPosition(x.Dimension) == x.Value);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return base.ToString();
        }

        // public static Position operator +(Position obj1, Position obj2)
        // {
        //     return new Position((obj1.X + obj2.X), (obj1.Y + obj2.Y));
        // }

        // public override int GetHashCode()
        // {
        //     return X ^ Y;
        // }

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
            if (obj1.DimensionCount != obj2.DimensionCount)
            {
                return false;
            }
            return obj1.All((x) => obj2.GetPosition(x.Dimension) == x.Value);
        }
        public static bool operator ==(Position obj1, Position obj2)
        {
            return OperatorOverride(obj1, obj2);
        }

        public static bool operator !=(Position obj1, Position obj2)
        {
            return !OperatorOverride(obj1, obj2);
        }

        public static List<DimensionValue> Factory_2DPosition()
        {
            throw new NotImplementedException();
        }
    }
}