using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebMediaManager.Models;

namespace WebMediaManager.Controllers
{
    class ContainersController
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

        public ContainersController(PersonalInterface view, Model model)
        {
            this.View = view;
            this.Model = model;
        }

        public List<string> GetNamesCategory()
        {
            List<string> result = new List<string>();
            Playlist test = new Playlist("test");

            for (int i = 0; i < this.Model.ListContainer.Count; i++)
            {
                if(!Object.ReferenceEquals(test.GetType(), this.Model.ListContainer[i].GetType()))
                {
                    result.Add(this.Model.ListContainer[i].Name);
                }
            }
            return result;
        }

        public List<string> GetNamesPlaylist()
        {
            List<string> result = new List<string>();
            Playlist test = new Playlist("test"); ;

            for (int i = 0; i < this.Model.ListContainer.Count; i++)
            {
                if (Object.ReferenceEquals(test.GetType(), this.Model.ListContainer[i].GetType()))
                {
                    result.Add(this.Model.ListContainer[i].Name);
                }
            }
            return result;
        }

        public void CreateFileContainers()
        {
            this.Model.CreateFileContainers();
        }

        public void OpenFileContainers()
        {
            this.Model.OpenFileCategories();
            this.Model.OpenFilePlaylists();
        }
    }
}
