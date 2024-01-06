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

        public Klant NewKlanten { get; set; } = new Klant();

        private Klant _geselecteerdeKlant;

        public Klant GeselecteerdeKlant
        {
            get { return _geselecteerdeKlant; }
            set
            {
                SetProperty(ref _geselecteerdeKlant, value);
            }
        }

        private LijstStatus _status;

        public LijstStatus Status
        {
            get { return _status; }
            set
            {


                if (SetProperty(ref _status, value))
                {
                    switch (Status)
                    {
                        case LijstStatus.Tonen:
                            IsEnabled = true;
                            break;
                        case LijstStatus.Toevoegen:
                            break;
                        case LijstStatus.Wijzigen:
                            break;
                        case LijstStatus.Verwijderen:
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
            Status = LijstStatus.Tonen;

            // Commands
            KlantToevoegenCommand = new RelayCommand(KlantToevoegenCommandExecute, KlantToevoegenCommandCanExecute);
            KlantWijzigenCommand = new RelayCommand(KlantWijzigenCommandExecute, KlantWijzigenCommandCanExecute);
            KlantVerwijderenCommand = new RelayCommand(KlantVerwijderenCommandExecute, KlantVerwijderenCommandCanExecute);
        }

        #endregion

        #region Methods

        #region Command  methods
        private void KlantToevoegenCommandExecute()
        {
            KlantenRepository.AddKlant(NewKlanten);
            Klanten = KlantenRepository.GetKlanten();
        }
        private Boolean KlantToevoegenCommandCanExecute()
        {
            return IsEnabled = true;
        }

        private void KlantWijzigenCommandExecute()
        {
            IsEnabled = false;
            Status = LijstStatus.Wijzigen;
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
