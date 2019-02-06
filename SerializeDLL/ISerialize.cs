namespace SerializeDLL
{
    interface ISerialize
    {
        Input DeSerialize(string str);
        string Serialize(Output data);
    }
}
