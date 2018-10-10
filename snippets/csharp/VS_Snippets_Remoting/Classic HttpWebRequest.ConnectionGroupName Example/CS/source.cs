using System;
using System.Net;
using System.Web;
using System.Security.Cryptography;
using System.Text;

public class TestClass
{
    public static void Main()
    {
// <Snippet1>  
        // Create a secure group name.
        SHA1Managed sha1 = new SHA1Managed();
        Byte[] updHash = sha1.ComputeHash(Encoding.UTF8.GetBytes("username" + "password" +  "domain"));
        String secureGroupName = Encoding.Default.GetString(updHash);

        // Create a request for a specific URL.
        WebRequest myWebRequest = WebRequest.Create("http://www.contoso.com");

        // Set the authentication credentials for the request.      
        myWebRequest.Credentials = new NetworkCredential("username", "password", "domain"); 
        myWebRequest.ConnectionGroupName = secureGroupName;

        // Get the response.
        WebResponse myWebResponse = myWebRequest.GetResponse();

        // Insert the code that uses myWebResponse here.

        // Close the response.
        myWebResponse.Close();
// </Snippet1>
    }
}
