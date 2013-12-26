using DBHelper;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using project.models;



namespace project.models
{
    class TicketType : BaseModel

    {
        private string _ID;

        public string ID
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

        private ObservableCollection<TicketType> _TicketTypes;

        public ObservableCollection<TicketType> TicketTypes {

            get { return _TicketTypes; }
            set { _TicketTypes = value; OnPropertyChanged("TicketType"); }

        
        }

        public static ObservableCollection<TicketType> GetTicketTypes() {
            ObservableCollection<TicketType> ticketTypes = new ObservableCollection<TicketType>();

        string sSQL = "Select * FROM TicketType";
        DbDataReader reader = Database.GetData(sSQL);
        while (reader.Read()) {
            TicketType t = new TicketType();

            
            string ID = (string)reader["ID"];
            t._ID = ID;
            t.Name = !Convert.IsDBNull((string)reader["Name"]) ? (string)reader["Name"] : "";
            t.Price = !Convert.IsDBNull((int)reader["Price"]) ? (int)reader["Price"] : 0;
            t.AvailableTickets = !Convert.IsDBNull((int)reader["AvailableTickets"]) ? (int)reader["AvailableTickets"] : 0;

            ticketTypes.Add(t);

                  }
        return ticketTypes;

        }
       

    }
}
