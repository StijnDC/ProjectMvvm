using DBHelper;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


//////////////nog niet klaar
namespace ProjectMvvm.models
{
    class ContactPersonType
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



        //Alle contacttypes ophalen uit de database 
        public static ObservableCollection<ContactPersonType> GetTypes()
        {
            ObservableCollection<ContactPersonType> lijst = new ObservableCollection<ContactPersonType>();

            String sSQL = "SELECT * FROM ContactPersonType";
            DbDataReader reader = Database.GetData(sSQL);

            while (reader.Read())
            {
                ContactPersonType ct = new ContactPersonType();

                /// herwerken!!!!!!!!!!!!!!!!!!!!!!!!!!

                ct._ID = reader["ContactPersonTypeID"].ToString();
                ct._Name = reader["Name"].ToString();

                lijst.Add(ct);
            }
            return lijst;
        }

        public static ContactPersonType GetJobeRoleByID(String JobRoleID)
        {
            ObservableCollection<ContactPersonType> lijst = ContactPersonType.GetTypes();
            return lijst.Where(ct => ct._ID == JobRoleID).SingleOrDefault();
        }

        public static ContactPersonType GetJobeRoleByName(ContactPersonType ct)
        {
            ObservableCollection<ContactPersonType> lijst = ContactPersonType.GetTypes();
            return lijst.Where(cpt => cpt == ct).SingleOrDefault();
        }

        public override string ToString()
        {
            return this._Name;
        }

        //Insert in de database
        public static void InsertContactpersonType(ContactPersonType ct)
        {
            String sSQL = "INSERT INTO ContactPersonType (Name) VALUES (@Name)";

            DbParameter par1 = Database.AddParameter("@Name", ct._Name);

            Database.ModifyData(sSQL, par1);
        }

        //Update in de database 
        public static void UpdateContactpersonType(ContactpersonType ct)
        {
            String sSQL = "UPDATE ContactPersonType SET Name = @Name WHERE ContactPersonTypeID = @ID";

            DbParameter par1 = Database.AddParameter("@Name", ct._Name);
            DbParameter par2 = Database.AddParameter("@ID", ct._ID);

            Database.ModifyData(sSQL, par1, par2);
        }

    }
}
