using System.Text;
using System.Net;
using System.IO;
using System.IO.Compression;
using System.Text.RegularExpressions;
using System;
using System.Windows.Forms;

namespace TBAuction
{
    class AuctionOperations 
    {
        AuctionLog auctionLog; 
        
        //类初始化
        public AuctionOperations(AuctionLog auctionLog)
        {
            this.auctionLog = auctionLog;
        }
        
        //用于登录淘宝的方法
        public bool Login(string userName, string password, out CookieCollection ccReturned)
        {
            HttpWebRequest request;
            HttpWebResponse response;

            
            request = (HttpWebRequest)HttpWebRequest.Create("http://login.taobao.com/member/login.jhtml");
            request.CookieContainer = new CookieContainer();

            string data = @"TPL_username=" +  userName +  "&TPL_password=" + password + "&TPL_checkcode=&need_check_code=&_tb_token_=3ae3d5fe1558&action=Authenticator&event_submit_do_login=anything&TPL_redirect_url=&from=tb&fc=2&style=default&css_style=&tid=XOR_1_000000000000000000000000000000_6A583326340B7D790D7C017F&support=000001&CtrlVersion=1%2C0%2C0%2C7&loginType=3&minititle=&minipara=&umto=Tc3d70457869e730a9a1c0256c50b5d0e%2C200&pstrong=2&llnick=&sign=&need_sign=&isIgnore=&full_redirect=&popid=&callback=&guf=&not_duplite_str=&need_user_id=&poy=&gvfdcname=10&gvfdcre=&from_encoding=";

            byte[] postData = Encoding.Default.GetBytes(data);

            request.Method = "POST";
            request.ProtocolVersion = HttpVersion.Version11;

            //request.Connection = "keep-alive";

            request.UserAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/535.2 (KHTML, like Gecko) Chrome/15.0.861.0 Safari/535.2";
            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = postData.Length;
            request.Referer = " http://login.taobao.com/member/login.jhtml";
            request.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8";
            
            //request.Headers.Add("Connection", "keep-alive");

            request.Headers.Add("Cache-Control", "max-age=0");
            request.Headers.Add("Origin", "http://login.taobao.com");
            request.Headers.Add("Accept-Encoding", "gzip,deflate,sdch");
            request.Headers.Add("Accept-Language", "zh-CN,zh;q=0.8");
            request.Headers.Add("Accept-Charset", "GBK,utf-8;q=0.7,*;q=0.3");

            Stream st = request.GetRequestStream();
            st.Write(postData, 0, postData.Length);
            st.Close();

            request.AllowAutoRedirect = false;

            response = (HttpWebResponse)request.GetResponse();
            ccReturned = response.Cookies;

            response.Close();
            return ccReturned == null? false: true;
        }

        //用于获取商品页面的方法
        public string GetProductPage(string productAddress, CookieContainer ccEntered, out CookieCollection ccReturned)
        {
            HttpWebRequest request;
            HttpWebResponse response;            
            
            request = (HttpWebRequest)HttpWebRequest.Create(productAddress);

            request.Method = "GET";
            request.ProtocolVersion = HttpVersion.Version11;
            //request.Connection = "keep-alive";
            request.UserAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/535.2 (KHTML, like Gecko) Chrome/15.0.861.0 Safari/535.2";           
            request.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8";
            
            //request.Headers.Add("Connection", "keep-alive"); 

            request.Headers.Add("Accept-Encoding", "gzip,deflate,sdch");
            request.Headers.Add("Accept-Language", "zh-CN,zh;q=0.8");
            request.Headers.Add("Accept-Charset", "GBK,utf-8;q=0.7,*;q=0.3");
           
            request.CookieContainer = ccEntered;

            request.AllowAutoRedirect = true;

            response = (HttpWebResponse)request.GetResponse();
            ccReturned = response.Cookies;

            Stream st;
            st = response.GetResponseStream();

            if (response.ContentEncoding.ToLower().Contains("gzip"))
            {
                st = new GZipStream(st, CompressionMode.Decompress, true);
            }

            string htmlText;

            StreamReader stReader = new StreamReader(st, Encoding.Default);
            htmlText = stReader.ReadToEnd();

            stReader.Close();
            st.Close();

            if (htmlText.IndexOf("J_LinkBuy") > -1)
            {
                auctionLog.ShowTextInForm(response.ResponseUri.ToString(), htmlText);
            }            
            response.Close();

            return htmlText;
        }

