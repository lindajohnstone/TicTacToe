using System;
using System.Collections.Generic;

namespace TicTacToe2D
{
    public class Board
    {
        // container of fields
        // Dictionary with coord as key, field as value??
        private Dictionary<Coords, Field> _dictionary = new Dictionary<Coords, Field>();// size??

        public Board() 
        {
            // implement population of dictionary with coords and fields based on 3x3 fields.
            // _dictionary.Add(position(x,y), Field.empty)// Field.0
            // loop 
        }  

        public Board DrawBoard(int width, int length)
        {
            throw new NotImplementedException();
        }
    }
}