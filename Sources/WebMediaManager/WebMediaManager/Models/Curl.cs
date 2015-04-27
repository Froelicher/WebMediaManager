using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace WebMediaManager.Models
{
    static class Curl
    {
        /// <summary>
        /// Send request and get response html
        /// </summary>
        /// <param name="urlRequest">request url</param>
        /// <param name="p_method">method to use</param>
        /// <param name="p_access_token">user access token</param>
        /// <param name="acceptHeader">the accept header html</param>
        /// <returns>HttpWebResponse</returns>
        public static HttpWebResponse SendRequest(string urlRequest, string p_method, string p_access_token, string acceptHeader)
        {
            //Create a new http request
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(urlRequest);

            //Init the http request
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Accept = acceptHeader;
            httpWebRequest.Method = p_method;
            httpWebRequest.Headers.Add("Authorization: OAuth " + p_access_token);
             if (p_method == "PUT")
                httpWebRequest.ContentLength = 0;

             //Create a http response
             var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();

             return httpResponse;
        }

        /// <summary>
        /// Send request and get response html
        /// </summary>
        /// <param name="urlRequest">request url</param>
        /// <param name="p_method">method to use</param>
        /// <param name="acceptHeader">the accept header html</param>
        /// <returns>HttpWebResponse</returns>
        public static HttpWebResponse SendRequest(string urlRequest, string p_method, string acceptHeader)
        {
            //Create a new http request
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(urlRequest);

            //Init the http request
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Accept = acceptHeader;
            httpWebRequest.Method = p_method;

            //Create a http response
            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();

            return httpResponse;
        }

        /// <summary>
        /// Deserialize a http web response
        /// </summary>
        /// <typeparam name="T">Generic type</typeparam>
        /// <param name="jsonContent">content json</param>
        /// <returns>the object deserialized</returns>
        public static T Deserialize<T>(HttpWebResponse jsonContent)
        {
            var httpResponse = jsonContent;

            //Read the response
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                //Add to the generics variable the result
                T answer = JsonConvert.DeserializeObject<T>(streamReader.ReadToEnd());
                return answer;
            }
        }
    }
}
