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
        private const string URL_SITE = "https://twitch.tv/";
        private const string ACCEPT_HTTP_HEADER = "application/vnd.twitchtv.v3+json";
        #endregion

        /// <summary>
        /// 
        /// </summary>
        /// <param name="stream"></param>
        /// <returns></returns>
        public override SVideo CreateVideo(Stream stream)
        {
            SVideo video = new SVideo();
            video.videoName = stream.channel.status;
            video.channelName = stream.channel.display_name;
            video.description = "";
            video.createdAt = stream.created_at;
            video.id = stream._id.ToString();
            video.nbViews = stream.viewers;
            video.preview = stream.preview.medium;
            video.playerLink = "https://www.twitch.tv/" + stream.channel.name + "/popout";
            video.link = URL_SITE + stream.channel.name;
            return video;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="channelFollowed"></param>
        /// <returns></returns>
        public override SChannel CreateChannel(WebMediaManager.Structures.STwitch.Channel channelFollowed)
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
            
            //TODO : SOUPE POUR FAIRE LA DESCRIPTION

            return "";
        }

        /// <summary>
        /// Update the list of online streams
        /// </summary>
        public override void UpdateLastVideo()
        {
            this.ListLastVideos = this.GetNewVideos();
        }

        /// <summary>
        /// Get the online stream
        /// </summary>
        /// <returns></returns>
        public override List<SVideo> GetNewVideos()
        {

            Streams streamsOnlineFollowed = Curl.Deserialize<Streams>(Curl.SendRequest(URL_API + "streams/followed", GET_METHOD, this.AccessToken, ACCEPT_HTTP_HEADER));

            List<SVideo> listVideos = new List<SVideo>();

            for (int i = 0; i < streamsOnlineFollowed.streams.Count(); i++)
            {
                SVideo video = this.CreateVideo(streamsOnlineFollowed.streams[i]);
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
                SVideo video = this.CreateVideo(searchStreams.streams[i]);
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
            Curl.Deserialize<Follow>(Curl.SendRequest(URL_API + "users/" + this.UserName + "/follows/channels/" + channelName, "PUT", this.AccessToken, ACCEPT_HTTP_HEADER));
            this.UpdateLastVideo();
        }

        /// <summary>
        /// To unfollow a channel
        /// </summary>
        /// <param name="channelName">channel name</param>
        public override void UnFollowChannel(string channelName)
        {
            Curl.Deserialize<Follow>(Curl.SendRequest(URL_API + "users/" + this.UserName + "/follows/channels/" + channelName, "DELETE", this.AccessToken, ACCEPT_HTTP_HEADER));
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
                SVideo video = this.CreateVideo(streams.streams[i]);
                listVideos.Add(video);
            }

            return listVideos;
        }
    }
}
