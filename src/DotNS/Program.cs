﻿// See https://aka.ms/new-console-template for more information
using System.Net;
using System.Net.Sockets;
using System.Text;
using DotNS;

var buffer = new byte[1_024]; // buffer can be define base on the need of the server and the intentional use case

Helper.TryParseIpAddress("192.168.0.176:9500", out var sumip, out var port);

var ip = new IPAddress(sumip);
var endpoint = new IPEndPoint(ip, 9500);

using var socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
socket.SetSocketOption(SocketOptionLevel.IP, SocketOptionName.PacketInformation, true);
socket.Bind(endpoint);

var remoteEndPoint = new IPEndPoint(IPAddress.Any, 0);
var remote = (EndPoint)remoteEndPoint;
var receiveData = socket.ReceiveFrom(buffer, ref remote);

socket.Connect(remote);

Console.WriteLine($"ReceiveFrom {remote.ToString()}, with message: {Encoding.UTF8.GetString(buffer, 0, receiveData)}");

var responseData = Encoding.UTF8.GetBytes("Welcome to DotNS");
socket.SendTo(responseData, 0, responseData.Length, SocketFlags.None, remote);


try
{
    while (true)
    {
        buffer = new byte[1_024];
        receiveData = socket.Receive(buffer);

        /*
         * this is to encode the bytes receive from Client to human-readable string
         * */
        var data = Encoding.UTF8.GetString(buffer, 0, receiveData);

        Console.WriteLine(data);
    }
}
catch (Exception)
{
    throw;
}

