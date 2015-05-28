using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebMediaManager.Structures.STwitch;

namespace WebMediaManager.Models
{
    public class StreamingSite
    {

        #region STRUCTURES
        public struct SVideo
        {
            public string id;
            public string videoName;
            public string channelName;
            public int nbViews;
            public string description;
            public string preview;
            public string playerLink;
            public DateTime createdAt;
            public string link;
            public bool live;
            public string siteName;
            public string url_irc;
            public bool channelIsFollowed;
        }

        public struct SChannel
        {
            public string id;
            public string channelName;
            public string description;
            public string logoLink;
            public string headerLink;
            public int nbTotalViews;
            public int nbFollowers;
            public DateTime createdAt;
            public string siteName;
        }
        #endregion

        #region PROPERTIES

        private List<SVideo> _listLastVideos;
        private List<SVideo> _listOnlineStreams;
        private string _userName;
        private Authentification _auth;
        private string _name;
        private List<SChannel> _listChannelsFollowed;

        public List<SChannel> ListChannelsFollowed
        {
            get { return _listChannelsFollowed; }
            set { _listChannelsFollowed = value; }
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        internal Authentification Auth
        {
            get { return _auth; }
            set { _auth = value; }
        }

        public string UserName
        {
            get { return _userName; }
            set { _userName = value; }
        }

        internal List<SVideo> ListLastVideos
        {
            get { return _listLastVideos; }
            set { _listLastVideos = value; }
        }

        public List<SVideo> ListOnlineStreams
        {
            get { return _listOnlineStreams; }
            set { _listOnlineStreams = value; }
        }

        #endregion

        public StreamingSite()
        {
            this.ListLastVideos = new List<SVideo>();
        }

        public virtual SVideo GetVideoById(string id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Get video ID by a video link
        /// </summary>
        /// <param name="link"></param>
        /// <returns></returns>
        public virtual string GetIdVideoByLink(string link)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public virtual void UpdateLastVideo()
        {
            throw new NotImplementedException();
        }

        public virtual void UpdateOnlineStream()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Get the last video released
        /// </summary>
        /// <returns>list of last video</returns>
        public virtual List<SVideo> GetLastVideos()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Get the online streams
        /// </summary>
        /// <returns></returns>
        public virtual List<SVideo> GetOnlineStreams()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Update the channels followed
        /// </summary>
        public virtual void UpdateChannelsFollowed()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Get list of channel followed
        /// </summary>
        /// <returns></returns>
        public virtual List<SChannel> GetChannelFollowed()
        {
            throw new NotImplementedException();
        }

        public virtual List<SVideo> GetVideosByChannel(string channelName)
        {
            throw new NotImplementedException();
        }

        public virtual List<SVideo> GetStreamsByChannel(string channelName)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Search videos
        /// </summary>
        /// <param name="request"></param>
        /// <returns>list of videos</returns>
        public virtual List<SVideo> SearchVideos(string request, int limit)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Search channels
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public virtual List<SChannel> SearchChannels(string request)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Follow channel
        /// </summary>
        /// <param name="channelName"></param>
        public virtual void FollowChannel(string channelName)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Unfollow channel
        /// </summary>
        /// <param name="channelName"></param>
        public virtual void UnFollowChannel(string channelName)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Connect to account
        /// </summary>
        /// <returns></returns>
        public virtual bool Connect()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Disconnect the account
        /// </summary>
        /// <returns></returns>
        public virtual bool Disconnect()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Get the popular videos
        /// </summary>
        /// <returns></returns>
        public virtual List<SVideo> GetPopularVideos()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Get the playlists
        /// </summary>
        /// <returns></returns>
        public virtual List<SVideo> GetPlaylists()
        {
            throw new NotImplementedException();
        }    
        
        /// <summary>
        /// Check if the channel is followed
        /// </summary>
        /// <param name="channelName">channel name</param>
        /// <returns>bool</returns>
        public virtual bool CheckChannelIsFollowed(string channelName)
        {
            for (int i = 0; i < this.ListChannelsFollowed.Count; i++)
            {
                if (ListChannelsFollowed[i].channelName == channelName)
                    return true;
            }
            return false;   
        }
    }
}
