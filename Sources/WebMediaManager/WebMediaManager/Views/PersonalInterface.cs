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
            Model model = new Model();
            this.SitesController = new SitesController(this, model);
            this.ContainersController = new ContainersController(this, model);

            this.ContainersController.CreateFileContainers();
            this.ContainersController.OpenFileContainers();

            DisplayButtonsSite();
            DisplayOnlineStreams();
            DisplayLinkCategory();
            DisplayLinkPlaylist();
            DisplayLastVideos();

            if (!this.pnlContent.Focused)
                this.pnlContent.Focus();
        }

        public void DisplayOnlineStreams()
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
                    this.pnlStreams.Size = new Size(this.pnlStreams.Size.Width, this.pnlStreams.Size.Height + 200);
                }
                ViewUtils.CreatePreview(this.pnlStreams, onlineStreams[i], j, counter_for_line);
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

        private void DisplayLastVideos()
        {
            this.lblLastVideos.Location = new Point(lblLastVideos.Location.X, this.pnlStreams.Height + lblLastVideos.Size.Height + 10);
            this.pnlVideos.Location = new Point(pnlVideos.Location.X, this.lblLastVideos.Location.Y + lblLastVideos.Size.Height + 10);
            List<StreamingSite.SVideo> lastVideos = this.SitesController.GetLastVideos();
            int j = 0;
            int counter_for_line = 0;
            for (int i = 0; i < lastVideos.Count; i++)
            {
                if (j % 4 == 0 && j != 0)
                {
                    j = 0;
                    counter_for_line++;
                    this.pnlVideos.Size = new Size(this.pnlVideos.Size.Width, this.pnlVideos.Size.Height + 120);
                }   
                ViewUtils.CreatePreview(this.pnlVideos, lastVideos[i], j, counter_for_line);
                j++;
            }
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
            lblCategory.Click += (sender, e) => OnClickLabel(sender, e, name);
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
            lblPlaylist.Click += (sender, e) => OnClickLabel(sender, e, name);
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

        private void OnClickLabel(object sender, EventArgs e, string name)
        {
            CreateFullPanelVideos(name);
        }

        public void CreateFullPanelVideos(string name)
        {
            List<StreamingSite.SVideo> listVideos = this.ContainersController.GetVideosOfContainer(name);
            Panel newPanel = new Panel();
            this.pnlContent.Visible = false;
            newPanel.Parent = pnlContent.Parent;
            newPanel.Visible = true;
            newPanel.Location = pnlContent.Location;
            newPanel.Size = pnlContent.Size;

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
                ViewUtils.CreatePreview(newPanel, listVideos[i], j, counter_for_line);
                j++;
            }
        }
    }
}
