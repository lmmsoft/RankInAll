using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;

namespace RankInAll.Utility
{
    public static class Http
    {
        public static string Get(string url, CookieContainer container)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = WebRequestMethods.Http.Get;
            request.CookieContainer = container;
			request.AllowAutoRedirect = false;
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            StreamReader reader = new StreamReader(response.GetResponseStream());
            string ret = reader.ReadToEnd();
            reader.Close();
            return ret;
        }
        public static string Get(string url, bool AutoRedirect)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = WebRequestMethods.Http.Get;
            request.CookieContainer = null;
            request.AllowAutoRedirect = AutoRedirect;
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            StreamReader reader = new StreamReader(response.GetResponseStream());
            string ret = reader.ReadToEnd();
            reader.Close();
            return ret;
        }

        public static string Get(string url, CookieContainer container,Encoding encoding)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = WebRequestMethods.Http.Get;
            request.CookieContainer = container;
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            StreamReader reader = new StreamReader(response.GetResponseStream(),encoding);
            string ret = reader.ReadToEnd();
            reader.Close();
            return ret;
        }


        //System.Net.ServicePointManager.Expect100Continue = false;
        public static PostResponse Post(string url, string content)
        {
            var data = Encoding.ASCII.GetBytes(content);
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.CookieContainer = new CookieContainer();
            request.Method = WebRequestMethods.Http.Post;
            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = data.Length;
            Stream stream = request.GetRequestStream();
            stream.Write(data, 0, data.Length);
            stream.Close();
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            StreamReader reader = new StreamReader(response.GetResponseStream());
            string ret = reader.ReadToEnd();
            reader.Close();
            return new PostResponse() { Container = request.CookieContainer, Content = ret };
        }


        public static PostResponse Post(string url, string content,int mark)
        {
            System.Net.ServicePointManager.Expect100Continue = false;
            var data = Encoding.ASCII.GetBytes(content);
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.CookieContainer = new CookieContainer();
            request.Method = WebRequestMethods.Http.Post;
            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = data.Length;
            Stream stream = request.GetRequestStream();
            stream.Write(data, 0, data.Length);
            stream.Close();
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            StreamReader reader = new StreamReader(response.GetResponseStream());
            string ret = reader.ReadToEnd();
            reader.Close();
            return new PostResponse() { Container = request.CookieContainer, Content = ret };
        }

        public static PostResponse Post(string url, string content, CookieContainer container)
        {
            var data = Encoding.ASCII.GetBytes(content);
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.CookieContainer = container;
            request.Method = WebRequestMethods.Http.Post;
            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = data.Length;
            Stream stream = request.GetRequestStream();
            stream.Write(data, 0, data.Length);
            stream.Close();
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            StreamReader reader = new StreamReader(response.GetResponseStream());
            string ret = reader.ReadToEnd();
            return new PostResponse() { Container = request.CookieContainer, Content = ret };
        }
    }
}
