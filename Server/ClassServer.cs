using System.IO;
using System.Net;
using System.Text;
using SerializeDLL;

namespace Server
{
    class Server
    {
        private HttpListener listener;
        private HttpListenerContext _context;
        private HttpListenerRequest _request;
        private HttpListenerResponse _response;
        private string _data;
        public Server(string url, string port)
        {
            var prefix = string.Format("{0}:{1}/", url, port);

            listener = new HttpListener();
            listener.Prefixes.Add(prefix);
            listener.Start();
        }

        public bool Looper()
        {
            bool flagStop = false;

            //Ожидание входящего запроса
            _context = listener.GetContext();
            //Объект запроса
            _request = _context.Request;

            string method = _request.RawUrl;
            //Создаем ответ
            string requestBody = "";

            switch (method)
            {
                case "/Ping":
                {
                    Ping();
                    OutResponse();
                }
                    break;
                case "/Stop":
                {
                    OutResponse();
                    flagStop = Stop();
                }
                    break;
                case "/PostInputData":
                {
                    PostInputData(ref requestBody);
                    _data = requestBody;
                    OutResponse();
                }
                    break;
                case "/GetAnswer":
                {
                    OutResponse(GetAnswer(_data));
                }
                    break;
            }

            return flagStop;
        }

        private void OutResponse(string body = "")
        {
            //Объект ответа
            _response = _context.Response;

            _response.ContentEncoding = Encoding.UTF8;
            _response.ContentLength64 = Encoding.UTF8.GetByteCount(body);

            //Возвращаем ответ
            using (Stream stream = _response.OutputStream)
            {
                stream.Write(Encoding.UTF8.GetBytes(body), 0, System.Convert.ToInt32(_response.ContentLength64));
            }
        }

        private void Ping()
        {
            //Оказывается не нужно =(Q_Q)=
            //_response.StatusCode = (int)HttpStatusCode.OK;
        }

        private void PostInputData(ref string requestBody)
        {
            Stream inputStream = _request.InputStream;
            Encoding encoding = _request.ContentEncoding;

            using (StreamReader reader = new StreamReader(inputStream, encoding))
            {
                requestBody = reader.ReadToEnd();
            }          
        }

        private string GetAnswer(string str)
        {
            Input input;
            Output output;
            Data data = new Data();
            JsonSerialize js = new JsonSerialize();

            input = js.DeSerialize(str);
            output = data.Result(input);
            return js.Serialize(output);
        }

        private bool Stop()
        {
            listener.Stop();
            listener.Close();
            return true;
        }
    }
}
