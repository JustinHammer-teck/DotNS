// See https://aka.ms/new-console-template for more information
using System.Net;
using System.Net.Sockets;


ReadOnlySpan<byte> addressByte = new byte[]{ 0x7F , 0x00, 0x00, 0x00 }.AsSpan();

var ip = new IPAddress(addressByte);

var endpoint = new EndPoint();

var socket = new Socket();

