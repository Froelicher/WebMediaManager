using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebMediaManager.Models
{
    class IrcChat
    {

        private string _username;
        private string _nickname;
        private string _oauth_token;

        public string Oauth_token
        {
            get { return _oauth_token; }
            set { _oauth_token = value; }
        }

        public string Nickname
        {
            get { return _nickname; }
            set { _nickname = value; }
        }

        public string Username
        {
            get { return _username; }
            set { _username = value; }
        }

        public IrcChat(string username, string token)
        {
            this.Username = username;
            this.Nickname = username;
            this.Oauth_token = token;
        }

        public string BuildMessage(string message)
        {
            StringBuilder result = new StringBuilder();

            if (message.Contains("PRIVMSG"))
            {
                result.Append("<< ");
                result.Append(message.Substring(1, message.IndexOf('!') - 1));
                string[] split = message.Split();
                for (int i = 3; i < split.Count(); i++)
                {
                    result.Append(split[i] + " ");
                }
                result.Append("\r\n");
            }

            return result.ToString();
        }



    }
}
