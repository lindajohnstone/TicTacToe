using System;
using System.Collections.Generic;

namespace TicTacToe2D
{
    public class TurnQueue
    {
        // stores queue of player turns
        Queue<Player> _queue = new Queue<Player>();

        public TurnQueue(List<Player> players)
        {
            foreach (var player in players)
            {
                _queue.Enqueue(player);
            }
        }
        
        public Player GetCurrentPlayer()
        {
            return _queue.Peek();
        }

        public Player SetNextPlayer()
        {
            var lastPlayer = _queue.Dequeue();
            _queue.Enqueue(lastPlayer);
            return GetCurrentPlayer();
        }
    }
}