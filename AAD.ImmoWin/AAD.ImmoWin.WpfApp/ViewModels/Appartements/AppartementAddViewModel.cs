using AAD.ImmoWin.Business.Classes;
using AAD.ImmoWin.Business.Exceptions;
using AAD.ImmoWin.Business.Interfaces;
using AAD.ImmoWin.Business.Services;
using AAD.ImmoWin.Business.Validatie;
using AAD.ImmoWin.WpfApp.Views;
using Odisee.Common.Commands;
using Odisee.Common.ViewModels;
using System;
using System.Collections.Generic;
using System.Windows;

namespace AAD.ImmoWin.WpfApp.ViewModels
{
    public class AppartementAddViewModel : BaseViewModel
    {
        public RelayCommand AppartementToevoegenCommand { get; set; }
        public RelayCommand AppartementWijzigenCommand { get; set; }
        public RelayCommand AppartementVerwijderenCommand { get; set; }


        public Appartement NewAppartement { get; set; } = new Appartement();

        private List<Appartement> _appartement;

        public List<Appartement> Appartementen
        {
            get { return _appartement; }
            set
            {
                SetProperty(ref _appartement, value);
            }
        }

        private List<Klant> _klanten;
        public List<Klant> Klanten
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

        private Appartement _geselecteerdeappartement;

        public Appartement GeselecteerdeAppartement
        {
            get { return _geselecteerdeappartement; }
            set
            {
                SetProperty(ref _geselecteerdeappartement, value);
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


        public AppartementAddViewModel(List<Appartement> appartement)
        {
            Title = "Toevoegen Appartementen";
            Appartementen = appartement;
            Klanten = KlantenRepository.GetKlanten();
            Status = LijstStatus.Tonen;

            NewAppartement = new Appartement
            {
                Adres = new Adres(),
            };

            // Commands
            AppartementToevoegenCommand = new RelayCommand(AppartementToevoegenCommandExecute, AppartementToevoegenCommandCanExecute);
            AppartementWijzigenCommand = new RelayCommand(AppartementWijzigenCommandExecute, AppartementWijzigenCommandCanExecute);
            AppartementVerwijderenCommand = new RelayCommand(AppartementVerwijderenCommandExecute, AppartementVerwijderenCommandCanExecute);
        }

        public void AppartementToevoegenCommandExecute()
        {

            try
            {
                WoningenAppValidatie.ValidateAppartement(NewAppartement);
                if (SelectedType != null)
                {
                    SelectedType.Eigendommen.Add(NewAppartement);
                    KlantenRepository.AddWoning(NewAppartement);
                    Appartementen = KlantenRepository.GetAppartementen();
                    Status = LijstStatus.Toevoegen;
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
            Status = LijstStatus.Wijzigen;

        }
        private Boolean AppartementWijzigenCommandCanExecute()
        {
            return GeselecteerdeAppartement != null;

        }
        private void AppartementVerwijderenCommandExecute()
        {
            KlantenRepository.RemoveWoningByID(GeselecteerdeAppartement.Id);
            Appartementen = KlantenRepository.GetAppartementen();
            Status = LijstStatus.Verwijderen;
        }
        private Boolean AppartementVerwijderenCommandCanExecute()
        {
            return GeselecteerdeAppartement != null;
        }
    }
}