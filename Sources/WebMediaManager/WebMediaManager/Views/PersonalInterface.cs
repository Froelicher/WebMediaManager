using ChatSharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;
using WebMediaManager.Controllers;
using WebMediaManager.Models;
using WebMediaManager.Views;

namespace WebMediaManager
{
    public partial class PersonalInterface : Form
    {
        private SitesController _sitesController;
        private ContainersController _containersController;
        private Model _model;
        private System.Timers.Timer _timerCheck;

        public System.Timers.Timer TimerCheck
        {
            get { return _timerCheck; }
            set { _timerCheck = value; }
        }

        internal Model Model
        {
            get { return _model; }
            set { _model = value; }
        }

        internal ContainersController ContainersController
        {
            get { return _containersController; }
            set { _containersController = value; }
        }

        internal SitesController SitesController
        {
            get { return _sitesController; }
            set { _sitesController = value; }
        }

        public PersonalInterface()
        {
            InitializeComponent();
            this.Model = new Model();
            this.SitesController = new SitesController(this, this.Model);
            this.ContainersController = new ContainersController(this, this.Model);

            this.ContainersController.CreateFileContainers();
            this.ContainersController.OpenFileContainers();

            DisplayButtonsSite();
            DisplayLinkCategory();
            DisplayLinkPlaylist();
            CreateButtonHome();
            DisplayHomePanel();

            InitTimer();

            if (!this.pnlContent.Focused)
                this.pnlContent.Focus();

        }

        private void InitTimer()
        {
            this.TimerCheck = new System.Timers.Timer();
            this.TimerCheck.Enabled = true;
            this.TimerCheck.Elapsed += new System.Timers.ElapsedEventHandler(OnTickCheck);
            this.TimerCheck.Interval = 5000;
        }

        private void OnTickCheck(object sender, ElapsedEventArgs e)
        {
            if(this.SitesController.CountConnectedSite() > 0)
            {
                this.PopNotificationVideos();
                this.PopNotificationStreams();
            }
        }

        private void PopNotificationVideos()
        {
            List<List<StreamingSite.SVideo>> newVideos = this.SitesController.CheckNotificationsLastVideos();

            for (int i = 0; i < newVideos.Count; i++)
			{
			    this.Invoke((MethodInvoker)delegate
                {
                    if (newVideos[i].Count > 0)
                    {
                        this.Notif.TitleText = newVideos[i][0].videoName;
                        this.Notif.ContentText = newVideos[i][0].channelName + "\n" + newVideos[i][0].nbViews + "\n" + newVideos[i][0].siteName;
                        this.Notif.ContentPadding = new Padding(1);
                        this.Notif.TitlePadding = new Padding(1);

                        WebClient wc = new WebClient();
                        byte[] bytes = wc.DownloadData(newVideos[i][0].preview);
                        MemoryStream ms = new MemoryStream(bytes);
                        System.Drawing.Image img = System.Drawing.Image.FromStream(ms);

                        System.Drawing.Size sizeimg = new System.Drawing.Size(150, 82);

                        this.Notif.Image = img;
                        this.Notif.ImagePadding = new Padding(5);
                        this.Notif.ImageSize = sizeimg;
                        this.Notif.Click += (s, e) => { ViewUtils.CreateFormVideo(newVideos[i][0], this.Model); };
                        this.Notif.Popup();
                    }
                }
                );
			}
            
       }

