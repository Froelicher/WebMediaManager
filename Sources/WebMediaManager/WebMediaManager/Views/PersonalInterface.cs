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
using WebMediaManager.Views;

namespace WebMediaManager
{
    public partial class PersonalInterface : Form
    {
        private SitesController _sitesController;
        private ContainersController _containersController;
        private Model _model;

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

            if (!this.pnlContent.Focused)
                this.pnlContent.Focus();

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

        private void DisplayButtonsSite()
        {
            string[] nameSites = this.SitesController.GetNameSites();

            for (int i = 0; i < nameSites.Length; i++)
			{
			    ViewUtils.CreateButtonSite(this.pnlSite, nameSites[i], i);
                this.pnlContainers.Location = new Point(this.pnlContainers.Location.X, this.pnlContainers.Location.Y + 25);
			}
        }

        private void DisplayLinkCategory()
        {
            Label lblTitle = new Label();
            lblTitle.Font = new Font("Arial", 12, FontStyle.Bold);
            lblTitle.Location = new Point(0, 0);
            lblTitle.Text = "Categories";
            this.pnlContainers.Location = new Point(this.pnlContainers.Location.X, this.pnlSite.Size.Height + pnlSite.Location.Y);
            this.pnlContainers.Controls.Add(lblTitle);

            List<string> nameCategory = this.ContainersController.GetNamesCategory();

            for (int i = 0; i < nameCategory.Count; i++)
            {
                CreateLinkCategory(this.pnlContainers, nameCategory[i], i, this.pnlContent);
            }
        }

        private void DisplayLinkPlaylist()
        {
            Label lblTitle = new Label();
            lblTitle.Font = new Font("Arial", 12, FontStyle.Bold);
            lblTitle.Location = new Point(0, this.pnlContainers.Height);
            lblTitle.Text = "Playlist";
            this.pnlContainers.Size = new Size(this.pnlContainers.Size.Width, this.pnlContainers.Size.Height + 25);
            this.pnlContainers.Controls.Add(lblTitle);

            List<string> namePlaylist = this.ContainersController.GetNamesPlaylist();

            for (int i = 0; i < namePlaylist.Count; i++)
            {
                CreateLinkPlaylist(this.pnlContainers, namePlaylist[i], i, this.pnlContent);
            }
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
            btnHome.Size = new Size(pnlSite.Width - 20, 25);
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
            lblCategory.Location = new Point(0, (15 * index_cont) + 20);
            lblCategory.MouseEnter += new EventHandler(MouseEnterLabel);
            lblCategory.MouseLeave += new EventHandler(MouseLeaveLabel);
            lblCategory.Click += (sender, e) => OnClickLabel(sender, e);
            pnlContainers.Size = new Size(pnlContainers.Size.Width, pnlContainers.Size.Height + 10);
            pnlContainers.Controls.Add(lblCategory);
        }

        public void CreateLinkPlaylist(Panel pnlContainers, string name, int index_play, Panel pnlContent)
        {
            Label lblPlaylist = new Label();
            lblPlaylist.Font = new Font("Arial", 9);
            lblPlaylist.AutoSize = true;
            lblPlaylist.Text = name;
            lblPlaylist.Location = new Point(0, pnlContainers.Size.Height - 5);
            lblPlaylist.MouseEnter += new EventHandler(MouseEnterLabel);
            lblPlaylist.MouseLeave += new EventHandler(MouseLeaveLabel);
            lblPlaylist.Click += (sender, e) => OnClickLabel(sender, e);
            pnlContainers.Size = new Size(pnlContainers.Size.Width, pnlContainers.Size.Height + 15);
            pnlContainers.Controls.Add(lblPlaylist);
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

        private void OnClickLabel(object sender, EventArgs e)
        {
            Label lbl = sender as Label;
            CreateFullPanelVideos(lbl.Text);
        }

        private void OnClickButtonHome(object sender, EventArgs e)
        {
            DisplayHomePanel();
        }

        public void CreateFullPanelVideos(string name)
        {
            List<StreamingSite.SVideo> listVideos = this.ContainersController.GetVideosOfContainer(name);
            Panel newPanel = new Panel();
            this.pnlContent.Controls.Clear();


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
}
