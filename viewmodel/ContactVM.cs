using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using GalaSoft.MvvmLight.Command;
using System.Windows;
using System.Windows.Input;
using ProjectMvvm.models;

namespace ProjectMvvm.viewmodel
{
    class ContactVM : ObservableObject, IPage
    {
        //alles inlezen uit database
        public ContactVM()
        {
            _contactpersons = CheckContactPerson(_selectedType);
            _types = ContactPersonType.GetTypes();
            _changeTypes = ContactPersonType.GetTypes();
        }

        public string Name
        {
            get
            {
                return "Contact";
            }
        }

        //moet nog aangepast worden, hier zit nog een fout!
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

        //constructors aanmaken om alles bij te houden
        private ObservableCollection<ContactPerson> _contactpersons;
        private ObservableCollection<ContactPersonType> _changeTypes;
        private ContactPerson _contactperson;
        private ContactPersonType _selectedType;
        private ContactPersonType _typeChange;
        public ObservableCollection<ContactPerson> Contactpersons
        {
            get
            {
                return _contactpersons;
            }
            set
            {
                _contactpersons = value;
                OnPropertyChanged("Contactpersons");
            }
        }
        public ObservableCollection<ContactPersonType> ChangeTypes
        {
            get
            {
                return _changeTypes;
            }
            set
            {
                _changeTypes = value;
                OnPropertyChanged("ChangeTypes");
            }
        }
        public ContactPerson SelectedContactperson
        {
            get
            {
                return _contactperson;
            }
            set
            {
                _contactperson = value;
                OnPropertyChanged("SelectedContactperson");
               
            }
        }
        public ContactPersonType SelectedType
        {
            get
            {
                return _selectedType;
            }
            set
            {
                _selectedType = value;
                OnPropertyChanged("SelectedType");
                CheckContactPerson(_selectedType);
            }
        }
        public ContactPersonType TypeChange
        {
            get
            {
                return _typeChange;
            }
            set
            {
                _typeChange = value;
                OnPropertyChanged("TypeChange");
            }
        }

        private ObservableCollection<ContactPerson> CheckContactPerson(ContactPersonType type)
        {
            if (type != null)
            {
                if (type.Name == "Alle")
                {
                    return _contactpersons = ContactPerson.GetContactPersons();
                }
                else
                {
                    return _contactpersons = ContactPerson.FilterContactpersons(type.ID);
                }
            }
            else
            {
                return _contactpersons = ContactPerson.GetContactPersons();
            }
        }


        public ICommand NewContactPersonCommand
        {
            get
            {
                return new RelayCommand(NewContactperson);
            }
        }
        public ICommand SaveContactPersonCommand
        {
            get
            {
                return new RelayCommand(SaveContactperson);
            }
        }
        public ICommand DeleteContactPersonCommand
        {
            get
            {
                return new RelayCommand(DeleteContactperson);
            }
        }

        //nieuw contactpersoon aanmaken
        private void NewContactperson()
        {
            if (_typeChange == null)
            {
                MessageBox.Show("Er is geen functie geselecteerd.");
            }
            else
            {
                ContactPerson c = new ContactPerson();

                c.Name = _contactperson.Name;
                c.Company = _contactperson.Company;
                c.JobRole = _typeChange;
                c.City = _contactperson.City;
                c.Email = _contactperson.Email;
                c.Phone = _contactperson.Phone;
                c.Cellphone = _contactperson.Cellphone;

                ContactPerson.InsertContactperson(c);

                MessageBox.Show("De wijzigingen werden opgeslaan.");
                OnPropertyChanged("Contactpersons");
            }
        }

        //contactpersoon aanmaken
        private void SaveContactperson()
        {
            if (_typeChange == null)
            {
                MessageBox.Show("Er is geen functie geselecteerd.");
            }
            else
            {
                ContactPerson c = new ContactPerson();

                c.ID = _contactperson.ID;
                c.Name = _contactperson.Name;
                c.Company = _contactperson.Company;
                c.JobRole = _typeChange;
                c.City = _contactperson.City;
                c.Email = _contactperson.Email;
                c.Phone = _contactperson.Phone;
                c.Cellphone = _contactperson.Cellphone;

                ContactPerson.UpdateContactperson(c);

                MessageBox.Show("De wijzigingen werden opgeslaan.");
                OnPropertyChanged("Contactpersons");
            }
        }
        //Contactpersoon verwijderen
        private void DeleteContactperson()
        {
            ContactPerson c = new ContactPerson();

            c.ID = _contactperson.ID;
            c.Name = _contactperson.Name;
            c.Company = _contactperson.Company;
            c.JobRole = _contactperson.JobRole;
            c.City = _contactperson.City;
            c.Email = _contactperson.Email;
            c.Phone = _contactperson.Phone;
            c.Cellphone = _contactperson.Cellphone;

            ContactPerson.DeleteContactperson(c);

            MessageBox.Show("De wijzigingen werden opgeslaan.");
            OnPropertyChanged("Contactpersons");
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

        private void NewContactpersonType()
        {
            ContactPersonType ct = new ContactPersonType();

            ct.Name = _cType.Name;

            ContactPersonType.InsertContactpersonType(ct);

            MessageBox.Show("De nieuwe functie werd toegevoegd");
            OnPropertyChanged("Types");
            OnPropertyChanged("ChangeTypes");
        }
        private void SaveContactpersonType()
        {
            ContactPersonType ct = new ContactPersonType();

            ct.ID = _cType.ID;
            ct.Name = _cType.Name;

            ContactPersonType.UpdateContactpersonType(ct);

            MessageBox.Show("De functie werd gewijzigd");
            OnPropertyChanged("Types");
            OnPropertyChanged("ChangeTypes");
        }
    }
}
