using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Collections.ObjectModel;
using System.Data.Common;
using DBHelper;

namespace ProjectMvvm.models
{
    class Ticket
    {
        private string _ID;

        public string ID
        {
            get { return _ID; }
            set { _ID = value; }
        }
        private String _Ticketholder;

        public String Ticketholder
        {
            get { return _Ticketholder; }
            set { _Ticketholder = value; }
        }
        private String _TicketholderEmail;

        public String TicketholderEmail
        {
            get { return _TicketholderEmail; }
            set { _TicketholderEmail = value; }
        }
        private TicketType _TicketType;

        public TicketType TicketType
        {
            get { return _TicketType; }
            set { _TicketType = value; }
        }
        [Required]
        [Range(0, Int32.MaxValue)]
        private int _Amount;

        public int Amount
        {
            get { return _Amount; }
            set { _Amount = value; }
        }

        public static ObservableCollection<Ticket> GetTickets()
        {
            ObservableCollection<Ticket> lijst = new ObservableCollection<Ticket>();

            String sSQL = "SELECT * FROM Ticket";
            DbDataReader reader = Database.GetData(sSQL);

            while (reader.Read())
            {
                Ticket t = new Ticket();
                TicketType tick = new TicketType();
                t._ID = reader["ID"].ToString();
                t.Ticketholder = !Convert.IsDBNull((string)reader["TicketHolder"]) ? (string)reader["TicketHolder"] : "";
                t.TicketholderEmail = !Convert.IsDBNull((string)reader["TicketHolderEmail"]) ? (string)reader["TicketHolderEmail"] : "";
                t.TicketType = !Convert.IsDBNull((TicketType)reader["TicketType"]) ? (TicketType)reader["TicketType"] : tick ;
                t.Amount = !Convert.IsDBNull((int)reader["Amount"]) ? (int)reader["Amount"] : 0;
                
                lijst.Add(t);
            }
            return lijst;
        }

        public static void InsertTicket(Ticket t)
        {
            String sSQL = "INSERT INTO Ticket (TicketHolder, TicketHolderEmail, ID, Amount) VALUES (@TicketHolder, @TicketHolderEmail, @TicketTypeID, @Amount)";

            DbParameter par1 = Database.AddParameter("@TicketHolder", t._Ticketholder);
            DbParameter par2 = Database.AddParameter("@TicketHolderEmail", t._TicketholderEmail);
            DbParameter par3 = Database.AddParameter("@ID", Convert.ToInt32(t._TicketType.ID));
            DbParameter par4 = Database.AddParameter("@Amount", Convert.ToInt32(t._Amount));

            Database.ModifyData(sSQL, par1, par2, par3, par4);
        }
    }
}
