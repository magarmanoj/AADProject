using AAD.ImmoWin.Business.Classes;
using AAD.ImmoWin.Business.Services;
using Odisee.Common.Commands;
using Odisee.Common.ViewModels;
using System;

namespace AAD.ImmoWin.WpfApp.ViewModels
{
    public class AppartementEditViewModel : BaseViewModel
    {
        public RelayCommand AppartementBewarenCommand { get; set; }
        public RelayCommand AppartementAnnulerenCommand { get; set; }

        private Appartement _appartement;

        public Appartement Appartementen
        {
            get { return _appartement; }
            set
            {
                SetProperty(ref _appartement, value);
            }
        }

        private Woningen _woning;

        public Woningen Woningen
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
        private Appartement _geselecteerdeappartement;

        public Appartement GeselecteerdeAppartement
        {
            get { return _geselecteerdeappartement; }
            set
            {
                SetProperty(ref _geselecteerdeappartement, value);
            }
        }

        public AppartementEditViewModel()
        {
            Title = "Aanpassen Appartementen";
            IsEnabled = false;
            Woningen = KlantenRepository.GetAppartementen();

            // Commands
            AppartementBewarenCommand = new RelayCommand(AppartementBewarenCommandExecute, AppartementBewarenCommandCanExecute);
            AppartementAnnulerenCommand = new RelayCommand(AppartementAnnulerenCommandExecute);
        }

        public void AppartementBewarenCommandExecute()
        {
            KlantenRepository.UpdateWoning(Appartementen);
        }
        private Boolean AppartementBewarenCommandCanExecute()
        {
            return Appartementen?.Changed??false;
        }

        private void AppartementAnnulerenCommandExecute()
        {
            IsEnabled = false;
        }
    }
}