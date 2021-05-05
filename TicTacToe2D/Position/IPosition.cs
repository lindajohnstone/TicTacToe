using System.Collections.Generic;

namespace TicTacToe2D
{
    public interface IPosition : IEnumerable<DimensionValue>
    {
        // allow Position to deal with any number of dimensions
        public int DimensionCount { get; }
        public int GetPosition(int dimension);
    }
}