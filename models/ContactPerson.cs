using DBHelper;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Data.Common;
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
        private ContactPersonType _JobRole;

        public ContactPersonType JobRole
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

        [Required]
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        public String Email
        {
            get { return _Email; }
            set { _Email = value; }
        }
        private String _Phone;
        
        [Required]
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


        //Ophalen uit de database
        public static ObservableCollection<ContactPerson> GetContactPersons()
        {
            ObservableCollection<ContactPerson> list = new ObservableCollection<ContactPerson>();

            String sSQL = "SELECT * FROM [ContactPerson]";
            DbDataReader reader = Database.GetData(sSQL);



            while (reader.Read())
            {
                ContactPerson c = new ContactPerson();


                int ID = (int)reader["ID"];
                c.ID = Convert.ToString(ID);
                c.Name = !Convert.IsDBNull((string)reader["Name"]) ? (string)reader["Name"] : "";
                c.Company = !Convert.IsDBNull((string)reader["Company"]) ? (string)reader["Company"] : "";
                c.JobRole = ContactPersonType.GetJobeRoleByID(Convert.ToString(reader["JobRole"]));

                c.City = !Convert.IsDBNull((string)reader["City"]) ? (string)reader["City"] : "";
                c.Email = !Convert.IsDBNull((string)reader["EMail"]) ? (string)reader["EMail"] : "";
                c.Phone = !Convert.IsDBNull((string)reader["Phone"]) ? (string)reader["Phone"] : "";
                c.Cellphone = !Convert.IsDBNull((string)reader["CellPhone"]) ? (string)reader["CellPhone"] : "";
                

                list.Add(c);
            }
            return list;
        }

       

        //Insert in de database
        public static void InsertContactperson(ContactPerson c)
        {
            String sSQL = "INSERT INTO ContactPerson (Name, Company, JobRole, City, EMail, Phone, CellPhone) VALUES (@Name, @Company, @JobRole, @City, @Email, @Phone, @Cellphone)";

            DbParameter par1 = Database.AddParameter("@Name", c._Name);
            DbParameter par2 = Database.AddParameter("@Company", c._Company);
            DbParameter par3 = Database.AddParameter("@JobRole", Convert.ToInt32(c.JobRole.ID));
            DbParameter par4 = Database.AddParameter("@City", c._City);
            DbParameter par5 = Database.AddParameter("@Email", c._Email);
            DbParameter par6 = Database.AddParameter("@Phone", c._Phone);
            DbParameter par7 = Database.AddParameter("@Cellphone", c._CellPhone);

            Database.ModifyData(sSQL, par1, par2, par3, par4, par5, par6, par7);
        }

        //Update in de database 
        public static void UpdateContactperson(ContactPerson c)
        {
            String sSQL = "UPDATE ContactPerson SET Name = @Name, Company = @Company, JobRole = @JobRole, City = @City, EMail = @Email, Phone = @Phone, CellPhone = @Cellphone WHERE ID = @ID";

            DbParameter par1 = Database.AddParameter("@Name", c._Name);
            DbParameter par2 = Database.AddParameter("@Company", c._Company);
            DbParameter par3 = Database.AddParameter("@JobRole", Convert.ToInt32(c._JobRole.ID));
            DbParameter par4 = Database.AddParameter("@City", c._City);
            DbParameter par5 = Database.AddParameter("@Email", c._Email);
            DbParameter par6 = Database.AddParameter("@Phone", c._Phone);
            DbParameter par7 = Database.AddParameter("@Cellphone", c._CellPhone);
            DbParameter par8 = Database.AddParameter("@ID", c._ID);

            Database.ModifyData(sSQL, par1, par2, par3, par4, par5, par6, par7, par8);
        }

        //Delete in de database 
        public static void DeleteContactperson(ContactPerson c)
        {
            String sSQL = "DELETE FROM ContactPerson WHERE Name = @Name";

            DbParameter par1 = Database.AddParameter("@Name", c._Name);

            Database.ModifyData(sSQL, par1);
        }



    }
}
