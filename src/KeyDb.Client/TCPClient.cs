using System.Net.Sockets;
using KeyDb.Client.Interfaces;

namespace KeyDb.Client
{
    public sealed class TCPClient : TcpClient, ITCPClient
    {
        public TCPClient() : base()
        {
            
        }
    }
}
