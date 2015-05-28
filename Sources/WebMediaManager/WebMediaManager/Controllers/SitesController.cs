using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        public SitesController(PersonalInterface personalView, Model model)
        {
            this.Model = model;
            this.PView = personalView;
        }

        public SitesController(VidForm view, Model model)
        {
            this.Model = model;
            this.Vview = view;
        }

        public List<StreamingSite.SVideo> GetLastVideos()
        {
            return this.Model.GetLastVideos();
        }

        public List<StreamingSite.SVideo> GetOnlineStreams()
        {
            return this.Model.GetOnlineStreams();
        }

        public string[] GetNameSites()
        {
            return this.Model.GetNameSites();
        }

        public string GetUserName(string nameSite)
        {
            return this.Model.GetUserName(nameSite);
        }

        public string GetAccessToken(string nameSite)
        {
            return this.Model.GetAccessToken(nameSite);
        }

        public void Follow(string channelName, string siteName)
        {
            for (int i = 0; i < this.Model.ListSite.Count; i++)
            {
                if (siteName == this.Model.ListSite[i].Name)
                    this.Model.ListSite[i].FollowChannel(channelName);
            }
        }
        
        public void UnFollow(string channelName, string siteName)
        {
            for (int i = 0; i < this.Model.ListSite.Count; i++)
            {
                if (siteName == this.Model.ListSite[i].Name)
                    this.Model.ListSite[i]. UnFollowChannel(channelName);
            }
        }

        public List<StreamingSite.SVideo> SearchVideos(string request, int limit)
        {
            return this.Model.SearchVideos(request, limit);
        }

        //public List<StreamingSite.SChannel> Get

        public List<List<StreamingSite.SVideo>> GetVideosBySite(List<StreamingSite.SVideo> videos)
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

        public List<List<StreamingSite.SChannel>> GetChannelsFollowedBySite(List<StreamingSite.SChannel> channels)
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

        public List<StreamingSite.SChannel> GetChannelFollowed()
        {
            return this.Model.GetChannelsFollowed();
        }

        public List<StreamingSite.SVideo> GetOnlineStreamBySite(string siteName)
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

        public List<StreamingSite.SVideo> GetLastVideosBySite(string siteName)
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
    }
}
