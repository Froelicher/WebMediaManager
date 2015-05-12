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

        public static Button CreateButtonSite(Panel pnlSite, string nameSite, int index_btn)
        {
            Button btnSite = new Button();
            btnSite.Size = new Size(pnlSite.Width-20, 25);
            btnSite.Location = new Point(0, (30 * index_btn));
            btnSite.FlatStyle = FlatStyle.Flat;
            btnSite.Text = nameSite;
            pnlSite.Controls.Add(btnSite);
            pnlSite.Size = new Size(pnlSite.Width, pnlSite.Size.Height + 30);
            return btnSite;
        }

        public static void CreateLinkCategory(Panel pnlContainers, string name, int index_cont)
        {
            Label lblCategory = new Label();
            lblCategory.AutoSize = true;
            lblCategory.Text = name;
            lblCategory.Location = new Point(0, (15 * index_cont)+20);
            pnlContainers.Size = new Size(pnlContainers.Size.Width, pnlContainers.Size.Height + 10);
            pnlContainers.Controls.Add(lblCategory);
        }

        public static void CreateLinkPlaylist(Panel pnlContainers, string name, int index_play)
        {
            Label lblPlaylist = new Label();
            lblPlaylist.AutoSize = true;
            lblPlaylist.Text = name;
            lblPlaylist.Location = new Point(0, pnlContainers.Size.Height + (1*index_play));
            pnlContainers.Size = new Size(pnlContainers.Size.Width, pnlContainers.Size.Height + lblPlaylist.Height);
            pnlContainers.Controls.Add(lblPlaylist);
        }

    }
}
