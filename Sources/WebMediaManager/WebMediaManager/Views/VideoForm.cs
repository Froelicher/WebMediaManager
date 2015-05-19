using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WebMediaManager.Models;

namespace WebMediaManager.Views
{
    public partial class VideoForm : Form
    {
        public VideoForm(StreamingSite.SVideo video)
        {
            InitializeComponent();

            this.webBrowser1.Url = new Uri(video.playerLink);
            this.lblTitle.Text = video.videoName;
            this.lblView.Text = video.nbViews.ToString();
            this.webBrowser2.DocumentText = video.description;

        }

        private void VideoForm_Load(object sender, EventArgs e)
        {

        }
    }
}
