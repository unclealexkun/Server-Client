using System.Net.Http.Headers;

namespace Client
{
	/// <summary>
	/// Клиент для API.
	/// </summary>
	public class ApiClient<T>
	{
		#region Константы

		/// <summary>
		/// Адрес сервера.
		/// </summary>
		private static readonly string Url = "http://localhost:5000/";

		#endregion

		#region Поля и свойства

		/// <summary>
		/// HTTP клиент.
		/// </summary>
		private HttpClient client = new HttpClient();

		#endregion

		#region Методы

		/// <summary>
		/// Создать объект.
		/// </summary>
		/// <param name="input">Входной параметр.</param>
		/// <returns>Объект.</returns>
		public async Task<T?> CreateAsync(T input)
		{
			T? result = default;
			var response = await this.client.PostAsJsonAsync($"api/{typeof(T).Name.ToLower()}/add{input?.GetType().Name.ToLower()}", input);
			if (response.IsSuccessStatusCode)
			{
				result = await response.Content.ReadAsAsync<T?>();
			}
			return result;
		}

		/// <summary>
		/// Получить объект.
		/// </summary>
		/// <param name="id">Идентификатор объекта.</param>
		/// <returns>Объект.</returns>
		public async Task<T?> GetAsync(string id)
		{
			T? result = default;
			var response = await this.client.GetAsync($"api/{typeof(T).Name.ToLower()}/{typeof(T).Name.ToLower()}byid/{id}");
			if (response.IsSuccessStatusCode)
			{
				result = await response.Content.ReadAsAsync<T?>();
			}
			return result;
		}

		/// <summary>
		/// Обновить объект.
		/// </summary>
		/// <param name="input">Объект с новыми данными.</param>
		/// <returns>Обновленный объект.</returns>
		public async Task<T?> UpdateAsync(T? input)
		{
			var response = await client.PutAsJsonAsync($"api/{typeof(T).Name.ToLower()}/update{input?.GetType().Name.ToLower()}", input);
			response.EnsureSuccessStatusCode();
			input = await response.Content.ReadAsAsync<T?>();
			return input;
		}

		/// <summary>
		/// Удалить объакт.
		/// </summary>
		/// <param name="id">Идентификатор объекта.</param>
		/// <returns>Результат удаления.</returns>
		public async Task<bool> DeleteAsync(string id)
		{
			var response = await client.DeleteAsync($"api/{typeof(T).Name.ToLower()}/delete{typeof(T).Name}byid/{id}");
			return await response.Content.ReadAsAsync<bool>();
		}

		#endregion

		#region Конструктор

		public ApiClient()
		{
			this.client.Timeout = new TimeSpan(hours: 0, minutes: 1, seconds: 0);
			this.client.BaseAddress = new Uri(Url);
			this.client.DefaultRequestHeaders.Accept.Clear();
			this.client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
		}

		#endregion
	}
}
