using System;
using CommonLibrary;
using SerializeLibrary;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            string port = Console.ReadLine();

            Client client = new Client("http://127.0.0.1", port);

            while (!client.Ping()) { }

            var input = new Input();
            var data = new DataProcessing();

            while ((input = client.GetInputData()) == null) { }
            var output = data.Result(input);

            while (!client.WriteAnswer(output)) { }
        }
    }
}
