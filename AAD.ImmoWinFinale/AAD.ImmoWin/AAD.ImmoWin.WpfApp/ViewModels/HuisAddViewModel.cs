using AAD.ImmoWin.Business.Classes;
using AAD.ImmoWin.Business.Enumerations;
using AAD.ImmoWin.Business.Exceptions;
using AAD.ImmoWin.Business.Interfaces;
using AAD.ImmoWin.Business.Services;
using AAD.ImmoWin.Business.Validatie;
using AAD.ImmoWin.Data.Converter;
using AAD.ImmoWin.Data.Data;
using Odisee.Common.Commands;
using Odisee.Common.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace AAD.ImmoWin.WpfApp.ViewModels
{
    public class HuisAddViewModel : BaseViewModel
    {
        public RelayCommand HuisToevoegenCommand { get; set; }
        public RelayCommand HuisWijzigenCommand { get; set; }
        public RelayCommand HuisVerwijderenCommand { get; set; }
        public RelayCommand SortByPriceCommand { get; set; }


        public Data.Data.Huis NewHuizen { get; set; } = new Data.Data.Huis();

        public List<String> HuisSoort { get; set; }

        private List<Data.Data.Huis> _huis;

        public List<Data.Data.Huis> Huizen
        {
            get { return _huis; }
            set
            {
                SetProperty(ref _huis, value);
            }
        }

        private List<Data.Data.Klant> _klant;
        public List<Data.Data.Klant> Klanten
        {
            get
            {
                return _klant;
            }
            set
            {
                SetProperty(ref _klant, value);
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

        private Data.Data.Huis _geselecteerdeHuis;

        public Data.Data.Huis GeselecteerdeHuizen
        {
            get { return _geselecteerdeHuis; }
            set
            {
                SetProperty(ref _geselecteerdeHuis, value);
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
        public HuisAddViewModel(List<Data.Data.Huis> Huis)
        {
            Title = "Lijst Huisen";
            Huizen = Huis;
            Klanten = Data.Services.KlantenRepository.GetKlanten();
            Status = KlantLijstStatus.Tonen;
            NewHuizen = new Data.Data.Huis
            {
                Adres = new Data.Data.Adres()
            };
            FilteredHuizen = Huis;

            // Commands
            HuisToevoegenCommand = new RelayCommand(HuisToevoegenCommandExecute, HuisToevoegenCommandCanExecute);
            HuisWijzigenCommand = new RelayCommand(HuisWijzigenCommandExecute, HuisBewarenCommandCanExecute);
            HuisVerwijderenCommand = new RelayCommand(HuisVerwijderenCommandExecute, HuisVerwijderenCommandCanExecute);
            SortByPriceCommand = new RelayCommand(SortByPrice);
            HuisSoort = Enums.GetDescriptions<Huistype>();
        }

        #region Filter
        private string _filterText;
        public string FilterText
        {
            get { return _filterText; }
            set
            {
                SetProperty(ref _filterText, value);
                FilterHuizenList();
            }
        }


        private IEnumerable<Data.Data.Huis> _filteredHuizen;
        public IEnumerable<Data.Data.Huis> FilteredHuizen
        {
            get { return _filteredHuizen; }
            set { SetProperty(ref _filteredHuizen, value); }
        }

        private void FilterHuizenList()
        {
            if (string.IsNullOrWhiteSpace(FilterText))
            {
                FilteredHuizen = Huizen;
            }
            else
            {
                string lowerCaseFilterText = FilterText.ToLowerInvariant();
                FilteredHuizen = Huizen.Where(h =>
                    (h.Adres != null &&
                     h.Adres.Straat != null && h.Adres.Straat.ToLowerInvariant().Contains(lowerCaseFilterText) ||
                     h.Adres.Nummer != 0 && h.Adres.Nummer.ToString().Contains(lowerCaseFilterText) ||
                     h.Adres.Postnummer != 0 && h.Adres.Postnummer.ToString().Contains(lowerCaseFilterText) ||
                     h.Adres.Gemeente != null && h.Adres.Gemeente.ToLowerInvariant().Contains(lowerCaseFilterText)) ||
                    h.Waarde.ToString().Contains(lowerCaseFilterText) ||
                    h.Type.ToString().ToLowerInvariant().Contains(lowerCaseFilterText));
            }
        }
        #endregion

        #region Sorteren
        private bool isSortedDescending = false;
        private void SortByPrice()
        {
            if (isSortedDescending)
            {
                FilteredHuizen = FilteredHuizen.OrderByDescending(a => a.Waarde).ToList();                
            }
            else
            {
                FilteredHuizen = FilteredHuizen.OrderBy(a => a.Waarde).ToList();
            }
            isSortedDescending = !isSortedDescending;
        }
        #endregion

        #region Commands
        public void HuisToevoegenCommandExecute()
        {
            try
            {
                WoningenHuizenValidatie.ValidateHuizen(NewHuizen);

                if (SelectedType != null)
                {
                    Data.Services.WoningRepository.AddWoning(NewHuizen, SelectedType.Id);
                    Huizen = Data.Services.WoningRepository.GetHuizen();
                    Klanten = Data.Services.KlantenRepository.GetKlanten();
                    FilterHuizenList();
                    Status = KlantLijstStatus.Toevoegen;
                }
                else
                {
                    MessageBox.Show("Selecteer een eigenaar voordat u een nieuw huis toevoegt.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch (WoningException ex)
            {
                MessageBox.Show(ex.Message, "Validation Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }
        private Boolean HuisToevoegenCommandCanExecute()
        {
            return true;
        }

        private void HuisWijzigenCommandExecute()
        {
            IsEnabled = false;
            Status = KlantLijstStatus.Wijzigen;
        }
        private Boolean HuisBewarenCommandCanExecute()
        {
            return GeselecteerdeHuizen != null;

        }
        private void HuisVerwijderenCommandExecute()
        {
            GeselecteerdeHuizen.Klant.Eigendommen.Remove(GeselecteerdeHuizen);
            Data.Services.WoningRepository.RemoveWoningByID(GeselecteerdeHuizen.Id);
            FilteredHuizen = Data.Services.WoningRepository.GetHuizen();
            Status = KlantLijstStatus.Verwijderen;
        }
        private Boolean HuisVerwijderenCommandCanExecute()
        {
            return GeselecteerdeHuizen != null;
        }
        #endregion
    }
}