        private void PopNotificationStreams()
        {
            List<List<StreamingSite.SVideo>> newVideos = this.SitesController.CheckNotificationsOnlineStreams();

            for (int i = 0; i < newVideos.Count; i++)
            {
                this.Invoke((MethodInvoker)delegate
                {
                    if (newVideos[i].Count > 0)
                    {
                        this.Notif.TitleText = newVideos[i][0].videoName;
                        this.Notif.ContentText = newVideos[i][0].channelName + "\n" + newVideos[i][0].nbViews + "\n" + newVideos[i][0].siteName;
                        this.Notif.ContentPadding = new Padding(1);
                        this.Notif.TitlePadding = new Padding(1);

                        WebClient wc = new WebClient();
                        byte[] bytes = wc.DownloadData(newVideos[i][0].preview);
                        MemoryStream ms = new MemoryStream(bytes);
                        System.Drawing.Image img = System.Drawing.Image.FromStream(ms);

                        System.Drawing.Size sizeimg = new System.Drawing.Size(150, 82);

                        this.Notif.Image = img;
                        this.Notif.ImagePadding = new Padding(5);
                        this.Notif.ImageSize = sizeimg;
                        this.Notif.Click += (s, e) => { ViewUtils.CreateFormVideo(newVideos[i][0], this.Model); };
                        this.Notif.Popup();
                    }
                }
                );
            }

        }

        public void DisplayOnlineStreams(Panel pnl)
        {
            List<StreamingSite.SVideo> onlineStreams = this.SitesController.GetOnlineStreams();
            int j = 0;
            int counter_for_line = 0;

            for (int i = 0; i < onlineStreams.Count; i++)
            {
                if (j % 4 == 0 && j != 0)
                {
                    j = 0;
                    counter_for_line++;
                    pnl.Size = new Size(pnl.Size.Width, pnl.Size.Height + 200);
                }
                ViewUtils.CreatePreview(pnl, onlineStreams[i], j, counter_for_line, this.Model);
                j++;
            }
        }

        public void DisplayOnlineStreamsBySite(Panel pnl, string siteName)
        {
            List<StreamingSite.SVideo> onlineStreams = this.SitesController.GetOnlineStreamBySite(siteName);

            if (onlineStreams != null)
            {

                int j = 0;
                int counter_for_line = 0;

                for (int i = 0; i < onlineStreams.Count; i++)
                {
                    if (j % 4 == 0 && j != 0)
                    {
                        j = 0;
                        counter_for_line++;
                        pnl.Size = new Size(pnl.Size.Width, pnl.Size.Height + 200);
                    }
                    ViewUtils.CreatePreview(pnl, onlineStreams[i], j, counter_for_line, this.Model);
                    j++;
                }
            }
        }

        private void DisplayButtonsSite()
        {
            string[] nameSites = this.SitesController.GetNameSites();

            for (int i = 0; i < nameSites.Length; i++)
			{
			    this.CreateButtonSite(nameSites[i], i);
                this.pnlLeftMid.Location = new Point(this.pnlLeftMid.Location.X, this.pnlLeftMid.Location.Y + 25);
			}
        }

        public Button CreateButtonSite(string nameSite, int index_btn)
        {
            Button btnSite = new Button();
            btnSite.Size = new Size(this.pnlLeftTop.Width - 20, 25);
            btnSite.Location = new Point(8, 30 * (index_btn));
            btnSite.FlatStyle = FlatStyle.Flat;
            btnSite.Text = nameSite;
            btnSite.Click += (sender, e) => OnClickButtonSite(sender, e, nameSite);
            this.pnlLeftTop.Controls.Add(btnSite);
            if (index_btn != 0)
                this.pnlLeftTop.Size = new Size(this.pnlLeftTop.Width, this.pnlLeftTop.Size.Height + 20);
            return btnSite;
        }

        private void DisplayLinkCategory()
        {
            this.pnlLeftBot.Controls.Clear();
            this.pnlLeftMid.Controls.Clear();
            this.pnlLeftMid.Size = new Size(194, 45);
            Label lblTitle = new Label();
            lblTitle.Font = new Font("Arial", 12, FontStyle.Bold);
            lblTitle.Location = new Point(0, 0);
            lblTitle.Text = "Categories";

            TextBox tbxCategory = new TextBox();
            tbxCategory.Location = new Point(10, 20);
            tbxCategory.Size = new Size(120, 20);
            tbxCategory.BorderStyle = BorderStyle.FixedSingle;

            Button btnAddCategory = new Button();
            btnAddCategory.Location = new Point(15 + tbxCategory.Size.Width, 20);
            btnAddCategory.Size = new Size(40, 22);
            btnAddCategory.FlatStyle = FlatStyle.Flat;
            btnAddCategory.Text = "Add";
            btnAddCategory.Click += (sender, e) => OnClickAddContainer(sender, e, tbxCategory.Text, false);

            this.pnlLeftMid.Location = new Point(this.pnlLeftMid.Location.X, this.pnlLeftTop.Size.Height + pnlLeftTop.Location.Y);
            this.pnlLeftMid.Controls.Add(btnAddCategory);
            this.pnlLeftMid.Controls.Add(tbxCategory);
            this.pnlLeftMid.Controls.Add(lblTitle);

            List<string> nameCategory = this.ContainersController.GetNamesCategory();

            for (int i = 0; i < nameCategory.Count; i++)
            {
                CreateLinkCategory(this.pnlLeftMid, nameCategory[i], i, this.pnlContent);
            }
        }