        //用于获取营销信息，可能不需要
        public string GetMarketingInformation(string productAddress, CookieContainer ccEntered, out CookieCollection ccReturned)
        {
            HttpWebRequest request;
            HttpWebResponse response;            

            //生成获取营销信息的地址
            string marketingAddress = string.Empty, id = string.Empty;
            Match idMatch = Regex.Match(productAddress, "id\\s*=\\s*(?<id>\\d+)", RegexOptions.Compiled | RegexOptions.IgnoreCase | RegexOptions.Singleline);
            if (idMatch.Success)
            {
                id = idMatch.Groups["id"].ToString();
            }
            else
            {
                ccReturned = new CookieCollection();
                return string.Empty;
            }

            marketingAddress = "http://marketing.taobao.com/home/promotion/item_promotion_list.do?itemId=" + id;

            request = (HttpWebRequest)HttpWebRequest.Create(marketingAddress);

            request.Method = "GET";
            request.ProtocolVersion = HttpVersion.Version11;
            //request.Connection = "keep-alive";
            request.UserAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/535.2 (KHTML, like Gecko) Chrome/15.0.861.0 Safari/535.2";
            request.Accept = "*/*";
            request.Referer = productAddress;

            //request.Headers.Add("Connection", "keep-alive"); 

            request.Headers.Add("Accept-Encoding", "gzip,deflate,sdch");
            request.Headers.Add("Accept-Language", "zh-CN,zh;q=0.8");
            request.Headers.Add("Accept-Charset", "GBK,utf-8;q=0.7,*;q=0.3");

            request.CookieContainer = ccEntered;

            request.AllowAutoRedirect = true;

            response = (HttpWebResponse)request.GetResponse();
            ccReturned = response.Cookies;

            Stream st;
            st = response.GetResponseStream();

            if (response.ContentEncoding.ToLower().Contains("gzip"))
            {
                st = new GZipStream(st, CompressionMode.Decompress, true);
            }

            string htmlText;

            StreamReader stReader = new StreamReader(st, Encoding.Default);
            htmlText = stReader.ReadToEnd();

            stReader.Close();
            st.Close();

            auctionLog.ShowTextInForm(response.ResponseUri.ToString(), htmlText);

            response.Close();

            return htmlText;
 
        }
        
        //用于预提交商品页面的方法，可能不需要
        public string PreSubmitProductPage(string productAddress, CookieContainer ccEntered, out CookieCollection ccReturned)
        {
            HttpWebRequest request;
            HttpWebResponse response;

            //生成预处理地址
            string buyAddress = string.Empty, id = string.Empty;
            Match idMatch = Regex.Match(productAddress, "id\\s*=\\s*(?<id>\\d+)", RegexOptions.Compiled | RegexOptions.IgnoreCase | RegexOptions.Singleline);
            if (idMatch.Success)
            {
                id = idMatch.Groups["id"].ToString();
            }
            else
            {
                ccReturned = new CookieCollection();
                return string.Empty; 
            }

            DateTime dt1 = new DateTime(1970, 1, 1);
            DateTime dt2 = DateTime.Now;
            TimeSpan ts = new TimeSpan(dt2.Ticks - dt1.Ticks);

            buyAddress = "http://buy.taobao.com/auction/buy.htm?from=itemDetail&x_id=&item_id=" + id + "&id=" + id + "&var=login_indicator&t=" + (ts.Ticks / 10000).ToString();

            request = (HttpWebRequest)HttpWebRequest.Create(buyAddress);

            request.Method = "GET";
            request.ProtocolVersion = HttpVersion.Version11;
            //request.Connection = "keep-alive";
            request.UserAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/535.2 (KHTML, like Gecko) Chrome/15.0.861.0 Safari/535.2";
            request.Accept = "*/*";
            request.Referer = productAddress;

            //request.Headers.Add("Connection", "keep-alive"); 

            request.Headers.Add("Accept-Encoding", "gzip,deflate,sdch");
            request.Headers.Add("Accept-Language", "zh-CN,zh;q=0.8");
            request.Headers.Add("Accept-Charset", "GBK,utf-8;q=0.7,*;q=0.3");

            request.CookieContainer = ccEntered;

            request.AllowAutoRedirect = true;

            response = (HttpWebResponse)request.GetResponse();
            ccReturned = response.Cookies;

            Stream st;
            st = response.GetResponseStream();

            if (response.ContentEncoding.ToLower().Contains("gzip"))
            {
                st = new GZipStream(st, CompressionMode.Decompress, true);
            }

            string htmlText;

            StreamReader stReader = new StreamReader(st, Encoding.Default);
            htmlText = stReader.ReadToEnd();

            stReader.Close();
            st.Close();

            auctionLog.ShowTextInForm(response.ResponseUri.ToString(), htmlText);
           
            response.Close();

            return htmlText;
 
        }
        
