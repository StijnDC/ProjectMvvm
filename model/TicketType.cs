using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project.Classes
{
    class TicketType
    {
        private String _ID;

        public String ID
        {
            get { return _ID; }
            set { _ID = value; }
        }
        private string _Name;

        public string Name

        {
            get { return _Name; }
            set { _Name = value; }
        }
        private double _Price;

        public double Price

        {
            get { return _Price; }
            set { _Price = value; }
        }

        private int _AvailableTickets;

        public int AvailableTickets
        {
            get { return _AvailableTickets; }
            set { _AvailableTickets = value; }
        }
        

    }
}
