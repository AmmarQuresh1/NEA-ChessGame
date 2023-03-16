using System;
using System.Collections.Generic;
using System.Linq;

namespace ChessGame
{
    //Move maker for player and computer, also detects game win state
    class PlayMove
    {
        static List<int[]> moves = MoveGeneration.moves;
        static char[,] boardArray = Board.ChessBoard;
        //This method is for the user to make a move
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
                //avoids any error due to user input
                try
                {
                    Console.Write("Select piece to move: ");
                    sSquare = Console.ReadLine();
                    //Converts the number passed as a character by the user into a number 
                    //The 8 - inverts the number, as when the board is printed the visual co-ordinate 8 is actually at position 0
                    sRow = 8 - Convert.ToInt16(Char.GetNumericValue(sSquare[1]));
                    //The first character passed by the user is converted to ascii and the subtract 97 gives an integer that will be the actual position on the board
                    sFile = sSquare[0] - 97;

                    Console.Write("Select square to move to: ");
                    eSquare = Console.ReadLine();
                    eRow = 8 - Convert.ToInt16(Char.GetNumericValue(eSquare[1]));
                    eFile = eSquare[0] - 97;
                }
                catch{ }
                
                //Loops through the list of arrays "moves"
                for (int i = 0; i < moves.Count; i++)
                {
                    //Checks if the user's selection for where to move the piece to or from
                    //matches any entry inside the list of arrays. 
                    if (moves[i].SequenceEqual(new int[] { sRow, sFile, eRow, eFile }))
                    {
                        validMoveSelection = true;
                        break;
                    }
                    //If the user selection does not match any array in the list, they will be told with the print message shown on the console.
                    else if (i == moves.Count - 1)
                    {
                        Console.WriteLine("Invalid move selection\n");
                    }
                }
            }

            //If the piece that is taken by the user is the black king 'k' then set bool gameEnd to true
            bool gameEnd = false;
            if (boardArray[eRow,eFile] == 'k')
            {
                gameEnd = true;
            }

            //sets piece to the current location
            char piece;
            piece = boardArray[sRow, sFile];
            //Then sets current location to an empty square
            boardArray[sRow, sFile] = '-';
            //Then places piece on the end location
            boardArray[eRow, eFile] = piece;

            if (gameEnd)
            {
                //returning 1 shows that white has won
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

                //switch statement for what type of piece (if there is one) is on the 
                //ending squares (square that the piece in the move will land on)
                switch(boardArray[currentMove[2], currentMove[3]])
                {
                    //Each piece is given a value as some pieces are worth more
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
                    //Setting the value of the white king high makes it so the 
                    //computer will always take the white king if possible
                    case 'K':
                        moveValue += 100;
                        break;
                }
                //if the current move that is being looped through is better
                //than the last highest move then that move will be set to the bestMove
                if (moveValue > bestMoveValue)
                {
                    bestMoveValue = moveValue;
                    bestMove = moves[i];
                    //if a move has been quantified as being good the program will not make a random move
                    makeRandomMove = false;
                }
            }
            //A random move will only be made if it is not clear what is the best move
            //Such as no pieces can be taken
            if (makeRandomMove)
            {
                int r = rnd.Next(moves.Count);

                bestMove = moves[r];
            }

            bool gameEnd = false;
            //If the piece that is taken by the computer is the white king 'K' then set bool gameEnd to true
            if (boardArray[bestMove[2], bestMove[3]] == 'K')
            {
                gameEnd = true;
            }

            //sets piece to the current location
            char piece;
            piece = boardArray[bestMove[0], bestMove[1]];
            //Then sets current location to an empty square
            boardArray[bestMove[0], bestMove[1]] = '-';
            //Then places piece on the end location
            boardArray[bestMove[2], bestMove[3]] = piece;

            if (gameEnd)
            {
                //returning 2 shows that black has won
                return 2;
            }
            else
            {
                return 0;
            }
        }
    }
}

