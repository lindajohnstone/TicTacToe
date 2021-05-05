using System;

namespace TicTacToe2D
{
    public class DimensionValue : Tuple<int, int>
    {
        public int Dimension { get { return Item1; } }
        public int Value { get { return Item2; } }

        public DimensionValue(int dimension, int value) : base(dimension, value)
        {
            
        }
    }
}