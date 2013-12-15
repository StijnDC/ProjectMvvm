using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace project
{
    class Festival
    {

        private DateTime _StartDate;

        public DateTime StartDate
        {
            get { return StartDate; }
            set { StartDate = value; }
        }

        private DateTime _EndDate;

        public DateTime EndDate
        {
            get { return _EndDate; }
            set { _EndDate = value; }
        }


        public static ObservableCollection<Festival> getData()
        {
            ObservableCollection<Festival> Festival = new ObservableCollection<Festival>();
            XmlDocument doc = new XmlDocument();
            doc.Load(".xml");

            XmlNodeList elemList = doc.GetElementsByTagName("company");

            return null;

        }
    }
}
