using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Transactions;

namespace ChessGame
{
    class PlayMove
    {
        public static void MakeMove(bool whiteToPlay)
        {
            List<int[]> moves = MoveGeneration.moves;
            char[,] boardArray = Board.ChessBoard;

            //starting square of piece
            string sSquare;
            int sRow = 0;
            int sFile = 0;      

            //end square of piece
            string eSquare;
            int eRow = 0;
            int eFile = 0; 

            bool validMoveSelection = false;
            
            while (!validMoveSelection) 
            {
                Console.WriteLine("Select piece to move: ");
                sSquare = Console.ReadLine();
                sRow = 8 - Convert.ToInt16(Char.GetNumericValue(sSquare[1]));
                sFile = sSquare[0] - 97;

                Console.WriteLine("Select square to move to: ");
                eSquare = Console.ReadLine();
                eRow = 8 - Convert.ToInt16(Char.GetNumericValue(eSquare[1]));
                eFile = eSquare[0] - 97;
                for (int i = 0; i < moves.Count; i++)
                {
                    if (moves[i].SequenceEqual(new int[] { sRow, sFile, eRow, eFile }))
                    {
                        validMoveSelection = true;
                        break;
                    }
                    else if (i == moves.Count - 1)
                    {
                        Console.WriteLine("Invalid move selection\n");
                    }
                }
                
            }
            char piece;
            piece = boardArray[sRow, sFile];
            boardArray[sRow, sFile] = '-';
            boardArray[eRow, eFile] = piece;
        }
    }
}

