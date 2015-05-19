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

namespace TestChatIrc
{
    public partial class Form1 : Form
    {
        private RichTextBox _chat;

        public RichTextBox Chat
        {
            get { return _chat; }
            set { _chat = value; }
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CreateTextBox();
            InitIrc();
        }

        private void CreateTextBox()
        {
            this.Chat = new RichTextBox();
           this.Chat.Location = new Point(0, 0);
           this.Chat.Multiline = true;
           this.Chat.Size = new Size(250, 300);
           this.Chat.ScrollBars = (RichTextBoxScrollBars)ScrollBars.Vertical;
           this.Controls.Add(this.Chat);
        }

        private void BuildMessage(string message)
        {
            StringBuilder result = new StringBuilder();

            if(message.Contains("PRIVMSG"))
            {
                result.Append("<< ");
                result.Append(message.Substring(1, message.IndexOf('!')-1));
                string[] split = message.Split();
                for (int i = 3; i < split.Count(); i++)
                {
                    result.Append(split[i]+ " ");
                }
                result.Append("\r\n");
            }

            this.Chat.AppendText(result.ToString());
                
        }

        private void InitIrc()
        {
            var user = new IrcUser("grunghi", "grunghi", "oauth:0w0w9dxtdxr6qrri1qnk553uqnu2b1");
                var client = new IrcClient("irc.twitch.tv", user);
                StringBuilder result = new StringBuilder();

                client.ConnectionComplete += (s, e) => client.JoinChannel("#kevin3594");
                client.NetworkError += (s, e) => this.Chat.Invoke(new MethodInvoker(delegate { this.Chat.AppendText("Error: " + e.SocketError);}));

                client.RawMessageRecieved += (s, e) => this.Chat.Invoke(new MethodInvoker(delegate { BuildMessage(e.Message); }));
                client.RawMessageSent += (s, e) => this.Chat.Invoke(new MethodInvoker(delegate { BuildMessage(e.Message); }));

                client.UserMessageRecieved += (s, e) =>
                {
                    if (e.PrivateMessage.Message.StartsWith(".join "))
                    {
                        client.Channels.Join(e.PrivateMessage.Message.Substring(6));
                    }
                    else if (e.PrivateMessage.Message.StartsWith(".list "))
                    {

                        var channel = client.Channels[e.PrivateMessage.Message.Substring(6)];
                        var list = channel.Users.Select(u => u.Nick).Aggregate((a, b) => a + "," + b);
                        client.SendMessage(list, e.PrivateMessage.User.Nick);
                    }
                    else if (e.PrivateMessage.Message.StartsWith(".whois "))
                        client.WhoIs(e.PrivateMessage.Message.Substring(7), null);
                    else if (e.PrivateMessage.Message.StartsWith(".raw "))
                        client.SendRawMessage(e.PrivateMessage.Message.Substring(5));
                    else if (e.PrivateMessage.Message.StartsWith(".mode "))
                    {
                        var parts = e.PrivateMessage.Message.Split(' ');
                        client.ChangeMode(parts[1], parts[2]);
                    }
                    else if (e.PrivateMessage.Message.StartsWith(".topic "))
                    {
                        string messageArgs = e.PrivateMessage.Message.Substring(7);
                        if (messageArgs.Contains(" "))
                        {
                            string channel = messageArgs.Substring(0, messageArgs.IndexOf(" "));
                            string topic = messageArgs.Substring(messageArgs.IndexOf(" ") + 1);
                            client.Channels[channel].SetTopic(topic);

                        }
                        else
                        {
                            string channel = messageArgs.Substring(messageArgs.IndexOf("#"));
                            client.GetTopic(channel);
                        }
                    }
                };

                client.ChannelMessageRecieved += (s, e) =>
                {
                    result.Append("<"+e.PrivateMessage.User.Nick+">" + " " + e.PrivateMessage.Message + "\n");
                };
                client.ChannelTopicReceived += (s, e) =>
                {
                    result.Append("Received topic for channel " + e.Channel.Name + ": " + e.Topic + "\n");
                };

                client.ConnectAsync();
        }
    }
}
