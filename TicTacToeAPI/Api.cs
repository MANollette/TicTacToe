using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Threading;
using System.IO;

namespace TicTacToeAPI
{
    public class Api
    {
        //Set up delegate to handle message receipt. 
        public delegate void
            MessageHandler(string msg);
        public MessageHandler OnMessageHandler;

        //Initialize client and stream data handlers
        private TcpClient client;
        private StreamReader reader;
        private StreamWriter writer;

        //Method for instantiating a new instance of the API class
        public static Api create()
        {
            var api = new Api();
            new Thread(api.listen).Start();
            return api;
        }

        //Constructor initializing API with new client
        private Api()
        {
            client =
                new TcpClient("localhost", 9999);
            reader = new StreamReader(client.GetStream());
            writer = new StreamWriter(client.GetStream());
        }

        //Method for storing move data for input
        public void move(int xTo, int yTo)
        {
            writer.WriteLine(String.Join(",", new int[]
            {
                xTo, yTo
            }));
            writer.Flush();
        }

        //Method for awaiting user input for next move
        private void listen()
        {
            while (true)
            {
                String msg = reader.ReadLine();
                OnMessageHandler(msg);
            }
        }
    }
}
