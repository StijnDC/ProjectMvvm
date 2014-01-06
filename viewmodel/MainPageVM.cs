using GalaSoft.MvvmLight.Command;
using ProjectMvvm.models;
using ProjectMvvm.view;
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
    class MainPageVM : ObservableObject, IPage
    {
        public string Name
        {
            get { return "Main"; }
        }

        public MainPageVM()
        {
            _tickettypes = TicketType.GetTicketTypes();
                   
        }

        public void refresh(){

            _tickettypes = TicketType.GetTicketTypes();
        }

        public ICommand OpenFormCommand
        {
            get { return new RelayCommand<int>(OpenForm); }
        }

        private void OpenForm(int page)
        {

            int pagecase = page;
            switch (pagecase){
                    
                case 1:  
            var Ticketing = new view.Ticketing();
            refresh();

            Ticketing.Show();
          
            break;

                case 2:
                    var Stage = new view.Stage();
                    refresh();
            Stage.Show();
            break;

                case 3:
            var Contact = new view.Contact();
            refresh();
            Contact.Show();
            break;

                }
        }

        private ObservableCollection<TicketType> _tickettypes;
        public ObservableCollection<TicketType> TicketTypes
        {
            get
            {
                refresh();
                return _tickettypes;
                
            }
            set
            {
                _tickettypes = value;
                OnPropertyChanged("TicketTypes");
               
            }
        }

    }
}
