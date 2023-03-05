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

        /* this is so normal chess notation for ranks and files can be inputted
         * by users. This function converts those inputs into co-ordinates for the
         * 2d board array. 
        */

        public static int LocationConvert(char selectedFile, int selectedRank)
        {
            char[] boardArray;
            //boardArray = Board.ChessBoard.ToCharArray();

            int row;
            row = 9 - selectedRank;
            row = row * 8;


            int positionInRow;
            selectedFile = char.ToLower(selectedFile);
            positionInRow = ((int)selectedFile - 97);

            int index = row - (8 - positionInRow);
            return index;
        }

        public static int PieceSelect()
        {
            char selectedFile;
            int selectedRank;

            int pieceIndex;

            Console.WriteLine("Enter co-ordinate of piece square: ");
            string chosenSquare = Console.ReadLine();
            chosenSquare = chosenSquare.ToUpper();
            selectedFile = chosenSquare[0];
            selectedRank = chosenSquare[1] - '0';

            pieceIndex = LocationConvert(selectedFile, selectedRank);

            return pieceIndex;
            
        }

            static void Main()
        {


            PrintBoard();
            Console.Write("\n\n");
            //int pieceIndex = PieceSelect();

            bool whiteToPlay = true;
            MoveGeneration.PieceLogic(whiteToPlay);
            PlayMove.MakeMove();


            //https://learn.microsoft.com/en-us/dotnet/csharp/how-to/modify-string-contents

        }
    }
}