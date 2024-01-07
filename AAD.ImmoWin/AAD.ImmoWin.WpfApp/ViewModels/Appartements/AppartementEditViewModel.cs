using AAD.ImmoWin.Business.Classes;
using AAD.ImmoWin.Business.Exceptions;
using AAD.ImmoWin.Business.Services;
using AAD.ImmoWin.Business.Validatie;
using Odisee.Common.Commands;
using Odisee.Common.ViewModels;
using System;
using System.Collections.Generic;
using System.Windows;

namespace AAD.ImmoWin.WpfApp.ViewModels
{
    public class AppartementEditViewModel : BaseViewModel
    {
        public RelayCommand AppartementBewarenCommand { get; set; }
        public RelayCommand AppartementAnnulerenCommand { get; set; }


        private Appartement _appartement;
        public Appartement Appartement
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


        private List<Appartement> _appartementen;

        public List<Appartement> Appartementen
        {
            get { return _appartementen; }
            set
            {
                if (_appartementen != value)
                {
                    _appartementen = value;
                    OnPropertyChanged(nameof(Appartementen));
                }
            }
        }

        private DetailStatus _status;

        public DetailStatus Status
        {
            get { return _status; }
            set
            {
                if (SetProperty(ref _status, value))
                {
                    switch (Status)
                    {
                        case DetailStatus.Tonen:
                            break;
                        case DetailStatus.Wijzigen:
                            IsEnabled = true;
                            break;
                        case DetailStatus.Bewaren:
                            break;
                        case DetailStatus.Annuleren:
                            break;
                        default:
                            break;
                    }
                }
            }
        }

        public AppartementEditViewModel()
        {
            Title = "Aanpassen Appartementen";
            IsEnabled = false;
            Status = DetailStatus.Tonen;
            Appartementen = KlantenRepository.GetAppartementen();
            Klanten = KlantenRepository.GetKlanten();

            // Commands
            AppartementBewarenCommand = new RelayCommand(AppartementBewarenCommandExecute, AppartementBewarenCommandCanExecute);
            AppartementAnnulerenCommand = new RelayCommand(AppartementAnnulerenCommandExecute);
        }

        public void AppartementBewarenCommandExecute()
        {
            try
            {
                WoningenAppValidatie.ValidateAppartement(Appartement);
                IsEnabled = false;
                Status = DetailStatus.Bewaren;

                KlantenRepository.UpdateWoning(Appartement.Id, Appartement);
                if (SelectedType != null)
                {
                    Appartement.Klant = SelectedType;
                    SelectedType.Eigendommen.Add(Appartement);
                    KlantenRepository.UpdateKlantByID(SelectedType.Id, SelectedType);
                }
                Appartementen = KlantenRepository.GetAppartementen();

            }
            catch (WoningException ex)
            {
                MessageBox.Show(ex.Message, "Validation Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private Boolean AppartementBewarenCommandCanExecute()
        {
            return Appartement?.Changed ?? false;
        }

        private void AppartementAnnulerenCommandExecute()
        {
            IsEnabled = false;
            Status = DetailStatus.Annuleren;
        }
    }
}