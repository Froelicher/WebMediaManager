using DotNetOpenAuth.AspNet.Clients;
using DotNetOpenAuth.Messaging;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Net;
using System.Text;
using System.Web;

namespace test1
{
    public class SiteClient : OAuth2Client 
    {
        private const string CODEVAR = "code";
        private const string STATEVAR = "state";

        private string _apiUrl;
        private string _enduserauthlink;
        private string _tokenLink;
        private string _clientId;
        private string _clientSecret;
        private string _scopes;
        private string _userUrl;

        public string UserUrl
        {
            get { return _userUrl; }
            set { _userUrl = value; }
        }

        public string Scopes
        {
            get { return _scopes; }
            set { _scopes = value; }
        }

        public string ClientSecret
        {
            get { return _clientSecret; }
            set { _clientSecret = value; }
        }

        public string ClientId
        {
            get { return _clientId; }
            set { _clientId = value; }
        }

        public string TokenLink
        {
            get { return _tokenLink; }
            set { _tokenLink = value; }
        }

        public string Enduserauthlink
        {
            get { return _enduserauthlink; }
            set { _enduserauthlink = value; }
        }

        public string ApiUrl
        {
            get { return _apiUrl; }
            set { _apiUrl = value; }
        }


        private static readonly Dictionary<string, string> Replacements = new Dictionary<string, string>()
        {
            {"name", "username"},
            {"_id", "id"}
        };

        public SiteClient(string clientId, string clientSecret, IEnumerable<string> scopes, string provider) : base(provider)
        {
            if (clientId == null) throw new ArgumentNullException("clientId");
            if (clientSecret == null) throw new ArgumentNullException("clientSecret");
            if (scopes == null) throw new ArgumentNullException("scopes");

            this.ClientId = clientId;
            this.ClientSecret = clientSecret;

            // TODO : Vérifié le minimum de scopes
        }

        protected override Uri GetServiceLoginUrl(Uri returnUrl)
        {
            if (this.Enduserauthlink == null) throw new ArgumentNullException("Enduserauthlink");
            if (this.Scopes == null) throw new ArgumentNullException("Scopes");

            var builder = new UriBuilder(Enduserauthlink);

            builder.AppendQueryArgument("client_id", this.ClientId);
            builder.AppendQueryArgument("redirect_uri", returnUrl.GetLeftPart(UriPartial.Path));
            //Removes the '?' at the start of the query string so TwitchState.DecodeTwitchCallback doesn't have to deal with it
            builder.AppendQueryArgument(STATEVAR, returnUrl.Query.Substring(1));
            builder.AppendQueryArgument("scope", this.Scopes);

            return builder.Uri;
        }

        protected override string QueryAccessToken(Uri returnUrl, string authorizationCode)
        {
            using (var client = new WebClient())
            {
                SetHeaders(client);

                var data = client.UploadValues(TokenLink, new NameValueCollection()
                {
                    {"client_id", this.ClientId},
                    {"client_secret", this.ClientSecret},
                    {"redirect_uri", returnUrl.GetLeftPart(UriPartial.Path)},
                    {"code", authorizationCode}
                });

                var response = Encoding.UTF8.GetString(data);

                var json = JObject.Parse(response);

                return json.GetValue("access_token").ToObject<string>();
            }
        }

        protected override IDictionary<string, string> GetUserData(string accessToken)
        {
            using (var client = new WebClient())
            {
                SetHeaders(client, accessToken);

                var response = client.DownloadString(this.UserUrl);

                var json = JObject.Parse(response);

                var dic = new Dictionary<string, string>();

                foreach (var pair in json)
                {
                    var name = Replacements.ContainsKey(pair.Key) ? Replacements[pair.Key] : pair.Key;
                    var value = pair.Value.ToString();

                    dic.Add(name, value);
                }

                return dic;
            }
        }

        private void SetHeaders(WebClient client, string token = null)
        {
            var headers = new WebHeaderCollection
            {
                //TODO : PARAMETRE POUR LHEADER
                {HttpRequestHeader.Accept, "application/vnd.twitchtv.v3+json"},
                {"Client-ID", this.ClientId}
            };

            if (!string.IsNullOrWhiteSpace(token))
                headers.Add(HttpRequestHeader.Authorization, string.Format("OAuth {0}", token));

            client.Headers = headers;
        }


        public static bool DecodeCallback(out Uri redirectUrl)
        {
            redirectUrl = null;
            var context = HttpContext.Current;

            if (context == null)
                return false;

            var request = context.Request;

            var state = request.QueryString[STATEVAR];
            var code = request.QueryString[CODEVAR];

            if (string.IsNullOrWhiteSpace(state) || string.IsNullOrWhiteSpace(code))
                return false;

            var b = new UriBuilder(request.Url.GetLeftPart(UriPartial.Path))
            {
                Query = Uri.UnescapeDataString(state)
            };

            b.AppendQueryArgument(CODEVAR, code);

            redirectUrl = b.Uri;

            return true;
        }
    }
}
