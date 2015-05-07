using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebMediaManager.Models.Sites;

namespace WebMediaManager.Models
{
    class Model
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
                for (int j = 0; j < this.ListSite[i].ListLastVideos.Count; j++)
                {
                    listLastVideos.Add(this.ListSite[i].ListLastVideos[j]);
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
                for (int j = 0; j < this.ListSite[i].ListOnlineStreams.Count; j++)
                {
                    if (this.ListSite[i].ListOnlineStreams[j].live)
                        listLastStreams.Add(this.ListSite[i].ListOnlineStreams[j]);
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
            Youtube youtube = new Youtube();
            Dailymotion dailymotion = new Dailymotion();
            Vimeo vimeo = new Vimeo();
            Twitch twitch = new Twitch();

            this.ListSite.Add(youtube);
            this.ListSite.Add(dailymotion);
            this.ListSite.Add(vimeo);
            this.ListSite.Add(twitch);
        }



        /// <summary>
        /// Open file categorie
        /// </summary>
        private void OpenFileCategories()
        {
            string pathFile = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "WebMediaManager/Category.ini");
            string[] videosLink = null;
            List<StreamingSite.SVideo> videos = new List<StreamingSite.SVideo>();
            string nameCategory = "";
            int pFrom = 0;
            int pTo = 0;

            if (File.Exists(pathFile))
            {
                string[] allVideos = File.ReadAllLines(pathFile);

                for (int i = 0; i < allVideos.Length; i++)
                {
                    if(allVideos[i][0] == '[')
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
                                    videos[x] = this.ListSite[j].GetVideoById(this.ListSite[j].GetIdVideoByLink(videosLink[x]));
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
        private void OpenFilePlaylists()
        {
            string pathFile = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "WebMediaManager/Playlist.ini");
            string[] videosLink = null;
            List<StreamingSite.SVideo> videos = new List<StreamingSite.SVideo>();
            string namePlaylist = "";
            int pFrom = 0;
            int pTo = 0;

            if (File.Exists(pathFile))
            {
                string[] allVideos = File.ReadAllLines(pathFile);

                for (int i = 0; i < allVideos.Length; i++)
                {
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
                                    videos[x] = this.ListSite[j].GetVideoById(this.ListSite[j].GetIdVideoByLink(videosLink[x]));
                            }
                        }

                        playlist.FillListVideos(videos);
                        this.ListContainer.Add(playlist);
                    }
                }

            }

        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<List<StreamingSite.SVideo>> CheckNotifications()
        {
            List<List<StreamingSite.SVideo>> listDiff = new List<List<StreamingSite.SVideo>>();

            //for all site
            for (int i = 0; i < this.ListSite.Count; i++)
            {
                List<StreamingSite.SVideo> diff = null;

                if(this.ListSite[i].ListLastVideos != null)
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
                            if(this.ListSite[i].ListLastVideos[x].id == oldLastVideo[y].id)
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
    }
}
