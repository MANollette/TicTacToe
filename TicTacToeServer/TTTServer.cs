using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using TicTacToeAPI;

namespace TicTacToeServer
{
    class TTTServer
    {
        //Initializes the stream reader, instantiates the API and creates a constant loop for entering moves. 
        static StreamReader reader;
        static void Main(string[] args)
        {
            Api api = Api.create();
            api.OnMessageHandler += listen;
            while (true)
            {
                var move = Console.ReadLine();
                // Code for making a move
            }
        }

        static void listen(String msg)
        {
            System.Console.WriteLine("heard: " + msg);
        }
    }
}
