using Newtonsoft.Json;

namespace SerializeDLL
{
    public class JsonSerialize:ISerialize
    {
        public Input DeSerialize(string str)
        {
            return JsonConvert.DeserializeObject<Input>(str);
        }

        public string Serialize(Output data)
        {
            return JsonConvert.SerializeObject(data);
        }
    }
}
