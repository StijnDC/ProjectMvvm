using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project.models
{
    class Band
    {
        private String _ID;

        public String ID
        {
            get { return _ID; }
            set { _ID = value; }
        }
        private String _Name;

        public String Name
        {
            get { return _Name; }
            set { _Name = value; }
        }
        private String _Picture;

        public String Picture
        {
            get { return _Picture; }
            set { _Picture = value; }
        }
        private String _Description;

        public String Description
        {
            get { return _Description; }
            set { _Description = value; }
        }
        private String _Genres;

        public String Genres
        {
            get { return _Genres; }
            set { _Genres = value; }
        }


    }
}
