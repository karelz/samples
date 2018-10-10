/* System.Net.WebRequest.PreAuthenticate, System.Net.WebRequest.Credentials
This program demonstrates the 'PreAuthenticate' and 'NetworkCredential' properties of the WebRequest Class.
The PreAuthenticate Property has a default value set to False.
This is set to True and new NetwrokCredential object is created with UserName and Password.
This NetworkCredential Object associated to the WebRequest Object to be able to authenticate the requested Uri.
To check the validity of this program, please try with some authenticated sites with appropriate credentials. */

using System;
using System.IO;
using System.Net;
using System.Text;

class WebRequest_Preauthenticate
{
	static void Main(string[] args)
	{
		if (args.Length < 1)
		{
			Console.WriteLine("Please type the url which requires authentication as command line parameter");
			Console.WriteLine("Example: WebRequest_PreAuthenticate http://www.microsoft.com");		
		}
		else
		{
			GetPage(args[0]);
		}
	}

    public static void GetPage(string url)
	{
		try
		{
// <Snippet1>
// <Snippet2>
            // Create a new webrequest to the mentioned URL.
			WebRequest myWebRequest=WebRequest.Create(url);

			// Set 'Preauthenticate' property to true.  Credentials will be sent with the request.
			myWebRequest.PreAuthenticate = true;

			Console.WriteLine("Please enter your credentials for the requested Url");
            Console.WriteLine("Username: ");
			string username = Console.ReadLine();
			Console.WriteLine("Password: ");
			string password = Console.ReadLine();

			// Create a New 'NetworkCredential' object.
			NetworkCredential networkCredential = new NetworkCredential(username, password);

			// Associate the 'NetworkCredential' object with the 'WebRequest' object.
			myWebRequest.Credentials=networkCredential;

			// Assign the response object of 'WebRequest' to a 'WebResponse' variable.
			WebResponse myWebResponse = myWebRequest.GetResponse();
// </Snippet2>
// </Snippet1>
			// Read the 'Response' into a Stream object and then print to the console.
			Stream streamResponse = myWebResponse.GetResponseStream();
			StreamReader streamRead = new StreamReader(streamResponse);
			char[] readBuff = new char[256];
			int count = streamRead.Read(readBuff, 0, 256);
			Console.WriteLine("The contents of the Html page of the requested Uri are:");
			while (count > 0)
			{
				String outputData = new String(readBuff, 0, count);
				Console.Write(outputData);
				count = streamRead.Read(readBuff, 0, 256);
			}

			// Close the Stream object.
			streamResponse.Close();
			streamRead.Close();

			// Release the HttpWebResponse Resource.
			myWebResponse.Close();
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
