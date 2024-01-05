using AAD.ImmoWin.Business.Classes;
using AAD.ImmoWin.Business.Interfaces;
using AAD.ImmoWin.Business.Services;
using Odisee.Common.Commands;
using Odisee.Common.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace AAD.ImmoWin.WpfApp.ViewModels
{
    public class KlantenLijstViewModel : BaseViewModel
    {
        #region Properties

        #region Command properties
        public RelayCommand KlantToevoegenCommand { get; set; }
        public RelayCommand KlantWijzigenCommand { get; set; }
        public RelayCommand KlantVerwijderenCommand { get; set; }



        #endregion

        #region Observable properties

        private List<Klant> _klanten;

        public List<Klant> Klanten
        {
            get { return _klanten; }
            set
            {
                SetProperty(ref _klanten, value);
            }
        }

        private Klant _geselecteerdeKlant;

        public Klant GeselecteerdeKlant
        {
            get { return _geselecteerdeKlant; }
            set
            {
                SetProperty(ref _geselecteerdeKlant, value);
            }
        }

        private KlantLijstStatus _status;

        public KlantLijstStatus Status
        {
            get { return _status; }
            set
            {


                if (SetProperty(ref _status, value))
                {
                    switch (Status)
                    {
                        case KlantLijstStatus.Tonen:
                            IsEnabled = true;
                            break;
                        case KlantLijstStatus.Toevoegen:
                            break;
                        case KlantLijstStatus.Wijzigen:
                            break;
                        case KlantLijstStatus.Verwijderen:
                            break;
                        default:
                            break;
                    }
                }
            }
        }

        #endregion

        #endregion

        #region Constructors

        public KlantenLijstViewModel(List<Klant> klanten)
        {
            // Observable properties
            Title = "Lijst klanten";
            Klanten = klanten;
            Status = KlantLijstStatus.Tonen;

            // Commands
            KlantToevoegenCommand = new RelayCommand(KlantToevoegenCommandExecute, KlantToevoegenCommandCanExecute);
            KlantWijzigenCommand = new RelayCommand(KlantWijzigenCommandExecute, KlantWijzigenCommandCanExecute);
            KlantVerwijderenCommand = new RelayCommand(KlantVerwijderenCommandExecute, KlantVerwijderenCommandCanExecute);
        }

        #endregion

        #region Methods

        #region Command  methods
        private string _voornaam;
        public string Voornaam
        {
            get { return _voornaam; }
            set { SetProperty(ref _voornaam, value); }
        }

        private string _familienaam;

        public string Familienaam
        {
            get { return _familienaam; }
            set { SetProperty(ref _familienaam, value); }
        }
        private void KlantToevoegenCommandExecute()
        {

        }
        private Boolean KlantToevoegenCommandCanExecute()
        {
            return IsEnabled = true;
        }

        private void KlantWijzigenCommandExecute()
        {
            IsEnabled = false;
            Status = KlantLijstStatus.Wijzigen;
        }
        private Boolean KlantWijzigenCommandCanExecute()
        {
            return GeselecteerdeKlant != null;
        }

        private void KlantVerwijderenCommandExecute()
        {
            KlantenRepository.RemoveKlant(GeselecteerdeKlant);
        }
        private Boolean KlantVerwijderenCommandCanExecute()
        {
            return GeselecteerdeKlant != null;
        }

        #endregion

        #endregion
    }
}
