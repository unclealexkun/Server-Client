using EmbedIO;
using EmbedIO.Routing;
using EmbedIO.WebApi;
using Server.Database;
using SharedModel;

namespace Server
{
	public class PeopleController : WebApiController
	{
		#region Константы

		/// <summary>
		/// Логгер.
		/// </summary>
		private static readonly NLog.Logger Logger = NLog.LogManager.GetCurrentClassLogger();

		#endregion

		[Route(HttpVerbs.Get, "/peoplebyid")]
		public People? GetPeopleById(int id)
		{
			Logger.Info($"Get people by {id}.");
			using (var db = new TaskTrackerContext())
			{
				return db.Peoples.FirstOrDefault(p => p.PeopleId == id);
			}
		}

		[Route(HttpVerbs.Get, "/allpeople")]
		public List<People> GetAllPeople()
		{
			Logger.Info("Get all peoples.");
			using (var db = new TaskTrackerContext())
			{
				return db.Peoples.ToList();
			}
		}

		[Route(HttpVerbs.Post, "/addpeople")]
		public People? SavePeople(People people)
		{
			Logger.Info("Save people.");
			using (var db = new TaskTrackerContext())
			{
				var result = db.Peoples.Add(people);
				db.SaveChanges();
				return result?.Entity;
			}
		}

		[Route(HttpVerbs.Post, "/updatepeople")]
		public People? UpdatePeople(People people)
		{
			Logger.Info("Update people.");
			using (var db = new TaskTrackerContext())
			{
				var result = db.Peoples.FirstOrDefault(p => p.PeopleId == people.PeopleId);
				if (result == null)
				{
					Logger.Info("People not found.");
					return null;
				}

				result.FirstName = people.FirstName;
				result.LastName = people.LastName;
				result.JobTitle = people.JobTitle;

				db.SaveChanges();
				return result;
			}
		}

		[Route(HttpVerbs.Post, "/deletetaskbyid")]
		public bool DeleteTask(int id)
		{
			Logger.Info("Update people.");
			using (var db = new TaskTrackerContext())
			{
				var result = db.Peoples.FirstOrDefault(p => p.PeopleId == id);
				if (result == null)
				{
					Logger.Info("People not found.");
					return false;
				}

				db.Remove(result);
				db.SaveChanges();
				return true;
			}
		}
	}
}
