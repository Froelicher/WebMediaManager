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
        }

        public void DisplayOnlineStreams()
        {
            List<StreamingSite.SVideo> onlineStreams = this.SitesController.GetOnlineStreams();

            for (int i = 0; i < onlineStreams.Count; i++)
            {
                
            }
        }

        

    }
}
