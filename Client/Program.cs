using System;
using SerializeDLL;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            string port = Console.ReadLine();

            Client client = new Client("http://127.0.0.1", port);
            //Client client = new Client("http://menote.ru/study/", port);

            while (!client.Ping()) { }

            Input input = new Input();
            Data data = new Data();
            Output output = new Output();

            while ((input = client.GetInputData()) == null) { }
            output = data.Result(input);

            while (!client.WriteAnswer(output)) { }
        }
    }
}
