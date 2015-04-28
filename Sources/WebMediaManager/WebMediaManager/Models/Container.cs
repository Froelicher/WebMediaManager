using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public Container(string name)
        {
            this.Name = name;
        }

        public void SetPathCategory()
        {
            this.FilePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "WebMediaManager/Category.ini");
        }

        public void SetPathPlaylist()
        {
            this.FilePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "WebMediaManager/Playlist.ini");
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
