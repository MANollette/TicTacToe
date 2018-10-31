using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TicTacToeLibrary;

namespace TicTacToeTests
{
    [TestClass]
    public class GameStateTests
    {
        [TestMethod]
        public void TestMethodXWins()
        {
            var board = Board.create();
            board.move(0, 1, PieceType.PIECEX);
            board.move(0, 2, PieceType.PIECEO);
            board.move(1, 1, PieceType.PIECEX);
            board.move(0, 0, PieceType.PIECEO);
            board.move(2, 1, PieceType.PIECEX);
            Assert.AreEqual(board.getState(), GameState.XVICTORY);
        }

        [TestMethod]
        public void TestMethodCannotPlaceOnOccupiedSquare()
        {
            var board = Board.create();
            board.move(1, 1, PieceType.PIECEX);
            board.move(1, 2, PieceType.PIECEO);
            Assert.IsFalse(board.move(1, 2, PieceType.PIECEX));
        }

        [TestMethod]
        public void TestMethodOWins()
        {
            var board = Board.create();
            board.move(1, 0, PieceType.PIECEX);   //X O
            board.move(0, 0, PieceType.PIECEO);   //XO
            board.move(0, 1, PieceType.PIECEX);   //OX
            board.move(2, 2, PieceType.PIECEO);
            board.move(0, 2, PieceType.PIECEX);
            board.move(1, 1, PieceType.PIECEO);
            Assert.AreEqual(GameState.OVICTORY, board.getState());
        }

        [TestMethod]
        public void TestMethodDraw()
        {
            var board = Board.create();
            board.move(0, 0, PieceType.PIECEX);       //OXX
            board.move(1, 0, PieceType.PIECEO);       //XOO
            board.move(0, 1, PieceType.PIECEX);       //XOX
            board.move(1, 1, PieceType.PIECEO);
            board.move(2, 0, PieceType.PIECEX);
            board.move(0, 2, PieceType.PIECEO);
            board.move(2, 2, PieceType.PIECEX);
            board.move(2, 1, PieceType.PIECEO);
            board.move(1, 2, PieceType.PIECEX);
            Assert.AreEqual(GameState.DRAW, board.getState());
        }
    }
}
