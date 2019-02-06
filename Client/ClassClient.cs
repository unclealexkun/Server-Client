using System;
using System.IO;
using System.Net;
using System.Text;
using SerializeDLL;

namespace Client
{
    class Client: IClient
    {
        private string _url;
        private string _port;

        public Client(string url, string port)
        {
            _url = url;
            _port = port;
        }

        public bool Ping()
        {
            HttpWebResponse result = Request("Ping");

            if ((result != null)&&(result.StatusCode == HttpStatusCode.OK)) return true;
            else return false;
        }

        public Input GetInputData()
        {
            HttpWebResponse result = Request("GetInputData");
            Encoding encode = Encoding.GetEncoding("utf-8");
            Stream stream = result.GetResponseStream();

            StreamReader readStream = new StreamReader(stream, encode);
            JsonSerialize js = new JsonSerialize();

            return js.DeSerialize(readStream.ReadToEnd());
        }

        public bool WriteAnswer(Output output)
        {
            JsonSerialize js = new JsonSerialize();
            string body = js.Serialize(output);

            HttpWebResponse result = Request("WriteAnswer", body);

            if (result != null) return true;
            else return false;
        }

        private HttpWebResponse Request(string typeRequest, string body = "")
        {
            // Создать объект запроса
            HttpWebRequest httpWReq = (HttpWebRequest)WebRequest.Create(String.Format("{0}:{1}/{2}",_url,_port,typeRequest));
            //HttpWebRequest HttpWReq = (HttpWebRequest)WebRequest.Create(String.Format("{0}/{1}", _url,typeRequest));

            httpWReq.Timeout = 150;
            //HttpWReq.UserAgent = "Amigo Web-browser";
            httpWReq.ContentLength = Encoding.UTF8.GetByteCount(body);

            if (body == string.Empty) httpWReq.Method = "GET";
            else
            {
                httpWReq.Method = "POST";

                Stream receiveStream = httpWReq.GetRequestStream();
                receiveStream.Write(Encoding.UTF8.GetBytes(body),0,Convert.ToInt32(httpWReq.ContentLength));
            }

            try
            {
                // Получить ответ с сервера
                HttpWebResponse httpWResp = (HttpWebResponse)httpWReq.GetResponse();

                return httpWResp;
            }
            catch (Exception)
            {
                return null;
            }          
        }

    }
}
