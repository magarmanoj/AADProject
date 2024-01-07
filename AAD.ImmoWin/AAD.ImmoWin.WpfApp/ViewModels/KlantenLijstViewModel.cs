using AAD.ImmoWin.Business.Classes;
using AAD.ImmoWin.Business.Exceptions;
using AAD.ImmoWin.Business.Services;
using AAD.ImmoWin.Business.Validatie;
using Odisee.Common.Commands;
using Odisee.Common.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

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
            FilteredKlanten = Klanten;

            // Commands
            KlantToevoegenCommand = new RelayCommand(KlantToevoegenCommandExecute, KlantToevoegenCommandCanExecute);
            KlantWijzigenCommand = new RelayCommand(KlantWijzigenCommandExecute, KlantWijzigenCommandCanExecute);
            KlantVerwijderenCommand = new RelayCommand(KlantVerwijderenCommandExecute, KlantVerwijderenCommandCanExecute);
        }

        #region Filter
        private string _filterText;
        public string FilterText
        {
            get { return _filterText; }
            set
            {
                SetProperty(ref _filterText, value);
                FilterKlantenList();
            }
        }


        private IEnumerable<Klant> _filteredKlanten;
        public IEnumerable<Klant> FilteredKlanten
        {
            get { return _filteredKlanten; }
            set { SetProperty(ref _filteredKlanten, value); }
        }

        private void FilterKlantenList()
        {
            if (string.IsNullOrWhiteSpace(FilterText))
            {
                FilteredKlanten = Klanten;
            }
            else
            {
                string lowerCaseFilterText = FilterText.ToLowerInvariant();
                FilteredKlanten = Klanten.Where(k =>
                    (k.Voornaam != null && k.Voornaam.ToLowerInvariant().Contains(lowerCaseFilterText)) ||
                    (k.Familienaam != null && k.Familienaam.ToLowerInvariant().Contains(lowerCaseFilterText)) ||
                    k.Eigendommen.Count.ToString().Contains(lowerCaseFilterText));
            }
        }
        #endregion
        #endregion

        #region Methods

        #region Command  methods
        private void KlantToevoegenCommandExecute()
        {
            try
            {
                KlantenValidatie.ValidateKlant(NewKlanten);

                KlantenRepository.AddKlant(NewKlanten);
                FilteredKlanten = KlantenRepository.GetKlanten();
                Status = LijstStatus.Toevoegen;
            }
            catch (NaamLeeg_KlantException ex)
            {
                MessageBox.Show(ex.Message, "Validation Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private Boolean KlantToevoegenCommandCanExecute()
        {
            return true;
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
            Status = LijstStatus.Verwijderen;
            // Klant alleen kunnen verwijderen als die geen eigendommen heeft. 
            if (GeselecteerdeKlant != null)
            {
                bool heeftEigendommen = KlantenRepository.HeeftEigendommen(GeselecteerdeKlant.Id);

                if (heeftEigendommen)
                {
                    MessageBox.Show("Klant kan niet worden verwijderd omdat deze nog anderen eigendommen heeft.");
                }
                else
                {
                    // Proceed with customer deletion
                    KlantenRepository.RemoveKlantByID(GeselecteerdeKlant.Id);
                }
            }
            FilteredKlanten = KlantenRepository.GetKlanten();

        }
        private Boolean KlantVerwijderenCommandCanExecute()
        {
            return GeselecteerdeKlant != null;
        }

        #endregion

        #endregion

    }
}
