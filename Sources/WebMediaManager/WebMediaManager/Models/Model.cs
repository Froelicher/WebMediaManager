﻿/*
 * Author : JP. Froelicher
 * Description : Model class
 * Date : 29/05/2015
 */ 
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using WebMediaManager.Models.Sites;

namespace WebMediaManager.Models
{
    public class Model
    {
        #region CONSTANTES



        #endregion
        #region PROPERTIES
        private List<StreamingSite> _listSite;
        private List<Container> _listContainer;

        internal List<Container> ListContainer
        {
            get { return _listContainer; }
            set { _listContainer = value; }
        }

        internal List<StreamingSite> ListSite
        {
            get { return _listSite; }
            set { _listSite = value; }
        }

        #endregion

        public Model()
        {
            this.InitSite();
            this.ListContainer = new List<Container>();
        }




        /// <summary>
        /// Get lasts videos of all site
        /// </summary>
        /// <returns>list of last video</returns>
        public List<StreamingSite.SVideo> GetLastVideos()
        {
            List<StreamingSite.SVideo> listLastVideos = new List<StreamingSite.SVideo>();
            for (int i = 0; i < this.ListSite.Count; i++)
            {
                if (this.ListSite[i].Auth.IsConnected)
                {
                    this.ListSite[i].UpdateLastVideo();
                    for (int j = 0; j < this.ListSite[i].ListLastVideos.Count; j++)
                    {
                        listLastVideos.Add(this.ListSite[i].ListLastVideos[j]);
                    }
                }
            }

            return listLastVideos;
        }

        /// <summary>
        /// Get the new streams
        /// </summary>
        /// <returns></returns>
        public List<StreamingSite.SVideo> GetOnlineStreams()
        {
            List<StreamingSite.SVideo> listLastStreams = new List<StreamingSite.SVideo>();
            for (int i = 0; i < this.ListSite.Count; i++)
            {
                if (this.ListSite[i].Auth.IsConnected)
                {
                    this.ListSite[i].UpdateOnlineStream();
                    if (this.ListSite[i].ListOnlineStreams != null)
                    {
                        for (int j = 0; j < this.ListSite[i].ListOnlineStreams.Count; j++)
                        {
                            if (this.ListSite[i].ListOnlineStreams[j].live)
                                listLastStreams.Add(this.ListSite[i].ListOnlineStreams[j]);
                        }
                    }
                }
            }

            return listLastStreams;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="listVideos"></param>
        /// <returns></returns>
        public List<StreamingSite.SVideo> SortVideos(List<StreamingSite.SVideo> listVideos)
        {
            StreamingSite.SVideo[] listResult = new StreamingSite.SVideo[listVideos.Count];

            listVideos.Sort((x, y) => DateTime.Compare(x.createdAt, y.createdAt));

            return listVideos;
        }

        /// <summary>
        /// 
        /// </summary>
        private void InitSite()
        {
            this.ListSite = new List<StreamingSite>();

            Youtube youtube = new Youtube();
            Dailymotion dailymotion = new Dailymotion();
            Vimeo vimeo = new Vimeo();
            Twitch twitch = new Twitch();
            this.ListSite.Add(twitch);
        }



        /// <summary>
        /// Open file categorie
        /// </summary>
        public void OpenFileCategories()
        {
            string pathFile = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "WebMediaManager/Category.ini");
            string[] videosLink = null;
            string nameCategory = "";
            int pFrom = 0;
            int pTo = 0;

            if (File.Exists(pathFile))
            {
                string[] allVideos = File.ReadAllLines(pathFile);

                for (int i = 0; i < allVideos.Length; i++)
                {
                    List<StreamingSite.SVideo> videos = new List<StreamingSite.SVideo>();
                    if (allVideos[i][0] == '[')
                    {
                        pFrom = allVideos[i].IndexOf('[') + "[".Length;
                        pTo = allVideos[i].LastIndexOf(']');

                        nameCategory = allVideos[i].Substring(pFrom, pTo - pFrom);

                        Container category = new Container(nameCategory);
                        category.SetPathCategory();
                        videosLink = category.GetVideos();

                        for (int j = 0; j < this.ListSite.Count; j++)
                        {
                            for (int x = 0; x < videosLink.Count(); x++)
                            {
                                if (this.ListSite[j].GetIdVideoByLink(videosLink[x]) != null)
                                    videos.Add(this.ListSite[j].GetVideoById(this.ListSite[j].GetIdVideoByLink(videosLink[x])));
                            }
                        }

                        category.FillListVideos(videos);
                        this.ListContainer.Add(category);
                    }
                }

            }
        }

