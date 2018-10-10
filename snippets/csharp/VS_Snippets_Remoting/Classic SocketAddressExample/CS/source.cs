using System;
using System.Text;
using System.Net; 
using System.Net.Sockets;

public class MySerializeExample
{
    public static void Main()
    {
//<Snippet1>
        // Creates an IpEndPoint.
        IPAddress ipAddress = Dns.Resolve("www.contoso.com").AddressList[0];
        IPEndPoint ipLocalEndPoint = new IPEndPoint(ipAddress, 11000);

        // Serializes the IPEndPoint. 
        SocketAddress socketAddress = ipLocalEndPoint.Serialize();

        // Verifies that ipLocalEndPoint is now serialized by printing its contents.
        Console.WriteLine($"Contents of the socketAddress are: {socketAddress}");
        // Checks the Family property.
        Console.WriteLine($"The address family of the socketAddress is: {socketAddress.Family}");
        // Checks the underlying buffer size.
        Console.WriteLine($"The size of the underlying buffer is: {socketAddress.Size}");
//</Snippet1>
    }
}
