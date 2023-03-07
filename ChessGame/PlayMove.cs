using System;
using System.Collections.Generic;
using System.Text;

namespace ChessGame
{
    class PlayMove
    {
        public static void MakeMove(bool whiteToPlay) 
        {
            List<PLegal> move = MoveGeneration.move;
            char[,] boardArray = Board.ChessBoard;

            //starting square of piece selected by user 
            string sSquare;
            int sFile = -1;
            int sRow = -1;


            //need to make sure if white is playing you cannot move opponents piece.
            while(sFile < 0 || sFile > 7 || sRow < 0 || sRow > 7 || boardArray[sRow, sFile] == '-' )
            {
                Console.WriteLine("Select piece to move: ");
                sSquare = Console.ReadLine();
                sFile = sSquare[0] - 97;
                sRow = 8 - Convert.ToInt16(Char.GetNumericValue(sSquare[1]));
                Console.WriteLine(sFile + " " + sRow);
            }
            Console.WriteLine(boardArray[sRow, sFile]);
        }
    }
}
