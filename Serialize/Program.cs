using System;
using CommonLibrary;
using SerializeLibrary;

namespace Serialize
{
  class Program
  {
		#region Поля и свойства

    /// <summary>
    /// Обработка данных.
    /// </summary>
    private static DataProcessing dataProcessing = new DataProcessing();

    #endregion

    static void Main(string[] args)
    {
      var line = Console.ReadLine();

      switch (line)
      {
        case "Xml":
        {
          line = Console.ReadLine();
          var inputXmlSerialize = new XmlSerialize<Input>();
          var outputXmlSerialize = new XmlSerialize<Output>();
          var input = inputXmlSerialize.DeSerialize(line);
          var output = dataProcessing.Result(input);

          line = outputXmlSerialize.Serialize(output);
          Console.WriteLine(line);
        }
        break;
        case "Json":
        {
          line = Console.ReadLine();
          var inputJsonSerialize = new JsonSerialize<Input>();
          var outputJsonSerialize = new JsonSerialize<Output>();
          var input = inputJsonSerialize.DeSerialize(line);
          var output = dataProcessing.Result(input);

          line = outputJsonSerialize.Serialize(output);
          Console.WriteLine(line);
        }
        break;
        default:
          throw new Exception("What can I do?");
      }

    }
  }
}
