/*
 * Author : JP. Froelicher
 * Description : cURL library class
 * Date : 16/04/2015
 */ 

using Newtonsoft.Json;
using System;
using System.IO;
using System.Net;

namespace WebMediaManager.Models
{
    public static class Curl
    {
        /// <summary>
        /// Send request and get response html
        /// </summary>
        /// <param name="urlRequest">request url</param>
        /// <param name="p_method">method to use</param>
        /// <param name="p_access_token">user access token</param>
        /// <param name="acceptHeader">the accept header html</param>
        /// <returns>HttpWebResponse</returns>
        public static Stream SendRequest(string urlRequest, string p_method, string p_access_token, string acceptHeader)
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
             Stream httpResponse = httpWebRequest.GetResponse().GetResponseStream();

             return httpResponse;
        }

        /// <summary>
        /// Send request and get response html
        /// </summary>
        /// <param name="urlRequest">request url</param>
        /// <param name="p_method">method to use</param>
        /// <param name="acceptHeader">the accept header html</param>
        /// <returns>HttpWebResponse</returns>
        public static Stream SendRequest(string urlRequest, string p_method, string acceptHeader)
        {
            try
            {
                //Create a new http request
                var httpWebRequest = (HttpWebRequest)WebRequest.Create(urlRequest);

                //Init the http request
                httpWebRequest.ContentType = "application/json";
                httpWebRequest.Accept = acceptHeader;
                httpWebRequest.Method = p_method;

                //Create a http response
                var httpResponse = httpWebRequest.GetResponse().GetResponseStream();

                return httpResponse;
            }
            catch(Exception e)
            {
                System.Windows.Forms.MessageBox.Show(e.Message + " // " + e.Data);
                return null;
            }
        }

        /// <summary>
        /// Deserialize a http web response
        /// </summary>
        /// <typeparam name="T">Generic type</typeparam>
        /// <param name="jsonContent">content json</param>
        /// <returns>the object deserialized</returns>
        public static T Deserialize<T>(Stream jsonContent)
        {
            var httpResponse = jsonContent;

            if (httpResponse != null)
            {
                //Read the response
                using (var streamReader = new StreamReader(httpResponse))
                {
                    //Add to the generics variable the result
                    T answer = JsonConvert.DeserializeObject<T>(streamReader.ReadToEnd());
                    return answer;
                }
            }

            return default(T);
        }

        /// <summary>
        /// Generate a stream from string
        /// </summary>
        /// <param name="s">string</param>
        /// <returns>stream</returns>
        public static Stream GenerateStreamFromString(string s)
        {
            MemoryStream stream = new MemoryStream();
            StreamWriter writer = new StreamWriter(stream);
            writer.Write(s);
            writer.Flush();
            stream.Position = 0;
            return stream;
        }
    }
}
