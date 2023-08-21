using EmbedIO.Routing;
using EmbedIO;
using EmbedIO.WebApi;
using Server.Database;
using Task = SharedModel.Task;

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

		[Route(HttpVerbs.Get, "/taskbyid/{id}")]
		public Task? GetTaskById(int id)
		{
			Logger.Info($"Get task by {id}.");
			using (var db = new TaskTrackerContext())
			{
				return db.Tasks.FirstOrDefault(t => t.TaskId == id);
			}
		}

		[Route(HttpVerbs.Get, "/alltask")]
		public List<Task> GetAllTask()
		{
			Logger.Info("Get all tasks.");
			using (var db = new TaskTrackerContext())
			{
				return db.Tasks.ToList();
			}
		}

		[Route(HttpVerbs.Post, "/addtask")]
		public Task? SaveTask([JsonData] Task task)
		{
			Logger.Info("Save task.");
			using (var db = new TaskTrackerContext())
			{
				var result = db.Add(task);
				db.SaveChanges();
				return result?.Entity;
			}
		}

		[Route(HttpVerbs.Put, "/updatetask")]
		public Task? UpdateTask([JsonData] Task task)
		{
			Logger.Info("Update task.");
			using (var db = new TaskTrackerContext())
			{
				var result = db.Tasks.FirstOrDefault(t => t.TaskId == task.TaskId);
				if (result == null)
				{
					Logger.Info("Task not found.");
					return null;
				}

				result.Title = task.Title;
				result.Description = task.Description;
				result.Deadline = task.Deadline;

				result.PeopleId = task.PeopleId;
				result.People = task.People;

				db.SaveChanges();
				return result;
			}
		}

		[Route(HttpVerbs.Post, "/deletetaskbyid/{id}")]
		public bool DeleteTask(int id)
		{
			Logger.Info("Update task.");
			using (var db = new TaskTrackerContext())
			{
				var result = db.Tasks.FirstOrDefault(t => t.TaskId == id);
				if (result == null)
				{
					Logger.Info("Task not found.");
					return false;
				}

				db.Remove(result);
				db.SaveChanges();
				return true;
			}
		}
	}
}
