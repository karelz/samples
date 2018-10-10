// System.Net.WebResponse.ResponseUri
/* This program demonstrates the 'ResponseUri' property of the 'WebResponse' class
It creates a web request and queries for a response. It then compares the ResponseUri value to the actual Url 
value to see if the original request was redirected. */

using System;
using System.Net;
using System.IO;
using System.Text;

class WebResponseSnippet
{
    public static void Main(string[] args) 
    {
	    if (args.Length < 1)
		{
			Console.WriteLine("Please type the Url as command line parameter");
			Console.WriteLine("Example:");
			Console.WriteLine("    WebResponse_ResponseUri http://www.microsoft.com");
		}
		else
		{
			GetPage(args[0]);
		}
    }

    public static void GetPage(String url) 
    {
	    try
        {
// <Snippet1>
		    Uri ourUri = new Uri(url);

		    // Create a 'WebRequest' object with the specified url.
			WebRequest myWebRequest = WebRequest.Create(url);

			// Send the 'WebRequest' and wait for response.
			WebResponse myWebResponse = myWebRequest.GetResponse();

            // Use "ResponseUri" property to get the actual Uri from where the response was attained.
            if (ourUri.Equals(myWebResponse.ResponseUri))
            {
                Console.WriteLine($"Request Url: {url} was not redirected");
            }
            else
            {
                Console.WriteLine($"Request Url: {url} was redirected to {myWebResponse.ResponseUri}");
            }

            // Release resources of response object.
			myWebResponse.Close();
// </Snippet1>
        }
		catch (WebException e)
		{
			Console.WriteLine($"WebException was raised. Status is: {e.Status}");
        }
		catch (Exception e)
		{
			Console.WriteLine($"The following Exception was raised. Message is: {e.Message}");
		}
	}
}
