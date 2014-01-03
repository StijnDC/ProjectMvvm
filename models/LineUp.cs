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
    class LineUp
    {
        private String _ID;

        public String ID
        {
            get { return _ID; }
            set { _ID = value; }
        }
        private DateTime _Date;

        public DateTime Date
        {
            get { return _Date; }
            set { _Date = value; }
        }
        private String _From;

        public String From
        {
            get { return _From; }
            set { _From = value; }
        }
        private String _Until;

        public String Until
        {
            get { return _Until; }
            set { _Until = value; }
        }

        private Stage _Stage;

        public Stage Stage
        {
            get { return _Stage; }
            set { _Stage = value; }
        }
        private Band _Band;

        public Band Band
        {
            get { return _Band; }
            set { _Band = value; }
        }


        public static ObservableCollection<LineUp> GetLineUp()
        {
            ObservableCollection<LineUp> lineUp = new ObservableCollection<LineUp>();

            String sSQL = "SELECT * FROM LineUP";
            DbDataReader reader = Database.GetData(sSQL);
            DateTime today = DateTime.Now;


            while (reader.Read())
            {
                LineUp l = new LineUp();
                
                string ID = (string)reader["ID"];
                l.ID = ID;
                l.Date = !Convert.IsDBNull((DateTime)reader["Date"]) ? (DateTime)reader["Date"] : today;
                l.From =!Convert.IsDBNull((string)reader["Van"]) ? (string)reader["Van"] : "";
                l.Until = !Convert.IsDBNull((string)reader["Until"]) ? (string)reader["Until"] : "";
               

                l.Stage = GetStageFromLineUp(reader["Stage"].ToString());
                l.Band = GetBandFromLineUp(reader["Band"].ToString());

                lineUp.Add(l);
            }
            return lineUp;
        }

        private static Stage GetStageFromLineUp(string StageID)
        {
            ObservableCollection<Stage> list = Stage.GetStages();
            return list.Where(stage => stage.ID == StageID).SingleOrDefault();
        }
        private static Band GetBandFromLineUp(string BandID)
        {
            ObservableCollection<Band> list = Band.GetBands();
            return list.Where(band => band.ID == BandID).SingleOrDefault();
        }

        //LineUp toevoegen aan database
        public static void AddLineUp(LineUp lu)
        {
            String sSQL = "INSERT INTO LineUp (Date, [From], Until, StageID, BandID) VALUES (@Date, @From, @Until, @StageID, @BandID)";

            DbParameter par1 = Database.AddParameter("@Date", Convert.ToDateTime(lu.Date));
            DbParameter par2 = Database.AddParameter("@From", lu.From);
            DbParameter par3 = Database.AddParameter("@Until", lu.Until);
            DbParameter par4 = Database.AddParameter("@StageID", Convert.ToInt32(lu.Stage));
            DbParameter par5 = Database.AddParameter("@BandID", Convert.ToInt32(lu.Band));

            Database.ModifyData(sSQL, par1, par2, par3, par4, par5);
        }

        //LineUp aanpassen in database 
        public static void ModifyLineUp(LineUp lu)
        {
            String sSQL = "UPDATE LineUP SET Date = @Date, [From] = @From, Until = @Until, StageID = @StageID, BandID = @BandID  WHERE LineUpID = @ID";

            DbParameter par1 = Database.AddParameter("@ID", lu.ID);
            DbParameter par2 = Database.AddParameter("@Date", Convert.ToDateTime(lu._Date));
            DbParameter par3 = Database.AddParameter("@From", lu._From);
            DbParameter par4 = Database.AddParameter("@Until", lu._Until);
            DbParameter par5 = Database.AddParameter("@StageID", Convert.ToInt32(lu.Stage));
            DbParameter par6 = Database.AddParameter("@BandID", Convert.ToInt32(lu.Band));

            Database.ModifyData(sSQL, par1, par2, par3, par4, par5, par6);
        }

        //LineUp verwijderen van database
        public static void DeleteLineUp(LineUp lu)
        {
            String sSQL = "DELETE FROM LineUp WHERE Date = @Date AND [From] = @From AND Until = @Until";

            DbParameter par1 = Database.AddParameter("@Date", lu._Date);
            DbParameter par2 = Database.AddParameter("@From", lu._From);
            DbParameter par3 = Database.AddParameter("@Until", lu._Until);

            Database.ModifyData(sSQL, par1, par2, par3);
        }


    }
}
