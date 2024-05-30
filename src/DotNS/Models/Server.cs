using System.Net;

namespace KeyDb.Client.Models
{
    public sealed class DNSServer
    {
        public byte[] AddressByte { get; set; }
        public IPAddress IPAddress { get; set; }
        public int Port { get; set; }
        public IPEndPoint EndPoint { get; set; }
    }

    public class UDPServer {

        public byte[] AddressByte { get; set; }
        public IPAddress IPAddress { get; set; }
        public int Port { get; set; }
        public IPEndPoint EndPoint { get; set; }

        public UDPServer WithIPAddress(IPAddress ipAddress){

            IPAddress = ipAddress;

            return this;
        }

        public static DNSServer Create() => new DNSServer();
    }
}
