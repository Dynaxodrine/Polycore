using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using Newtonsoft.Json;

namespace Polycore.API
{
    public class CoreBase
    {
        private static string RequestRaw(string url, Dictionary<string, string> headers)
        {
            WebRequest request = WebRequest.Create(url);

            foreach(KeyValuePair<string, string> value in headers)
                request.Headers.Add(value.Key, value.Value);
            
            Stream stream = request.GetResponse().GetResponseStream();

            if (stream == null)
                return null;

            StreamReader reader = new StreamReader(stream);
            StringBuilder sb = new StringBuilder();
            string line;

            while ((line = reader.ReadLine()) != null)
                sb.Append(line);
            
            return sb.ToString();
        }

        private static string RequestRaw(string url)
        {
            return RequestRaw(url, new Dictionary<string, string>());
        }

        protected static XDocument RequestXml(string url)
        {
            string response = RequestRaw(url);
            return XDocument.Parse(response.Trim());
            
        }

        protected static T RequestJson<T>(string url, Dictionary<string, string> headers)
        {
            string response = RequestRaw(url, headers);
            return JsonConvert.DeserializeObject<T>(response); 
        }

        protected static T RequestJson<T>(string url)
        {
            return RequestJson<T>(url, new Dictionary<string, string>());
        }
    }
}