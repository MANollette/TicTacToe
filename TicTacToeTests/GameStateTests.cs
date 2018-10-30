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
            board.move(0, 0, PieceType.PIECEX);
            board.move(0, 1, PieceType.PIECEO);
            board.move(1, 1, PieceType.PIECEX);
            board.move(0, 2, PieceType.PIECEO);
            board.move(2, 2, PieceType.PIECEX);
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
    }
}
