using ChatSharp;
using System;
using System.Linq;

namespace TestChatSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = new IrcClient("irc.freenode.net", new IrcUser("ChatSharp", "ChatSharp"));
            client.NetworkError += (s, e) => Console.WriteLine("Error: " + e.SocketError);
            client.RawMessageRecieved += (s, e) => Console.WriteLine("<< {0}", e.Message);
            client.RawMessageSent += (s, e) => Console.WriteLine(">> {0}", e.Message);
            client.UserMessageRecieved += (s, e) =>
                {
                    if (e.PrivateMessage.Message.StartsWith(".join "))
                        client.Channels.Join(e.PrivateMessage.Message.Substring(6));
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
                    Console.WriteLine("<{0}> {1}", e.PrivateMessage.User.Nick, e.PrivateMessage.Message);
                };
            client.ChannelTopicReceived += (s, e) =>
                {
                    Console.WriteLine("Received topic for channel {0}: {1}", e.Channel.Name, e.Topic);
                };
            client.ConnectAsync();
            while (true) ;
        }
    }
}
