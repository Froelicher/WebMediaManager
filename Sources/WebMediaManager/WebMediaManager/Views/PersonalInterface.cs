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

        internal SitesController SitesController
        {
            get { return _sitesController; }
            set { _sitesController = value; }
        }

        public PersonalInterface()
        {
            InitializeComponent();
            this.SitesController = new SitesController(this ,new Models.Model());
            this.pnlStreams.HorizontalScroll.Enabled = true;
            this.pnlStreams.HorizontalScroll.Visible = true;
            DisplayButtonsSite();
            DisplayOnlineStreams();
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

            for (int i = 0; i < nameSites.Length-1; i++)
			{
			    ViewUtils.CreateButtonSite(this.pnlSite, nameSites[i], i);
			}
        }
    }
}
