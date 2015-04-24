using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebMediaManager.Models
{
    class Playlist : Container
    {
        private int _indexCurrentVideo;

        public int IndexCurrentVideo
        {
            get { return _indexCurrentVideo; }
            set { _indexCurrentVideo = value; }
        }

        /// <summary>
        /// Next video
        /// </summary>
        public void Next()
        {
            if(this.IndexCurrentVideo != this.ListVideos.Count-1)
                this.IndexCurrentVideo++;
        }

        /// <summary>
        /// Reset video
        /// </summary>
        public void Reset()
        {
            this.IndexCurrentVideo = 0;
        }

        /// <summary>
        /// Previous video
        /// </summary>
        public void Previous()
        {
            if (this.IndexCurrentVideo != 0)
                this.IndexCurrentVideo--;
        }
    }
}