        //用于提交商品页面的方法
        public string SubmitProductPage(string productAddress, string orderAddress, string data, CookieContainer ccEntered, out CookieCollection ccReturned)
        {
            HttpWebRequest request;
            HttpWebResponse response;
            
            byte[] postData = Encoding.Default.GetBytes(data);

            request = (HttpWebRequest)HttpWebRequest.Create(orderAddress);

            request.Method = "POST";
            request.ProtocolVersion = HttpVersion.Version11;
            //request.Host = "buy.taobao.com";
            //request.Connection = "keep-alive";            
            request.UserAgent = "Mozilla/5.0 (Windows NT 6.1) AppleWebKit/535.2 (KHTML, like Gecko) Chrome/15.0.861.0 Safari/535.2";
            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = postData.Length;
            request.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8";
            request.Referer = productAddress;


            //request.Headers.Add("Connection", "keep-alive"); 

            request.Headers.Add("Cache-Control", "max-age=0");
            request.Headers.Add("Origin", "http://buy.taobao.com");
            request.Headers.Add("Accept-Encoding", "gzip,deflate,sdch");
            request.Headers.Add("Accept-Language", "zh-CN,zh;q=0.8");
            request.Headers.Add("Accept-Charset", "GBK,utf-8;q=0.7,*;q=0.3");

            request.CookieContainer = ccEntered;

            Stream st = request.GetRequestStream();
            st.Write(postData, 0, postData.Length);
            st.Close();

            request.AllowAutoRedirect = true;

            response = (HttpWebResponse)request.GetResponse();
            ccReturned = response.Cookies;
            
            st = response.GetResponseStream();

            if (response.ContentEncoding.ToLower().Contains("gzip"))
            {
                st = new GZipStream(st, CompressionMode.Decompress, true);
            }

            string htmlText;

            StreamReader stReader = new StreamReader(st, Encoding.Default);
            htmlText = stReader.ReadToEnd();

            stReader.Close();
            st.Close();

            auctionLog.ShowTextInForm(response.ResponseUri.ToString(), htmlText);
            response.Close();

            return htmlText; 
        }

        //用于提交订单页面的方法
        public string SubmitOrder(string submitAddress, string data, CookieContainer ccEntered, out CookieCollection ccReturned)
        {
            HttpWebRequest request;
            HttpWebResponse response;

            byte[] postData = Encoding.Default.GetBytes(data);

            request = (HttpWebRequest)HttpWebRequest.Create(submitAddress);

            request.Method = "POST";
            request.ProtocolVersion = HttpVersion.Version11;
            //request.Host = "buy.taobao.com";
            //request.Connection = "keep-alive";            
            request.UserAgent = "Mozilla/5.0 (Windows NT 6.1) AppleWebKit/535.2 (KHTML, like Gecko) Chrome/15.0.861.0 Safari/535.2";            
            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = postData.Length;
            request.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8";
            request.Referer = "http://buy.taobao.com/auction/buy_now.jhtml";
            

            //request.Headers.Add("Connection", "keep-alive"); 

            request.Headers.Add("Cache-Control", "max-age=0");
            request.Headers.Add("Origin", "http://buy.taobao.com");
            request.Headers.Add("Accept-Encoding", "gzip,deflate,sdch");
            request.Headers.Add("Accept-Language", "zh-CN,zh;q=0.8");
            request.Headers.Add("Accept-Charset", "GBK,utf-8;q=0.7,*;q=0.3");

            request.CookieContainer = ccEntered;

            Stream st = request.GetRequestStream();
            st.Write(postData, 0, postData.Length);
            st.Close();

            request.AllowAutoRedirect = true;

            response = (HttpWebResponse)request.GetResponse();
            ccReturned = response.Cookies;

            st = response.GetResponseStream();

            if (response.ContentEncoding.ToLower().Contains("gzip"))
            {
                st = new GZipStream(st, CompressionMode.Decompress, true);
            }
            
            string htmlText;

            StreamReader stReader = new StreamReader(st, Encoding.Default);
            htmlText = stReader.ReadToEnd();

            stReader.Close();
            st.Close();            

            auctionLog.ShowTextInForm(response.ResponseUri.ToString(), htmlText);
            
            return htmlText;
        }

