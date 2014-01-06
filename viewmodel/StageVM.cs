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
    class StageVM : ObservableObject
    {

        //ophalen gegevens.
        public StageVM()
        {
            _Bands = Band.GetBands();
            _Stages = Stage.GetStages();
            _LineUP = LineUp.GetLineUp();



        }


        private LineUp _LP;
        private ObservableCollection<LineUp> _LineUP;
        public ObservableCollection<LineUp> LineUP
        {
            get
            {
                return _LineUP;
            }

            set
            {
                _LineUP = value;
                OnPropertyChanged("LineUP");

            }

        }

        public LineUp SelectedLineUP
        {

            get
            {
                return _LP;
            }
            set
            {
                _LP = value;
                OnPropertyChanged("SelectedLineUP");

            }

        }

        //commands

        public ICommand NewLineUPCommand
        {
            get
            {
                return new RelayCommand(NewLineUP);
            }
        }




        public ICommand RemoveLineUPCommand
        {
            get
            {
                return new RelayCommand(RemoveLineUP);
            }
        }


        public ICommand EditLineUPCommand
        {
            get
            {
                return new RelayCommand(EditLineUP);
            }
        }



        private Band _Band;
        private ObservableCollection<Band> _Bands;
        public ObservableCollection<Band> Bands
        {
            get
            {
                return _Bands;
            }
            set
            {
                _Bands = value;
                OnPropertyChanged("Bands");
            }
        }

        public Band SelectedBand
        {
            get
            {
                return _Band;
            }
            set
            {
                _Band = value;
                OnPropertyChanged("SelectedBand");

            }
        }

        private Stage _Stage;
        private ObservableCollection<Stage> _Stages;
        public ObservableCollection<Stage> Stages
        {
            get
            {
                return _Stages;
            }
            set
            {
                _Stages = value;
                OnPropertyChanged("Stages");
            }
        }

        public Stage SelectedStage
        {
            get
            {
                return _Stage;
            }
            set
            {
                _Stage = value;
                OnPropertyChanged("SelectedStage");

            }
        }



        //nieuwe lineup aanmaken
        private void NewLineUP()
        {

            if (SelectedBand == null || SelectedStage == null)
            {
                MessageBox.Show("Door een bug in het systeem moet je momenteel nog de juiste band en stage selecteren");
            }
            else
            {

                LineUp lp = new LineUp();

                lp.Date = SelectedLineUP.Date;
                lp.From = SelectedLineUP.From;
                lp.Until = SelectedLineUP.Until;
                lp.Stage = SelectedStage;
               lp.Stage.ID = SelectedStage.ID;
                lp.Band = SelectedBand;
                lp.Band.ID = SelectedBand.ID;




                LineUp.AddLineUp(lp);



                MessageBox.Show("De LineUP  is toegevoegd");






                _LineUP = LineUp.GetLineUp();

                OnPropertyChanged("LineUP");
            }
        }


        //lineup verwijderen
        private void RemoveLineUP()
        {

            if (SelectedBand == null || SelectedStage == null)
            {
                MessageBox.Show("Door een bug in het systeem moet je momenteel nog de juiste band en stage selecteren");
            }
            else
            {

                LineUp lp = new LineUp();

                lp.Date = SelectedLineUP.Date;
                lp.From = SelectedLineUP.From;
                lp.Until = SelectedLineUP.Until;
                lp.Stage = SelectedLineUP.Stage;
                lp.Stage.ID = SelectedLineUP.Stage.ID;
                lp.Band = SelectedLineUP.Band;
                lp.Band.ID = SelectedLineUP.Band.ID;


                LineUp.DeleteLineUp(lp);



                MessageBox.Show("De LineUP  is verwijderd");






                _LineUP = LineUp.GetLineUp();

                OnPropertyChanged("LineUP");
            }
        }



        //lineup aanpassen

        private void EditLineUP()
        {

            if (SelectedBand == null || SelectedStage == null)
            {
                MessageBox.Show("Door een bug in het systeem moet je momenteel nog de juiste band en stage selecteren");
            }
            else
            {

                LineUp lp = new LineUp();

                lp.Date = SelectedLineUP.Date;
                lp.From = SelectedLineUP.From;
                lp.Until = SelectedLineUP.Until;
                lp.Stage = SelectedLineUP.Stage;
                lp.Stage.ID = SelectedLineUP.Stage.ID;
                lp.Band = SelectedLineUP.Band;
                lp.Band.ID = SelectedLineUP.Band.ID;


                LineUp.ModifyLineUp(lp);



                MessageBox.Show("De LineUP  is aangepast");






                _LineUP = LineUp.GetLineUp();

                OnPropertyChanged("LineUP");
            }






        }



    }

}

