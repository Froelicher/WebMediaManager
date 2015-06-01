/*
 * Author : JP. Froelicher
 * Description : Controller of containers
 * Date : 29/05/2015
 */ 
using System;
using System.Collections.Generic;
using WebMediaManager.Models;
using WebMediaManager.Views;

namespace WebMediaManager.Controllers
{
    class ContainersController
    {
        private PersonalInterface _view;
        private VidForm _viewVideo;

        public VidForm ViewVideo
        {
            get { return _viewVideo; }
            set { _viewVideo = value; }
        }

        private Model _model;

        internal Model Model
        {
            get { return _model; }
            set { _model = value; }
        }

        public PersonalInterface View
        {
            get { return _view; }
            set { _view = value; }
        }

        /// <summary>
        /// Constructor with the video view
        /// </summary>
        /// <param name="view">video view</param>
        /// <param name="model">model</param>
        public ContainersController(VidForm view, Model model)
        {
            this.ViewVideo = view;
            this.Model = model;
        }

        /// <summary>
        /// Constructor with the personal view
        /// </summary>
        /// <param name="view">personal view</param>
        /// <param name="model">model</param>
        public ContainersController(PersonalInterface view, Model model)
        {
            this.View = view;
            this.Model = model;
        }

        /// <summary>
        /// Get names of categories
        /// </summary>
        /// <returns>list of names</returns>
        public List<string> GetNamesCategory()
        {
            List<string> result = new List<string>();
            Playlist test = new Playlist("test");

            for (int i = 0; i < this.Model.ListContainer.Count; i++)
            {
                if (!Object.ReferenceEquals(test.GetType(), this.Model.ListContainer[i].GetType()))
                {
                    result.Add(this.Model.ListContainer[i].Name);
                }
            }
            return result;
        }

        /// <summary>
        /// Get names of playlists
        /// </summary>
        /// <returns>List of names</returns>
        public List<string> GetNamesPlaylist()
        {
            List<string> result = new List<string>();
            Playlist test = new Playlist("test"); ;

            for (int i = 0; i < this.Model.ListContainer.Count; i++)
            {
                if (Object.ReferenceEquals(test.GetType(), this.Model.ListContainer[i].GetType()))
                {
                    result.Add(this.Model.ListContainer[i].Name);
                }
            }
            return result;
        }

        /// <summary>
        /// Create the containers file
        /// </summary>
        public void CreateFileContainers()
        {
            this.Model.CreateFileContainers();
        }

        /// <summary>
        /// Open the containers files
        /// </summary>
        public void OpenFileContainers()
        {
            this.Model.OpenFileCategories();
            this.Model.OpenFilePlaylists();
        }

        /// <summary>
        /// Get videos of a container
        /// </summary>
        /// <param name="name">name of container</param>
        /// <returns>List of videos</returns>
        public List<StreamingSite.SVideo> GetVideosOfContainer(string name)
        {
            List<StreamingSite.SVideo> result = null;

            for (int i = 0; i < this.Model.ListContainer.Count; i++)
            {
                if (this.Model.ListContainer[i].Name == name)
                {
                    result = this.Model.ListContainer[i].ListVideos;
                }
            }

            return result;
        }

        /// <summary>
        /// Add video in container
        /// </summary>
        /// <param name="video">video</param>
        /// <param name="containerName">name of container</param>
        public void AddVideo(StreamingSite.SVideo video, string containerName)
        {
            for (int i = 0; i < this.Model.ListContainer.Count; i++)
            {
                if (containerName == this.Model.ListContainer[i].Name)
                {
                    this.Model.ListContainer[i].AddVideo(video);
                }
            }
        }
        
        /// <summary>
        /// Add a new container
        /// </summary>
        /// <param name="name">name of container</param>
        /// <param name="playlist">if the container is a playlist</param>
        public void AddContainer(string name, bool playlist)
        {
            this.Model.AddContainer(name, playlist);
        }
    }
}
