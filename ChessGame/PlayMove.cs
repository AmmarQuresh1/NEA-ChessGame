using System;
using System.Collections.Generic;
using System.Text;

namespace ChessGame
{
    class PlayMove
    {
        public static void MakeMove() 
        {
            List<PLegal> move = MoveGeneration.move;
            char[,] chessBoard = Board.ChessBoard;

            //starting square of piece selected by user 
            string sSquare;
            char sFile;
            double sRow;
            Console.WriteLine("Select piece to move: ");
            sSquare = Console.ReadLine();

            sFile = sSquare[0];
            sRow = Char.GetNumericValue(sSquare[1]);
            
            Console.WriteLine(sFile);
            Console.WriteLine(sRow);
        }
    }
}
