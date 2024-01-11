using AAD.ImmoWin.Business.Exceptions;
using Odisee.Common.Commands;
using Odisee.Common.ViewModels;
using System.Collections.Generic;
using System.Windows;
using System;
using AAD.ImmoWin.WpfApp.Views;
using AAD.ImmoWin.Business.Services;
using System.Linq;
using AAD.ImmoWin.Business.Validatie;
using static System.Net.Mime.MediaTypeNames;
using System.Windows.Controls;
using System.Windows.Data;

namespace AAD.ImmoWin.WpfApp.ViewModels
{
    public class AppartementAddViewModel : BaseViewModel
    {
        public RelayCommand AppartementToevoegenCommand { get; set; }
        public RelayCommand AppartementWijzigenCommand { get; set; }
        public RelayCommand AppartementVerwijderenCommand { get; set; }
        public RelayCommand SortByPriceCommand { get; set; }


        public Data.Data.Appartement NewAppartement { get; set; } = new Data.Data.Appartement();

        private List<Data.Data.Appartement> _appartement;

        public List<Data.Data.Appartement> Appartementen
        {
            get { return _appartement; }
            set
            {
                SetProperty(ref _appartement, value);
            }
        }

        private List<Data.Data.Klant> _klanten;
        public List<Data.Data.Klant> Klanten
        {
            get
            {
                return _klanten;
            }
            set
            {
                SetProperty(ref _klanten, value);
            }
        }

        private Data.Data.Klant _selectedType;
        public Data.Data.Klant SelectedType
        {
            get { return _selectedType; }
            set
            {
                _selectedType = value;
                OnPropertyChanged(nameof(SelectedType));
            }
        }

        private Data.Data.Appartement _geselecteerdeappartement;

        public Data.Data.Appartement GeselecteerdeAppartement
        {
            get { return _geselecteerdeappartement; }
            set
            {
                SetProperty(ref _geselecteerdeappartement, value);
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


        public AppartementAddViewModel(List<Data.Data.Appartement> appartement)
        {
            Title = "Lijsten Appartementen";
            Appartementen = appartement;
            Klanten = Data.Services.KlantenRepository.GetKlanten();
            Status = KlantLijstStatus.Tonen;
            FilteredAppartement = appartement;
            NewAppartement = new Data.Data.Appartement
            {
                Adres = new Data.Data.Adres(),
            };
            // Commands
            AppartementToevoegenCommand = new RelayCommand(AppartementToevoegenCommandExecute, AppartementToevoegenCommandCanExecute);
            AppartementWijzigenCommand = new RelayCommand(AppartementWijzigenCommandExecute, AppartementWijzigenCommandCanExecute);
            AppartementVerwijderenCommand = new RelayCommand(AppartementVerwijderenCommandExecute, AppartementVerwijderenCommandCanExecute);
            SortByPriceCommand = new RelayCommand(SortByPrice);
        }


        #region Sorteren
        private bool isSortedDescending = false;

        private void SortByPrice()
        {
            if (isSortedDescending)
            {
                FilteredAppartement = FilteredAppartement.OrderByDescending(a => a.Waarde).ToList();
            }
            else
            {
                FilteredAppartement = FilteredAppartement.OrderBy(a => a.Waarde).ToList();
            }
            isSortedDescending = !isSortedDescending;
        }
        #endregion

        #region Filter
        private string _filterText;
        public string FilterText
        {
            get { return _filterText; }
            set
            {
                SetProperty(ref _filterText, value);
                FilterAppartementList();
            }
        }


        private IEnumerable<Data.Data.Appartement> _filteredAppartement;
        public IEnumerable<Data.Data.Appartement> FilteredAppartement
        {
            get { return _filteredAppartement; }
            set { SetProperty(ref _filteredAppartement, value); }
        }

        private void FilterAppartementList()
        {
            if (string.IsNullOrWhiteSpace(FilterText))
            {
                FilteredAppartement = Appartementen;
            }
            else
            {
                string lowerCaseFilterText = FilterText.ToLowerInvariant();
                FilteredAppartement = Appartementen.Where(a =>
                    (a.Adres != null &&
                     a.Adres.Straat != null && a.Adres.Straat.ToLowerInvariant().Contains(lowerCaseFilterText) ||
                     a.Adres.Nummer != 0 && a.Adres.Nummer.ToString().Contains(lowerCaseFilterText) ||
                     a.Adres.Postnummer != 0 && a.Adres.Postnummer.ToString().Contains(lowerCaseFilterText) ||
                     a.Adres.Gemeente != null && a.Adres.Gemeente.ToLowerInvariant().Contains(lowerCaseFilterText)) ||
                    a.Waarde.ToString().Contains(lowerCaseFilterText) ||
                    a.Verdieping.ToString().Contains(lowerCaseFilterText));
            }
        }
        #endregion

        #region Command
        public void AppartementToevoegenCommandExecute()
        {

            try
            {
                WoningenAppValidatie.ValidateAppartement(NewAppartement);

                if (SelectedType != null)
                {

                    Data.Services.WoningRepository.AddWoning(NewAppartement, SelectedType.Id);
                    Appartementen = Data.Services.WoningRepository.GetAppartementen();
                    Klanten = Data.Services.KlantenRepository.GetKlanten();
                    FilterAppartementList();
                    Status = KlantLijstStatus.Toevoegen;
                }
                else
                {
                    MessageBox.Show("Selecteer een eigenaar voordat u een nieuw appartement toevoegt.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch (WoningException ex)
            {
                MessageBox.Show(ex.Message, "Validation Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private Boolean AppartementToevoegenCommandCanExecute()
        {
            return true;
        }

        private void AppartementWijzigenCommandExecute()
        {
            IsEnabled = false;
            Status = KlantLijstStatus.Wijzigen;
        }
        private Boolean AppartementWijzigenCommandCanExecute()
        {
            return GeselecteerdeAppartement != null;

        }
        private void AppartementVerwijderenCommandExecute()
        {
            GeselecteerdeAppartement.Klant.Eigendommen.Remove(GeselecteerdeAppartement);
            Data.Services.WoningRepository.RemoveWoningByID(GeselecteerdeAppartement.Id);
            GeselecteerdeAppartement = null;
            Appartementen = Data.Services.WoningRepository.GetAppartementen();
            Klanten = Data.Services.KlantenRepository.GetKlanten();
            OnPropertyChanged(nameof(Appartementen));
            OnPropertyChanged(nameof(Klanten));
            Status = KlantLijstStatus.Verwijderen;
        }
        private Boolean AppartementVerwijderenCommandCanExecute()
        {
            return GeselecteerdeAppartement != null;
        }
        #endregion
    }
}