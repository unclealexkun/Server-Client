namespace SharedModel
{
	/// <summary>
	/// Люди.
	/// </summary>
	public class People
	{
		/// <summary>
		/// Идентификатор.
		/// </summary>
		public int PeopleId { get; set; }

		/// <summary>
		/// Имя.
		/// </summary>
		public string FirstName { get; set; }

		/// <summary>
		/// Фамилия.
		/// </summary>
		public string LastName { get; set; }

		/// <summary>
		/// Должность.
		/// </summary>
		public string JobTitle { get; set; }

		public List<Task> Tasks { get; } = new();
	}
}
