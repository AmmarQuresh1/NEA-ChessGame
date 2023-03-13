using System;
using System.Collections.Generic;

namespace ChessGame
{
    class Game
    {
        public static void PrintBoard()
        {
            for (int i = 0; i < Board.ChessBoard.GetLength(0); i++)
            {
                Console.Write(8-i + "|  ");     
                for (int j = 0; j < Board.ChessBoard.GetLength(1); j++)
                {
                    Console.Write(Board.ChessBoard[i,j] + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine("    _______________"+"\n    A B C D E F G H");
        }

        static void Main()
        {   
            bool gameEnd = false;
            bool whiteToPlay = true;

            while (!gameEnd)
            {
                PrintBoard();
                Console.Write("\n");
                MoveGeneration.PieceLogic(whiteToPlay);
                if (whiteToPlay)
                {
                    PlayMove.MakeMove();
                    whiteToPlay = false;
                }
                else
                {
                    PlayMove.BlackMove();
                    whiteToPlay = true;
                }
                Console.Clear();
            }

            //next steps:

            //DONE finish move generator 
            //implement game end state checker (a king dies)
            //Give instructions on first open
            //implement computer black movement
        }
    }
}