        //用于获取验证码图像的方法
        public Stream GetCheckCodeImageStream(string imageAddress, CookieContainer ccEntered, out CookieCollection ccReturned)
        {
            HttpWebRequest request;
            HttpWebResponse response;

            request = (HttpWebRequest)HttpWebRequest.Create(imageAddress);

            request.Method = "GET";
            request.ProtocolVersion = HttpVersion.Version11;
            //request.Connection = "keep-alive";
            request.UserAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/535.2 (KHTML, like Gecko) Chrome/15.0.861.0 Safari/535.2";
            request.Accept = "*/*";
            request.Referer = "http://buy.taobao.com/auction/buy_now.jhtml";

            //request.Headers.Add("Connection", "keep-alive"); 

            request.Headers.Add("Accept-Encoding", "gzip,deflate,sdch");
            request.Headers.Add("Accept-Language", "zh-CN,zh;q=0.8");
            request.Headers.Add("Accept-Charset", "GBK,utf-8;q=0.7,*;q=0.3");

            request.CookieContainer = ccEntered;

            request.AllowAutoRedirect = true;

            response = (HttpWebResponse)request.GetResponse();
            ccReturned = response.Cookies;
            
            return response.GetResponseStream();
        }

        //获取验证码验证信息的方法
        public string GetNewCheckCode(OrderPageHandle.CheckCode checkCode, CookieContainer ccEntered, out CookieCollection ccReturned)
        {
            
            if (string.IsNullOrEmpty(checkCode.J_checkCodeUrl))
            {
                auctionLog.Log("警告：获取newCheckCode的URL地址为空");
                ccReturned = new CookieCollection();
                return string.Empty;
            }

            HttpWebRequest request;
            HttpWebResponse response;

            string queryString = "isCheckCode=" + checkCode.isCheckCode + "&"
                + "encrypterString=" + checkCode.encrypterString + "&"
                + "sid" + checkCode.sid + "&"
                + "gmtCreate" + checkCode.gmtCreate + "&"
                + "checkCodeIds" + checkCode.checkCodeIds + "&"
                + "checkCode=" + checkCode.checkCode;

            request = (HttpWebRequest)HttpWebRequest.Create(checkCode.J_checkCodeUrl + "?" + queryString);

            request.Method = "GET";
            request.ProtocolVersion = HttpVersion.Version11;
            //request.Connection = "keep-alive";
            request.ContentType = " application/x-www-form-urlencoded; charset=UTF-8";
            request.UserAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/535.2 (KHTML, like Gecko) Chrome/15.0.861.0 Safari/535.2";
            request.Accept = "*/*";
            request.Referer = "http://buy.taobao.com/auction/buy_now.jhtml";

            //request.Headers.Add("Connection", "keep-alive"); 

            request.Headers.Add("X-Requested-With", "XMLHttpRequest");
            request.Headers.Add("Accept-Encoding", "gzip,deflate,sdch");
            request.Headers.Add("Accept-Language", "zh-CN,zh;q=0.8");
            request.Headers.Add("Accept-Charset", "GBK,utf-8;q=0.7,*;q=0.3");

            request.CookieContainer = ccEntered;

            request.AllowAutoRedirect = true;

            response = (HttpWebResponse)request.GetResponse();

            ccReturned = response.Cookies;

            Stream st;
            st = response.GetResponseStream();

            if (response.ContentEncoding.ToLower().Contains("gzip"))
            {
                st = new GZipStream(st, CompressionMode.Decompress, true);
            }

            string htmlText = string.Empty;

            StreamReader stReader = new StreamReader(st, Encoding.Default);
            htmlText = stReader.ReadToEnd();

            stReader.Close();
            st.Close();

            auctionLog.ShowTextInForm(response.ResponseUri.ToString(), htmlText);
            response.Close();

            return htmlText;
            
        }
    }
}
