using DBHelper;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectMvvm.models
{
    class Genre
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


        //genres ophalen uit database
        public static ObservableCollection<Genre> GetGenres()
        {
            ObservableCollection<Genre> lijst = new ObservableCollection<Genre>();

            String sSQL = "SELECT * FROM Genre";
            DbDataReader reader = Database.GetData(sSQL);

            while (reader.Read())
            {
                Genre g = new Genre();
                int ID = (int)reader["ID"];
                g._ID = Convert.ToString(ID);
                g._Name = !Convert.IsDBNull((string)reader["Genre"]) ? (string)reader["Genre"] : "";
               
               lijst.Add(g);

            }
            return lijst;
        }

        //Genre toevoegen aan database
        public static void AddGenre(Genre g)
        {
            String sSQL = "INSERT INTO Genre (Genre) VALUES (@Name)";

            DbParameter par = Database.AddParameter("@Name", g._Name);

            Database.ModifyData(sSQL, par);
        }

        //Genre aanpassen in database 
        public static void ModifyGenre(Genre g)
        {
            String sSQL = "UPDATE Genre SET Genre = @Name WHERE ID = @ID";

            DbParameter par1 = Database.AddParameter("@ID", g._ID);
            DbParameter par2 = Database.AddParameter("@Name", g._Name);

            Database.ModifyData(sSQL, par1, par2);
        }

        //Genre verwijderen van database
        public static void DeleteGenre(Genre g)
        {
            String sSQL = "DELETE FROM Genre WHERE Genre = @Name";

            DbParameter par1 = Database.AddParameter("@Name", g._Name);

            Database.ModifyData(sSQL, par1);
        }

        public string Error
        {
            get
            {
                return "tis kapot";
            }
        }
        public string this[string columnName]
        {
            get
            {
                string error = string.Empty;
                switch (columnName)
                {
                    case "Genre":
                        if (string.IsNullOrEmpty(_Name))
                            error = "De naam is verplicht";
                        break;
                }
                return error;
            }
        }

    }
}
