using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToeLibrary
{
    
    public enum PieceType
    {
        PIECEX,
        PIECEO
    }


    public class Piece
    {
        private PieceType pieceType;
        public Piece(PieceType pieceType)
        {
            this.pieceType = pieceType;
        }

        public PieceType getPieceType()
        {
            return pieceType;
        }
    }
}
