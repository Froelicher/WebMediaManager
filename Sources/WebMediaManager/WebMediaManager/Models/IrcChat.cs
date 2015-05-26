using ChatSharp;
using ChatSharp.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WebMediaManager.Models
{
    class IrcChat
    {
        private TextBox _tbxChat;
        private string _username;
        private string _nickname;
        private string _token;
        private StreamingSite.SVideo _video;
        private IrcClient _client;
        private IrcUser _user;

        public IrcUser User
        {
            get { return _user; }
            set { _user = value; }
        }

        public IrcClient Client
        {
            get { return _client; }
            set { _client = value; }
        }


        public StreamingSite.SVideo Video
        {
            get { return _video; }
            set { _video = value; }
        }

        public string Token
        {
            get { return _token; }
            set { _token = value; }
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

        public TextBox TbxChat
        {
            get { return _tbxChat; }
            set { _tbxChat = value; }
        }

        public IrcChat(TextBox textbox, string username, string nickname, string token, StreamingSite.SVideo video)
        {
            this.TbxChat = textbox;
            this.Username = username;
            this.Nickname = nickname;
            this.Token = token;
            this.Video = video;
        }

        public void BuildMessage(string message)
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
        }

        private void NetWorkError(object sender, SocketErrorEventArgs e)
        {
            try { 
                if (this.TbxChat != null)
                    this.TbxChat.Invoke(new MethodInvoker(delegate { this.TbxChat.AppendText("Error: " + e.SocketError); }));
            }
            catch (ObjectDisposedException)
            { }
        }

        private void RawMessageReceived(object sender, RawMessageEventArgs e)
        {
            try{
                if(this.TbxChat != null)
                    this.TbxChat.Invoke(new MethodInvoker(delegate { BuildMessage(e.Message); }));
            }catch(ObjectDisposedException)
            { }
        }

        private void RawMessageSent(object sender, RawMessageEventArgs e)
        {
            try
            {
                if (this.TbxChat != null && e.Message != "QUIT")
                {
                    if (this.TbxChat != null)
                        this.TbxChat.Invoke(new MethodInvoker(delegate { BuildMessage(e.Message); }));
                }
            }catch(ObjectDisposedException)
            { }
        }

        private void ChannelMessageReceived(object sender, PrivateMessageEventArgs e)
        {
            try
            {
                if(this.TbxChat != null)
                    this.TbxChat.Invoke(new MethodInvoker(delegate { this.TbxChat.AppendText("<" + e.PrivateMessage.User.Nick + ">" + " " + e.PrivateMessage.Message + "\n"); }));
            }
            catch (ObjectDisposedException)
            { }
        }

        private void ChannelTopicReceived(object sender, ChannelTopicEventArgs e)
        {
            try
            {
                if (this.TbxChat != null)
                    this.TbxChat.Invoke(new MethodInvoker(delegate { this.TbxChat.AppendText("Received topic for channel " + e.Channel.Name + ": " + e.Topic + "\n"); }));
            }
            catch (ObjectDisposedException)
            { }

        }

        public void ConnectIrc()
        {  
            this.User = new IrcUser(this.Username, this.Nickname, "oauth:" + this.Token);
            this.Client = new IrcClient(this.Video.url_irc, this.User);

            if (this.Client != null)
            {

                this.Client.ConnectionComplete += (s, e) => this.Client.JoinChannel("#" + this.Video.channelName);

                this.Client.NetworkError += (s, e) => this.NetWorkError(s, e);
                this.Client.RawMessageRecieved += (s, e) => this.RawMessageReceived(s, e);
                this.Client.RawMessageSent += (s, e) => this.RawMessageSent(s, e);

                this.Client.UserMessageRecieved += (s, e) =>
                {
                    if (e.PrivateMessage.Message.StartsWith(".join "))
                    {
                        this.Client.Channels.Join(e.PrivateMessage.Message.Substring(6));
                    }
                    else if (e.PrivateMessage.Message.StartsWith(".list "))
                    {
                        var channel = this.Client.Channels[e.PrivateMessage.Message.Substring(6)];
                        var list = channel.Users.Select(u => u.Nick).Aggregate((a, b) => a + "," + b);
                        this.Client.SendMessage(list, e.PrivateMessage.User.Nick);
                    }
                    else if (e.PrivateMessage.Message.StartsWith(".whois "))
                        this.Client.WhoIs(e.PrivateMessage.Message.Substring(7), null);
                    else if (e.PrivateMessage.Message.StartsWith(".raw "))
                        this.Client.SendRawMessage(e.PrivateMessage.Message.Substring(5));
                    else if (e.PrivateMessage.Message.StartsWith(".mode "))
                    {
                        var parts = e.PrivateMessage.Message.Split(' ');
                        this.Client.ChangeMode(parts[1], parts[2]);
                    }
                    else if (e.PrivateMessage.Message.StartsWith(".topic "))
                    {
                        string messageArgs = e.PrivateMessage.Message.Substring(7);
                        if (messageArgs.Contains(" "))
                        {
                            string channel = messageArgs.Substring(0, messageArgs.IndexOf(" "));
                            string topic = messageArgs.Substring(messageArgs.IndexOf(" ") + 1);
                            this.Client.Channels[channel].SetTopic(topic);
                        }
                        else
                        {
                            string channel = messageArgs.Substring(messageArgs.IndexOf("#"));
                            this.Client.GetTopic(channel);
                        }
                    }
                };

                this.Client.ChannelMessageRecieved += (s, e) =>
                {
                    this.ChannelMessageReceived(s, e);
                };
                this.Client.ChannelTopicReceived += (s, e) =>
                {
                    this.ChannelTopicReceived(s, e);
                };

                this.Client.ConnectAsync();
            }
        }

        public void Quit()
        {
            //Unsubscribes client from three chat events
            this.Client.NetworkError -= (s, e) => this.NetWorkError(s, e);
            this.Client.RawMessageRecieved -= (s, e) => this.RawMessageReceived(s, e);
            this.Client.RawMessageSent -= (s, e) => this.RawMessageSent(s, e);

            this.Client.Quit();
            this.Client = null;
            this.TbxChat = null;
        }

        public void SendMessage(string msg)
        {
            this.Client.SendRawMessage(msg);
        }
    }
}
