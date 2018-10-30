using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToeLibrary
{
    class BoardUtils
    {
        public static bool inRange(int[] indexes)
        {
            bool ret = true;
            foreach (int index in indexes)
            {
                ret &= inRange(index);
            }
            return ret;
        }

        public static bool turnControl(bool xTurn, PieceType player)
        {
            var turn = xTurn ? PieceType.PIECEX : PieceType.PIECEO;
            if (turn != player)
            {
                return false;
            }
            return true;
        }
        private static bool inRange(int index)
        {
            if (index < 0 || index >= Board.SIZE)
            {
                return false;
            }
            return true;
        }
    }
}

