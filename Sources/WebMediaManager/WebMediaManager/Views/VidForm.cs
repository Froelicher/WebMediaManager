using ChatSharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WebMediaManager.Controllers;
using WebMediaManager.Models;

namespace WebMediaManager.Views
{
    public partial class VidForm : Form
    {
        private SitesController _siteController;
        private StreamingSite.SVideo _video;
        private IrcClient _client;
        private IrcUser _user;
        private IrcChat _chat;
        private ContainersController _containerController;

        internal ContainersController ContainerController
        {
            get { return _containerController; }
            set { _containerController = value; }
        }

        internal IrcChat Chat
        {
            get { return _chat; }
            set { _chat = value; }
        }

        public IrcUser User
        {
            get { return _user; }
            set { _user = value; }
        }

        public IrcClient Client
        {
            get { return _client; }
            set { _client = value; }
        }

        public StreamingSite.SVideo Video
        {
            get { return _video; }
            set { _video = value; }
        }

        internal SitesController SiteController
        {
            get { return _siteController; }
            set { _siteController = value; }
        }

        public VidForm(StreamingSite.SVideo video, Model model)
        {
            InitializeComponent();
            this.SiteController = new SitesController(this, model);
            this.ContainerController = new ContainersController(this, model);
            this.Video = video;
            this.wbbPlayer.Url = new Uri(video.playerLink);
            this.wbbDescription.DocumentText = video.description;
            this.lblTitle.Text = video.videoName;
            this.lblViews.Text = video.nbViews.ToString();

            this.Chat = new IrcChat(this.tbxChat, this.SiteController.GetUserName(this.Video.siteName), this.SiteController.GetUserName(this.Video.siteName), this.SiteController.GetAccessToken(this.Video.siteName), this.Video);
            this.Chat.ConnectIrc();
            this.SetBtnSubscribe();
        }

        public void SetBtnSubscribe()
        {
            if (this.Video.channelIsFollowed)
            {
                this.btnSubscribes.Text = "Désabonnement";
                this.btnSubscribes.BackColor = Color.Red;
                this.btnSubscribes.Click += (s, e) => this.btnUnFollow(s, e);
            }
            else
            {
                this.btnSubscribes.Text = "S'abonner";
                this.btnSubscribes.BackColor = Color.Green;
                this.btnSubscribes.Click += (s, e) => this.btnFollow(s, e);
            }
        }

        private void btnSendMsg_Click(object sender, EventArgs e)
        {
            if (tbxSendMsg.Text != "")
            {
                this.Chat.SendMessage(tbxSendMsg.Text);
            }
        }

        private void VidForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            //this.Chat.Quit();
        }

        private void VidForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Chat.Quit();
        }

        private void btnFollow(object sender, EventArgs e)
        {
            this.SiteController.Follow(this.Video.channelName, this.Video.siteName);
        }

        private void btnUnFollow(object sender, EventArgs e)
        {
            this.SiteController.UnFollow(this.Video.channelName, this.Video.siteName);
        }

        private void SetContainersList()
        {

        }

        private void btnSubscribes_Click(object sender, EventArgs e)
        {

        }
    }
}
