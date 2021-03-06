﻿/*
 * Author : JP. Froelicher
 * Description : Twitch class
 * Date : 30/05/2015
 */ 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebMediaManager.Structures.STwitch;

namespace WebMediaManager.Models.Sites
{
    public class Twitch : StreamingSite
    {
        #region CONSTS
        private const string GET_METHOD = "GET";
        private const string URL_API = "https://api.twitch.tv/kraken/";
        private const string URL_SITE = "http://www.twitch.tv/";
        private const string URL_AUTH = "https://api.twitch.tv/kraken/oauth2/authorize";
        private const string ACCEPT_HTTP_HEADER = "application/vnd.twitchtv.v3+json";
        private const string CLIENT_ID = "9jfbie2pedk3xzoj3s53268v7fb4zds";
        #endregion


        /// <summary>
        /// Constructor
        /// </summary>
        public Twitch() : base()
        {
            this.ListOnlineStreams = new List<SVideo>();
            this.ListLastVideos = new List<SVideo>();
            this.ListChannelsFollowed = new List<SChannel>();
            this.Name = "Twitch";
            string[] scopes = new string[4] {"user_read", "user_follows_edit", "chat_login", "channel_read"};
            this.Auth = new Authentification(scopes, URL_AUTH, CLIENT_ID);

        }

        /// <summary>
        /// Create a video stream
        /// </summary>
        /// <param name="stream">stream twitch</param>
        /// <returns>SVideo</returns>
        private SVideo CreateVideoStream
            (Stream stream)
        {
            SVideo video = new SVideo();
            video.videoName = stream.channel.status;
            video.channelName = stream.channel.name;
            video.description = this.CreateChannelDescription(stream.channel.name);
            video.createdAt = stream.created_at;
            video.id = stream._id.ToString();
            video.nbViews = stream.viewers;
            video.preview = stream.preview.medium;
            video.playerLink = URL_SITE + stream.channel.name + "/popout";
            video.link = URL_SITE + stream.channel.name;
            video.live = true;
            video.url_irc = "irc.twitch.tv";
            video.siteName = this.Name;
            video.channelIsFollowed = this.CheckChannelIsFollowed(stream.channel.name);
            return video;
        }

        /// <summary>
        /// Create a video
        /// </summary>
        /// <param name="video">video twitch</param>
        /// <returns>SVideo</returns>
        private SVideo CreateVideo(Video video)
        {
            SVideo sVideo = new SVideo();
            sVideo.videoName = video.title;
            sVideo.channelName = video.channel.name;
            sVideo.description = video.description;
            sVideo.createdAt = video.recroded_at;
            sVideo.id = video._id;
            sVideo.nbViews = video.view;
            sVideo.preview = video.preview;
            sVideo.playerLink = URL_SITE + video.channel.name + "/popout?videoId=" + video._id;
            sVideo.link = URL_SITE + video.channel.name + "/" + video._id;
            sVideo.live = false;
            sVideo.url_irc = "irc.twitch.tv";
            sVideo.siteName = this.Name;
            sVideo.channelIsFollowed = this.CheckChannelIsFollowed(video.channel.name);
            return sVideo;
        }

        /// <summary>
        /// Create a channel
        /// </summary>
        /// <param name="channelFollowed">channel twitch</param>
        /// <returns>channel</returns>
        private SChannel CreateChannel(WebMediaManager.Structures.STwitch.Channel channelFollowed)
        {
            SChannel channel = new SChannel();
            channel.channelName = channelFollowed.name;
            channel.createdAt = channelFollowed.created_at;
            channel.description = this.CreateChannelDescription(channelFollowed.name);
            channel.headerLink = channelFollowed.profile_banner;
            channel.id = channelFollowed.ToString();
            channel.logoLink = channelFollowed.logo;
            channel.nbFollowers = channelFollowed.followers;
            channel.nbTotalViews = channelFollowed.views;
            channel.siteName = this.Name;

            return channel;
        }

