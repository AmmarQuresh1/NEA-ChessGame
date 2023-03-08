using System;
using System.Collections.Generic;
using System.Linq;
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

            Console.WriteLine("Select piece to move: ");
            sSquare = Console.ReadLine();
            sFile = sSquare[0] - 97;
            sRow = 8 - Convert.ToInt16(Char.GetNumericValue(sSquare[1]));
            Console.WriteLine(sRow + " " + sFile);
            int[] list = {6, 0};
            int[] endList = { 5, 0 };

            var result = from s in move
                         where s.currentPos == list
                         select s;
            foreach(var results in result)
            {
                Console.WriteLine("ok");
            }
            
        }
    }
}


/*
            if (whiteToPlay)
            {
                while (sFile < 0 || sFile > 7 || sRow < 0 || sRow > 7 || boardArray[sRow, sFile] == '-' || friendlyPiece == true)
                {
                    Console.WriteLine("Select piece to move: ");
                    sSquare = Console.ReadLine();
                    sFile = sSquare[0] - 97;
                    sRow = 8 - Convert.ToInt16(Char.GetNumericValue(sSquare[1]));
                    Console.WriteLine(sRow + " " + sFile);
                    //need to make sure if white is playing you cannot move opponents piece.
                    foreach (char piece in blackPieces)
                    {
                        if (boardArray[sRow, sFile] == piece)
                        {
                            friendlyPiece = true;
                            break;
                        }
                        else
                        {
                            friendlyPiece = false;
                        }
                    }
                }
            }
            if (!whiteToPlay)
            {
                while (sFile < 0 || sFile > 7 || sRow < 0 || sRow > 7 || boardArray[sRow, sFile] == '-' || friendlyPiece == true)
                {
                    Console.WriteLine("Select piece to move: ");
                    sSquare = Console.ReadLine();
                    sFile = sSquare[0] - 97;
                    sRow = 8 - Convert.ToInt16(Char.GetNumericValue(sSquare[1]));
                    Console.WriteLine(sRow + " " + sFile);
                    foreach (char piece in whitePieces)
                    {
                        if (boardArray[sRow, sFile] == piece)
                        {
                            friendlyPiece = true;
                            break;
                        }
                        else
                        {
                            friendlyPiece = false;
                        }
                    }
                }
            }
            Console.WriteLine(boardArray[sRow, sFile]);
            */
