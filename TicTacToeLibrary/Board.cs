using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToeLibrary
{
    public enum GameState
    {
        ONGOING,
        XVICTORY,
        OVICTORY,
        DRAW
    }

    public class Board
    {
        public static int SIZE = 3;
        private Square[,] squares = new Square[SIZE, SIZE];
        private bool xTurn = true;
        private GameState state = GameState.ONGOING;

        private Board()
        {
            for (var x = 0; x < SIZE; ++x)
            {
                for (var y = 0; y < SIZE; ++y)
                {
                    squares[x, y] = new Square();
                }
            }
        }

        public static Board create()
        {
            return new Board();
        }


        public Square getSquare(int x, int y)
        {
            return squares[x, y];
        }

        // return false if illegal (I.e. not your turn, not valid destination).
        // return true if successful, then update board state.
        public bool move(int x, int y, PieceType player)
        {
            if (getState() != GameState.ONGOING)
            {
                return false;
            }
            if (!BoardUtils.turnControl(xTurn, player))
            {
                return false;
            }
            if (!BoardUtils.inRange(new int[] { x, y }))
            {
                return false;
            }

            if (squares[x, y].isOccupied())
            {
                return false;
            }          

            executeMove(x, y);
            xTurn = !xTurn;
            return true;
        }

        private void executeMove(int x, int y)
        {
            var piece = new Piece(PieceType.PIECEX);
            if (!BoardUtils.turnControl(true, PieceType.PIECEX)) piece = new Piece(PieceType.PIECEO);
            squares[x, y].placePiece(piece);

            //checkAllRows();
            //checkAllDiagonals();
        }

        #region victoryChecks
        private void checkAllRows()
        {
            int xCount = 0;
            int oCount = 0;

            for (int i = 0; i < 2; i++)
            {
                xCount = 0;
                oCount = 0;
                for (int j = 0; j < 2; j++)
                {
                    if (squares[i, j].getPiece().getPieceType() == PieceType.PIECEX)
                    {
                        xCount++;
                    }
                    if (squares[i, j].getPiece().getPieceType() == PieceType.PIECEO)
                    {
                        oCount++;
                    }

                    if (xCount == 3)
                    {
                        state = GameState.XVICTORY;
                    }
                    if (oCount == 3)
                    {
                        state = GameState.OVICTORY;
                    }
                }
            }
        }

        private void checkAllDiagonals()
        {
            int xCount = 0;
            int oCount = 0;

            for (int i = 1; i < 3; i++)
            {
                for (int j = 1; j < 3; j++)
                {
                    if (i == j && squares[j, i].getPiece().getPieceType() == PieceType.PIECEX)
                    {
                        xCount++;
                    }

                    if (i == j && squares[j, i].getPiece().getPieceType() == PieceType.PIECEO)
                    {
                        oCount++;
                    }

                    if (xCount == 3)
                    {
                        state = GameState.XVICTORY;
                    }
                    if (oCount == 3)
                    {
                        state = GameState.OVICTORY;
                    }
                }
            }
        }

        public GameState getState()
        {
            return state;
        }
    }
    #endregion
}
