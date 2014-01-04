using GalaSoft.MvvmLight.Command;
using ProjectMvvm.models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ProjectMvvm.viewmodel
{
    class SettingsVM : ObservableObject, IPage
    {
        //ophalen uit VM
        public SettingsVM() {
            _tickettypes = TicketType.GetTicketTypes();
        
        }
        public string Name
        {
            get { return "Settings"; }
        }
        //tickettypes returnen
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
        //selected Ticket bijhouden
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

        public ICommand NewTicketCommand
        {
            get
            {
                return new RelayCommand(NewTicketType);
            }
        }
        //new ticket aanmaken en inserten in database
        private void NewTicketType() {
            TicketType tt = new TicketType();

        tt.Name = _selectedTicketType.Name;
            tt.Price = _selectedTicketType.Price;
            tt.AvailableTickets = _selectedTicketType.AvailableTickets;

            TicketType.InsertTicketType(tt);
            OnPropertyChanged("TicketTypes");

        
        }

    }
}
