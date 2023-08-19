using EmbedIO.Routing;
using EmbedIO;
using EmbedIO.WebApi;

namespace Server
{
	public class TaskController : WebApiController
	{
		#region Константы

		/// <summary>
		/// Логгер.
		/// </summary>
		private static readonly NLog.Logger Logger = NLog.LogManager.GetCurrentClassLogger();

		#endregion

		[Route(HttpVerbs.Get, "/empty")]
		public void GetEmpty()
		{
			Logger.Info("Nothing happened.");
		}
	}
}
