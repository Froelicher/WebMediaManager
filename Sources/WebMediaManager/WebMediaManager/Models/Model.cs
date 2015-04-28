using System;
using System.Collections.Generic;
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
        public List<WebMediaManager.Models.StreamingSite.SVideo> GetAllLastVideos()
        {
            List<WebMediaManager.Models.StreamingSite.SVideo> listLastVideos = new List<WebMediaManager.Models.StreamingSite.SVideo>();
            for (int i = 0; i < this.ListSite.Count; i++)
            {
                for (int j = 0; j < this.ListSite[i].ListLastVideos.Count; j++)
                {
                    listLastVideos.Add(this.ListSite[i].ListLastVideos[j]);
                }
            }

            return listLastVideos;
        }

        public WebMediaManager.Models.StreamingSite.SVideo[] SortVideos(List<WebMediaManager.Models.StreamingSite.SVideo> listVideos)
        {
            WebMediaManager.Models.StreamingSite.SVideo[] listResult = new WebMediaManager.Models.StreamingSite.SVideo[listVideos.Count];
            listResult[0] = listVideos[0];

            for (int i = 1; i < listVideos.Count; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    if (DateTime.Compare(listResult[j].createdAt, listVideos[i].createdAt) < 0)
                    {
                        listResult[i] = listVideos[j];
                    }
                }

            }

            return null;
        }

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
            //TO DO : Ouvrir le fichier et remplir les categories


        }

        /// <summary>
        /// Open file playlists
        /// </summary>
        private void OpenFilePlaylists()
        {
            //TO DO : Ouvrir le fichier et remplis les playlists
        }

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