        private void DisplayLinkPlaylist()
        {
            Label lblTitle = new Label();
            lblTitle.Font = new Font("Arial", 12, FontStyle.Bold);
            lblTitle.Location = new Point(0, this.pnlLeftMid.Height + 2);
            lblTitle.Text = "Playlist";

            TextBox tbxPlaylist = new TextBox();
            tbxPlaylist.Location = new Point(10, lblTitle.Location.Y + lblTitle.Size.Height);
            tbxPlaylist.Size = new Size(120, 20);
            tbxPlaylist.BorderStyle = BorderStyle.FixedSingle;

            Button btnAddPlaylist = new Button();
            btnAddPlaylist.Location = new Point(15 + tbxPlaylist.Size.Width, lblTitle.Location.Y + lblTitle.Size.Height);
            btnAddPlaylist.Size = new Size(40, 22);
            btnAddPlaylist.FlatStyle = FlatStyle.Flat;
            btnAddPlaylist.Text = "Add";
            btnAddPlaylist.Click += (sender, e) => OnClickAddContainer(sender, e, tbxPlaylist.Text, true);

            this.pnlLeftMid.Size = new Size(this.pnlLeftMid.Size.Width, this.pnlLeftMid.Size.Height + 45);
            this.pnlLeftMid.Controls.Add(tbxPlaylist);
            this.pnlLeftMid.Controls.Add(btnAddPlaylist);
            this.pnlLeftMid.Controls.Add(lblTitle);

            List<string> namePlaylist = this.ContainersController.GetNamesPlaylist();

            for (int i = 0; i < namePlaylist.Count; i++)
            {
                CreateLinkPlaylist(this.pnlLeftMid, namePlaylist[i], i, this.pnlContent);
            }

            this.pnlLeftBot.Location = new Point(this.pnlLeftBot.Location.X, this.pnlLeftMid.Size.Height + this.pnlLeftMid.Location.Y);
        }

        private void DisplayLastVideos(Panel pnl)
        {
            List<StreamingSite.SVideo> lastVideos = this.SitesController.GetLastVideos();
            int j = 0;
            int counter_for_line = 0;
            for (int i = 0; i < lastVideos.Count; i++)
            {
                if (j % 4 == 0 && j != 0)
                {
                    j = 0;
                    counter_for_line++;
                    pnl.Size = new Size(pnl.Size.Width, pnl.Size.Height + 200);
                }
                ViewUtils.CreatePreview(pnl, lastVideos[i], j, counter_for_line, this.Model);
                j++;
            }
        }

        private void DisplayLastVideosBySite(Panel pnl, string siteName)
        {
            List<StreamingSite.SVideo> lastVideos = this.SitesController.GetLastVideosBySite(siteName);
            int j = 0;
            int counter_for_line = 0;
            for (int i = 0; i < lastVideos.Count; i++)
            {
                if (j % 4 == 0 && j != 0)
                {
                    j = 0;
                    counter_for_line++;
                    pnl.Size = new Size(pnl.Size.Width, pnl.Size.Height + 200);
                }
                ViewUtils.CreatePreview(pnl, lastVideos[i], j, counter_for_line, this.Model);
                j++;
            }
        }

