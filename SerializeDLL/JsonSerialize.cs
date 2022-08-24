using Newtonsoft.Json;

namespace SerializeLibrary
{
  /// <summary>
  /// Json сериализация.
  /// </summary>
	public class JsonSerialize<T>: ISerialize<T>
  {
    #region ISerialize

    public T DeSerialize(string str)
    {
      return JsonConvert.DeserializeObject<T>(str);
    }

    public string Serialize(T data)
    {
      return JsonConvert.SerializeObject(data);
    }

		#endregion
	}
}
