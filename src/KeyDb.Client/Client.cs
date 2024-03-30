using KeyDb.Client.Interfaces;

namespace KeyDb.Client
{
    public sealed class Client
    {
        private readonly ITCPClient _tcpClient;

        public Client(ITCPClient tcpClient)
        {
            _tcpClient = tcpClient;
        }
    }
}

