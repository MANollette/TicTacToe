using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using TicTacToeLibrary;

namespace TicTacToeTests
{
    [TestClass]
    public class MovementControlTests
    {
        [TestMethod]
        public void TestXMovesFirst()
        {
            Board board = Board.create();
            Assert.IsTrue(board.move(2, 2, PieceType.PIECEX));
        }

        [TestMethod]
        public void TestOCannotMoveFirst()
        {
            Board board = Board.create();
            Assert.IsFalse(board.move(2, 2, PieceType.PIECEO));
        }

        [TestMethod]
        public void TestOMoveSecond()
        {
            Board board = Board.create();
            board.move(2, 2, PieceType.PIECEX);
            Assert.IsTrue(board.move(1, 2,PieceType.PIECEO));
        }

        [TestMethod]
        public void TestThirdMoveX()
        {
            Board board = Board.create();
            board.move(1,1,PieceType.PIECEX);
            board.move(2, 2, PieceType.PIECEO);
            Assert.IsTrue(board.move(1,2,PieceType.PIECEX));
        }

        [TestMethod]
        public void TestXCannotMoveTwice()
        {
            Board board = Board.create();
            board.move(2, 2, PieceType.PIECEX);
            Assert.IsFalse(board.move(1,1, PieceType.PIECEX));
        }

        [TestMethod]
        public void TestOCannotMoveTwice()
        {
            Board board = Board.create();
            var moves = new List<int[]>();
            moves.Add(new int[] { 1, 2 });
            moves.Add(new int[] { 2, 1 });
            TicTacToeTestDuration.excuteMoves(
                moves,
                board);
            Assert.IsFalse(board.move(2, 2,
                PieceType.PIECEO));
        }


        [TestMethod]
        public void TestCanRetryMoveAfterBadAttempt()
        {
            Board board = Board.create();
            board.move(2, 5, PieceType.PIECEX);
            Assert.IsTrue(board.move(2, 2, 
                PieceType.PIECEX));
        }
    }
}
