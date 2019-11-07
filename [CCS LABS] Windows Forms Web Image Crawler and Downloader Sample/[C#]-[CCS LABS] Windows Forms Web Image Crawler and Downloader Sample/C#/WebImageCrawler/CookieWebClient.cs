using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;

namespace WebImageCrawler
{
    class CookieWebClient : WebClient
    {
        public CookieWebClient(CookieContainer container)
    {
        this.container = container;
    }

    private readonly CookieContainer container = new CookieContainer();

    protected override WebRequest GetWebRequest(Uri address)
    {
        WebRequest r = base.GetWebRequest(address);
        var request = r as HttpWebRequest;
        if (request != null)
        {
            request.CookieContainer = container;
        }
        return r;
    }

    protected override WebResponse GetWebResponse(WebRequest request, IAsyncResult result)
    {
        WebResponse response = base.GetWebResponse(request, result);
        ReadCookies(response);
        return response;
    }

    protected override WebResponse GetWebResponse(WebRequest request)
    {
        WebResponse response = base.GetWebResponse(request);
        ReadCookies(response);
        return response;
    }

    private void ReadCookies(WebResponse r)
    {
        var response = r as HttpWebResponse;
        if (response != null)
        {
            CookieCollection cookies = response.Cookies;
            container.Add(cookies);
        }
    }
    }
}
