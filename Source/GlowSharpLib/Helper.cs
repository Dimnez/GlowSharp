using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

public partial class GlowSharp
{
    public class Helper
    {
        //Basic HTTP-GET
        //Hue-Api is always responding with JSON, so we're returning a dynamic-object here
        public static dynamic GET(string url)
        {
            return JsonConvert.DeserializeObject((new WebClient()).DownloadString(url));
        }

        //Basic JSON-Post / Hue-Api is always responding with JSON, so we're returning 
        //a dynamic-object here
        public static dynamic POST(string url, dynamic obj)
        {
            string result = "";

            var httpRequest = (HttpWebRequest)WebRequest.Create(url);
            httpRequest.ContentType = "application/json";
            httpRequest.Method = "POST";

            using (var streamWriter = new StreamWriter(httpRequest.GetRequestStream()))
            {
                streamWriter.Write(JsonConvert.SerializeObject(obj));
            }

            var httpResponse = (HttpWebResponse)httpRequest.GetResponse();

            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                result = streamReader.ReadToEnd();
            }

            return JArray.Parse(result);
        }


        //Basic PUT for (e.g.) updating Light-States
        public static dynamic PUT(string url, dynamic obj)
        {
            string result = "";

            var httpRequest = (HttpWebRequest)WebRequest.Create(url);
            httpRequest.ContentType = "application/json";
            httpRequest.Method = "PUT";

            JsonSerializer _jsonWriter = new JsonSerializer
            {
                NullValueHandling = NullValueHandling.Ignore
            };
            
            using (var streamWriter = new StreamWriter(httpRequest.GetRequestStream()))
            {
                streamWriter.Write(JsonConvert.SerializeObject(obj));
            }

            var httpResponse = (HttpWebResponse)httpRequest.GetResponse();

            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                result = streamReader.ReadToEnd();
            }

            return JArray.Parse(result);
        }


    }
}