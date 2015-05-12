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

            this.pnlStreams.HorizontalScroll.Enabled = true;
            this.pnlStreams.HorizontalScroll.Visible = true;

            DisplayButtonsSite();
            DisplayOnlineStreams();
            DisplayLinkCategory();
            DisplayLinkPlaylist();
        }

        public void DisplayOnlineStreams()
        {
            List<StreamingSite.SVideo> onlineStreams = this.SitesController.GetOnlineStreams();

            for (int i = 0; i < onlineStreams.Count; i++)
            {
                ViewUtils.CreatePreview(this.pnlStreams, onlineStreams[i], i);
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
            lblTitle.Font = new Font("Arial", 12);
            lblTitle.Location = new Point(0, 0);
            lblTitle.Text = "Categories";
            this.pnlContainers.Controls.Add(lblTitle);

            List<string> nameCategory = this.ContainersController.GetNamesCategory();

            for (int i = 0; i < nameCategory.Count; i++)
            {
                ViewUtils.CreateLinkCategory(this.pnlContainers, nameCategory[i], i);
            }
        }

        private void DisplayLinkPlaylist()
        {
            Label lblTitle = new Label();
            lblTitle.Font = new Font("Arial", 12);
            lblTitle.Location = new Point(0, this.pnlContainers.Height);
            lblTitle.Text = "Playlist";
            this.pnlContainers.Controls.Add(lblTitle);

            List<string> namePlaylist = this.ContainersController.GetNamesPlaylist();

            for (int i = 0; i < namePlaylist.Count; i++)
            {
                ViewUtils.CreateLinkPlaylist(this.pnlContainers, namePlaylist[i], i);
            }
        }
    }
}