        /// <summary>
        /// Create a channel description
        /// </summary>
        /// <param name="channelName">channel name</param>
        /// <returns>description</returns>
        private string CreateChannelDescription(string channelName)
        {
            Panel[] panels = Curl.Deserialize<Panel[]>(Curl.SendRequest("https://api.twitch.tv/api/channels/"+channelName+"/panels", GET_METHOD, ACCEPT_HTTP_HEADER));
            StringBuilder result = new StringBuilder();

            for (int i = 0; i < panels.Count(); i++)
            {
                result.Append("<h1>"+panels[i].data.title+"</h1>");
                result.Append("<a href='" + panels[i].data.link + "'><img src='" + panels[i].data.image + "'/></a>");
                result.Append("<p>"+panels[i].data.description+"</p>");
            }

            return result.ToString();
        }

        /// <summary>
        /// Get video by id
        /// </summary>
        /// <param name="id">id video</param>
        /// <returns>video</returns>
        public override SVideo GetVideoById(string id)
        {
            Video video = Curl.Deserialize<Video>(Curl.SendRequest(URL_API+"videos/"+id, "GET", ACCEPT_HTTP_HEADER));
            
            return this.CreateVideo(video);
        }

        /// <summary>
        /// Get video ID by a video link
        /// </summary>
        /// <param name="link"></param>
        /// <returns></returns>
        public override string GetIdVideoByLink(string link)
        {
            string result = null;
            if (link != "")
            {
                string checkSite = link.Substring(0, URL_SITE.Length);
                string[] split = null;
                if (String.Compare(checkSite, URL_SITE) == 0)
                {
                    split = link.Split('/');
                    if (split.Count() == 6)
                        result = split[4] + split[5];
                    else
                        result = split[4];
                }
            }else
            {
                result = null;
            }
            return result;
        }

        /// <summary>
        /// Update the list of online streams
        /// </summary>
        public override void UpdateLastVideo()
        {
            this.ListLastVideos = this.GetLastVideos();
        }

        /// <summary>
        /// Update the online streams
        /// </summary>
        public override void UpdateOnlineStream()
        {
            this.ListOnlineStreams = this.GetOnlineStreams();
        }

        /// <summary>
        /// Update the channels followed
        /// </summary>
        public override void UpdateChannelsFollowed()
        {
            this.ListChannelsFollowed = this.GetChannelFollowed();
        }

        /// <summary>
        /// Get the last video
        /// </summary>
        /// <returns></returns>
        public override List<SVideo> GetLastVideos()
        {
            List<SVideo> result = new List<SVideo>();
            Videos videos = Curl.Deserialize<Videos>(Curl.SendRequest(URL_API + "videos/followed", "GET", this.Auth.Access_token, ACCEPT_HTTP_HEADER));
            for (int i = 0; i < videos.videos.Count(); i++)
            {
                result.Add(this.CreateVideo(videos.videos[i]));
            }
            return result;
        }

        /// <summary>
        /// Get the online stream
        /// </summary>
        /// <returns></returns>
        public override List<StreamingSite.SVideo> GetOnlineStreams()
        {
            Streams streamsOnlineFollowed = Curl.Deserialize<Streams>(Curl.SendRequest(URL_API + "streams/followed", GET_METHOD, this.Auth.Access_token, ACCEPT_HTTP_HEADER));

            List<SVideo> listVideos = new List<SVideo>();

            for (int i = 0; i < streamsOnlineFollowed.streams.Count(); i++)
            {
                SVideo video = this.CreateVideoStream(streamsOnlineFollowed.streams[i]);
                listVideos.Add(video);
            }

            return listVideos;
        }

        /// <summary>
        /// Get the followed channel
        /// </summary>
        /// <returns></returns>
        public override List<SChannel> GetChannelFollowed()
        {
            Follows channelFollowed = Curl.Deserialize<Follows>(Curl.SendRequest(URL_API + "users/" + this.UserName + "/follows/channels", GET_METHOD, this.Auth.Access_token, ACCEPT_HTTP_HEADER));

            List<SChannel> listChannels = new List<SChannel>();

            for (int i = 0; i < channelFollowed.follows.Count(); i++)
            {
                SChannel channel = this.CreateChannel(channelFollowed.follows[i].channel);
                listChannels.Add(channel);
            }

            return listChannels;
        }

