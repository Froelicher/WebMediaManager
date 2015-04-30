using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebMediaManager.Models
{
    class Authentification
    {
        private const string CLIENT_ID = "";
        private const string REDIRECT_URI = "";

        private string[] _scopes;
        private string _url_auth;

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

        public Authentification(string[] scopes, string url_auth)
        {
            this.Scopes = scopes;
            this.Url_auth = url_auth;
        }

        public string CreateUrlConnexion()
        {

            return "";
        }

        public string GetAccessToken()
        {
            return "";
        }

        public string GetCode()
        {
            return "";
        }
    }
}
