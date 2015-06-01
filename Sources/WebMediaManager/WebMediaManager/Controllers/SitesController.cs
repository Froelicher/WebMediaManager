/*
 * Author : JP. Froelicher
 * Description : Controller of sites
 * Date : 30/05/2015
 */
using System.Collections.Generic;
using WebMediaManager.Models;
using WebMediaManager.Views;

namespace WebMediaManager.Controllers
{
    class SitesController
    {
        private PersonalInterface _pview;
        private Model _model;
        private VidForm _vview;

        public VidForm Vview
        {
            get { return _vview; }
            set { _vview = value; }
        }

        internal Model Model
        {
            get { return _model; }
            set { _model = value; }
        }

        public PersonalInterface PView
        {
            get { return _pview; }
            set { _pview = value; }
        }

        /// <summary>
        /// Constructor with the personal view
        /// </summary>
        /// <param name="personalView">personal view</param>
        /// <param name="model">model</param>
        public SitesController(PersonalInterface personalView, Model model)
        {
            this.Model = model;
            this.PView = personalView;
        }

        /// <summary>
        /// Constructor with the video view
        /// </summary>
        /// <param name="view">video view</param>
        /// <param name="model">model</param>
        public SitesController(VidForm view, Model model)
        {
            this.Model = model;
            this.Vview = view;
        }

        /// <summary>
        /// Get the last videos
        /// </summary>
        /// <returns>list of lastest videos</returns>
        public List<StreamingSite.SVideo> GetLastVideos()
        {
            return this.Model.GetLastVideos();
        }

        /// <summary>
        /// Get the online streams
        /// </summary>
        /// <returns>list of online streams</returns>
        public List<StreamingSite.SVideo> GetOnlineStreams()
        {
            return this.Model.GetOnlineStreams();
        }

        /// <summary>
        /// Get the name of all sites
        /// </summary>
        /// <returns>array of names</returns>
        public string[] GetNameSites()
        {
            return this.Model.GetNameSites();
        }

        /// <summary>
        /// Get the username from a website
        /// </summary>
        /// <param name="nameSite">namesite username</param>
        /// <returns>username</returns>
        public string GetUserName(string nameSite)
        {
            return this.Model.GetUserName(nameSite);
        }

        /// <summary>
        /// Get the accesstoken from a website
        /// </summary>
        /// <param name="nameSite">name site</param>
        /// <returns>access token</returns>
        public string GetAccessToken(string nameSite)
        {
            return this.Model.GetAccessToken(nameSite);
        }

        /// <summary>
        /// Follow a channel
        /// </summary>
        /// <param name="channelName">channel name</param>
        /// <param name="siteName">site of the channel</param>
        public void Follow(string channelName, string siteName)
        {
            for (int i = 0; i < this.Model.ListSite.Count; i++)
            {
                if (siteName == this.Model.ListSite[i].Name)
                    this.Model.ListSite[i].FollowChannel(channelName);
            }
        }
        
        /// <summary>
        /// Unfollow a channel
        /// </summary>
        /// <param name="channelName">channel name</param>
        /// <param name="siteName">site of the channel</param>
        public void UnFollow(string channelName, string siteName)
        {
            for (int i = 0; i < this.Model.ListSite.Count; i++)
            {
                if (siteName == this.Model.ListSite[i].Name)
                    this.Model.ListSite[i]. UnFollowChannel(channelName);
            }
        }

        /// <summary>
        /// Search videos
        /// </summary>
        /// <param name="request">the request</param>
        /// <param name="limit">nb of result</param>
        /// <returns>List of videos</returns>
        public List<StreamingSite.SVideo> SearchVideos(string request, int limit)
        {
            return this.Model.SearchVideos(request, limit);
        }

        /// <summary>
        /// Get videos from site
        /// </summary>
        /// <param name="videos">List videos</param>
        /// <returns>List of list video</returns>
        public List<List<StreamingSite.SVideo>> GetVideosFromSite(List<StreamingSite.SVideo> videos)
        {
            List<List<StreamingSite.SVideo>> result = null;

            if (videos.Count > 0)
            {
                result = new List<List<StreamingSite.SVideo>>();
                result.Add(new List<StreamingSite.SVideo>());
                result[0].Add(videos[0]);

                for (int i = 0; i < videos.Count; i++)
                {
                    for (int j = 0; j < result.Count; j++)
                    {
                        if (videos[i].siteName == result[j][i].siteName)
                        {
                            result[j].Add(videos[i]);
                        }
                        else
                        {
                            result[j] = new List<StreamingSite.SVideo>();
                            result[j].Add(videos[i]);
                        }
                    }
                }

                result[0].RemoveAt(0);
                return result;
            }

            return result;
        }

