using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectMvvm.models
{
    class ContactPerson
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

        private String _Company;

        public String Company   
        {
            get { return _Company; }
            set { _Company = value; }
        }
        private ContactPeronType _JobRole;

        public ContactPeronType JobRole
        {
            get { return _JobRole; }
            set { _JobRole = value; }
        }
        private String _City;

        public String City
        {
            get { return _City; }
            set { _City = value; }
        }
        private String _Email;

        public String Email
        {
            get { return _Email; }
            set { _Email = value; }
        }
        private String _Phone;

        public String Phone
        {
            get { return _Phone; }
            set { _Phone = value; }
        }

        private string _CellPhone;

        public string Cellphone
        {
            get { return _CellPhone; }
            set { _CellPhone = value; }
        }
        
        
    }
}