        private void DisplayResultSearch()
        {
            if (this.tbxSearch.Text != "")
            {
                Panel newPanel = new Panel();
                this.pnlContent.Controls.Clear();
                newPanel.Size = new Size(850, 200);
                this.pnlContent.Controls.Add(newPanel);
                List<StreamingSite.SVideo> resultSearch = this.SitesController.SearchVideos(this.tbxSearch.Text, 8);

                //LABEL TITLE
                Label lblRequest = new Label();
                lblRequest.Text = this.tbxSearch.Text;
                lblRequest.AutoSize = true;
                lblRequest.Location = new Point(10, 10);
                lblRequest.Font = new Font("Arial", 22, FontStyle.Bold);

                newPanel.Location = new Point(10, lblRequest.Height + lblRequest.Location.Y + 50);

                this.pnlContent.Controls.Add(lblRequest);
                List<List<StreamingSite.SVideo>> videosSort = this.SitesController.GetVideosBySite(resultSearch);

                if (videosSort != null)
                {
                    for (int i = 0; i < videosSort.Count; i++)
                    {
                        Label lblTitleSite = new Label();
                        lblTitleSite.Text = videosSort[i][0].siteName;
                        lblTitleSite.Location = new Point(10, (newPanel.Size.Height - (newPanel.Size.Height - lblRequest.Size.Height))+10);
                        lblTitleSite.Font = new Font("Arial", 18, FontStyle.Bold);
                        this.pnlContent.Controls.Add(lblTitleSite);

                        int counter_for_line = 0;
                        int x = 0;
                        for (int j = 0; j < videosSort[i].Count; j++)
                        {
                            if (j % 4 == 0 && j != 0)
                            {
                                x = 0;
                                counter_for_line++;
                                newPanel.Size = new Size(newPanel.Size.Width, newPanel.Size.Height + 120);
                            }

                            ViewUtils.CreatePreview(newPanel, videosSort[i][j], x, counter_for_line, this.Model);
                            x++;
                        }
                    }
                }
            }
        }


        private void DisplaySubscribes(string nameSite)
        {
            int j = 0;
            this.pnlLeftMid.Location = new Point(this.pnlLeftTop.Location.X + 5, this.pnlLeftTop.Size.Height + this.pnlLeftTop.Location.Y);
            this.pnlLeftBot.Visible = true;
            this.pnlLeftBot.Controls.Clear();
            this.pnlLeftBot.Size = new Size(185, 45);
            Label lblTitle = new Label();
            lblTitle.Font = new Font("Arial", 12, FontStyle.Bold);
            lblTitle.Location = new Point(0, 0);
            lblTitle.Text = "Abonnements";
            lblTitle.AutoSize = true;

            List<StreamingSite.SChannel> channelsFollowed = this.SitesController.GetChannelFollowed();

            this.pnlLeftBot.Controls.Add(lblTitle);
            this.pnlLeftBot.Location = new Point(this.pnlLeftBot.Location.X + 5, this.pnlLeftMid.Size.Height + pnlLeftMid.Location.Y + 10);

            if (channelsFollowed != null)
            {
                for (int i = 0; i < channelsFollowed.Count; i++)
                {
                    if (channelsFollowed[i].siteName == nameSite)
                    {
                            Label lblChannel = new Label();
                            lblChannel.Font = new Font("Arial", 9);
                            lblChannel.Text = channelsFollowed[i].channelName;
                            lblChannel.Location = new Point(10, lblTitle.Size.Height + (lblChannel.Size.Height*j));
                            lblChannel.MouseEnter += new EventHandler(MouseEnterLabel);
                            lblChannel.MouseLeave += new EventHandler(MouseLeaveLabel);
                            lblChannel.Click += (sender, e) => OnClickLabelContainer(sender, e);

                            this.pnlLeftBot.Controls.Add(lblChannel);
                            this.pnlLeftBot.Size = new Size(this.pnlLeftBot.Size.Width, this.pnlLeftBot.Size.Height + lblChannel.Size.Height);
                            j++;
                    }
                }
            }
        }

