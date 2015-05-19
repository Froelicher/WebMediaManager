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
        public static Panel CreatePreview(Panel mainPanel, StreamingSite.SVideo video, int id_video_line, int counter_for_line, Model model)
        {
            Panel gPanel = new Panel();
            gPanel.Size = new Size(200, 200);
            gPanel.Location = new Point((205 * id_video_line) + 10, gPanel.Size.Height*counter_for_line);

            gPanel.BackColor = Color.White;
            gPanel.Click += (sender, e) => OnClickVideo(sender, e, video, model);

            //Create the picture box
            PictureBox imgPreview = new PictureBox();
            imgPreview.Size = new Size(200, 122);
            imgPreview.SizeMode = PictureBoxSizeMode.StretchImage;
            imgPreview.Load(video.preview);
            imgPreview.Location = new Point(0, 0);
            imgPreview.Click += (sender, e) =>  OnClickVideo(sender, e, video, model);

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
            btnSite.Location = new Point(8, 30 * (index_btn));
            btnSite.FlatStyle = FlatStyle.Flat;
            btnSite.Text = nameSite;
            pnlSite.Controls.Add(btnSite);
            if(index_btn != 0)
                pnlSite.Size = new Size(pnlSite.Width, pnlSite.Size.Height + 20);
            return btnSite;
        }

        private static void OnClickVideo(object sender, EventArgs e, StreamingSite.SVideo video, Model model)
        {
            CreateFormVideo(video, model);
        }

        public static void CreateFormVideo(StreamingSite.SVideo video, Model model)
        {
            VidForm videoForm = new VidForm(video, model);
            videoForm.Show();
        }

    }
}
