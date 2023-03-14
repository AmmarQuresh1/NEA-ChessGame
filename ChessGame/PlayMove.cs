using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Transactions;

namespace ChessGame
{
    class PlayMove
    {
        static List<int[]> moves = MoveGeneration.moves;
        static char[,] boardArray = Board.ChessBoard;
        public static int MakeMove()
        {
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
                try
                {
                    Console.Write("Select piece to move: ");
                    sSquare = Console.ReadLine();
                    sRow = 8 - Convert.ToInt16(Char.GetNumericValue(sSquare[1]));
                    sFile = sSquare[0] - 97;

                    Console.Write("Select square to move to: ");
                    eSquare = Console.ReadLine();
                    eRow = 8 - Convert.ToInt16(Char.GetNumericValue(eSquare[1]));
                    eFile = eSquare[0] - 97;
                }
                catch{ }
                
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

            bool gameEnd = false;
            if (boardArray[eRow,eFile] == 'k')
            {
                gameEnd = true;
            }

            char piece;
            piece = boardArray[sRow, sFile];
            boardArray[sRow, sFile] = '-';
            boardArray[eRow, eFile] = piece;

            if (gameEnd)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }

        static Random rnd = new Random();
        public static int BlackMove()
        {
            int[] currentMove;
            int[] bestMove = { 0, 0, 0, 0 };

            int moveValue;
            int bestMoveValue = 0;

            bool makeRandomMove = true;
            for (int i = 0; i < moves.Count; i++)
            {
                moveValue = 0;
                currentMove = moves[i];

                //prioritise taking pieces 
                switch(boardArray[currentMove[2], currentMove[3]])
                {
                    case 'P':
                        moveValue += 1;
                        break;
                    case 'R':
                        moveValue += 5;
                        break;
                    case 'N':
                        moveValue += 3;
                        break;
                    case 'B':
                        moveValue += 3;
                        break;
                    case 'Q':
                        moveValue += 9;
                        break;
                    case 'K':
                        moveValue += 100;
                        break;
                }
                if (moveValue > bestMoveValue)
                {
                    bestMoveValue = moveValue;
                    bestMove = moves[i];
                    makeRandomMove = false;
                }
            }
            if (makeRandomMove)
            {
                int r = rnd.Next(moves.Count);

                bestMove = moves[r];
            }

            bool gameEnd = false;
            if (boardArray[bestMove[2], bestMove[3]] == 'K')
            {
                gameEnd = true;
            }

            char piece;
            piece = boardArray[bestMove[0], bestMove[1]];
            boardArray[bestMove[0], bestMove[1]] = '-';
            boardArray[bestMove[2], bestMove[3]] = piece;

            if (gameEnd)
            {
                return 2;
            }
            else
            {
                return 0;
            }
        }
    }
}

