using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebMediaManager.Structures.SYoutube;

namespace WebMediaManager.Models.Sites
{
    class Youtube : StreamingSite
    {
        private const string URL_API = "https://www.googleapis.com/youtube/v3/";
        private const string URL_SITE = "https://www.youtube.com/";
        private const string ACCEPT_HTTP_HEADER = "application/json";

        public Youtube()
        {
            this.ListOnlineStreams = null;
            this.Name = "Youtube";
        }

        private SVideo CreateVideo(Video videos)
        {
            SVideo video = new SVideo();
            video.videoName = videos.snippet.title;
            video.channelName = videos.snippet.channelTitle;
            video.description = "";
            video.createdAt = videos.snippet.publisedAt;
            video.id = videos.id;
            video.nbViews = Convert.ToInt32(videos.statistics.viewCount);
            video.preview = videos.snippet.thumbnails.medium.url;
            video.playerLink = URL_SITE + "embed/" + videos.id +"?"+"autoplay=1";
            video.link = URL_SITE + "watch?v=" + videos.id;
            video.live = false;
            video.siteName = "Youtube";
            return video;
        }


        private SChannel CreateChannel(Channels channels)
        {
            SChannel channel = new SChannel();
            channel.channelName = channels.snippet.title;
            channel.createdAt = channels.snippet.publishedAt;
            channel.description = channels.snippet.description;
            channel.headerLink = channels.snippet.thumbnails.Default.url;
            channel.id = channels.id;
            channel.logoLink = channels.snippet.thumbnails.Default.url;
            channel.nbFollowers = (int)channels.statistics.subscriberCount;
            channel.nbTotalViews = (int)channels.statistics.viewCount;

            return channel;
        }

        public override SVideo GetVideoById(string id)
        {
            Videos videos = Curl.Deserialize<Videos>(Curl.SendRequest(URL_API + "videos?part=snippet,statistics&id="+id+"&key="+this.Auth.Client_secret , "GET", ACCEPT_HTTP_HEADER));

            return this.CreateVideo(videos.items[0]);
        }

        /// <summary>
        /// Get video ID by a video link
        /// </summary>
        /// <param name="link"></param>
        /// <returns></returns>
        public override string GetIdVideoByLink(string link)
        {
            string checkSite = link.Substring(0, URL_SITE.Length);
            StringBuilder result = null;

            if (String.Compare(checkSite, URL_SITE) == 0)
            {

                bool inId = false;
                result = new StringBuilder();

                for (int i = 0; i < link.Length; i++)
                {
                    if (inId)
                    {
                        if (link[i] != '&')
                        {
                            result.Append(link[i]);
                        }
                        else
                        {
                            break;
                        }
                    }
                    if (link[i] == '=')
                    {
                        inId = true;
                    }
                }
            }
            return result.ToString();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override void UpdateLastVideo()
        {
            throw new NotImplementedException();
        }

        public override void UpdateOnlineStream()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Get the last video released
        /// </summary>
        /// <returns>list of last video</returns>
        public override List<SVideo> GetLastVideos()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Get the online streams
        /// </summary>
        /// <returns></returns>
        public override List<SVideo> GetOnlineStreams()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Get list of channel followed
        /// </summary>
        /// <returns></returns>
        public override List<SChannel> GetChannelFollowed()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Search videos
        /// </summary>
        /// <param name="request"></param>
        /// <returns>list of videos</returns>
        public override List<SVideo> SearchVideos(string request, int limit)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Search channels
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public override List<SChannel> SearchChannels(string request)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Follow channel
        /// </summary>
        /// <param name="channelName"></param>
        public override void FollowChannel(string channelName)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Unfollow channel
        /// </summary>
        /// <param name="channelName"></param>
        public override void UnFollowChannel(string channelName)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Connect to account
        /// </summary>
        /// <returns></returns>
        public override bool Connect()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Disconnect the account
        /// </summary>
        /// <returns></returns>
        public override bool Disconnect()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Get the popular videos
        /// </summary>
        /// <returns></returns>
        public override List<SVideo> GetPopularVideos()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Get the playlists
        /// </summary>
        /// <returns></returns>
        public override List<SVideo> GetPlaylists()
        {
            throw new NotImplementedException();
        }  

    }
}
