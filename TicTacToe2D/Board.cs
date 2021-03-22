using System;
using System.Collections.Generic;

namespace TicTacToe2D
{
    public class Board
    {
        // container of fields
        // Dictionary with coord as key, field as value??
        private Dictionary<Position, Field> _dictionary;
        public int Width { get; private set; }
        public int Height { get; private set; }

        public Board() 
        {
            // implement population of dictionary with coords and fields based on 3x3 fields.

            //_dictionary.Add(position(0,0), Field.empty);// Field.0
            // loop 
        }  

        
        // another method to draw new board when player inputs valid position
    }
}