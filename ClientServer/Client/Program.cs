using SharedModel;
using Task = SharedModel.Task;

namespace Client
{
	public class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Start!");

			var people = new People()
			{
				PeopleId = 1,
				FirstName = "Bob",
				LastName = "Martin",
				JobTitle = "software engineer"
			};

			var task = new Task()
			{
				TaskId = 1,
				Title = "SpaceTourer",
				Description = "Like a monkey before launching into space",
				Deadline = DateTime.Now,
				People = people,
				PeopleId = 1
			};

			try
			{
				var apiTask = new ApiClient<Task>();
				var apiPeople = new ApiClient<People>();

				Console.WriteLine("Create task...");
				Console.WriteLine(apiTask.CreateAsync(task).GetAwaiter().GetResult());

				Console.WriteLine("Get people...");
				var result = apiPeople.GetAsync("1").GetAwaiter().GetResult();
				Console.WriteLine($"{result?.FirstName} {result?.LastName}");
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
			}
		}
	}
}