using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebMediaManager.Models;
using WebMediaManager.Views;

namespace WebMediaManager.Controllers
{
    class SitesController
    {
        private PersonalInterface _pview;
        private Model _model;
        private VidForm _vview;

        public VidForm Vview
        {
            get { return _vview; }
            set { _vview = value; }
        }

        internal Model Model
        {
            get { return _model; }
            set { _model = value; }
        }

        public PersonalInterface PView
        {
            get { return _pview; }
            set { _pview = value; }
        }

        public SitesController(PersonalInterface personalView, Model model)
        {
            this.Model = model;
            this.PView = personalView;
        }

        public SitesController(VidForm view, Model model)
        {
            this.Model = model;
            this.Vview = view;

        }

        public List<StreamingSite.SVideo> GetLastVideos()
        {
            return this.Model.GetLastVideos();
        }

        public List<StreamingSite.SVideo> GetOnlineStreams()
        {
            return this.Model.GetOnlineStreams();
        }

        public string[] GetNameSites()
        {
            return this.Model.GetNameSites();
        }

        public string GetUserName(string nameSite)
        {
            return this.Model.GetUserName(nameSite);
        }

        public string GetAccessToken(string nameSite)
        {
            return this.Model.GetAccessToken(nameSite);
        }
    }
}
