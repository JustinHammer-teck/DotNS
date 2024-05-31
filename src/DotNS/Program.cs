// See https://aka.ms/new-console-template for more information
using System.Net;
using System.Net.Sockets;
using System.Text;

internal class Program
{
    private static void Main(string[] args)
    {
        var buffer = new byte[1_232]; // buffer can be define base on the need of the server and the intentional use case

        var endpoint = new IPEndPoint(IPAddress.Parse("10.126.138.17"), 9500);

        using var socket = new Socket(
            AddressFamily.InterNetwork,
            SocketType.Dgram,
            ProtocolType.Udp
        );
        socket.SetSocketOption(SocketOptionLevel.IP, SocketOptionName.PacketInformation, true);
        socket.Bind(endpoint);

        var remoteEndPoint = new IPEndPoint(IPAddress.Any, 0);
        var remote = (EndPoint)remoteEndPoint;
        var receiveData = socket.ReceiveFrom(buffer, ref remote);

        Console.WriteLine(
            $"ReceiveFrom {remote.ToString()}, with message: {Encoding.ASCII.GetString(buffer, 0, receiveData)}"
        );

        var responseMsg = Encoding.ASCII.GetBytes("10.10.10.126");

        Console.WriteLine(responseMsg.Length);

        var responseData = buffer[..13].Concat(responseMsg).ToArray();

        socket.SendTo(responseData, 0, responseData.Length, SocketFlags.None, remote);

        try
        {
            while (true)
            {
                buffer = new byte[1_232];
                receiveData = socket.Receive(buffer);

                var data = Encoding.ASCII.GetString(buffer, 0, receiveData);

                Console.WriteLine(data);
            }
        }
        catch (Exception)
        {
            throw;
        }
    }
}