        private void DisplayChannel(string siteName)
        {
            this.pnlContent.Controls.Clear();
            Panel pnlOnlineStreams = new Panel();
        }

        private void DisplaySitePanel(string siteName)
        {
            //TODO : Créer deux panels : Last videos et online stream
            this.pnlContent.Controls.Clear();

            Panel pnlOnlineStreams = new Panel();
            Panel pnlLastVideos = new Panel();

            Label lblOnline = new Label();
            Label lblLast = new Label();

            //STREAMS ONLINE
            lblOnline.Text = "Online streams";
            lblOnline.AutoSize = true;
            lblOnline.Location = new Point(10, 10);
            lblOnline.Font = new Font("Arial", 18, FontStyle.Bold);

            pnlOnlineStreams.Location = new Point(10, lblOnline.Location.Y + lblOnline.Height + 10);
            pnlOnlineStreams.Size = new Size(850, 200);

            this.pnlContent.Controls.Add(lblOnline);
            this.pnlContent.Controls.Add(pnlOnlineStreams);

            DisplayOnlineStreamsBySite(pnlOnlineStreams, siteName);

            //LAST VIDEO RELEASED
            lblLast.Text = "Last videos";
            lblLast.AutoSize = true;
            lblLast.Location = new Point(10, pnlOnlineStreams.Size.Height + pnlOnlineStreams.Location.Y);
            lblLast.Font = new Font("Arial", 18, FontStyle.Bold);

            pnlLastVideos.Location = new Point(10, lblLast.Location.Y + lblLast.Size.Height + 10);
            pnlLastVideos.Size = new Size(850, 200);

            this.pnlContent.Controls.Add(lblLast);
            this.pnlContent.Controls.Add(pnlLastVideos);

            DisplayLastVideosBySite(pnlLastVideos, siteName);

        }


        private void DisplayHomePanel()
        {
            //TODO : Créer deux panels : Last videos et online stream
            this.pnlContent.Controls.Clear();
            Panel pnlOnlineStreams = new Panel();
            Panel pnlLastVideos = new Panel();

            Label lblOnline = new Label();
            Label lblLast = new Label();

            //STREAMS ONLINE
            lblOnline.Text = "Online streams";      
            lblOnline.AutoSize = true;
            lblOnline.Location = new Point(10, 10);
            lblOnline.Font = new Font("Arial", 18, FontStyle.Bold);

            pnlOnlineStreams.Location = new Point(10, lblOnline.Location.Y + lblOnline.Height+10);
            pnlOnlineStreams.Size = new Size(850, 200);

            this.pnlContent.Controls.Add(lblOnline);
            this.pnlContent.Controls.Add(pnlOnlineStreams);

            DisplayOnlineStreams(pnlOnlineStreams);

            //LAST VIDEO RELEASED
            lblLast.Text = "Last videos";
            lblLast.AutoSize = true;
            lblLast.Location = new Point(10, pnlOnlineStreams.Size.Height + pnlOnlineStreams.Location.Y);
            lblLast.Font = new Font("Arial", 18, FontStyle.Bold);

            pnlLastVideos.Location = new Point(10, lblLast.Location.Y + lblLast.Size.Height + 10);
            pnlLastVideos.Size = new Size(850, 200);

            this.pnlContent.Controls.Add(lblLast);
            this.pnlContent.Controls.Add(pnlLastVideos);

            DisplayLastVideos(pnlLastVideos);
        }

        public void CreateButtonHome()
        {
            Button btnHome = new Button();
            btnHome.Size = new Size(pnlLeftTop.Width - 20, 25);
            btnHome.Location = new Point(8, 5);
            btnHome.FlatStyle = FlatStyle.Flat;
            btnHome.Text = "Personnal interface";
            btnHome.Click += new EventHandler(OnClickButtonHome);
            pnlLeft.Controls.Add(btnHome);
        }

