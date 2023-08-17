using EmbedIO.Actions;
using EmbedIO;
using EmbedIO.WebApi;
using Swan.Logging;

namespace Server
{
	public class Program
	{
		#region Константы

		/// <summary>
		/// Порт сервера.
		/// </summary>
		private const int port = 5000;
		/// <summary>
		/// Адрес по которому будет доступен наш сервер.
		/// </summary>
		private readonly static Uri url = new Uri($"http://localhost:{port}/");

		#endregion

		#region Методы

		/// <summary>
		/// Создать Веб-сервер.
		/// </summary>
		/// <param name="url">Адрес сервера.</param>
		/// <returns>Веб-сервер.</returns>
		private static WebServer CreateWebServer(string url)
		{
			var server = new WebServer(o => o
							.WithUrlPrefix(url)
							.WithMode(HttpListenerMode.EmbedIO))
					.WithLocalSessionManager()
					.WithWebApi("/api", m => m
							.WithController<PeopleController>())
					.WithModule(new ActionModule("/", HttpVerbs.Any, ctx => ctx.SendDataAsync(new { Message = "Error" })));

			// Слушаем изменение состояния.
			server.StateChanged += (s, e) => $"WebServer New State - {e.NewState}".Info();

			return server;
		}

		#endregion

		static void Main(string[] args)
		{
			using (var server = CreateWebServer(url.AbsoluteUri))
			{
				server.RunAsync();
				// Подождите, пока будет нажата любая клавиша, прежде чем удалять наш веб-сервер.
				// В сервисе мы будем управлять жизненным циклом нашего веб-сервера, используя
				// что-то вроде BackgroundWorker или ManualResetEvent.
				Console.ReadKey(true);
			}
		}
	}
}