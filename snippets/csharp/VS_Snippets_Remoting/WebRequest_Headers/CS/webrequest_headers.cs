/* System.Net.WebRequest.Headers
 This program demonstrates the 'Headers' property of 'WebRequest' Class.
 A new 'WebRequest' object is created. The (name, value) collection of the HTTP Headers are displayed to the 
 console. The contents of the HTML page of the requested URI are displayed to the console. */

using System;
using System.IO;
using System.Net;
using System.Text;
	
class WebRequest_Headers
{
	static void Main()
	{
		try
		{
// <Snippet1>
            // Create a new request to the mentioned URL.
			WebRequest myWebRequest = WebRequest.Create("http://www.contoso.com");

			// Assign the response object of 'WebRequest' to a 'WebResponse' variable.
			WebResponse myWebResponse = myWebRequest.GetResponse();

			// Release the resources of response object.
			myWebResponse.Close();
            Console.WriteLine($"The HttpHeaders are: {myWebRequest.Headers}");
// </Snippet1>
		}
        catch (WebException e)
        {
            Console.WriteLine("WebException is raised");
            Console.WriteLine($"Message: {e.Message}");
            Console.WriteLine($"Status: {e.Status}");
        }
        catch (Exception e)
        {
            Console.WriteLine("Exception is raised");
            Console.WriteLine($"Message: {e.Message}");
        }
	}
}
