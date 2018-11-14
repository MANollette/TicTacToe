using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using TicTacToeAPI;
using TicTacToeLibrary;
using System.Net.Sockets;
using System.Threading;

namespace TicTacToeServer
{
    class ConnectionHandler
    {
        private StreamReader playerReader;
        private StreamWriter playerWriter;
        private StreamWriter oponentWriter;
        private Board board;
        private PieceType piece;

        public ConnectionHandler(
            Board board,
            PieceType piece,
            StreamReader reader,
            StreamWriter playerWriter,
            StreamWriter oponentWriter)
        {
            playerWriter.WriteLine("Game started: you are "
                + piece.ToString());
            this.board = board;
            this.piece = piece;
            this.playerReader = reader;
            this.playerWriter = playerWriter;
            this.oponentWriter = oponentWriter;
        }

        public void listen()
        {
            while (true)
            {
                String msg = playerReader.ReadLine();

                string[] split = msg.Split(',');
                int xTo = int.Parse(split[0]);
                int yTo = int.Parse(split[1]);
                if (board.move(xTo, yTo, piece))
                {
                    oponentWriter.WriteLine(msg);
                    oponentWriter.Flush();
                    playerWriter.WriteLine("Your move succeeded.");
                    playerWriter.Flush();
                }
                else
                {
                    playerWriter.WriteLine("Your move was invalid.");
                    playerWriter.Flush();
                }
            }
        }
    }

    class Session
    {
        ConnectionHandler xPlayer;
        ConnectionHandler oPlayer;
        public Session(TcpClient x, TcpClient o)
        {
            var board = Board.create();
            xPlayer = new ConnectionHandler(
                board,
                PieceType.PIECEX,
                new StreamReader(x.GetStream()),
                new StreamWriter(x.GetStream()),
            new StreamWriter(o.GetStream()));
            oPlayer = new ConnectionHandler(
                board,
                PieceType.PIECEO,
                new StreamReader(o.GetStream()),
                new StreamWriter(o.GetStream()),
                new StreamWriter(x.GetStream()));

            new Thread(xPlayer.listen).Start();
            new Thread(oPlayer.listen).Start();
        }
    }
}
