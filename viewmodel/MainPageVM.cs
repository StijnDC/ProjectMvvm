using GalaSoft.MvvmLight.Command;
using ProjectMvvm.view;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ProjectMvvm.viewmodel
{
    class MainPageVM : ObservableObject, IPage
    {
        public string Name
        {
            get { return "Main"; }
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
            var Ticketing = new Ticketing();
            Ticketing.Show();
            break;

                case 2:
                    var Stage = new Stage();
            Stage.Show();
            break;

                case 3:
            var Contact = new Contact();
            Contact.Show();
            break;

                }



        }
    }
}
