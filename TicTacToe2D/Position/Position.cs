using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
namespace TicTacToe2D
{
    public class Position : IPosition, IEquatable<Position> //TODO: is IPosition being used
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
        
        public override string ToString()
        {
            return base.ToString();
        }

        public static Position operator +(Position obj1, Position obj2)
        {
            if (obj1 == null || obj2 == null)
            {
                throw new ArgumentNullException();
            }
            if (obj1.DimensionCount != obj2.DimensionCount)
            {
                throw new ArgumentException("Addition requires matching position objects to have the same number of dimensions.");
            }
            var dimensionList = new List<DimensionValue>();
            for (int i = 0; i < obj1.DimensionCount; i++)
            {
                var value = obj1.GetPosition(i) + obj2.GetPosition(i);
                dimensionList.Add(new DimensionValue(i, value));
            }
            return new Position(dimensionList);
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
        
        public bool Equals(Position other)
        {
            if (other is null)
                return false;
            return OperatorOverride(this, other);
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as Position);
        }

        public override int GetHashCode()
        {
            return (GetPosition(0), GetPosition(1)).GetHashCode();
        }
        public static Position Factory_2DPosition(int x, int y)
        {
            var dv = new List<DimensionValue>()
            {
                new DimensionValue(0,x),
                new DimensionValue(1,y)
            };
            return new Position(dv);
        }
        public static Position Factory_3DPosition(int x, int y, int z)
        {
            var dv = new List<DimensionValue>()
            {
                new DimensionValue(0,x),
                new DimensionValue(1,y),
                new DimensionValue(2,z)
            };
            return new Position(dv);
        }
        public static Position Factory_FromPlayerInput(List<int> positions)
        {
            switch (positions.Count)
            {
                case 2:
                    return Factory_2DPosition(positions[0], positions[1]);
                case 3:
                    return Factory_3DPosition(positions[0], positions[1], positions[2]);
                default:
                    throw new ArgumentException();
            }
        }
    }
}