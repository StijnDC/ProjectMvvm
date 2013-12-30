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

        private String _Twitter;

        public String Twitter
        {
            get { return _Twitter; }
            set { _Twitter = value; }
        }

        private String _Facebook;

        public String Facebook
        {
            get { return _Facebook; }
            set { _Facebook = value; }
        }
        
        private ObservableCollection<Genre> _Genres;

        public ObservableCollection<Genre> Genres
        {
            get { return _Genres; }
            set { _Genres = value; }
        }


        private static ObservableCollection<Genre> GetAllGenresFromBand(String BandID)
        {
            ObservableCollection<Genre> lijst = new ObservableCollection<Genre>();
            ObservableCollection<Genre> genres = Genre.GetGenres();

            String sSQL = "SELECT * FROM BandGenre WHERE ID = @ID";
            DbParameter par1 = Database.AddParameter("@ID", BandID);
            DbDataReader reader = Database.GetData(sSQL, par1);

            while (reader.Read())
            {
                Genre aNieuw = new Genre();

                foreach (Genre genre in genres)
                {
                    if (genre.ID == reader["Genres"].ToString())
                    {
                        aNieuw.ID = genre.ID;
                        aNieuw.Name = genre.Name;
                    }
                }

                lijst.Add(aNieuw);
            }
            return lijst;
        }

        //Band toevoegen aan database
        public static void AddBand(Band b)
        {
            String sSQL = "INSERT INTO Band (Name, Picture, Description, Twitter, Facebook) VALUES (@Name, @Picture, @Description, @Twitter, @Facebook)";

            DbParameter par1 = Database.AddParameter("@Name", b._Name);
            DbParameter par2 = Database.AddParameter("@Picture", b._Picture);
            DbParameter par3 = Database.AddParameter("@Description", b._Description);
            DbParameter par4 = Database.AddParameter("@Twitter", b._Twitter);
            DbParameter par5 = Database.AddParameter("@Facebook", b._Facebook);

            Database.ModifyData(sSQL, par1, par2, par3, par4, par5);
        }

        //Band aanpassen in database 
        public static void ModifyBand(Band b)
        {
            String sSQL = "UPDATE Band SET Name = @Name, Picture = @Picture, Description = @Description, Twitter = @Twitter, Facebook = @Facebook WHERE ID = @ID";

            DbParameter par1 = Database.AddParameter("@Name", b._Name);
            DbParameter par2 = Database.AddParameter("@Picture", b._Picture);
            DbParameter par3 = Database.AddParameter("@Description", b._Description);
            DbParameter par4 = Database.AddParameter("@Twitter", b.Twitter);
            DbParameter par5 = Database.AddParameter("@Facebook", b._Facebook);
            DbParameter par6 = Database.AddParameter("@ID", b._ID);

            Database.ModifyData(sSQL, par1, par2, par3, par4, par5, par6);
        }

        //Band verwijderen van database
        public static void DeleteBand(Band b)
        {
            String sSQL = "DELETE FROM Band WHERE Name = @Name";

            DbParameter par1 = Database.AddParameter("@Name", b._Name);

            Database.ModifyData(sSQL, par1);
        }

        //Genres koppelen aan band
        public static void CommitGenresToBand(Band b, ObservableCollection<Genre> lijst)
        {
            foreach (Genre g in lijst)
            {
                String sSQL = "INSERT INTO BandGenre (ID, Genres) VALUES (@BandID,  @GenreID)";

                DbParameter par1 = Database.AddParameter("@BandID", b._ID);
                DbParameter par2 = Database.AddParameter("@GenreID", g.ID);

                Database.ModifyData(sSQL, par1, par2);
            }
        }

        public override string ToString()
        {
            return this.Name;
        }

    }
}
