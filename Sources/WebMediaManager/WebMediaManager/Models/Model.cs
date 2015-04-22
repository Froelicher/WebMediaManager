using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebMediaManager.Models
{
    class Model
    {
        #region PROPERTIES
        private List<StreamingSite> _listSite;
        private List<Container> _listContainer;

        internal List<Container> ListContainer
        {
            get { return _listContainer; }
            set { _listContainer = value; }
        }

        internal List<StreamingSite> ListSite
        {
            get { return _listSite; }
            set { _listSite = value; }
        }

        #endregion

        public Model()
        {

        }

        public List<StreamingSite.Video> CheckNotifications()
        {
            return null;
        }
    }
}