        /// <summary>
        /// Open file playlists
        /// </summary>
        public void OpenFilePlaylists()
        {
            string pathFile = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "WebMediaManager/Playlist.ini");
            string[] videosLink = null;
            string namePlaylist = "";
            int pFrom = 0;
            int pTo = 0;

            if (File.Exists(pathFile))
            {
                string[] allVideos = File.ReadAllLines(pathFile);

                for (int i = 0; i < allVideos.Length; i++)
                {
                    List<StreamingSite.SVideo> videos = new List<StreamingSite.SVideo>();
                    if (allVideos[i][0] == '[')
                    {
                        pFrom = allVideos[i].IndexOf('[') + "[".Length;
                        pTo = allVideos[i].LastIndexOf(']');

                        namePlaylist = allVideos[i].Substring(pFrom, pTo - pFrom);

                        Playlist playlist = new Playlist(namePlaylist);
                        playlist.SetPathPlaylist();
                        videosLink = playlist.GetVideos();

                        for (int j = 0; j < this.ListSite.Count; j++)
                        {
                            for (int x = 0; x < videosLink.Count(); x++)
                            {
                                if (this.ListSite[j].GetIdVideoByLink(videosLink[x]) != null)
                                    videos.Add(this.ListSite[j].GetVideoById(this.ListSite[j].GetIdVideoByLink(videosLink[x])));
                            }
                        }

                        playlist.FillListVideos(videos);
                        this.ListContainer.Add(playlist);
                    }
                }

            }

        }

