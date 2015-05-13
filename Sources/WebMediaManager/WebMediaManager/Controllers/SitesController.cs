﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebMediaManager.Models;

namespace WebMediaManager.Controllers
{
    class SitesController
    {
        private PersonalInterface _view;
        private Model _model;

        internal Model Model
        {
            get { return _model; }
            set { _model = value; }
        }

        public PersonalInterface View
        {
            get { return _view; }
            set { _view = value; }
        }

        public SitesController(PersonalInterface personalView, Model model)
        {
            this.Model = model;
            this.View = personalView;
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
    }
}
