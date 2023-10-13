using EmbedIO.Routing;
using EmbedIO;
using EmbedIO.WebApi;
using SharedModel;
using System.Data;

namespace Server
{
	public class CalculatorController : WebApiController
	{
		#region Константы

		/// <summary>
		/// Логгер.
		/// </summary>
		private static readonly NLog.Logger Logger = NLog.LogManager.GetCurrentClassLogger();

		#endregion

		[Route(HttpVerbs.Get, "/pi")]
		public double GetPi()
		{
			Logger.Info("Get number PI.");

			return Math.PI;
		}

		[Route(HttpVerbs.Get, "/e")]
		public double GetE()
		{
			Logger.Info("Get number E.");

			return Math.E;
		}

		[Route(HttpVerbs.Post, "/add")]
		public double Add([JsonData] Operated operated)
		{
			Logger.Info("Add value.");
			
			return operated.ValueA + operated.ValueB;
		}

		[Route(HttpVerbs.Post, "/sub")]
		public double Sub([JsonData] Operated operated)
		{
			Logger.Info("Subtract value.");

			return operated.ValueA - operated.ValueB;
		}

		[Route(HttpVerbs.Post, "/mul")]
		public double Mul([JsonData] Operated operated)
		{
			Logger.Info("Multiply value.");

			return operated.ValueA * operated.ValueB;
		}

		[Route(HttpVerbs.Post, "/div")]
		public double Div([JsonData] Operated operated)
		{
			Logger.Info("Division value.");

			if (operated.ValueB == 0)
				throw new DivideByZeroException("Not do this!");

			return operated.ValueA / operated.ValueB;
		}
	}
}
