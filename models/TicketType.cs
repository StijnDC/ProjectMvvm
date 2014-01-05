using DBHelper;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectMvvm.models;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;



namespace ProjectMvvm.models
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

        [Required]
        [Range(0.0, Double.MaxValue)]
        private double _Price;

        public double Price

        {
            get { return _Price; }
            set { _Price = value; }
        }
        [Required]
        [Range(0, Int32.MaxValue)]
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
        //tickettypes ophalen
        public static ObservableCollection<TicketType> GetTicketTypes() {
            ObservableCollection<TicketType> ticketTypes = new ObservableCollection<TicketType>();

        string sSQL = "Select * FROM TicketType";
        DbDataReader reader = Database.GetData(sSQL);
        while (reader.Read()) {
            TicketType t = new TicketType();

            
            int ID = (int)reader["ID"];
            t._ID = Convert.ToString(ID);
            t.Name = !Convert.IsDBNull((string)reader["Name"]) ? (string)reader["Name"] : "";
            t.Price = Convert.ToInt32(!Convert.IsDBNull((decimal)reader["Price"]) ? (decimal)reader["Price"] : 0);
            t.AvailableTickets = !Convert.IsDBNull((int)reader["AvailableTickets"]) ? (int)reader["AvailableTickets"] : 0;

            ticketTypes.Add(t);

                  }


        return ticketTypes;

        }



        public static TicketType GetTicketTypeByID(String TicketTypeID)
        {
            ObservableCollection<TicketType> TicketID = TicketType.GetTicketTypes();
            return TicketID.Where(tt => tt._ID == TicketTypeID).SingleOrDefault();
        }

        public static TicketType GetTicketByName(String TicketName)
        {
            ObservableCollection<TicketType> TicketNames = TicketType.GetTicketTypes();
            return TicketNames.Where(tt => tt._Name == TicketName).SingleOrDefault();
        }


        //update database
        public static void UpdateTicketType(TicketType ticketType)
        {
            String sSQL = "UPDATE TicketType SET Name = @Name, Price = @Price, AvailableTickets = @AvailableTickets WHERE ID = @ID";

            DbParameter par1 = Database.AddParameter("@Name", ticketType._Name);
            DbParameter par2 = Database.AddParameter("@Price", Convert.ToDouble(ticketType._Price));
            DbParameter par3 = Database.AddParameter("@AvailableTickets", Convert.ToInt32(ticketType._AvailableTickets));
            DbParameter par4 = Database.AddParameter("@ID", ticketType._ID);

            Database.ModifyData(sSQL, par1, par2, par3, par4);
        }
        public static void UpdateTicketTypeAmount(TicketType ticketType)
        {
            String sSQL = "UPDATE TicketType SET  AvailableTickets = @AvailableTickets WHERE Name= @Name";

            DbParameter par1 = Database.AddParameter("@Name", ticketType._Name);
           
            DbParameter par2 = Database.AddParameter("@AvailableTickets", Convert.ToInt32(ticketType._AvailableTickets));
           

            Database.ModifyData(sSQL, par1, par2);
        }



        //insert database
        public static void InsertTicketType(TicketType ticketType) { 
        string sSQL = "INSERT INTO TicketType (Name, Price, AvailableTickets) VALUES (@Name, @Price, @AvailableTickets)";
        DbParameter par1 = Database.AddParameter("@Name", ticketType._Name);
        DbParameter par2 = Database.AddParameter("@Price", ticketType.Price);
        DbParameter par3 = Database.AddParameter("@AvailableTickets", ticketType.AvailableTickets);

        Database.ModifyData(sSQL, par1, par2, par3);
        
        }

        //remove from database

        public static void DeleteTicketType(TicketType ticketType) {

            string sSQL = "DELETE FROM TicketType WHERE Name = @Name";
            
            DbParameter par1 = Database.AddParameter("@Name", ticketType._Name);

            Database.ModifyData(sSQL, par1);
        
        }

        public override string ToString()
        {
            return this.Name;
        }
    }
}
