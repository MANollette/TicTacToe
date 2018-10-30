using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToeLibrary;

namespace TicTacToeTests
{
    class TicTacToeTestDuration
    {
        public static void excuteMoves(
            List<int[]> moves,
            Board board)
        {
            bool isX = true;
            foreach (int[] move in moves)
            {
                board.move(move[0],
                    move[1],
                    isX ?
                    PieceType.PIECEX :
                    PieceType.PIECEO);
                isX = !isX;
            }
        }
    }
}
