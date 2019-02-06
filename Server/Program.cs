using System;

namespace Server
{
    class Program
    {
        static void Main(string[] args)
        {
            string port = Console.ReadLine();
            Server server = new Server("http://127.0.0.1",port);

            while (!server.Looper()) { }
        }
    }
}
