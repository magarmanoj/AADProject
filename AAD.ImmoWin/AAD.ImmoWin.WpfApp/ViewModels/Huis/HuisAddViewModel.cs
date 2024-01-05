using AAD.ImmoWin.Business.Classes;
using AAD.ImmoWin.Business.Enumerations;
using AAD.ImmoWin.Business.Exceptions;
using AAD.ImmoWin.Business.Interfaces;
using AAD.ImmoWin.Business.Services;
using Odisee.Common.Commands;
using Odisee.Common.ViewModels;
using System;
using System.Collections.Generic;

namespace AAD.ImmoWin.WpfApp.ViewModels
{
    public class HuisAddViewModel : BaseViewModel
    {
        public RelayCommand HuisToevoegenCommand { get; set; }
        public RelayCommand HuisWijzigenCommand { get; set; }
        public RelayCommand HuisVerwijderenCommand { get; set; }


        public List<String> HuisSoort { get; set; }

        private List<Huis> _huis;

        public List<Huis> Huizen
        {
            get { return _huis; }
            set
            {
                SetProperty(ref _huis, value);
            }
        }

        private List<Klant> _klant;
        public List<Klant> Klanten
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

        private string _selectedType;
        public string SelectedType
        {
            get { return _selectedType; }
            set
            {
                _selectedType = value;
                OnPropertyChanged(nameof(SelectedType));
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
        public HuisAddViewModel(List<Huis> Huis)
        {
            Title = "Toevoegen Huisen";
            Huizen = Huis;
            Klanten = KlantenRepository.GetKlanten();

            // Commands
            HuisToevoegenCommand = new RelayCommand(HuisToevoegenCommandExecute, HuisToevoegenCommandCanExecute);
            HuisWijzigenCommand = new RelayCommand(HuisWijzigenCommandExecute, HuisBewarenCommandCanExecute);
            HuisVerwijderenCommand = new RelayCommand(HuisVerwijderenCommandExecute, HuisVerwijderenCommandCanExecute);
            HuisSoort = Enums.GetDescriptions<Huistype>();
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
        public void HuisToevoegenCommandExecute()
        {
            Adres adres = new Adres(Straat, Nummer, Postnummer, Gemeente);
            Huistype? huistype = Enum.TryParse<Huistype>(SelectedType, out Huistype result) ? result : (Huistype?)null;

            Huis app = new Huis()
            {
                Type = huistype?? default,
                Waarde = Waarde,
                Adres = adres,
            };
            Huizen.Add(app);
            KlantenRepository.AddWoning(app);
        }
        private Boolean HuisToevoegenCommandCanExecute()
        {
            return IsEnabled = true;
        }

        private void HuisWijzigenCommandExecute()
        {
            IsEnabled = false;
            Status = KlantLijstStatus.Wijzigen;

        }
        private Boolean HuisBewarenCommandCanExecute()
        {
            return false;

        }
        private void HuisVerwijderenCommandExecute()
        {
            KlantenRepository.RemoveWoning(GeselecteerdeHuizen);

        }
        private Boolean HuisVerwijderenCommandCanExecute()
        {
            return IsEnabled = true;
        }
    }
}