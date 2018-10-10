/* System.Net.WebRequest.Proxy
This program demonstrates the 'Proxy' property of the 'WebRequest' class.
A WebRequest object is created and a new Proxy Object is created.
The Proxy Object is assigned the 'Proxy' Property of the WebRequest Object and then printed to the console,this is the default Proxy setting.
New Proxy address and the credentials are requested from the User.
A new Proxy object is then constructed from the inputs.
Then the 'Proxy' property of the request is associated with the new Proxy object constructed. */

using System;
using System.IO;
using System.Net;
using System.Text;

class WebRequest_Proxy
{
	static void Main()
	{
		try
		{
// <Snippet1>
			// Create a new request to the mentioned URL.
			WebRequest myWebRequest = WebRequest.Create("http://www.contoso.com");

			WebProxy myProxy = new WebProxy();
			// Obtain the Proxy Property of the Default browser.
			myProxy = (WebProxy)myWebRequest.Proxy;

			// Print myProxy address to the console.
			Console.WriteLine($"The actual default Proxy settings are {myProxy.Address}");

            try
			{
				Console.WriteLine("Please enter the new Proxy Address to be set");
				Console.WriteLine("The format of the address should be http://proxyUriAddress:portaddress");
				Console.WriteLine("    Example: http://proxyadress.com:8080");
				string proxyAddress = Console.ReadLine();

				if (proxyAddress.Length == 0)
				{
					myWebRequest.Proxy = myProxy;
				}
				else
				{
					Console.WriteLine("Please enter the Credentials");
					Console.WriteLine("Username:");
					string username = Console.ReadLine();
					Console.WriteLine("Password:");
					string password = Console.ReadLine();

					// Create a new Uri object.
					Uri newUri = new Uri(proxyAddress);

					// Associate the new Uri object to the myProxy object.
					myProxy.Address = newUri;

					// Create a NetworkCredential object and is assign to the Credentials property of the Proxy object.
					myProxy.Credentials = new NetworkCredential(username, password);
					myWebRequest.Proxy = myProxy;
				}
				Console.WriteLine($"The Address of the new Proxy settings are {myProxy.Address}");
				WebResponse myWebResponse = myWebRequest.GetResponse();

				// Print the HTML contents of the page to the console.
				Stream streamResponse = myWebResponse.GetResponseStream();
				StreamReader streamRead = new StreamReader(streamResponse);
				char[] readBuff = new char[256];
				int count = streamRead.Read(readBuff, 0, 256);
				Console.WriteLine("The contents of the Html pages are:");
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
			catch (UriFormatException e)
			{
				Console.WriteLine($"UriFormatException is thrown. Message is {e.Message}");
				Console.WriteLine("The format of the myProxy address you entered is invalid.");
			}
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
