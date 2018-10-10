using System;
using System.Net;
using System.Web;
using System.Web.UI;

public class Page1 : Page
{
    private void Page_Load(Object sender, EventArgs e)
    {
// <Snippet1>
        HttpWebRequest httpWReq = (HttpWebRequest)WebRequest.Create("http://www.contoso.com");
        HttpWebResponse httpWResp = (HttpWebResponse)httpWReq.GetResponse();

        // Insert code that uses the response object.

        httpWResp.Close();
// </Snippet1>
    }
}