        /// <summary>
        /// Get channel followed from site
        /// </summary>
        /// <param name="channels">channel</param>
        /// <returns>List of list channels</returns>
        public List<List<StreamingSite.SChannel>> GetChannelsFollowedFromSite(List<StreamingSite.SChannel> channels)
        {
            List<List<StreamingSite.SChannel>> result = null;

            if (channels.Count > 0)
            {
                result = new List<List<StreamingSite.SChannel>>();
                result.Add(new List<StreamingSite.SChannel>());
                result[0].Add(channels[0]);

                for (int i = 0; i < channels.Count; i++)
                {
                    for (int j = 0; j < result.Count; j++)
                    {
                        if (channels[i].siteName == result[j][i].siteName)
                        {
                            result[j].Add(channels[i]);
                        }
                        else
                        {
                            result[j] = new List<StreamingSite.SChannel>();
                            result[j].Add(channels[i]);
                        }
                    }
                }

                result[0].RemoveAt(0);
                return result;
            }

            return result;
        }

        /// <summary>
        /// Get the channel followed
        /// </summary>
        /// <returns></returns>
        public List<StreamingSite.SChannel> GetChannelFollowed()
        {
            return this.Model.GetChannelsFollowed();
        }

        /// <summary>
        /// Get online stream from site
        /// </summary>
        /// <param name="siteName">name site</param>
        /// <returns></returns>
        public List<StreamingSite.SVideo> GetOnlineStreamFromSite(string siteName)
        {
            List<StreamingSite.SVideo> allOnlineStreams = this.GetOnlineStreams();
            List<StreamingSite.SVideo> result = new List<StreamingSite.SVideo>();

            if (allOnlineStreams.Count > 0)
            {
                for (int i = 0; i < allOnlineStreams.Count; i++)
                {
                    if(allOnlineStreams[i].siteName == siteName)
                    {
                        result.Add(allOnlineStreams[i]);
                    }
                }

                return result;
            }

            return null;
        }

        /// <summary>
        /// Get last videos from site
        /// </summary>
        /// <param name="siteName">site name</param>
        /// <returns>list of last videos</returns>
        public List<StreamingSite.SVideo> GetLastVideosFromSite(string siteName)
        {
            List<StreamingSite.SVideo> allLastVideos = this.GetLastVideos();
            List<StreamingSite.SVideo> result = new List<StreamingSite.SVideo>();

            if(allLastVideos.Count > 0)
            {
                for (int i = 0; i < allLastVideos.Count; i++)
                {
                    if(allLastVideos[i].siteName == siteName)
                    {
                        result.Add(allLastVideos[i]);
                    }
                }

                return result;
            }

            return null;
        }

        /// <summary>
        /// Get link of connexion page
        /// </summary>
        /// <param name="siteName">site name</param>
        /// <returns>link</returns>
        public string GetLinkConnexionPage(string siteName)
        {
            for (int i = 0; i < this.Model.ListSite.Count; i++)
            {
                if(this.Model.ListSite[i].Name == siteName)
                {
                    return this.Model.ListSite[i].Auth.CreateUrlConnexion();
                }
            }

            return null;
        }

        /// <summary>
        /// If the site is connected
        /// </summary>
        /// <param name="siteName">site name</param>
        /// <returns>true or false</returns>
        public bool SiteIsConnected(string siteName)
        {
            for (int i = 0; i < this.Model.ListSite.Count; i++)
            {
                if(this.Model.ListSite[i].Name == siteName)
                {
                    return this.Model.ListSite[i].Auth.IsConnected;
                }
            }

            return false;
        }

        /// <summary>
        /// Get access token in string url
        /// </summary>
        /// <param name="url">url</param>
        /// <returns>access token</returns>
        public string GetAccessTokenInUrl(string url)
        {
            return this.Model.GetAccessTokenInUrl(url);
        }

        /// <summary>
        /// Connect from site
        /// </summary>
        /// <param name="accessToken">access token</param>
        /// <param name="nameSite">name site</param>
        public void Connect(string accessToken, string nameSite)
        {
            for (int i = 0; i < this.Model.ListSite.Count; i++)
            {
                if (nameSite == this.Model.ListSite[i].Name)
                {
                    this.Model.ListSite[i].Connect(accessToken);
                }
            }
        }

        /// <summary>
        /// Disconnect from site
        /// </summary>
        /// <param name="nameSite">site name</param>
        public void Disconnect(string nameSite)
        {
            for (int i = 0; i < this.Model.ListSite.Count; i++)
            {
                if (nameSite == this.Model.ListSite[i].Name)
                {
                    this.Model.ListSite[i].Disconnect();
                }
            }
        }

        /// <summary>
        /// Count the connected site
        /// </summary>
        /// <returns></returns>
        public int CountConnectedSite()
        {
            int result = 0;
            for (int i = 0; i < this.Model.ListSite.Count; i++)
            {
                if (this.Model.ListSite[i].Auth.IsConnected)
                    result++;
            }

            return result;
        }

        /// <summary>
        /// Check the last videos
        /// </summary>
        /// <returns>new videos</returns>
        public List<List<StreamingSite.SVideo>> CheckNotificationsLastVideos()
        {
            return this.Model.CheckNotificationsLastVideos();
        }

        /// <summary>
        /// Check the online streams
        /// </summary>
        /// <returns>new online streams</returns>
        public List<List<StreamingSite.SVideo>> CheckNotificationsOnlineStreams()
        {
            return this.Model.CheckNotificationsOnlineStreams();
        }
    }
}
