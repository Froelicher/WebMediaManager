using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebMediaManager.Structures;

namespace WebMediaManager.Models
{
    class Authentification
    {
        private const string REDIRECT_URI = "https://froelicher.github.io/WebMediaManager/WebSite/";

        private string[] _scopes;
        private string _url_auth;
        private string _client_id;
        private string _client_secret;
        private string _access_token;
        private bool _isConnected;

        public bool IsConnected
        {
            get { return _isConnected; }
            set { _isConnected = value; }
        }

        public string Access_token
        {
            get { return _access_token; }
            set { _access_token = value; }
        }

        public string Client_secret
        {
            get { return _client_secret; }
            set { _client_secret = value; }
        }

        public string Client_id
        {
            get { return _client_id; }
            set { _client_id = value; }
        }

        public string Url_auth
        {
            get { return _url_auth; }
            set { _url_auth = value; }
        }

        public string[] Scopes
        {
            get { return _scopes; }
            set { _scopes = value; }
        }

        public Authentification()
        {
            this.IsConnected = false;
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="scopes"></param>
        /// <param name="url_auth"></param>
        public Authentification(string[] scopes, string url_auth, string client_id) : this(scopes, url_auth, client_id, null, null)
        {
            //no code ...
        }

        public Authentification(string[] scopes, string url_auth, string client_id, string client_secret, string state)
        {
            this.Scopes = scopes;
            this.Url_auth = url_auth;
            this.Client_id = client_id;
            this.Client_secret = client_secret;
        }

        /// <summary>
        /// Create the url to log
        /// </summary>
        /// <returns></returns>
        public string CreateUrlConnexion()
        {
            string resultUrl = "";
            resultUrl = this.Url_auth+"?response_type=token&client_id="+this.Client_id+"&redirect_uri="+REDIRECT_URI+"&scope="+this.ConvertStringArrayToString(this.Scopes);
            return resultUrl;
        }

        /// <summary>
        /// Get the code
        /// </summary>
        /// <returns></returns>
        public string GetAccessTokenByCode(string url, string code, string accept_header)
        {
            AuthResponse authResponse = Curl.Deserialize<AuthResponse>(Curl.SendRequest(url, "POST", accept_header));
            return authResponse.access_token;
        }

        /// <summary>
        /// String array to string
        /// </summary>
        /// <param name="array"></param>
        /// <returns></returns>
        private string ConvertStringArrayToString(string[] array)
        {
            StringBuilder builder = new StringBuilder();
            foreach(string value in array)
            {
                builder.Append(value);
                builder.Append('+');
            }

            builder.Remove(builder.Length - 1, 1);

            return builder.ToString();
        }
    }
}
