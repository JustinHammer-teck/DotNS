namespace DotNS
{
    public static class Helper {

        public static void TryParseIpAddress(string ipAddress, out ReadOnlySpan<byte> ip, out int port)
        {
            if (string.IsNullOrWhiteSpace(ipAddress)) {
                throw new ArgumentNullException($"{nameof(ipAddress)} cannot be null or empty");
            }

            ip = new Span<byte>();
            port = 0;

            var ipSpan = ipAddress.AsSpan();
            var colonIndex = ipSpan.LastIndexOf(':');
            
            Console.WriteLine(ipAddress[..colonIndex]);
            Console.WriteLine(ipAddress[(colonIndex + 1)..]);
        }
    }
}
