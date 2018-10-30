using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToeLibrary
{
    public class Square
    {
        private Piece piece;

        public bool isOccupied()
        {
            return piece != null;
        }
        public Piece getPiece()
        {
            return piece;
        }
        public void placePiece(Piece piece)
        {
            this.piece = piece;
        }
        public void remove()
        {
            piece = null;
        }
    }
}