        public void CreateLinkCategory(Panel pnlContainers, string name, int index_cont, Panel pnlContent)
        {
            Label lblCategory = new Label();
            lblCategory.Font = new Font("Arial", 9);
            lblCategory.AutoSize = true;
            lblCategory.Text = name;
            lblCategory.Location = new Point(10, (15 * index_cont) + 50);
            lblCategory.MouseEnter += new EventHandler(MouseEnterLabel);
            lblCategory.MouseLeave += new EventHandler(MouseLeaveLabel);
            lblCategory.Click += (sender, e) => OnClickLabelContainer(sender, e);
            pnlContainers.Size = new Size(pnlContainers.Size.Width, pnlContainers.Size.Height + 16);
            pnlContainers.Controls.Add(lblCategory);
        }

        public void CreateLinkPlaylist(Panel pnlContainers, string name, int index_play, Panel pnlContent)
        {
            Label lblPlaylist = new Label();
            lblPlaylist.Font = new Font("Arial", 9);
            lblPlaylist.AutoSize = true;
            lblPlaylist.Text = name;
            lblPlaylist.Location = new Point(10, pnlContainers.Size.Height);
            lblPlaylist.MouseEnter += new EventHandler(MouseEnterLabel);
            lblPlaylist.MouseLeave += new EventHandler(MouseLeaveLabel);
            lblPlaylist.Click += (sender, e) => OnClickLabelContainer(sender, e);
            pnlContainers.Size = new Size(pnlContainers.Size.Width, pnlContainers.Size.Height + 15);
            pnlContainers.Controls.Add(lblPlaylist);
        }

        private void OnClickDisconnect(object sender, EventArgs e, string nameSite)
        {
            this.wbrConnexion.Navigated -= (s, ev) => this.OnChangeUrl(s, ev, nameSite);
            this.SitesController.Disconnect(nameSite);
            this.ClearCookies();
            this.wbrConnexion.AllowNavigation = false;
        }

        private void MouseEnterLabel(object sender, EventArgs e)
        {
            Label lbl = sender as Label;
            lbl.ForeColor = Color.Red;
        }

        private void MouseLeaveLabel(object sender, EventArgs e)
        {
            Label lbl = sender as Label;
            lbl.ForeColor = Color.Black;
        }

        private void OnClickLabelContainer(object sender, EventArgs e)
        {
            Label lbl = sender as Label;
            CreateFullPanelVideos(lbl.Text);
        }

        private void OnClickChannelFollowed(object sender, EventArgs e)
        {
            Label lbl = sender as Label;
            this.DisplayChannel(lbl.Text);
        }

        private void OnClickButtonHome(object sender, EventArgs e)
        {
            this.pnlLeftBot.Visible = false;
            DisplayLinkCategory();
            DisplayLinkPlaylist();
            DisplayHomePanel();
        }

        private void OnClickButtonSite(object sender, EventArgs e, string nameSite)
        {
            this.pnlLeftBot.Visible = true;

            if(this.SitesController.SiteIsConnected(nameSite))
            {
                this.DisplayOptionAccount(nameSite);
                this.DisplaySubscribes(nameSite);
                this.DisplaySitePanel(nameSite);
            }
            else
            {
                this.wbrConnexion.Navigated += (s, ev) => this.OnChangeUrl(s, ev, nameSite);
                this.DisplayConnexionPage(nameSite);
            }
            
        }

        private void OnClickAddContainer(object sender, EventArgs e, string name, bool playlist)
        {
            if (name != "")
            {
                this.ContainersController.AddContainer(name, playlist);
                this.DisplayLinkCategory();
                this.DisplayLinkPlaylist();
            }
        }

