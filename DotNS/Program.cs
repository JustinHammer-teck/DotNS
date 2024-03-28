// See https://aka.ms/new-console-template for more information
using System.Net;
using System.Net.Sockets;
using System.Text;


const string ACK = "<|ACK|>";

var buffer = new byte[1_024]; // buffer can be define base on the need of the server and the intentional use case
var receiveData = 0;

/**/
/* var addressByte = new byte[4] { 10, 126, 138, 236 }; */
/**/
/* foreach (var item in addressByte) */
/* { */
/*     Console.WriteLine(item); */
/* } */
/**/
/* var ip = new IPAddress(addressByte.AsSpan()); */

var endpoint = new IPEndPoint(IPAddress.Any, 9500);

using var socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);

socket.SetSocketOption(SocketOptionLevel.IP, SocketOptionName.PacketInformation, true);

socket.Bind(endpoint);

var remoteEndPoint = new IPEndPoint(IPAddress.Any, 0);
var remote = (EndPoint)remoteEndPoint;

receiveData = socket.ReceiveFrom(buffer, ref remote);

Console.WriteLine($"ReceiveFrom {remote.ToString()}, with message: {Encoding.UTF8.GetString(buffer, 0, receiveData)}");

var greeting = "Welcome";

var responseData = Encoding.UTF8.GetBytes(greeting);

socket.SendTo(responseData, 0, responseData.Length, SocketFlags.None, remote);

try
{
    while (true)
    {
        buffer = new byte[1_024];
        var segmentReceive = socket.Receive(buffer);

        /*
         * this is to encode the bytes receive from Client to human-readable string
         * */
        var data = Encoding.UTF8.GetString(buffer, 0, segmentReceive);

        Console.WriteLine(data);

        break;
    }
}
catch (Exception)
{
    throw;
}


