/*
 * Author : JP. Froelicher
 * Description : Container class
 * Date : 29/05/2015
 */ 
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace WebMediaManager.Models
{
    public class Container
    {
        #region CONST

        #endregion

        #region PROPERTIES
        private string _name;
        private List<StreamingSite.SVideo> _listVideos;
        private string _filePath;

        public string FilePath
        {
            get { return _filePath; }
            set { _filePath = value; }
        }

        internal List<StreamingSite.SVideo> ListVideos
        {
            get { return _listVideos; }
            set { _listVideos = value; }
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        #endregion

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="name">constructor name</param>
        public Container(string name)
        {
            this.Name = name;
        }

        /// <summary>
        /// Set the path of category
        /// </summary>
        public void SetPathCategory()
        {
            this.FilePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "WebMediaManager/Category.ini");
        }

        /// <summary>
        /// Set the path of playlist
        /// </summary>
        public void SetPathPlaylist()
        {
            this.FilePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "WebMediaManager/Playlist.ini");
        }
        
        /// <summary>
        /// Fill the list videos
        /// </summary>
        /// <param name="videos">List videos</param>
        public void FillListVideos(List<StreamingSite.SVideo> videos)
        {
            this.ListVideos = videos;
        }

        /// <summary>
        /// Add container in file
        /// </summary>
        public bool AddContainer()
        {
            if (File.Exists(this.FilePath))
            {
                if (!CheckExistContainer())
                {
                    using (System.IO.StreamWriter file = new System.IO.StreamWriter(this.FilePath, true))
                    {
                        file.WriteLine("[" + this.Name + "]");
                        file.WriteLine("link=");
                    }
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Check if the container exist
        /// </summary>
        /// <returns></returns>
        private bool CheckExistContainer()
        {
            if (File.Exists(this.FilePath))
            {
                string[] allVideos = File.ReadAllLines(this.FilePath);

                for (int i = 0; i < allVideos.Length; i++)
                {
                    if (allVideos[i] == "[" + this.Name + "]")
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        /// <summary>
        /// Get video of container
        /// </summary>
        /// <returns>List of videos</returns>
        public string[] GetVideos()
        {
            string[] videos = null;

            if (File.Exists(this.FilePath))
            {
                string[] allVideos = File.ReadAllLines(this.FilePath);
                string stringVideos = "";

                for (int i = 0; i < allVideos.Length; i++)
                {
                    if (allVideos[i] == "[" + this.Name + "]")
                    {
                        stringVideos = allVideos[i + 1];
                        break;
                    }
                }

                stringVideos = stringVideos.Substring("link=".Length);

                videos = stringVideos.Split(';');
                if(videos[videos.Count()-1] == "")
                    videos = videos.Take(videos.Count() - 1).ToArray();

            }
            return videos;
        }

        /// <summary>
        /// Add a video in list and in ini file
        /// </summary>
        /// <param name="video">video</param>
        public void AddVideo(StreamingSite.SVideo video)
        {
            this.ListVideos.Add(video);

            if(File.Exists(this.FilePath))
            {
                string[] lines = File.ReadAllLines(this.FilePath);

                for (int i = 0; i < lines.Length; i++)
                {
                    if(lines[i] == "["+ this.Name +"]")
                    {
                        lines[i + 1] = lines[i + 1].Replace(lines[i + 1], lines[i + 1] + ";" + video.link);
                    }
                }
                File.WriteAllLines(this.FilePath, lines);
            }
        }

        /// <summary>
        /// Delete video in list and in ini file
        /// </summary>
        /// <param name="video">video</param>
        public void DeleteVideo(StreamingSite.SVideo video)
        {
            this.ListVideos.Remove(video);

            if(File.Exists(this.FilePath))
            {
                string[] lines = File.ReadAllLines(this.FilePath);

                for (int i = 0; i < lines.Length; i++)
                {
                    if(lines[i] == "["+ this.Name +"]")
                    {
                        lines[i + 1] = lines[i + 1].Replace(video.link+";", "");
                    }
                }
                File.WriteAllLines(this.FilePath, lines);
            }
        }
    }
}