        public void CreateFullPanelVideos(string name)
        {
            List<StreamingSite.SVideo> listVideos = this.ContainersController.GetVideosOfContainer(name);
            Panel newPanel = new Panel();
            this.pnlContent.Controls.Clear();


            if (listVideos != null)
            {
                newPanel.Size = new Size(this.pnlContent.Size.Width - 10, this.pnlContent.Height - 50);
                newPanel.Location = new Point(10, 50);
                pnlContent.Controls.Add(newPanel);

                Label lblTitle = new Label();
                lblTitle.Location = new Point(0, 15);
                lblTitle.Font = new Font("Arial", 16, FontStyle.Bold);
                lblTitle.Text = name;
                lblTitle.AutoSize = true;

                pnlContent.Controls.Add(lblTitle);

                int j = 0;
                int counter_for_line = 0;
                for (int i = 0; i < listVideos.Count; i++)
                {
                    if (j % 4 == 0 && j != 0)
                    {
                        j = 0;
                        counter_for_line++;
                        newPanel.Size = new Size(newPanel.Size.Width, newPanel.Size.Height + 120);
                    }
                    ViewUtils.CreatePreview(newPanel, listVideos[i], j, counter_for_line, this.Model);
                    j++;
                }
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            this.DisplayResultSearch();
        }

        private void DisplayOptionAccount(string nameSite)
        {
            this.pnlLeftMid.Controls.Clear();
            this.pnlLeftMid.Size = new Size(194, 45);
            Label lblTitle = new Label();
            lblTitle.Font = new Font("Arial", 12, FontStyle.Bold);
            lblTitle.Location = new Point(0, 0);
            lblTitle.Text = "Options";

            CheckBox cbxNotif = new CheckBox();
            cbxNotif.Font = new Font("Arial", 9);
            cbxNotif.Location = new Point(10, lblTitle.Size.Height);
            cbxNotif.Text = "Notification";

            Label lblAccount = new Label();
            lblAccount.Font = new Font("Arial", 9);
            lblAccount.Location = new Point(10, cbxNotif.Location.Y + cbxNotif.Size.Height);
            lblAccount.Text = "Account";

            Label lblDisconnect = new Label();
            lblDisconnect.Font = new Font("Arial", 9);
            lblDisconnect.Location = new Point(10, lblAccount.Location.Y + lblAccount.Size.Height);
            lblDisconnect.Text = "Disconnect";
            lblDisconnect.Click += (s, e) => this.OnClickDisconnect(s, e, nameSite);

            this.pnlLeftMid.Location = new Point(5, this.pnlLeftTop.Height);
            this.pnlLeftMid.Size = new Size(this.pnlLeftMid.Size.Width, lblTitle.Size.Height + cbxNotif.Size.Height + lblAccount.Size.Height + lblDisconnect.Size.Height);
            this.pnlLeftMid.Controls.Add(lblTitle);
            this.pnlLeftMid.Controls.Add(cbxNotif);
            this.pnlLeftMid.Controls.Add(lblAccount);
            this.pnlLeftMid.Controls.Add(lblDisconnect);
        }

        private void DisplayConnexionPage(string siteName)
        {
            this.pnlContent.Controls.Clear();
            this.wbrConnexion.AllowNavigation = true;
            this.wbrConnexion.Dock = DockStyle.Fill;
            this.wbrConnexion.Navigate(this.SitesController.GetLinkConnexionPage(siteName));
            this.pnlContent.Controls.Add(this.wbrConnexion);
        }

        private void OnChangeUrl(object sender, WebBrowserNavigatedEventArgs e, string siteName)
        {
            if (this.wbrConnexion.Url != null)
            {
                string accessToken = this.SitesController.GetAccessTokenInUrl(this.wbrConnexion.Url.ToString());

                if (accessToken != "")
                {
                    this.SitesController.Connect(accessToken, siteName);
                    this.DisplaySitePanel(siteName);
                    this.DisplayOptionAccount(siteName);
                    this.DisplaySubscribes(siteName);
                }

                Console.WriteLine(this.wbrConnexion.Url);
            }
        }

        private void ClearCookies()
        {
            this.wbrConnexion.Navigate("javascript:void((function(){var a,b,c,e,f;f=0;a=document.cookie.split('; ');for(e=0;e<a.length&&a[e];e++){f++;for(b='.'+location.host;b;b=b.replace(/^(?:%5C.|[^%5C.]+)/,'')){for(c=location.pathname;c;c=c.replace(/.$/,'')){document.cookie=(a[e]+'; domain='+b+'; path='+c+'; expires='+new Date((new Date()).getTime()-1e11).toGMTString());}}}})())");

        }
    }
}
