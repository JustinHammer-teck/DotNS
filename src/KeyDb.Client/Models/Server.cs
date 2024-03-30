using System.Net;

namespace KeyDb.Client.Models
{
    public sealed class Server
    {
        public byte[] AddressByte { get; set; }
        public IPAddress IPAddress { get; set; }
        public int Port { get; set; }
        public IPEndPoint EndPoint { get; set; }
    }
}
