using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using TicTacToeAPI;

namespace TicTacToeClient
{
    class TTTClient
    {
        //Initialize StreamReader for use in main
        static StreamReader reader;

        static void Main(string[] args)
        {
            //Initialize API, append data from listen
            Api api = Api.create();
            api.OnMessageHandler += listen;

            //Repeatedly loop through move entries until broken externally
            while (true)
            {
                var move = Console.ReadLine();
                //Code for making a move
            }
        }

        //Method to reiterate input
        static void listen(String msg)
        {
            System.Console.WriteLine("heard: " + msg);
        }
    }
}
