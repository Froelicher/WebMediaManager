using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebMediaManager.Structures.STwitch;

namespace WebMediaManager.Models.Sites
{
    public class Twitch : StreamingSite
    {
        #region CONSTS
        private const string GET_METHOD = "GET";
        private const string URL_API = "https://api.twitch.tv/kraken/";
        private const string URL_SITE = "http://www.twitch.tv/";
        private const string ACCEPT_HTTP_HEADER = "application/vnd.twitchtv.v3+json";
        #endregion


        /// <summary>
        /// Constructor
        /// </summary>
        public Twitch() : base()
        {
            this.ListOnlineStreams = new List<SVideo>();
            this.Name = "Twitch";
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="stream"></param>
        /// <returns></returns>
        private SVideo CreateVideoStream
            (Stream stream)
        {
            SVideo video = new SVideo();
            video.videoName = stream.channel.status;
            video.channelName = stream.channel.display_name;
            video.description = this.CreateChannelDescription(stream.channel.name);
            video.createdAt = stream.created_at;
            video.id = stream._id.ToString();
            video.nbViews = stream.viewers;
            video.preview = stream.preview.medium;
            video.playerLink = URL_SITE + stream.channel.name + "/popout";
            video.link = URL_SITE + stream.channel.name;
            video.live = true;
            video.siteName = "Twitch";
            return video;
        }

        private SVideo CreateVideo(Video video)
        {
            SVideo sVideo = new SVideo();
            sVideo.videoName = video.title;
            sVideo.channelName = video.channel.display_name;
            sVideo.description = video.description;
            sVideo.createdAt = video.recroded_at;
            sVideo.id = video._id;
            sVideo.nbViews = video.view;
            sVideo.preview = video.preview;
            sVideo.playerLink = URL_SITE + video.channel.name + "/popout?videoId=" + video._id;
            sVideo.link = URL_SITE + video.channel.name + "/" + video._id;
            sVideo.live = false;
            return sVideo;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="channelFollowed"></param>
        /// <returns></returns>
        private SChannel CreateChannel(WebMediaManager.Structures.STwitch.Channel channelFollowed)
        {
            SChannel channel = new SChannel();
            channel.channelName = channelFollowed.display_name;
            channel.createdAt = channelFollowed.created_at;
            channel.description = this.CreateChannelDescription(channelFollowed.name);
            channel.headerLink = channelFollowed.profile_banner;
            channel.id = channelFollowed.ToString();
            channel.logoLink = channelFollowed.logo;
            channel.nbFollowers = channelFollowed.followers;
            channel.nbTotalViews = channelFollowed.views;

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
            string checkSite = link.Substring(0, URL_SITE.Length);
            string[] split = null;
            string result = null;
            if (String.Compare(checkSite, URL_SITE) == 0)
            {
                split = link.Split('/');
                result = split[4] + split[5];
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
            Follows channelFollowed = Curl.Deserialize<Follows>(Curl.SendRequest(URL_API + "users/" + this.UserName + "/follows/channels", GET_METHOD, ACCEPT_HTTP_HEADER));

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
        public override List<SVideo> SearchVideos(string request)
        {
            SearchStreams searchStreams = Curl.Deserialize<SearchStreams>(Curl.SendRequest(URL_API + "search/streams?q=" + request, GET_METHOD, ACCEPT_HTTP_HEADER));

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
        }

        /// <summary>
        /// To unfollow a channel
        /// </summary>
        /// <param name="channelName">channel name</param>
        public override void UnFollowChannel(string channelName)
        {
            Curl.Deserialize<Follow>(Curl.SendRequest(URL_API + "users/" + this.UserName + "/follows/channels/" + channelName, "DELETE", this.Auth.Access_token, ACCEPT_HTTP_HEADER));
            this.UpdateLastVideo();
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
    }
}
