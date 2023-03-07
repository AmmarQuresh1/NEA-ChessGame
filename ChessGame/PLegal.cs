using System;
using System.Collections.Generic;
using System.Linq;

namespace ChessGame
{
    internal class PLegal
    {
        //Pseudo-legal moves obey normal rules of piece movement but don't check to see if the king is left in check
        // the board index of the piece and the index of the square it can move to  
        public int[] currentPos { get; set; }  
        public int[] moveablePos { get; set; }

        public override string ToString()
        {
            string x = string.Join(", ", currentPos);
            string y = string.Join(", ", moveablePos);

            return "currentPos: " + x + " moveablePos: " + y;
        }
    }
}