        /// <summary>
        /// Get the result of search video
        /// </summary>
        /// <param name="request">request</param>
        /// <returns>video list</returns>
        public override List<SVideo> SearchVideos(string request, int limit)
        {
            SearchStreams searchStreams = Curl.Deserialize<SearchStreams>(Curl.SendRequest(URL_API + "search/streams?q=" + request + "&limit="+limit.ToString(), GET_METHOD, ACCEPT_HTTP_HEADER));

            List<SVideo> listVideos = new List<SVideo>();

            for (int i = 0; i < searchStreams.streams.Count(); i++)
            {
                SVideo video = this.CreateVideoStream(searchStreams.streams[i]);
                listVideos.Add(video);
            }

            return listVideos;
        }

        /// <summary>
        /// Get the result of search channel
        /// </summary>
        /// <param name="request">request</param>
        /// <returns>channel list</returns>
        public override List<SChannel> SearchChannels(string request)
        {
            SearchChannels searchChannels = Curl.Deserialize<SearchChannels>(Curl.SendRequest(URL_API + "search/channels?q=" + request, GET_METHOD, ACCEPT_HTTP_HEADER));

            List<SChannel> listChannels = new List<SChannel>();

            for (int i = 0; i < searchChannels.channels.Count(); i++)
            {
                SChannel channel = this.CreateChannel(searchChannels.channels[i]);
                listChannels.Add(channel);
            }
            return listChannels;
        }

        /// <summary>
        /// To follow a channel
        /// </summary>
        /// <param name="channelName">channel name</param>
        public override void FollowChannel(string channelName)
        {
            Curl.Deserialize<Follow>(Curl.SendRequest(URL_API + "users/" + this.UserName + "/follows/channels/" + channelName, "PUT", this.Auth.Access_token, ACCEPT_HTTP_HEADER));
            this.UpdateLastVideo();
            this.UpdateChannelsFollowed();
        }

        /// <summary>
        /// To unfollow a channel
        /// </summary>
        /// <param name="channelName">channel name</param>
        public override void UnFollowChannel(string channelName)
        {
            Curl.Deserialize<Follow>(Curl.SendRequest(URL_API + "users/" + this.UserName + "/follows/channels/" + channelName, "DELETE", this.Auth.Access_token, ACCEPT_HTTP_HEADER));
            this.UpdateLastVideo();
            this.UpdateChannelsFollowed();
        }

        /// <summary>
        /// Get the popular streams
        /// </summary>
        /// <returns></returns>
        public override List<SVideo> GetPopularVideos()
        {
            Streams streams = Curl.Deserialize<Streams>(Curl.SendRequest(URL_API + "streams/", GET_METHOD, ACCEPT_HTTP_HEADER));

            List<SVideo> listVideos = new List<SVideo>();

            for (int i = 0; i < streams.streams.Count(); i++)
            {
                SVideo video = this.CreateVideoStream(streams.streams[i]);
                listVideos.Add(video);
            }

            return listVideos;
        }

        /// <summary>
        /// Connnect to twitch
        /// </summary>
        /// <param name="access_token">access token</param>
        public override void Connect(string access_token)
        {
            this.Auth.Access_token = access_token;
            this.Auth.IsConnected = true;
            this.UpdateOnlineStream();
            this.UpdateLastVideo();
            Users user = Curl.Deserialize<Users>(Curl.SendRequest("https://api.twitch.tv/kraken/user", "GET", this.Auth.Access_token, ACCEPT_HTTP_HEADER));
            this.UserName = user.name;
        }

        /// <summary>
        /// Disconnect
        /// </summary>
        public override void Disconnect()
        {
            //Curl.Deserialize<AuthResponse>(Curl.SendRequest("https://api.twitch.tv/kraken/oauth2/authorization/"+this.Auth.Client_id, "DELETE", this.Auth.Access_token, ACCEPT_HTTP_HEADER));
            this.Auth.IsConnected = false;
            this.Auth.Access_token = "";
            
        }
    }
}
