using ProjectMvvm.models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight.Command;
using System.Windows.Input;
using System.Windows;

namespace ProjectMvvm.viewmodel
{
    class TicketingVM : ObservableObject
    {

        //gegevens ophalen 
        public TicketingVM()
        {
            _tickettypes = TicketType.GetTicketTypes();
            _tickets = Ticket.GetTickets();


        }
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

        private ObservableCollection<Ticket> _tickets;
        public ObservableCollection<Ticket> Tickets
        {
            get
            {
                return _tickets;
            }
            set
            {
                _tickets = value;
                OnPropertyChanged("Tickets");
                
            }
        }

        private Ticket _selectedTicket;
        public Ticket SelectedTicket
        {
            get
            {
                return _selectedTicket;
            }
            set
            {
                _selectedTicket = value;
                OnPropertyChanged("SelectedTicket");
                OnPropertyChanged("SelectedTicketType");
                
            }
        }

        //commands

        public ICommand NewTicketCommand
        {
            get
            {
                return new RelayCommand(NewTicket);
            }
        }


        public ICommand RemoveTicketCommand
        {
            get
            {
                return new RelayCommand(RemoveTicket);
            }
        }


        //verwijderen ticket
        private void RemoveTicket()
        {
            if (SelectedTicketType == null)
            {
                MessageBox.Show("Door een bug in het systeem moet je momenteel nog de juiste tickettype selecteren");
            }
            else
            {
                Ticket t = new Ticket();
                t.Ticketholder = SelectedTicket.Ticketholder;
                t.TicketholderEmail = SelectedTicket.TicketholderEmail;
                t.TicketType = SelectedTicketType;
                t.TicketType.ID = SelectedTicketType.ID;
                t.Amount = SelectedTicket.Amount;




                TicketType tt = new TicketType();
                tt.ID = SelectedTicketType.ID;
                tt.Name = SelectedTicketType.Name;
                tt.Price = SelectedTicketType.Price;
                tt.AvailableTickets = SelectedTicketType.AvailableTickets + t.Amount;

                if (tt.AvailableTickets <= 0)
                {

                    MessageBox.Show("geen negatieve waarden aub");
                }
                else
                {
                    Ticket.RemoveTicket(t);
                    TicketType.UpdateTicketTypeAmount(tt);



                    MessageBox.Show("de ticket(s) van " + SelectedTicket.Ticketholder + " zijn verwijderd");
                    MessageBox.Show("Er zijn momenteel nog " + tt.AvailableTickets + " Tickets van het type " + tt.Name + " over");

                    _tickets = Ticket.GetTickets();
                    OnPropertyChanged("Tickets");
                }
            }
        }

        //nieuw ticket aanmaken.

        private void NewTicket()
        {

            if (SelectedTicketType == null)
            {
                MessageBox.Show("Door een bug in het systeem moet je momenteel nog de juiste tickettype selecteren");
            }
            else
            {

                Ticket t = new Ticket();
                t.Ticketholder = SelectedTicket.Ticketholder;
                t.TicketholderEmail = SelectedTicket.TicketholderEmail;
                t.TicketType = SelectedTicketType;
                t.TicketType.ID = SelectedTicketType.ID;
                t.Amount = SelectedTicket.Amount;




                TicketType tt = new TicketType();
                tt.ID = SelectedTicketType.ID;
                tt.Name = SelectedTicketType.Name;
                tt.Price = SelectedTicketType.Price;
                tt.AvailableTickets = SelectedTicketType.AvailableTickets - t.Amount;

                if (tt.AvailableTickets <= 0)
                {

                    MessageBox.Show("er zijn niet genoeg tickets meer beschibaar, er zijn nog maar " + SelectedTicketType.AvailableTickets + " beschikbaar van het type " + tt.Name);
                }
                else
                {
                    Ticket.InsertTicket(t);
                    TicketType.UpdateTicketType(tt);



                    MessageBox.Show("de ticket(s) van " + SelectedTicket.Ticketholder + " zijn toegevoegd");
                    MessageBox.Show("Er zijn momenteel nog " + tt.AvailableTickets + " Tickets van het type " + tt.Name + " over");

                    _tickets = Ticket.GetTickets();
                    OnPropertyChanged("Tickets");
                }
            }
        }

    }
}
