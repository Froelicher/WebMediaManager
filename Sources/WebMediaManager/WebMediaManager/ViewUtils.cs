using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WebMediaManager.Models;

namespace WebMediaManager.Views
{
    static class ViewUtils
    {
        public static Panel CreatePreview(Panel mainPanel, StreamingSite.SVideo video, int index_video)
        {
            Panel gPanel = new Panel();
            gPanel.Size = new Size(200, 220);
            gPanel.Location = new Point((205 * index_video)+10, 0);
            gPanel.BackColor = Color.White;

            //Create the picture box
            PictureBox imgPreview = new PictureBox();
            imgPreview.Size = new Size(200, 122);
            imgPreview.SizeMode = PictureBoxSizeMode.StretchImage;
            imgPreview.Load(video.preview);
            imgPreview.Location = new Point(0, 0);

            //Create the label title
            Label title = new Label();
            title.Location = new Point(0, 125);
            title.Text = video.videoName;
            title.Size = new Size(200, 20);
            title.Font = new Font("Segoe UI", 9f);
            title.AutoEllipsis = true;

            //Create label channel
            Label channel = new Label();
            channel.Location = new Point(0, 145);
            channel.Text = video.channelName;
            channel.Size = new Size(200, 20);

            //Create label views
            Label views = new Label();
            views.Location = new Point(0, 165);
            views.Text = video.nbViews.ToString();
            views.Size = new Size(200, 20);

            //Add component to panel
            gPanel.Controls.Add(imgPreview);
            gPanel.Controls.Add(title);
            gPanel.Controls.Add(channel);
            gPanel.Controls.Add(views);

            mainPanel.Controls.Add(gPanel);

            return mainPanel;
        }
    }
}
