using System;

namespace TicTacToe2D
{
    public static class OutputFormatter 
    {
        // print instructions to console
        // print board to console
        // print win (which player) or draw 

        public static Board DrawBoard(Board board, Player player, ConsoleOutput output)
        {
            throw new NotImplementedException();
        }

        public static void PrintInstructions(ConsoleOutput output, Player player)
        {
            output.ConsoleWriteLine("Here's the current board:");
            //DrawBoard()
            var playerId = (int)player;
            var playerToken = player;
            var message = "Player {playerId} enter a coord x,y to place your {player} or enter 'q' to give up: ";
            output.ConsoleWrite("Player 1 enter a coord x,y to place your X or enter 'q' to give up: "); 
            // TODO: string interpolation so becomes dynamic for each player 
        }

        public static string PrintGameEnd(ConsoleOutput output)
        {
            throw new NotImplementedException();
        }

        private static void PrintPlayerMove(ConsoleOutput output)
        {
            throw new NotImplementedException();
        }
    }
}