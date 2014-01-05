using GalaSoft.MvvmLight.Command;
using ProjectMvvm.models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace ProjectMvvm.viewmodel
{
    class SettingsVM : ObservableObject, IPage
    {
        //ophalen uit model
        public SettingsVM() {
            _types = ContactPersonType.GetTypes();
            _changeTypes = ContactPersonType.GetTypes();
            _festival = Festival.GetFestival();
            _tickettypes = TicketType.GetTicketTypes();
            _stagetypes = Stage.GetStages();



          
         
        
        }
        public string Name
        {
            get { return "Settings"; }
        }

        private ObservableCollection<Stage> _stagetypes;
        public ObservableCollection<Stage> StageTypes {

            get {

                return _stagetypes;
            }
            set {

                _stagetypes = value;
                OnPropertyChanged("StageTypes");

            }
        }


        private Stage _selectedStageType;
        public Stage SelectedStageType
        {
            get
            {
                return _selectedStageType;
            }
            set
            {
                _selectedStageType = value;
                OnPropertyChanged("SelectedStageType");
            }
        }

        public ICommand EditStageTypeCommand
        {
            get
            {
                return new RelayCommand(EditStageType);
            }
        }

        private void EditStageType()
        {
           Stage s = new Stage();
            s.Name = _selectedStageType.Name;

            Stage.ModifyStage(s);

            MessageBox.Show("de stage " + _selectedStageType.Name + " is aangepast");

            _stagetypes = Stage.GetStages();
            OnPropertyChanged("StageTypes");
        }


        public ICommand NewStageTypeCommand
        {
            get
            {
                return new RelayCommand(NewStageType);
            }
        }

        private void NewStageType()
        {
            Stage s = new Stage();
            s.Name = _selectedStageType.Name;

            Stage.AddStage(s);

            MessageBox.Show("de stage " + _selectedStageType.Name + " is aangemaakt");

            _stagetypes = Stage.GetStages();
            OnPropertyChanged("StageTypes");
        }

        public ICommand DeleteStageTypeCommand
        {
            get
            {
                return new RelayCommand(DeleteStageType);
            }
        }

        private void DeleteStageType()
        {
            Stage s = new Stage();
            s.Name = _selectedStageType.Name;

            Stage.DeleteStage(s);

            MessageBox.Show("de stage " + _selectedStageType.Name + " is verwijderd");

            _stagetypes = Stage.GetStages();
            OnPropertyChanged("StageTypes");
        }




        #region ticket types
        private ObservableCollection<TicketType> _tickettypes;
        public ObservableCollection<TicketType> TicketTypes
        {
            get
            {
                return _tickettypes;
            }
            set
            {
                _tickettypes = value;
                OnPropertyChanged("TicketTypes");
            }
        }

        private TicketType _selectedTicketType;
        public TicketType SelectedTicketType
        {
            get
            {
                return _selectedTicketType;
            }
            set
            {
                _selectedTicketType = value;
                OnPropertyChanged("SelectedTicketType");
            }
        }

        public ICommand EditTicketTypeCommand
        {
            get
            {
                return new RelayCommand(EditTicketType);
            }
        }


        public ICommand NewTicketTypeCommand
        {
            get
            {
                return new RelayCommand(NewTicketType);
            }
        }

        public ICommand DeleteTicketTypeCommand
        {
            get
            {
                return new RelayCommand(DeleteTicketType);
            }
        }

        private void DeleteTicketType()
        {
            TicketType tt = new TicketType();
            tt.Name = _selectedTicketType.Name;
            tt.Price = _selectedTicketType.Price;
            tt.AvailableTickets = _selectedTicketType.AvailableTickets;

            TicketType.DeleteTicketType(tt);
            MessageBox.Show("De ticket " + _selectedTicketType.Name + "is verwijderd");
            MessageBox.Show("Indien er hier tickets mee gemaakt zijn, zijn deze niet meer geldig");
           
            _tickettypes = TicketType.GetTicketTypes();
            OnPropertyChanged("TicketTypes");
        }


        private void NewTicketType()
        {
            TicketType tt = new TicketType();
            tt.Name = _selectedTicketType.Name;
            tt.Price = _selectedTicketType.Price;
            tt.AvailableTickets = _selectedTicketType.AvailableTickets;

            TicketType.InsertTicketType(tt);
            MessageBox.Show("de nieuwe ticket " + _selectedTicketType.Name + " is toegevoegd");
            
            _tickettypes = TicketType.GetTicketTypes();
            OnPropertyChanged("TicketTypes");


        }



        private void EditTicketType()
        {
            TicketType tt = new TicketType();

            tt.ID = _selectedTicketType.ID;
            tt.Name = _selectedTicketType.Name;
            tt.Price = _selectedTicketType.Price;
            tt.AvailableTickets = _selectedTicketType.AvailableTickets;

            TicketType.UpdateTicketType(tt);

            MessageBox.Show("De instellingen voor " + _selectedTicketType.Name + " zijn aangepast");
            _tickettypes = TicketType.GetTicketTypes();
            OnPropertyChanged("TicketTypes");
        }
        #endregion


        #region festival settings
        private Festival _festival;
        public Festival Festivals
        {
            get{
                return _festival;
            }
            set
            {
                _festival = value;
                OnPropertyChanged("Festivals");
            }
        }

        public ICommand EditFestivalCommand
        {
            get
            {
                return new RelayCommand(EditFestival);
            }
        }

        private void EditFestival()
        {
            Festival editFestival = new Festival();
            editFestival.Name = Festivals.Name;
            editFestival.StartDate = Festivals.StartDate;
            editFestival.EndDate = Festivals.EndDate;

            Festival.SaveFestival(editFestival);

            MessageBox.Show("De wijzigingen aan het festival werden opgeslaan");
            _festival = Festival.GetFestival();
            OnPropertyChanged("Festivals");
        }
        #endregion

        #region contactpersontype settings

        private ObservableCollection<ContactPersonType> _changeTypes;
        private ObservableCollection<ContactPersonType> _types;
        public ObservableCollection<ContactPersonType> Types
        {
            get
            {
                return _types;
            }
            set
            {
                _types = value;
                OnPropertyChanged("Types");
            }
        }


        private ContactPersonType _cType;
        public ContactPersonType CType
        {
            get
            {
                return _cType;
            }
            set
            {
                _cType = value;
                OnPropertyChanged("CType");
            }
        }

        public ICommand NewContactpersonTypeCommand
        {
            get
            {
                return new RelayCommand(NewContactpersonType);
            }
        }
        public ICommand SaceContactpersonTypeCommand
        {
            get
            {
                return new RelayCommand(SaveContactpersonType);
            }
        }

        public ICommand DeleteContactpersonTypeCommand
        {
            get
            {
                return new RelayCommand(DeleteContactpersonType);
            }
        }

        private void DeleteContactpersonType()
        {

            ContactPersonType ct = new ContactPersonType();
            ct.Name = _cType.Name;
            ContactPersonType.DeleteContactpersonType(ct);
            MessageBox.Show("The job was removed");
            _types = ContactPersonType.GetTypes();
            _changeTypes = ContactPersonType.GetTypes();
            OnPropertyChanged("Types");
            OnPropertyChanged("ChangeTypes");


        }

        private void NewContactpersonType()
        {
            ContactPersonType ct = new ContactPersonType();

            ct.Name = _cType.Name;

            ContactPersonType.InsertContactpersonType(ct);

            MessageBox.Show("the new job was added");
            _types = ContactPersonType.GetTypes();
            _changeTypes = ContactPersonType.GetTypes();
            OnPropertyChanged("Types");
            OnPropertyChanged("ChangeTypes");
        }
        private void SaveContactpersonType()
        {
            ContactPersonType ct = new ContactPersonType();

            ct.ID = _cType.ID;
            ct.Name = _cType.Name;

            ContactPersonType.UpdateContactpersonType(ct);

            MessageBox.Show("the function was edited");
            _types = ContactPersonType.GetTypes();
            _changeTypes = ContactPersonType.GetTypes();
            OnPropertyChanged("Types");
            OnPropertyChanged("ChangeTypes");
        }


        #endregion


    }
}
