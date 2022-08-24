using System;
using System.IO;
using System.Net;
using System.Text;
using CommonLibrary;
using SerializeLibrary;

namespace Client
{
  class Client: IClient
  {
		#region Поля и свойства

    /// <summary>
    /// URL адрес.
    /// </summary>
		private string url;
    /// <summary>
    /// Порт.
    /// </summary>
    private string port;

		#endregion

		#region IClient

		public bool Ping()
    {
      using (var result = Request("Ping"))
			{
        return (result != null) && (result.StatusCode == HttpStatusCode.OK)
          ? true
          : false;
      }
    }

    public Input GetInputData()
    {
      using (var result = Request("GetInputData"))
			{
        var encode = Encoding.GetEncoding("utf-8");

        using (var stream = result.GetResponseStream())
				{
          using (var readStream = new StreamReader(stream, encode))
          {
            var jsonSerialize = new JsonSerialize<Input>();
            return jsonSerialize.DeSerialize(readStream.ReadToEnd());
          }
				}
			}
    }

    public bool WriteAnswer(Output output)
    {
      var jsonSerialize = new JsonSerialize<Output>();
      var body = jsonSerialize.Serialize(output);

      using (var result = Request("WriteAnswer", body))
			{
        return result != null
          ? true
          : false;
      }
    }

    #endregion

    #region Методы

    /// <summary>
    /// Запрос.
    /// </summary>
    /// <param name="typeRequest">Тип запроса.</param>
    /// <param name="body">Тело запроса.</param>
    /// <returns>Ответ от сервера.</returns>
    private HttpWebResponse Request(string typeRequest, string body = "")
    {
      // Создать объект запроса
      var httpWebRequest = (HttpWebRequest)WebRequest.Create(String.Format("{0}:{1}/{2}", url, port, typeRequest));
      httpWebRequest.Timeout = 150;
      httpWebRequest.ContentLength = Encoding.UTF8.GetByteCount(body);

      if (body == string.Empty) httpWebRequest.Method = "GET";
      else
      {
        httpWebRequest.Method = "POST";

        using (var receiveStream = httpWebRequest.GetRequestStream())
          receiveStream.Write(Encoding.UTF8.GetBytes(body), 0, Convert.ToInt32(httpWebRequest.ContentLength));
      }

      try
      {
        // Получить ответ с сервера
        using (var httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse())
          return httpWebResponse;
      }
      catch (Exception)
      {
        return null;
      }
    }

    #endregion

    #region Конструктор

    /// <summary>
    /// Конструктор.
    /// </summary>
    /// <param name="url">URL адрес.</param>
    /// <param name="port">Порт.</param>
    public Client(string url, string port)
    {
      this.url = url;
      this.port = port;
    }

    #endregion
  }
}
