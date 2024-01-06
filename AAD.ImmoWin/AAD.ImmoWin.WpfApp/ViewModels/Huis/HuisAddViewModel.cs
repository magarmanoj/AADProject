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

        public Huis NewHuizen { get; set; } = new Huis();

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
        public HuisAddViewModel(List<Huis> Huis)
        {
            Title = "Toevoegen Huisen";
            Huizen = Huis;
            Klanten = KlantenRepository.GetKlanten();
            NewHuizen = new Huis
            {
                Adres = new Adres()
            };
            // Commands
            HuisToevoegenCommand = new RelayCommand(HuisToevoegenCommandExecute, HuisToevoegenCommandCanExecute);
            HuisWijzigenCommand = new RelayCommand(HuisWijzigenCommandExecute, HuisBewarenCommandCanExecute);
            HuisVerwijderenCommand = new RelayCommand(HuisVerwijderenCommandExecute, HuisVerwijderenCommandCanExecute);
            HuisSoort = Enums.GetDescriptions<Huistype>();
        }


        public void HuisToevoegenCommandExecute()
        {
            KlantenRepository.AddWoning(NewHuizen);
            Huizen = KlantenRepository.GetHuizen();
        }
        private Boolean HuisToevoegenCommandCanExecute()
        {
            return IsEnabled = true;
        }

        private void HuisWijzigenCommandExecute()
        {
            IsEnabled = false;
            Status = LijstStatus.Wijzigen;
        }
        private Boolean HuisBewarenCommandCanExecute()
        {
            return GeselecteerdeHuizen != null;

        }
        private void HuisVerwijderenCommandExecute()
        {
            KlantenRepository.RemoveWoning(GeselecteerdeHuizen);

        }
        private Boolean HuisVerwijderenCommandCanExecute()
        {
            return GeselecteerdeHuizen != null;
        }
    }
}