using AAD.ImmoWin.Business.Classes;
using AAD.ImmoWin.Business.Exceptions;
using AAD.ImmoWin.Data.Services;
using AAD.ImmoWin.Data.Validatie;
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
        public Data.Data.Klant NewKlanten { get; set; } = new Data.Data.Klant();


        private List<Data.Data.Klant> _klanten;

		public List<Data.Data.Klant> Klanten
		{
			get { return _klanten; }
			set
			{
				SetProperty(ref _klanten, value);
			}
		}

		private Data.Data.Klant _geselecteerdeKlant;

		public Data.Data.Klant GeselecteerdeKlant
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

				
				if(SetProperty(ref _status, value))
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

		public KlantenLijstViewModel(List<Data.Data.Klant> klanten)
		{
			// Observable properties
			Title = "Lijst klanten";
			Klanten = klanten;
			Status = KlantLijstStatus.Tonen;
			FilteredKlanten = Klanten;
            Klanten = KlantenRepository.GetKlanten();

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
			try
			{
                KlantenValidatie.ValidateKlant(NewKlanten);

                KlantenRepository.AddKlant(NewKlanten);
                FilteredKlanten = KlantenRepository.GetKlanten();
                Status = KlantLijstStatus.Toevoegen;
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
			Status = KlantLijstStatus.Wijzigen;
		}
		private Boolean KlantWijzigenCommandCanExecute()
		{
			return GeselecteerdeKlant != null;
		}

		private void KlantVerwijderenCommandExecute()
		{
            Status = KlantLijstStatus.Verwijderen;
            if (GeselecteerdeKlant != null)
            {
                bool heeftEigendommen = KlantenRepository.HeeftEigendommen(GeselecteerdeKlant.Id);

                if (heeftEigendommen)
                {
                    MessageBox.Show("Klant kan niet worden verwijderd omdat deze nog anderen eigendommen heeft.");
                }
                else
                {
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

        private IEnumerable<Data.Data.Klant> _filteredKlanten;
        public IEnumerable<Data.Data.Klant> FilteredKlanten
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
    }
}
