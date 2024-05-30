namespace DotNS
{
    public static class Helper
    {
        public static void TryParseIpAddress(string ipAddress, out ReadOnlySpan<byte> ip, out int port)
        {
            if (string.IsNullOrWhiteSpace(ipAddress))
            {
                throw new ArgumentNullException($"{nameof(ipAddress)} cannot be null or empty");
            }

            ip = new Span<byte>();
            port = 0;

            var ipaSpan = ipAddress.AsSpan();
            var colonIndex = ipaSpan.LastIndexOf(':');
            var ipSpan = ipaSpan.Slice(0, colonIndex);
        }
    }
}
