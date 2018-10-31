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
        Square[,] squares = new Square[SIZE, SIZE];
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
            if (!BoardUtils.turnControl(xTurn, PieceType.PIECEX)) piece = new Piece(PieceType.PIECEO);
            squares[x, y].placePiece(piece);


            
            checkAllRows();
            checkAllColumns();
            checkAllDiagonals();
            checkForDraw();
        }

        #region victoryChecks
        private void checkAllRows()
        {
            int xCount = 0;
            int oCount = 0;

            
            for (int i = 0; i < 3; i++)
            {
                xCount = 0;
                oCount = 0;
            

                for (int j = 0; j < 3; j++)
                {
                    if (squares[i, j].getPiece() != null)
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
        }

        private void checkAllColumns()
        {
            int xCount = 0;
            int oCount = 0;


            for (int i = 0; i < 3; i++)
            {
                xCount = 0;
                oCount = 0;


                for (int j = 0; j < 3; j++)
                {
                    if (squares[j, i].getPiece() != null)
                    {
                        if (squares[j, i].getPiece().getPieceType() == PieceType.PIECEX)
                        {
                            xCount++;
                        }
                        if (squares[j, i].getPiece().getPieceType() == PieceType.PIECEO)
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
        }

        private void checkAllDiagonals()
        {
            if (squares[0, 0].getPiece() != null && squares[1, 1].getPiece() != null && squares[2, 2].getPiece() != null)
            {
                if (squares[0, 0].getPiece().getPieceType() == PieceType.PIECEX)
                {
                    if (squares[1, 1].getPiece().getPieceType() == PieceType.PIECEX)
                    {
                        if (squares[2, 2].getPiece().getPieceType() == PieceType.PIECEX)
                        {
                            state = GameState.XVICTORY;
                        }
                    }
                }
                if (squares[0, 0].getPiece().getPieceType() == PieceType.PIECEO)
                {
                    if (squares[1, 1].getPiece().getPieceType() == PieceType.PIECEO)
                    {
                        if (squares[2, 2].getPiece().getPieceType() == PieceType.PIECEO)
                        {
                            state = GameState.OVICTORY;
                        }
                    }
                }
            }
            if (squares[2, 0].getPiece() != null && squares[1, 1].getPiece() != null && squares[0, 2].getPiece() != null)
            {
                if (squares[2, 0].getPiece().getPieceType() == PieceType.PIECEO)
                {
                    if (squares[1, 1].getPiece().getPieceType() == PieceType.PIECEO)
                    {
                        if (squares[0, 2].getPiece().getPieceType() == PieceType.PIECEO)
                        {
                            state = GameState.OVICTORY;
                        }
                    }
                }
                if (squares[2, 0].getPiece().getPieceType() == PieceType.PIECEX)
                {
                    if (squares[1, 1].getPiece().getPieceType() == PieceType.PIECEX)
                    {
                        if (squares[0, 2].getPiece().getPieceType() == PieceType.PIECEX)
                        {
                            state = GameState.XVICTORY;
                        }
                    }
                }
            }
        }

        private void checkForDraw()
        {
            int count = 0;
            foreach(Square s in squares)
            {
                if (s.getPiece() != null)
                {
                    count++;
                }
            }
            if (count == 9)
                state = GameState.DRAW;
        }

        public GameState getState()
        {
            return state;
        }
    }
    #endregion
}
