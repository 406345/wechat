using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace WechatSDK.API
{
    internal class HTTP
    {
        
        private CookieContainer cookies = new CookieContainer();

        private enum HTTPMETHOD
        {
            GET,
            POST
        }

        private string Request(string url , int port , HTTPMETHOD method , Dictionary<string,string> header = null, string data = "" )
        {
            Uri uri = new Uri(url);
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url); 
            //request.ContentType = "application/x-www-form-urlencoded";
            
            if( method == HTTPMETHOD.GET)
            {
                request.Method = "GET";
            }
            else if( method == HTTPMETHOD.POST)
            {
                request.Method = "POST";
            }

            if (header == null)
                header = new Dictionary<string, string>();

            request.CookieContainer = cookies;
            request.KeepAlive = true; 
            request.UserAgent = "Mozilla/5.0 (Windows NT 10.0; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/55.0.2883.87 Safari/537.36";
            request.Accept = "*/*";
            request.Host = uri.Host;
            //request.Headers["Accept-Encoding"] = "gzip, deflate";
            request.Headers["Accept-Language"] = "zh-CN,zh;q=0.8,en;q=0.6";
            request.Referer = uri.Scheme + "://" + uri.Host + "/" ;

            if (header.ContainsKey("ContentType"))
            {
                request.ContentType = header["ContentType"];
            }

            if (header.ContainsKey("Accept"))
            {
                request.Accept = header["Accept"];
            }

            if ( method == HTTPMETHOD.POST)
            {
                byte[] buffer = Encoding.UTF8.GetBytes(data);
                request.ContentType = "application/json;";
                request.ContentLength = buffer.Length;
                request.GetRequestStream().Write(buffer, 0, buffer.Length);
            }

            HttpWebResponse response = null;

            try
            {
                response = (HttpWebResponse)request.GetResponse();
                string ret = "";

                using (StreamReader reader = new StreamReader(response.GetResponseStream(), System.Text.Encoding.UTF8))
                {
                    ret = reader.ReadToEnd();
                }

                return ret;
            }
            catch
            {

            }

            return "";
        }

        public string Get(string url, object header = null)
        {
            //Console.WriteLine("[GET] " + url);
            string ret = Request(url, 80, HTTPMETHOD.GET, Misc.Obj2Dict(header));
            return ret;
        }

        public string Post(string url, string data, Dictionary<string, string> header = null)
        {
           // Console.WriteLine("[POST] " + url);
            return Request(url, 80, HTTPMETHOD.POST, header, data);
        }
    }
}
