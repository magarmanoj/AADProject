using AAD.ImmoWin.Business.Classes;
using AAD.ImmoWin.Business.Interfaces;
using AAD.ImmoWin.Business.Services;
using Odisee.Common.Commands;
using Odisee.Common.ViewModels;
using System;
using System.Collections.Generic;

namespace AAD.ImmoWin.WpfApp.ViewModels
{
    public class HuisEditViewModel : BaseViewModel
    {
        public RelayCommand HuisBewarenCommand { get; set; }
        public RelayCommand HuisAnnulerenCommand { get; set; }

        private Huis _huis;

        public Huis Huizen
        {
            get { return _huis; }
            set
            {
                SetProperty(ref _huis, value);
            }
        }

        private List<Huis> _woning;

        public List<Huis> Woningen
        {
            get { return _woning; }
            set
            {
                SetProperty(ref _woning, value);
            }
        }


        private Adres _adres;

        public Adres Adres
        {
            get { return _adres; }
            set
            {
                SetProperty(ref _adres, value);
            }
        }
        private Huis _geselecteerdeHuis;

        public Huis GeselecteerdeHuizen
        {
            get { return _geselecteerdeHuis; }
            set
            {
                SetProperty(ref _geselecteerdeHuis, value);
            }
        }

        public HuisEditViewModel()
        {
            Title = "Aanpassen Huizen";
            IsEnabled = false;
            Woningen = KlantenRepository.GetHuizen();

            // Commands
            HuisBewarenCommand = new RelayCommand(HuisBewarenCommandExecute, HuisBewarenCommandCanExecute);
            HuisAnnulerenCommand = new RelayCommand(HuisAnnulerenCommandExecute);
        }

        public void HuisBewarenCommandExecute()
        {
            KlantenRepository.UpdateWoning(Huizen);
        }
        private Boolean HuisBewarenCommandCanExecute()
        {
            return Huizen?.Changed??false;
        }

        private void HuisAnnulerenCommandExecute()
        {
            IsEnabled = false;
        }
    }
}