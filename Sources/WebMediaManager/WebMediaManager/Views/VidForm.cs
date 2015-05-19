using ChatSharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WebMediaManager.Controllers;
using WebMediaManager.Models;

namespace WebMediaManager.Views
{
    public partial class VidForm : Form
    {
        private SitesController _controller;
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

        internal SitesController Controller
        {
            get { return _controller; }
            set { _controller = value; }
        }

        public VidForm(StreamingSite.SVideo video, Model model)
        {
            InitializeComponent();
            this.Controller = new SitesController(this, model);
            this.Video = video;
            this.wbbPlayer.Url = new Uri(video.playerLink);
            this.wbbDescription.DocumentText = video.description;
            this.lblTitle.Text = video.videoName;
            this.lblViews.Text = video.nbViews.ToString();
            this.ConnectIrc();
        }

        private void VidForm_Load(object sender, EventArgs e)
        {
            
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

        public void ConnectIrc()
        {
            this.User = new IrcUser(this.Controller.GetUserName(this.Video.siteName), this.Controller.GetUserName(this.Video.siteName), "oauth:"+this.Controller.GetAccessToken(this.Video.siteName));
            this.Client = new IrcClient(this.Video.url_irc, this.User);

            this.Client.ConnectionComplete += (s, e) => this.Client.JoinChannel("#" + this.Video.channelName);

            if (this.IsHandleCreated)
            {
                this.Client.NetworkError += (s, e) => this.tbxChat.Invoke(new MethodInvoker(delegate { this.tbxChat.AppendText("Error: " + e.SocketError); }));
                this.Client.RawMessageRecieved += (s, e) => this.tbxChat.Invoke(new MethodInvoker(delegate { BuildMessage(e.Message); }));
                this.Client.RawMessageSent += (s, e) => this.tbxChat.Invoke(new MethodInvoker(delegate { BuildMessage(e.Message); }));
            }
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
                        this.tbxChat.Invoke(new MethodInvoker(delegate { this.tbxChat.AppendText("<" + e.PrivateMessage.User.Nick + ">" + " " + e.PrivateMessage.Message + "\n"); }));
                    };
                    this.Client.ChannelTopicReceived += (s, e) =>
                    {
                        this.tbxChat.Invoke(new MethodInvoker(delegate { this.tbxChat.AppendText("Received topic for channel " + e.Channel.Name + ": " + e.Topic + "\n"); }));
                    };

                this.Client.ConnectAsync();
            
        }

        private void VidForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Client.Quit();
            this.Client = null;
        }

        private void btnSendMsg_Click(object sender, EventArgs e)
        {
            if (tbxSendMsg.Text != "")
            {
                IrcMessage msg = new IrcMessage(this.tbxSendMsg.Text);
                this.Client.SendMessage(tbxSendMsg.Text, this.Client.ServerAddress);
            }
        }
    }
}
