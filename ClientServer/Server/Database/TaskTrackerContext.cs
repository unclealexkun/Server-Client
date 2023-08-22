using Microsoft.EntityFrameworkCore;
using SharedModel;
using Task = SharedModel.Task;

namespace Server.Database
{
	/// <summary>
	/// Контекст для работы базы данных с задачами.
	/// </summary>
	internal class TaskTrackerContext : DbContext
	{
		#region Поля и свойства

		/// <summary>
		/// Путь до базы данных.
		/// </summary>
		private string DbPath { get; }

		public DbSet<Task> Tasks { get; set; }
		public DbSet<People> Peoples { get; set; }

		#endregion

		#region Методы

		/// <summary>
		/// Настройка Entity Framework для создания файла базы данных Sqlite
		/// в специальной папке для любой платформы.
		/// </summary>
		/// <param name="options">Параметры настройки.</param>
		protected override void OnConfiguring(DbContextOptionsBuilder options)
			=> options.UseSqlite($"Data Source={DbPath}");

		#endregion

		#region Конструктор

		public TaskTrackerContext()
		{
			var folder = Environment.CurrentDirectory;
			var path = Path.Join(folder, "\\Database\\", "\\DB\\");

			if (!Directory.Exists(path))
				Directory.CreateDirectory(path);

			DbPath = Path.Join(path, "Database.db");
		}

		#endregion
	}
}
