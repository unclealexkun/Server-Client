using SerializeDLL;

namespace Client
{
    interface IClient
    {
        bool Ping();
        Input GetInputData();
        bool WriteAnswer(Output output);
    }
}
