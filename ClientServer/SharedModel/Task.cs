namespace SharedModel
{
	/// <summary>
	/// Задачи.
	/// </summary>
	public class Task
	{
		/// <summary>
		/// Идентификатор.
		/// </summary>
		public int TaskId { get; set; }

		/// <summary>
		/// Заголовок.
		/// </summary>
		public string Title { get; set; }

		/// <summary>
		/// Описание.
		/// </summary>
		public string Description { get; set; }

		/// <summary>
		/// Срок исполнения.
		/// </summary>
		public DateTime Deadline { get; set; }

		public int PeopleId { get; set; }
		public People People { get; set; }
	}
}