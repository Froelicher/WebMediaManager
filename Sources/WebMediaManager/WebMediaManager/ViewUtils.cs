/*
 * Author : JP. Froelicher
 * Description : Viewutils
 * Date : 16/04/2015
 */
using System;
using System.Drawing;
using System.Windows.Forms;
using WebMediaManager.Models;

namespace WebMediaManager.Views
{
    static class ViewUtils
    {
        /// <summary>
        /// Create preview videos
        /// </summary>
        /// <param name="mainPanel">panel</param>
        /// <param name="video">video</param>
        /// <param name="id_video_line">video in line</param>
        /// <param name="counter_for_line">nb of line</param>
        /// <param name="model">model</param>
        /// <returns>Panel preview</returns>
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

        /// <summary>
        /// On click preview video
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <param name="video"></param>
        /// <param name="model"></param>
        private static void OnClickVideo(object sender, EventArgs e, StreamingSite.SVideo video, Model model)
        {
            CreateFormVideo(video, model);
        }

        /// <summary>
        /// Create form video
        /// </summary>
        /// <param name="video"></param>
        /// <param name="model"></param>
        public static void CreateFormVideo(StreamingSite.SVideo video, Model model)
        {
            VidForm videoForm = new VidForm(video, model);
            videoForm.Show();
        }

    }
}
