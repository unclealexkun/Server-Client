using EmbedIO;
using EmbedIO.Routing;
using EmbedIO.WebApi;

namespace Server
{
	public class PeopleController : WebApiController
	{
		[Route(HttpVerbs.Get, "/empty")]
		public void GetEmpty()
		{ }
	}
}
