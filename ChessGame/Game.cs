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
                for (int j = 0; j < Board.ChessBoard.GetLength(1); j++)
                {
                    Console.Write(Board.ChessBoard[i,j]);
                }
                Console.WriteLine();
            }
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
        
        /* REDUNDANT
        public static void PieceLogic(int pieceIndex)
        {

            bool whitePiece;
            char selectedPiece = Board.ChessBoard[pieceIndex];

            if (Char.IsUpper(selectedPiece))
            {
                whitePiece = true;
            }
            else
            {
                whitePiece = false;
            }


            // directions
            int N = -8;
            int E = 1;
            int S = 8;
            int W = -1;

            int[] pawnMoves = { N, N + N, N + W, N + E };


            int[] possibleMoves;

            if (Char.ToUpper(selectedPiece) == 'P')
            {
                possibleMoves = pawnMoves;
            }
            else
            {
                possibleMoves = pawnMoves;
            }

            if (!whitePiece)
            {
                foreach (int move in possibleMoves)
                {
                    possibleMoves[move] = possibleMoves[move] * -1;
                }
            }

            int searchSquare;
            char[] boardArray = Board.ChessBoard.ToCharArray();
            List<int> LegalMoves = new List<int>();

            for (int i = 0; i < possibleMoves.Length; i++)
            {

                searchSquare = pieceIndex + possibleMoves[i];
                if (boardArray[searchSquare] == ' ')
                {
                    LegalMoves.Add(possibleMoves[i]);
                }

            }
        }
        */

            static void Main()
        {


            //PrintBoard();
            Console.Write("\n\n");
            //int pieceIndex = PieceSelect();

            bool whiteToPlay = true;
            //MoveGeneration.PieceLogic(whiteToPlay);
            BishopTest.PieceLogic(whiteToPlay);



            //https://learn.microsoft.com/en-us/dotnet/csharp/how-to/modify-string-contents

        }
    }
}