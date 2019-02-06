using System;
using SerializeDLL;

namespace Serialize
{
    class Program
    {       
        static void Main(string[] args)
        {
            string str = Console.ReadLine();

            switch (str)
            {
                case "Xml":
                {
                    str = Console.ReadLine();
                    XmlSerialize XS = new XmlSerialize();

                    Input input = new Input();
                    Output output = new Output();
                    input = XS.DeSerialize(str);

                    Data data = new Data();
                    output = data.Result(input);

                    str = XS.Serialize(output);

                    Console.WriteLine(str);
                }
                break;
                case "Json":
                {
                    str = Console.ReadLine();
                    JsonSerialize JS = new JsonSerialize();

                    Input input = new Input();
                    Output output = new Output();
                    input = JS.DeSerialize(str);

                    Data data = new Data();
                    output = data.Result(input);

                    str = JS.Serialize(output);

                    Console.WriteLine(str);
                }
                break;
                default:
                    new Exception("What can I do?");
                    break;
            }

        }
    }
}
