using DBHelper;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ProjectMvvm.models
{
    class Festival
    {

        private DateTime _StartDate;

        public DateTime StartDate
        {
            get { return _StartDate; }
            set { _StartDate = value; }
        }

        private DateTime _EndDate;

        public DateTime EndDate
        {
            get { return _EndDate; }
            set { _EndDate = value; }
        }

        private String _Name;
        public String Name
        {
            get
            {
                return _Name;
            }
            set
            {
                _Name = value;
            }
        }


        //festival datum + naam ophalen uit database
        public static Festival GetFestival()
        {
            Festival festival = new Festival();

            String sSQL = "SELECT * FROM Festival";

            DbDataReader reader = Database.GetData(sSQL);
            while (reader.Read())
            {
                Festival fes = new Festival();

                DateTime today = DateTime.Now;

                fes.Name = !Convert.IsDBNull((string)reader["Name"]) ? (string)reader["Name"] : "";
                fes.StartDate = !Convert.IsDBNull((DateTime)reader["StartDate"]) ? (DateTime)reader["StartDate"] : today;
                fes.EndDate = !Convert.IsDBNull((DateTime)reader["EndDate"]) ? (DateTime)reader["EndDate"] : today; 
               
                festival = fes;
            }
            return festival;
        }

        //Festival datum + naam updaten 
        public static void SaveFestival(Festival editFestival)
        {
            String sSQL = "UPDATE Festival SET FestivalName = @Name, StartDate = @StartDate, EndDate = @EndDate";

            DbParameter par1 = Database.AddParameter("@Name", editFestival.Name);
            DbParameter par2 = Database.AddParameter("@StartDate", editFestival.StartDate);
            DbParameter par3 = Database.AddParameter("@EndDate", editFestival.EndDate);

            Database.ModifyData(sSQL, par1, par2, par3);
        }
 
    }
}