        /// <summary>
        /// Create files of containers
        /// </summary>
        public void CreateFileContainers()
        {
            string pathCategory = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "WebMediaManager/Category.ini");
            string pathPlaylist = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "WebMediaManager/Playlist.ini");

            if (!System.IO.Directory.Exists(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "WebMediaManager")))
            {
                Directory.CreateDirectory(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "WebMediaManager"));
            }

            if (!File.Exists(pathCategory))
            {
                File.Create(pathCategory);
            }

            if (!File.Exists(pathPlaylist))
            {
                File.Create(pathPlaylist);
            }
        }

        /// <summary>
        /// Add a container
        /// </summary>
        /// <param name="name">container name</param>
        /// <param name="t_playlist">if is a playlist</param>
        public void AddContainer(string name, bool t_playlist)
        {
            if (t_playlist)
            {
                Playlist playlist = new Playlist(name);
                playlist.SetPathPlaylist();
                if (playlist.AddContainer())
                    this.ListContainer.Add(playlist);
            }
            else
            {
                Container category = new Container(name);
                category.SetPathCategory();
                if (category.AddContainer())
                    this.ListContainer.Add(category);
            }

        }

        /// <summary>
        /// Check and get the new videos
        /// </summary>
        /// <returns></returns>
        public List<List<StreamingSite.SVideo>> CheckNotificationsLastVideos()
        {
            List<List<StreamingSite.SVideo>> listDiff = new List<List<StreamingSite.SVideo>>();

            //for all site
            for (int i = 0; i < this.ListSite.Count; i++)
            {
                List<StreamingSite.SVideo> diff = null;

                if (this.ListSite[i].ListLastVideos != null)
                {
                    //create a new list with the current last videos
                    List<StreamingSite.SVideo> oldLastVideo = new List<StreamingSite.SVideo>(this.ListSite[i].ListLastVideos);

                    //Update the current list of last video
                    this.ListSite[i].UpdateLastVideo();

                    //create a new list with the current last videos
                    diff = new List<StreamingSite.SVideo>(this.ListSite[i].ListLastVideos);

                    //Compare the two list
                    for (int x = 0; x < this.ListSite[i].ListLastVideos.Count; x++)
                    {
                        for (int y = 0; y < oldLastVideo.Count; y++)
                        {
                            if (this.ListSite[i].ListLastVideos[x].id == oldLastVideo[y].id)
                            {
                                //remove if the current video is on the old list video
                                diff.Remove(this.ListSite[i].ListLastVideos[x]);
                            }
                        }
                    }
                }
                else
                {
                    this.ListSite[i].UpdateLastVideo();
                }
                listDiff.Add(diff);
            }

            return listDiff;
        }

        /// <summary>
        /// Check and get new online streams
        /// </summary>
        /// <returns></returns>
        public List<List<StreamingSite.SVideo>> CheckNotificationsOnlineStreams()
        {
            List<List<StreamingSite.SVideo>> listDiff = new List<List<StreamingSite.SVideo>>();

            //for all site
            for (int i = 0; i < this.ListSite.Count; i++)
            {
                List<StreamingSite.SVideo> diff = null;

                if (this.ListSite[i].ListOnlineStreams != null)
                {
                    //create a new list with the current last videos
                    List<StreamingSite.SVideo> oldLastVideo = new List<StreamingSite.SVideo>(this.ListSite[i].ListOnlineStreams);

                    //Update the current list of last video
                    this.ListSite[i].UpdateOnlineStream();

                    //create a new list with the current last videos
                    diff = new List<StreamingSite.SVideo>(this.ListSite[i].ListOnlineStreams);

                    //Compare the two list
                    for (int x = 0; x < this.ListSite[i].ListOnlineStreams.Count; x++)
                    {
                        for (int y = 0; y < oldLastVideo.Count; y++)
                        {
                            if (this.ListSite[i].ListOnlineStreams[x].id == oldLastVideo[y].id)
                            {
                                //remove if the current video is on the old list video
                                diff.Remove(this.ListSite[i].ListOnlineStreams[x]);
                            }
                        }
                    }
                }
                else
                {
                    this.ListSite[i].UpdateOnlineStream();
                }
                listDiff.Add(diff);
            }

            return listDiff;
        }


        /// <summary>
        /// Get the name site
        /// </summary>
        /// <returns>array name</returns>
        public string[] GetNameSites()
        {
            string[] nameSites = new string[this.ListSite.Count];

            for (int i = 0; i < ListSite.Count; i++)
            {
                nameSites[i] = this.ListSite[i].Name;
            }

            return nameSites;
        }

        /// <summary>
        /// Get username from site
        /// </summary>
        /// <param name="nameSite">name site</param>
        /// <returns>username</returns>
        public string GetUserName(string nameSite)
        {
            for (int i = 0; i < this.ListSite.Count; i++)
            {
                if (this.ListSite[i].Name == nameSite)
                {
                    return this.ListSite[i].UserName;
                }
            }

            return null;
        }

        /// <summary>
        /// Get the accesstoken from a website
        /// </summary>
        /// <param name="nameSite">name site</param>
        /// <returns>access token</returns>
        public string GetAccessToken(string nameSite)
        {
            for (int i = 0; i < this.ListSite.Count; i++)
            {
                if (this.ListSite[i].Name == nameSite)
                {
                    return this.ListSite[i].Auth.Access_token;
                }
            }

            return null;
        }

        /// <summary>
        /// Search videos
        /// </summary>
        /// <param name="request">request</param>
        /// <param name="limit">limit of result</param>
        /// <returns></returns>
        public List<StreamingSite.SVideo> SearchVideos(string request, int limit)
        {
            List<StreamingSite.SVideo> result = new List<StreamingSite.SVideo>();
            for (int i = 0; i < this.ListSite.Count; i++)
            {
                List<StreamingSite.SVideo> listVideosSite = this.ListSite[i].SearchVideos(request, limit);

                for (int j = 0; j < listVideosSite.Count; j++)
                {
                    result.Add(listVideosSite[j]);
                }
            }

            return result;
        }

        /// <summary>
        /// Get channels followed
        /// </summary>
        /// <returns></returns>
        public List<StreamingSite.SChannel> GetChannelsFollowed()
        {
            List<StreamingSite.SChannel> listChannelsSite = null;
            for (int i = 0; i < this.ListSite.Count; i++)
            {
                if(this.ListSite[i].Auth.IsConnected)
                    listChannelsSite = this.ListSite[i].GetChannelFollowed();
            }

            return listChannelsSite;
        }

        /// <summary>
        /// Get the access token in Url
        /// </summary>
        /// <returns></returns>
        public string GetAccessTokenInUrl(string urlWithAccessToken)
        {
            bool inToken = false;
            StringBuilder result = new StringBuilder();

            for (int i = 0; i < urlWithAccessToken.Length; i++)
            {
                if (inToken)
                {
                    if (urlWithAccessToken[i] != '&')
                    {
                        result.Append(urlWithAccessToken[i]);
                    }
                    else
                    {
                        break;
                    }
                }

                if (urlWithAccessToken[i] == '=')
                {
                    inToken = true;
                }
            }
            if (result.ToString() != "authorize")
                return result.ToString();
            else
                return "";
        }
    }
}
