using AAD.ImmoWin.Business.Classes;
using AAD.ImmoWin.Business.Exceptions;
using AAD.ImmoWin.Business.Services;
using Odisee.Common.Commands;
using Odisee.Common.ViewModels;
using System;

namespace AAD.ImmoWin.WpfApp.ViewModels
{
    public class AppartementAddViewModel : BaseViewModel
    {
        public RelayCommand AppartementToevoegenCommand { get; set; }
        public RelayCommand AppartementWijzigenCommand { get; set; }
        public RelayCommand AppartementVerwijderenCommand { get; set; }



        private Woningen _appartement;

        public Woningen Appartementen
        {
            get { return _appartement; }
            set
            {
                SetProperty(ref _appartement, value);
            }
        }

        private Klanten _klant;
        public Klanten Klanten
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

        private Klant _selectedType;
        public Klant SelectedType
        {
            get { return _selectedType; }
            set
            {
                _selectedType = value;
                OnPropertyChanged(nameof(SelectedType));
            }
        }

        public int SelectedKlantId
        {
            get { return _selectedType?.Id ?? 0; }
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
        public AppartementAddViewModel(Woningen appartement)
        {
            Title = "Toevoegen Appartementen";
            Appartementen = appartement;
            Klanten = KlantenRepository.GetKlanten();

            // Commands
            AppartementToevoegenCommand = new RelayCommand(AppartementToevoegenCommandExecute, AppartementToevoegenCommandCanExecute);
            AppartementWijzigenCommand = new RelayCommand(AppartementWijzigenCommandExecute, AppartementBewarenCommandCanExecute);
            AppartementVerwijderenCommand = new RelayCommand(AppartementVerwijderenCommandExecute, AppartementVerwijderenCommandCanExecute);
        }

        private String _straat;
        public string Straat
        {
            get { return _straat; }
            set { SetProperty(ref _straat, value); }
        }

        private int _nummer;
        public int Nummer
        {
            get { return _nummer; }
            set { SetProperty(ref _nummer, value); }
        }

        private int _postnummer;
        public int Postnummer
        {
            get { return _postnummer; }
            set { SetProperty(ref _postnummer, value); }
        }

        private String _gemeente;
        public String Gemeente
        {
            get { return _gemeente; }
            set { SetProperty(ref _gemeente, value); }
        }


        private int _verdieping;
        public int Verdieping
        {
            get { return _verdieping; }
            set { SetProperty(ref _verdieping, value); }
        }

        private int _waarde;
        public int Waarde
        {
            get { return _waarde; }
            set { SetProperty(ref _waarde, value); }
        }

        private Klant _eigenaar;
        public Klant Eigenaar
        {
            get { return _eigenaar; }
            set
            {
                SetProperty(ref _eigenaar, value);
            }
        }
        public void AppartementToevoegenCommandExecute()
        {
            Adres adres = new Adres(Straat, Nummer, Postnummer, Gemeente);
            Appartement app = new Appartement()
            {
                Verdieping = Verdieping,
                Waarde = Waarde,
                Adres = adres,
                Eigenaar = SelectedType

            };
            Appartementen.Add(app);
            KlantenRepository.AddWoning(app);
        }
        private Boolean AppartementToevoegenCommandCanExecute()
        {
            return IsEnabled = true;
        }

        private void AppartementWijzigenCommandExecute()
        {
            IsEnabled = false;
            Status = KlantLijstStatus.Wijzigen;

        }
        private Boolean AppartementBewarenCommandCanExecute()
        {
            return false;

        }
        private void AppartementVerwijderenCommandExecute()
        {
            KlantenRepository.RemoveWoning(GeselecteerdeAppartement);

        }
        private Boolean AppartementVerwijderenCommandCanExecute()
        {
            return IsEnabled = true;
        }
    }
}